using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace FangameUtil
{
    internal class Windows
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public static string GetForegroundClassName()
        {
            IntPtr hWnd = GetForegroundWindow();
            StringBuilder className = new StringBuilder(256);
            GetClassName(hWnd, className, className.Capacity);
            return className.ToString();
        }
    }
}
