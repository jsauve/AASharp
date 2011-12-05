using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    internal struct AberrationCoefficient
    {
        internal AberrationCoefficient(int l2, int l3, int l4, int l5, int l6, int l7, int l8, int lDash, int d, int mDash, int f, int xSin, int xSint, int xCos, int xCost, int ySin, int ySint, int yCos, int yCost, int zSin, int zSint, int zCos, int zCost)
        {
            _L2 = l2;
            _L3 = l3;
            _L4 = l4;
            _L5 = l5;
            _L6 = l6;
            _L7 = l7;
            _L8 = l8;
            _Ldash = lDash;
            _D = d;
            _Mdash = mDash;
            _F = f;
            _xsin = xSin;
            _xsint = xSint;
            _xcos = xCos;
            _xcost = xCost;
            _ysin = ySin;
            _ysint = ySint;
            _ycos = yCos;
            _ycost = yCost;
            _zsin = zSin;
            _zsint = zSint;
            _zcos = zCos;
            _zcost = zCost;
        }

        private readonly int _L2;
        private readonly int _L3;
        private readonly int _L4;
        private readonly int _L5;
        private readonly int _L6;
        private readonly int _L7;
        private readonly int _L8;
        private readonly int _Ldash;
        private readonly int _D;
        private readonly int _Mdash;
        private readonly int _F;
        private readonly int _xsin;
        private readonly int _xsint;
        private readonly int _xcos;
        private readonly int _xcost;
        private readonly int _ysin;
        private readonly int _ysint;
        private readonly int _ycos;
        private readonly int _ycost;
        private readonly int _zsin;
        private readonly int _zsint;
        private readonly int _zcos;
        private readonly int _zcost;

        public int L2
        {
            get
            {
                return _L2;
            }
        }
        public int L3
        {
            get
            {
                return _L3;
            }
        }
        public int L4
        {
            get
            {
                return _L4;
            }
        }
        public int L5
        {
            get
            {
                return _L5;
            }
        }
        public int L6
        {
            get
            {
                return _L6;
            }
        }
        public int L7
        {
            get
            {
                return _L7;
            }
        }
        public int L8
        {
            get
            {
                return _L8;
            }
        }
        public int Ldash
        {
            get
            {
                return _Ldash;
            }
        }
        public int D
        {
            get
            {
                return _D;
            }
        }
        public int Mdash
        {
            get
            {
                return _Mdash;
            }
        }
        public int F
        {
            get
            {
                return _F;
            }
        }
        public int xsin
        {
            get
            {
                return _xsin;
            }
        }
        public int xsint
        {
            get
            {
                return _xsint;
            }
        }
        public int xcos
        {
            get
            {
                return _xcos;
            }
        }
        public int xcost
        {
            get
            {
                return _xcost;
            }
        }
        public int ysin
        {
            get
            {
                return _ysin;
            }
        }
        public int ysint
        {
            get
            {
                return _ysint;
            }
        }
        public int ycos
        {
            get
            {
                return _ycos;
            }
        }
        public int ycost
        {
            get
            {
                return _ycost;
            }
        }
        public int zsin
        {
            get
            {
                return _zsin;
            }
        }
        public int zsint
        {
            get
            {
                return _zsint;
            }
        }
        public int zcos
        {
            get
            {
                return _zcos;
            }
        }
        public int zcost
        {
            get
            {
                return _zcost;
            }
        }
    }
}
