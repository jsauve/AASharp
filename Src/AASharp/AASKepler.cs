using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASKepler
    {
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
