using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FangameUtil
{
    public partial class Util : Form
    {
        HookManager _hooks = new HookManager();
        Keyboard _keyboard = new Keyboard();
        readonly System.Threading.Timer _timer;
        int _counter = 0;

        volatile string _foregroundClassName = null;
        volatile AutoFire _autoFire = null;
        volatile bool _numPadHold = false;
        volatile bool _active = false;

        public Util()
        {
            InitializeComponent();
            _hooks.SubscribeToWindowEvents();
            _hooks.ForegroundChanged = ResetProcess;
            _timer = new System.Threading.Timer(Update, null, 1, 50);
            Activated += Form_Activated;
            Deactivate += Form_Deactivated;
        }

        ~Util()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            WaitHandle handle = new AutoResetEvent(false);
            _timer.Dispose(handle);
            handle.WaitOne();
            _timer.Dispose();

            _hooks.UnsubscribeFromWindowEvents();
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
                string className = _foregroundClassName;

                if (!(className is object))
                {
                    className = Windows.GetForegroundClassName();
                    _foregroundClassName = className;
                    SafeInvoke(() => 
                    {
                        textBoxName.Text = className;
                    });
                }

                if (!(className is object))
                    return;

                if (className != "TRunnerForm")
                    return;

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
                    var mod = autoFire.hold + autoFire.release;
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
            catch (Exception)
            {

            }
        }

        private void ResetProcess()
        {
            _foregroundClassName = null;
        }

        private void OnAutoFireChange(object sender, EventArgs e)
        {
            AutoFire autoFire = null;
            if (checkBoxAutoFire.Enabled)
            {
                if (int.TryParse(textBoxAutoFireHold.Text   , out int hold)    && 0 != hold 
                 && int.TryParse(textBoxAutoFireRelease.Text, out int release) && 0 != release)
                {
                    autoFire = new AutoFire(hold, release);
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
        }

        private void Form_Deactivated(object sender, System.EventArgs e)
        {
            _active = false;
        }
    }
}
