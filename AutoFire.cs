using System;
using System.Collections.Generic;
using System.Text;

namespace FangameUtil
{
    internal class AutoFire
    {
        public AutoFire(int hold, int release)
        {
            this.hold = hold;
            this.release = release;
        }

        public readonly int hold;
        public readonly int release;
    }
}
