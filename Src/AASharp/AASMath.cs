using System;

namespace AASharp
{
    /// <summary>
    /// Additional mathematical operations.
    /// </summary>
    internal static class AASMath
    {
        /// <summary>
        /// Equivalent of modf in C++.
        /// Break into fractional and integral parts
        /// Breaks value into an integral and a fractional part.
        /// </summary>
        /// <param name="value">The value to break apart.</param>
        /// <param name="integralPart">This will hold the integral part</param>
        /// <returns>The fractional part</returns>
        internal static double modF(double value, ref double integralPart)
        {
            integralPart = Math.Floor(value);
            return value - integralPart;
        }
    }
}
