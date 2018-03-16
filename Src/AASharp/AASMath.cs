using System;

namespace AASharp
{
    internal static class AASMath
    {
        /// <summary>
        /// Equivalent of modf in C++.
        /// Break into fractional and integral parts
        /// Breaks value into an integral and a fractional part.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="integralPart"></param>
        /// <returns></returns>
        internal static double modF(double value, ref double integralPart)
        {
            integralPart = Math.Floor(value);
            return value - integralPart;
        }
    }
}
