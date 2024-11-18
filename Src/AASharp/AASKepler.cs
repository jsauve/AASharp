using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for the solution of Kepler's equation. This refers to Chapter 30 in the book.
    /// </summary>
    public static class AASKepler
    {
        /// <param name="M">The mean anomaly in degrees.</param>
        /// <param name="e">The eccentricity of the orbit</param>
        /// <param name="nIterations">The method uses the third method to solve the equation. This uses a binary chop to find the solution. The default value of 53 is the number of iterations required to obtain the accuracy of the standard Visual C "double".</param>
        /// <returns>The Eccentric anomaly in degrees (i.e. the solution to Kepler's equation).</returns>
        public static double Calculate(double M, double e, int nIterations = 53)
        {
            //Convert from degrees to radians
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double PI = AASCoordinateTransformation.PI();

            double F = 1;
            if (M < 0)
                F = -1;
            M = Math.Abs(M) / (2 * PI);
            M = (M - (int)(M)) * 2 * PI * F;
            if (M < 0)
                M += 2 * PI;
            F = 1;
            if (M > PI)
                F = -1;
            if (M > PI)
                M = 2 * PI - M;

            double E = PI / 2;
            double scale = PI / 4;
            for (int i = 0; i < nIterations; i++)
            {
                double R = E - e * Math.Sin(E);
                if (M > R)
                    E += scale;
                else
                    E -= scale;
                scale /= 2;
            }

            //Convert the result back to degrees
            return AASCoordinateTransformation.RadiansToDegrees(E) * F;
        }
    }
}
