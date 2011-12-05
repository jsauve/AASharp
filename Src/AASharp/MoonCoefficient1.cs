using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    internal struct MoonCoefficient1
    {
        internal MoonCoefficient1(int d, int m, int mDash, int f)
        {
            _D = d;
            _M = m;
            _Mdash = mDash;
            _F = f;
        }

        private readonly int _D;
        public int D
        {
            get
            {
                return _D;
            }
        }
        private readonly int _M;
        public int M
        {
            get
            {
                return _M;
            }
        }
        private readonly int _Mdash;
        public int Mdash
        {
            get
            {
                return _Mdash;
            }
        }
        private readonly int _F;
        public int F
        {
            get
            {
                return _F;
            }
        }
    }
}
