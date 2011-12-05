using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASGlobe
    {
        public static double RhoSinThetaPrime(double GeographicalLatitude, double Height)
        {
            GeographicalLatitude = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude);

            double U = Math.Atan(0.99664719 * Math.Tan(GeographicalLatitude));
            return 0.99664719 * Math.Sin(U) + (Height / 6378149 * Math.Sin(GeographicalLatitude));
        }

        public static double RhoCosThetaPrime(double GeographicalLatitude, double Height)
        {
            //Convert from degress to radians
            GeographicalLatitude = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude);

            double U = Math.Atan(0.99664719 * Math.Tan(GeographicalLatitude));
            return Math.Cos(U) + (Height / 6378149 * Math.Cos(GeographicalLatitude));
        }

        public static double RadiusOfParallelOfLatitude(double GeographicalLatitude)
        {
            //Convert from degress to radians
            GeographicalLatitude = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude);

            double sinGeo = Math.Sin(GeographicalLatitude);
            return (6378.14 * Math.Cos(GeographicalLatitude)) / (Math.Sqrt(1 - 0.0066943847614084 * sinGeo * sinGeo));
        }

        public static double RadiusOfCurvature(double GeographicalLatitude)
        {
            //Convert from degress to radians
            GeographicalLatitude = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude);

            double sinGeo = Math.Sin(GeographicalLatitude);
            return (6378.14 * (1 - 0.0066943847614084)) / Math.Pow((1 - 0.0066943847614084 * sinGeo * sinGeo), 1.5);
        }

        public static double DistanceBetweenPoints(double GeographicalLatitude1, double GeographicalLongitude1, double GeographicalLatitude2, double GeographicalLongitude2)
        {
            //Convert from degress to radians
            GeographicalLatitude1 = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude1);
            GeographicalLatitude2 = AASCoordinateTransformation.DegreesToRadians(GeographicalLatitude2);
            GeographicalLongitude1 = AASCoordinateTransformation.DegreesToRadians(GeographicalLongitude1);
            GeographicalLongitude2 = AASCoordinateTransformation.DegreesToRadians(GeographicalLongitude2);

            double F = (GeographicalLatitude1 + GeographicalLatitude2) / 2;
            double G = (GeographicalLatitude1 - GeographicalLatitude2) / 2;
            double lambda = (GeographicalLongitude1 - GeographicalLongitude2) / 2;
            double sinG = Math.Sin(G);
            double cosG = Math.Cos(G);
            double cosF = Math.Cos(F);
            double sinF = Math.Sin(F);
            double sinLambda = Math.Sin(lambda);
            double cosLambda = Math.Cos(lambda);
            double S = (sinG * sinG * cosLambda * cosLambda) + (cosF * cosF * sinLambda * sinLambda);
            double C = (cosG * cosG * cosLambda * cosLambda) + (sinF * sinF * sinLambda * sinLambda);
            double w = Math.Atan(Math.Sqrt(S / C));
            double R = Math.Sqrt(S * C) / w;
            double D = 2 * w * 6378.14;
            double Hprime = (3 * R - 1) / (2 * C);
            double Hprime2 = (3 * R + 1) / (2 * S);
            const double f = 0.0033528131778969144060323814696721;

            return D * (1 + (f * Hprime * sinF * sinF * cosG * cosG) - (f * Hprime2 * cosF * cosF * sinG * sinG));
        }

    }
}
