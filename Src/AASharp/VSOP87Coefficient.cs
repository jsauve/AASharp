using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    internal struct VSOP87Coefficient
    {
        internal VSOP87Coefficient(double a, double b, double c)
        {
            _A = a;
            _B = b;
            _C = c;
        }

        private readonly double _A;
        public double A
        {
            get
            {
                return _A;
            }
        }
        private readonly double _B;
        public double B
        {
            get
            {
                return _B;
            }
        }
        private readonly double _C;
        public double C
        {
            get
            {
                return _C;
            }
        }
    }
}
