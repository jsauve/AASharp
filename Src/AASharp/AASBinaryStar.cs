using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASBinaryStar
    {
        public static AASBinaryStarDetails Calculate(double t, double P, double T, double e, double a, double i, double omega, double w)
        {
            double n = 360 / P;
            double M = AASCoordinateTransformation.MapTo0To360Range(n * (t - T));
            double E = AASKepler.Calculate(M, e);
            E = AASCoordinateTransformation.DegreesToRadians(E);
            i = AASCoordinateTransformation.DegreesToRadians(i);
            w = AASCoordinateTransformation.DegreesToRadians(w);
            omega = AASCoordinateTransformation.DegreesToRadians(omega);

            AASBinaryStarDetails details = new AASBinaryStarDetails { r = a * (1 - e * Math.Cos(E)) };

            double v = Math.Atan(Math.Sqrt((1 + e) / (1 - e)) * Math.Tan(E / 2)) * 2;
            details.Theta = Math.Atan2(Math.Sin(v + w) * Math.Cos(i), Math.Cos(v + w)) + omega;
            details.Theta = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(details.Theta));

            double sinvw = Math.Sin(v + w);
            double cosvw = Math.Cos(v + w);
            double cosi = Math.Cos(i);
            details.Rho = details.r * Math.Sqrt((sinvw * sinvw * cosi * cosi) + (cosvw * cosvw));

            return details;
        }

        public static double ApparentEccentricity(double e, double i, double w)
        {
            i = AASCoordinateTransformation.DegreesToRadians(i);
            w = AASCoordinateTransformation.DegreesToRadians(w);

            double cosi = Math.Cos(i);
            double cosw = Math.Cos(w);
            double sinw = Math.Sin(w);
            double esquared = e * e;
            double A = (1 - esquared * cosw * cosw) * cosi * cosi;
            double B = esquared * sinw * cosw * cosi;
            double C = 1 - esquared * sinw * sinw;
            double D = (A - C) * (A - C) + 4 * B * B;

            double sqrtD = Math.Sqrt(D);
            return Math.Sqrt(2 * sqrtD / (A + C + sqrtD));
        }
    }
}
