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
            return AASEarth.EclipticLatitude(JD, bHighPrecision);
        }

        public static double GeometricEclipticLongitudeJ2000(double JD)
        {
            return AASCoordinateTransformation.MapTo0To360Range(AASEarth.EclipticLongitudeJ2000(JD) + 180);
        }

        public static double GeometricEclipticLatitudeJ2000(double JD)
        {
            return AASEarth.EclipticLatitudeJ2000(JD);
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

            AAS3DCoordinate value = new AAS3DCoordinate()
            {
            X = R * Math.Cos(Latitude) * Math.Cos(Longitude),
            Y = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Cos(epsilon) - Math.Sin(Latitude) * Math.Sin(epsilon)),
            Z = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Sin(epsilon) + Math.Sin(Latitude) * Math.Cos(epsilon))
            };

            return value;
        }

        public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(double JD, bool bHighPrecision)
        {
            double Longitude = GeometricEclipticLongitudeJ2000(JD);
            Longitude = AASCoordinateTransformation.DegreesToRadians(Longitude);
            double Latitude = GeometricEclipticLatitudeJ2000(JD);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            double R = AASEarth.RadiusVector(JD, bHighPrecision);

            double coslatitude = Math.Cos(Latitude);
            AAS3DCoordinate value = new AAS3DCoordinate()
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
    }
}
