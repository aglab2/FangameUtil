using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace FangameUtil
{
    internal class HotKey : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        readonly IntPtr _handle;
        readonly int id_;
        bool _registered = false;

        public HotKey(IntPtr handle, int id)
        {
            _handle = handle;
            id_ = id;
        }

        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            if (_registered)
                return;

            _registered = true;
            RegisterHotKey(_handle, id_, (uint)modifier, (uint)key);
        }

        public void UnregisterHotKey()
        {
            if (!_registered)
                return;

            _registered = false;
            UnregisterHotKey(_handle, id_);
        }

        public void Dispose()
        {
            UnregisterHotKey();
        }
    }
}
