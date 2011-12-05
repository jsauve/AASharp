using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    internal struct PlutoCoefficient1
    {
        internal PlutoCoefficient1(int j, int s, int p)
        {
            _J = j;
            _S = s;
            _P = p;
        }

        private readonly int _J;
        public int J
        {
            get
            {
                return _J;
            }
        }
        private readonly int _S;
        public int S
        {
            get
            {
                return _S;
            }
        }
        private readonly int _P;
        public int P
        {
            get
            {
                return _P;
            }
        }
    }
}
