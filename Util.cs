using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FangameUtil
{
    public partial class Util : Form
    {
        readonly HookManager _hooks = new HookManager();
        readonly HotKey _autofireKey;
        readonly HotKey _fullscreenKey;
        readonly Keyboard _keyboard = new Keyboard();
        readonly System.Threading.Timer _timer;
        readonly KeyMessageFilter _filter = new KeyMessageFilter();
        readonly SaveBackup _saveBackup = new SaveBackup();

        int _counter = 0;

        volatile IntPtr _foregroundWindow = IntPtr.Zero;
        volatile bool _foregroundIsFangame = false;
        volatile AutoFire _autoFire = null;
        volatile bool _numPadHold = false;
        volatile bool _active = false;

        Windows.RECT _fullscreenSavedWindowedRect;
        IntPtr _fullscreenSavedWindowedStyle;

        public class KeyMessageFilter : IMessageFilter
        {
            public delegate void KeyPressedDelegate();
            public KeyPressedDelegate OnAutoFireChange;
            public KeyPressedDelegate OnFullScreen;

            const int WM_KEYDOWN = 0x0100;
            const int WM_HOTKEY = 0x0312;

            volatile Keys _autoFireChangeKey = Keys.None;
            volatile Keys _fullscreenKey = Keys.None;

            public Keys AutoFireChangeKey { set => _autoFireChangeKey = value; }
            public Keys FullScreenKey { set => _fullscreenKey = value; }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_KEYDOWN)
                {
                    if (_autoFireChangeKey != Keys.None && (Keys) m.WParam == _autoFireChangeKey)
                    {
                        OnAutoFireChange();
                    }
                }

                if (m.Msg == WM_HOTKEY)
                {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);
                    if (_autoFireChangeKey != Keys.None && key == _autoFireChangeKey)
                    {
                        OnAutoFireChange();
                    }
                    if (_fullscreenKey != Keys.None && key == _fullscreenKey)
                    {
                        OnFullScreen();
                    }
                }

                return false;
            }
        }

        public Util()
        {
            InitializeComponent();
            _autofireKey = new HotKey(Handle, 2);
            _fullscreenKey = new HotKey(Handle, 1);
            _hooks.SubscribeToWindowEvents();
            _hooks.ForegroundChanged = ResetProcess;
            _timer = new System.Threading.Timer(Update, null, 1, 50);
            Activated += Form_Activated;
            Deactivate += Form_Deactivated;
            _filter.OnAutoFireChange = () => { checkBoxAutoFire.Checked = !checkBoxAutoFire.Checked; };
            _filter.OnFullScreen = SwitchFullScreen;
            _filter.FullScreenKey = Keys.F11;
            Application.AddMessageFilter(_filter);
            comboBoxAutoFireSwitch.SelectedIndex = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }


                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                WaitHandle handle = new AutoResetEvent(false);
                _timer.Dispose(handle);
                handle.WaitOne();
                _timer.Dispose();
                _hooks.UnsubscribeFromWindowEvents();
                _autofireKey.Dispose();
                _fullscreenKey.Dispose();
            }

            base.Dispose(disposing);
        }

        // Call from other thread for safe UI invoke
        private void SafeInvoke(MethodInvoker updater, bool forceSynchronous = false)
        {
            if (InvokeRequired)
            {
                if (forceSynchronous)
                {
                    Invoke((MethodInvoker)delegate { SafeInvoke(updater, forceSynchronous); });
                }
                else
                {
                    BeginInvoke((MethodInvoker)delegate { SafeInvoke(updater, forceSynchronous); });
                }
            }
            else
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException("Control is already disposed.");
                }

                updater();
            }
        }

        private void Update(object state)
        {
            try
            {
                if (_active)
                    return;

                int count = _counter++;
                IntPtr foregroundWindow = _foregroundWindow;
                if (foregroundWindow == IntPtr.Zero)
                {
                    foregroundWindow = Windows.GetForegroundWindow();
                    if (foregroundWindow == IntPtr.Zero)
                        return;

                    var className = Windows.GetForegroundClassName(foregroundWindow);
                    if (!(className is object))
                    {
                        return;
                    }

                    SafeInvoke(() => { textBoxName.Text = className; });
                    _foregroundWindow = foregroundWindow;
                    _foregroundIsFangame = className == "TRunnerForm" || className == "YYGameMakerYY" || className == "UnityWndClass";
                }

                if (!_foregroundIsFangame)
                {
                    _counter = 0;
                    return;
                }

                var numPadHold = _numPadHold;
                var autoFire = _autoFire;

                if (numPadHold)
                {
                    if (!IsKeyLocked(Keys.NumLock))
                    {
                        _keyboard.Send(Keyboard.ScanCodeShort.NUMLOCK);
                    }
                }

                if (autoFire is object)
                {
                    if (autoFire.keepHolding)
                    {
                        if (0 == (count % 3))
                        {
                            _keyboard.Send(Keyboard.ScanCodeShort.KEY_Z);
                        }
                    }
                    else
                    {
                        var mod = autoFire.hold + autoFire.release;
                        if (0 != mod)
                        {
                            var timer = count % mod;
                            if (0 == timer)
                            {
                                _keyboard.Send(Keyboard.ScanCodeShort.KEY_Z);
                            }
                            if (autoFire.hold == timer)
                            {
                                _keyboard.Release(Keyboard.ScanCodeShort.KEY_Z);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void ResetProcess()
        {
            _foregroundWindow = IntPtr.Zero;
        }

        private void OnAutoFireChange(object sender, EventArgs e)
        {
            AutoFire autoFire = null;
            if (checkBoxAutoFire.Checked)
            {
                if (int.TryParse(textBoxAutoFireHold.Text   , out int hold)    && 0 != hold 
                 && int.TryParse(textBoxAutoFireRelease.Text, out int release) && 0 != release)
                {
                    autoFire = new AutoFire(hold, release, checkBoxHold.Checked);
                }
            }

            _autoFire = autoFire;
        }

        private void OnNumPadChange(object sender, EventArgs e)
        {
            _numPadHold = checkBoxHoldNumPad.Checked;
        }

        private void Form_Activated(object sender, System.EventArgs e)
        {
            _active = true;
            _fullscreenKey.RegisterHotKey(0, Keys.F11);
        }

        private void Form_Deactivated(object sender, System.EventArgs e)
        {
            _active = false;
        }

        private void comboBoxAutoFireSwitch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Keys key = 0 == comboBoxAutoFireSwitch.SelectedIndex ? Keys.None : (comboBoxAutoFireSwitch.SelectedIndex + Keys.A - 1);
            _filter.AutoFireChangeKey = key;

            if (0 == comboBoxAutoFireSwitch.SelectedIndex)
            {
                _autofireKey.UnregisterHotKey();
            }
            else
            {
                _autofireKey.UnregisterHotKey();
                _autofireKey.RegisterHotKey(0, key);
            }
        }

        private void buttonSaveBackupOpen_Click(object sender, EventArgs e)
        {
            var fp = new FolderPicker();
            if (fp.ShowDialog(Handle) == true)
            {
                textBoxSaveBackupDir.Text = fp.ResultPath;
            }
        }

        private void textBoxSaveBackupDir_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxSaveBackupDir.Text))
            {
                _saveBackup.Dir = textBoxSaveBackupDir.Text;
            }
        }

        private void textBoxSaveBackupMaxFileSize_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSaveBackupMaxFileSize.Text, out int maxFileSize))
            {
                _saveBackup.MaxFileSize = maxFileSize;
            }
        }

        private void textBoxSaveBackupMaxBackups_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxSaveBackupMaxBackups.Text, out int maxBackups))
            {
                _saveBackup.MaxBackups = maxBackups;
            }
        }

        private void SwitchFullScreen()
        {
            if (!_foregroundIsFangame)
                return;

            IntPtr foregroundWindow = _foregroundWindow;
            if (foregroundWindow == IntPtr.Zero)
                return;

            var style = Windows.GetWindowLongPtr(foregroundWindow, Windows.GWL_STYLE);
            if (0 == ((Windows.WindowStyles) style.ToInt64() & Windows.WindowStyles.WS_THICKFRAME))
            {
                Windows.GetWindowRect(foregroundWindow, out _fullscreenSavedWindowedRect);
                var monitor = Windows.MonitorFromWindow(foregroundWindow, Windows.MONITOR_DEFAULTTONEAREST);
                Windows.MONITORINFOEX monitorInfo = new Windows.MONITORINFOEX
                {
                    cbSize = 72
                };
                Windows.GetMonitorInfo(monitor, monitorInfo);

                var r = monitorInfo.rcMonitor;
                _fullscreenSavedWindowedStyle = style;
                long wantStyle = style.ToInt64() & ~(long)(Windows.WindowStyles.WS_CAPTION | Windows.WindowStyles.WS_THICKFRAME | Windows.WindowStyles.WS_MINIMIZEBOX | Windows.WindowStyles.WS_MAXIMIZEBOX | Windows.WindowStyles.WS_SYSMENU);
                Windows.SetWindowLongPtr(foregroundWindow, Windows.GWL_STYLE, new IntPtr(wantStyle));
                Windows.SetWindowPos(foregroundWindow, new IntPtr(-1), r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top, (uint)Windows.SetWindowPosFlags.SWP_FRAMECHANGED);
            }
            else
            {
                Windows.SetWindowLongPtr(foregroundWindow, Windows.GWL_STYLE, _fullscreenSavedWindowedStyle);
                // Windows.SetWindowLongPtr(foregroundWindow, Windows.GWL_EXSTYLE, WS_EX_ACCEPTFILES | WS_EX_APPWINDOW);
                Windows.SetWindowPos(foregroundWindow, new IntPtr(-2), 0, 0, 0, 0, (uint) (Windows.SetWindowPosFlags.SWP_NOMOVE | Windows.SetWindowPosFlags.SWP_NOSIZE | Windows.SetWindowPosFlags.SWP_DRAWFRAME | Windows.SetWindowPosFlags.SWP_FRAMECHANGED));

                var r = _fullscreenSavedWindowedRect;
                Windows.SetWindowPos(foregroundWindow, IntPtr.Zero, r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top, (uint) Windows.SetWindowPosFlags.SWP_FRAMECHANGED);
            }
        }
    }
}
