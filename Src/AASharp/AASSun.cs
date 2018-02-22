using System;

namespace AASharp
{
    public static class AASSun
    {
        public static double GeometricEclipticLongitude(double JD, bool bHighPrecision)
        {
            return AASCoordinateTransformation.MapTo0To360Range(AASEarth.EclipticLongitude(JD, bHighPrecision) + 180);
        }

        public static double GeometricEclipticLatitude(double JD, bool bHighPrecision)
        {
            return -AASEarth.EclipticLatitude(JD, bHighPrecision);
        }

        public static double GeometricEclipticLongitudeJ2000(double JD, bool bHighPrecision)
        {
            return AASCoordinateTransformation.MapTo0To360Range(AASEarth.EclipticLongitudeJ2000(JD, bHighPrecision) + 180);
        }

        public static double GeometricEclipticLatitudeJ2000(double JD, bool bHighPrecision)
        {
            return -AASEarth.EclipticLatitudeJ2000(JD, bHighPrecision);
        }

        public static double GeometricFK5EclipticLongitude(double JD, bool bHighPrecision)
        {
            //Convert to the FK5 stystem
            double Longitude = GeometricEclipticLongitude(JD, bHighPrecision);
            double Latitude = GeometricEclipticLatitude(JD, bHighPrecision);
            Longitude += AASFK5.CorrectionInLongitude(Longitude, Latitude, JD);

            return Longitude;
        }

        public static double GeometricFK5EclipticLatitude(double JD, bool bHighPrecision)
        {
            //Convert to the FK5 stystem
            double Longitude = GeometricEclipticLongitude(JD, bHighPrecision);
            double Latitude = GeometricEclipticLatitude(JD, bHighPrecision);
            double SunLatCorrection = AASFK5.CorrectionInLatitude(Longitude, JD);
            Latitude += SunLatCorrection;

            return Latitude;
        }

        public static double ApparentEclipticLongitude(double JD, bool bHighPrecision)
        {
            double Longitude = GeometricFK5EclipticLongitude(JD, bHighPrecision);

            //Apply the correction in longitude due to nutation
            Longitude += AASCoordinateTransformation.DMSToDegrees(0, 0, AASNutation.NutationInLongitude(JD));

            //Apply the correction in longitude due to aberration
            double R = AASEarth.RadiusVector(JD, bHighPrecision);
            if (bHighPrecision)
                Longitude -= (0.005775518 * R * AASCoordinateTransformation.DMSToDegrees(0, 0, VariationGeometricEclipticLongitude(JD)));
            else
                Longitude -= AASCoordinateTransformation.DMSToDegrees(0, 0, 20.4898 / R);

            return Longitude;
        }

        public static double ApparentEclipticLatitude(double JD, bool bHighPrecision)
        {
            return GeometricFK5EclipticLatitude(JD, bHighPrecision);
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesMeanEquinox(double JD, bool bHighPrecision)
        {
            double Longitude = AASCoordinateTransformation.DegreesToRadians(GeometricFK5EclipticLongitude(JD, bHighPrecision));
            double Latitude = AASCoordinateTransformation.DegreesToRadians(GeometricFK5EclipticLatitude(JD, bHighPrecision));
            double R = AASEarth.RadiusVector(JD, bHighPrecision);
            double epsilon = AASCoordinateTransformation.DegreesToRadians(AASNutation.MeanObliquityOfEcliptic(JD));

            AAS3DCoordinate value = new AAS3DCoordinate
            {
                X = R * Math.Cos(Latitude) * Math.Cos(Longitude),
                Y = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Cos(epsilon) - Math.Sin(Latitude) * Math.Sin(epsilon)),
                Z = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Sin(epsilon) + Math.Sin(Latitude) * Math.Cos(epsilon))
            };

            return value;
        }

        public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(double JD, bool bHighPrecision)
        {
            double Longitude = GeometricEclipticLongitudeJ2000(JD, bHighPrecision);
            Longitude = AASCoordinateTransformation.DegreesToRadians(Longitude);
            double Latitude = GeometricEclipticLatitudeJ2000(JD, bHighPrecision);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            double R = AASEarth.RadiusVector(JD, bHighPrecision);

            double coslatitude = Math.Cos(Latitude);
            AAS3DCoordinate value = new AAS3DCoordinate
            {
                X = R * coslatitude * Math.Cos(Longitude),
                Y = R * coslatitude * Math.Sin(Longitude),
                Z = R * Math.Sin(Latitude)
            };

            return value;
        }


        public static AAS3DCoordinate EquatorialRectangularCoordinatesJ2000(double JD, bool bHighPrecision)
        {
            AAS3DCoordinate value = EclipticRectangularCoordinatesJ2000(JD, bHighPrecision);
            value = AASFK5.ConvertVSOPToFK5J2000(value);

            return value;
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesB1950(double JD, bool bHighPrecision)
        {
            AAS3DCoordinate value = EclipticRectangularCoordinatesJ2000(JD, bHighPrecision);
            value = AASFK5.ConvertVSOPToFK5B1950(value);

            return value;
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesAnyEquinox(double JD, double JDEquinox, bool bHighPrecision)
        {
            AAS3DCoordinate value = EquatorialRectangularCoordinatesJ2000(JD, bHighPrecision);
            value = AASFK5.ConvertVSOPToFK5AnyEquinox(value, JDEquinox);

            return value;
        }

        private static double VariationGeometricEclipticLongitude(double JD)
        {
            //D is the number of days since the epoch
            double D = JD - 2451545.00;
            double tau = (D / 365250);
            double tau2 = tau * tau;
            double tau3 = tau2 * tau;

            double deltaLambda = 3548.193
                                 + 118.568 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(87.5287 + 359993.7286 * tau))
                                 + 2.476 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(85.0561 + 719987.4571 * tau))
                                 + 1.376 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(27.8502 + 4452671.1152 * tau))
                                 + 0.119 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(73.1375 + 450368.8564 * tau))
                                 + 0.114 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(337.2264 + 329644.6718 * tau))
                                 + 0.086 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(222.5400 + 659289.3436 * tau))
                                 + 0.078 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(162.8136 + 9224659.7915 * tau))
                                 + 0.054 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(82.5823 + 1079981.1857 * tau))
                                 + 0.052 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(171.5189 + 225184.4282 * tau))
                                 + 0.034 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(30.3214 + 4092677.3866 * tau))
                                 + 0.033 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(119.8105 + 337181.4711 * tau))
                                 + 0.023 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(247.5418 + 299295.6151 * tau))
                                 + 0.023 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(325.1526 + 315559.5560 * tau))
                                 + 0.021 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(155.1241 + 675553.2846 * tau))
                                 + 7.311 * tau * Math.Sin(AASCoordinateTransformation.DegreesToRadians(333.4515 + 359993.7286 * tau))
                                 + 0.305 * tau * Math.Sin(AASCoordinateTransformation.DegreesToRadians(330.9814 + 719987.4571 * tau))
                                 + 0.010 * tau * Math.Sin(AASCoordinateTransformation.DegreesToRadians(328.5170 + 1079981.1857 * tau))
                                 + 0.309 * tau2 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(241.4518 + 359993.7286 * tau))
                                 + 0.021 * tau2 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(205.0482 + 719987.4571 * tau))
                                 + 0.004 * tau2 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(297.8610 + 4452671.1152 * tau))
                                 + 0.010 * tau3 * Math.Sin(AASCoordinateTransformation.DegreesToRadians(154.7066 + 359993.7286 * tau));

            return deltaLambda;
        }
    }
}
