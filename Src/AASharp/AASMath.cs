using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASMath
    {
        // equivalent of modf in C++
        public static double modF(double source, ref double integralPart)
        {
            return source - (integralPart = Math.Floor(source));
        }
    }
}
