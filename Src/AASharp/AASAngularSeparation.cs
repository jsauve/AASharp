using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASAngularSeparation
    {
        public static double Separation(double Alpha1, double Delta1, double Alpha2, double Delta2)
        {
            Delta1 = AASCoordinateTransformation.DegreesToRadians(Delta1);
            Delta2 = AASCoordinateTransformation.DegreesToRadians(Delta2);

            Alpha1 = AASCoordinateTransformation.HoursToRadians(Alpha1);
            Alpha2 = AASCoordinateTransformation.HoursToRadians(Alpha2);

            double x = Math.Cos(Delta1) * Math.Sin(Delta2) - Math.Sin(Delta1) * Math.Cos(Delta2) * Math.Cos(Alpha2 - Alpha1);
            double y = Math.Cos(Delta2) * Math.Sin(Alpha2 - Alpha1);
            double z = Math.Sin(Delta1) * Math.Sin(Delta2) + Math.Cos(Delta1) * Math.Cos(Delta2) * Math.Cos(Alpha2 - Alpha1);

            double value = Math.Atan2(Math.Sqrt(x * x + y * y), z);
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            if (value < 0)
                value += 180;

            return value;
        }

        public static double PositionAngle(double Alpha1, double Delta1, double Alpha2, double Delta2)
        {
            Delta1 = AASCoordinateTransformation.DegreesToRadians(Delta1);
            Delta2 = AASCoordinateTransformation.DegreesToRadians(Delta2);

            Alpha1 = AASCoordinateTransformation.HoursToRadians(Alpha1);
            Alpha2 = AASCoordinateTransformation.HoursToRadians(Alpha2);

            double DeltaAlpha = Alpha1 - Alpha2;
            double value = Math.Atan2(Math.Sin(DeltaAlpha), Math.Cos(Delta2) * Math.Tan(Delta1) - Math.Sin(Delta2) * Math.Cos(DeltaAlpha));
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            if (value < 0)
                value += 180;

            return value;
        }

        public static double DistanceFromGreatArc(double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3)
        {
            Delta1 = AASCoordinateTransformation.DegreesToRadians(Delta1);
            Delta2 = AASCoordinateTransformation.DegreesToRadians(Delta2);
            Delta3 = AASCoordinateTransformation.DegreesToRadians(Delta3);

            Alpha1 = AASCoordinateTransformation.HoursToRadians(Alpha1);
            Alpha2 = AASCoordinateTransformation.HoursToRadians(Alpha2);
            Alpha3 = AASCoordinateTransformation.HoursToRadians(Alpha3);

            double X1 = Math.Cos(Delta1) * Math.Cos(Alpha1);
            double X2 = Math.Cos(Delta2) * Math.Cos(Alpha2);

            double Y1 = Math.Cos(Delta1) * Math.Sin(Alpha1);
            double Y2 = Math.Cos(Delta2) * Math.Sin(Alpha2);

            double Z1 = Math.Sin(Delta1);
            double Z2 = Math.Sin(Delta2);

            double A = Y1 * Z2 - Z1 * Y2;
            double B = Z1 * X2 - X1 * Z2;
            double C = X1 * Y2 - Y1 * X2;

            double m = Math.Tan(Alpha3);
            double n = Math.Tan(Delta3) / Math.Cos(Alpha3);

            double value = Math.Asin((A + B * m + C * n) / (Math.Sqrt(A * A + B * B + C * C) * Math.Sqrt(1 + m * m + n * n)));
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            if (value < 0)
                value = Math.Abs(value);

            return value;
        }

        public static double SmallestCircle(double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, ref bool bType1)
        {
            double d1 = Separation(Alpha1, Delta1, Alpha2, Delta2);
            double d2 = Separation(Alpha1, Delta1, Alpha3, Delta3);
            double d3 = Separation(Alpha2, Delta2, Alpha3, Delta3);

            double a = d1;
            double b = d2;
            double c = d3;
            if (b > a)
            {
                a = d2;
                b = d1;
                c = d3;
            }
            if (c > a)
            {
                a = d3;
                b = d1;
                c = d2;
            }

            double value;
            if (a > Math.Sqrt(b * b + c * c))
            {
                bType1 = true;
                value = a;
            }
            else
            {
                bType1 = false;
                value = 2 * a * b * c / (Math.Sqrt((a + b + c) * (a + b - c) * (b + c - a) * (a + c - b)));
            }

            return value;
        }
    }
}
