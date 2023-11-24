using System;
using System.Collections.Generic;
using System.Text;

namespace FangameUtil
{
    internal class AutoFire
    {
        public AutoFire(int hold, int release, bool keepHolding)
        {
            this.hold = hold;
            this.release = release;
            this.keepHolding = keepHolding;
        }

        public readonly int hold;
        public readonly int release;
        public readonly bool keepHolding;
    }
}
