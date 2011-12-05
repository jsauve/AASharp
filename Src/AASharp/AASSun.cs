using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASSun
    {
        public static double GeometricEclipticLongitude(double JD)
        {
            return AASCoordinateTransformation.MapTo0To360Range(AASEarth.EclipticLongitude(JD) + 180);
        }

        public static double GeometricEclipticLatitude(double JD)
        {
            return AASEarth.EclipticLatitude(JD);
        }

        public static double GeometricEclipticLongitudeJ2000(double JD)
        {
            return AASCoordinateTransformation.MapTo0To360Range(AASEarth.EclipticLongitudeJ2000(JD) + 180);
        }

        public static double GeometricEclipticLatitudeJ2000(double JD)
        {
            return AASEarth.EclipticLatitudeJ2000(JD);
        }

        public static double GeometricFK5EclipticLongitude(double JD)
        {
            //Convert to the FK5 stystem
            double Longitude = GeometricEclipticLongitude(JD);
            double Latitude = GeometricEclipticLatitude(JD);
            Longitude += AASFK5.CorrectionInLongitude(Longitude, Latitude, JD);

            return Longitude;
        }

        public static double GeometricFK5EclipticLatitude(double JD)
        {
            //Convert to the FK5 stystem
            double Longitude = GeometricEclipticLongitude(JD);
            double Latitude = GeometricEclipticLatitude(JD);
            double SunLatCorrection = AASFK5.CorrectionInLatitude(Longitude, JD);
            Latitude += SunLatCorrection;

            return Latitude;
        }

        public static double ApparentEclipticLongitude(double JD)
        {
            double Longitude = GeometricFK5EclipticLongitude(JD);

            //Apply the correction in longitude due to nutation
            Longitude += AASCoordinateTransformation.DMSToDegrees(0, 0, AASNutation.NutationInLongitude(JD));

            //Apply the correction in longitude due to aberration
            double R = AASEarth.RadiusVector(JD);
            Longitude -= AASCoordinateTransformation.DMSToDegrees(0, 0, 20.4898 / R);

            return Longitude;
        }

        public static double ApparentEclipticLatitude(double JD)
        {
            return GeometricFK5EclipticLatitude(JD);
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesMeanEquinox(double JD)
        {
            double Longitude = AASCoordinateTransformation.DegreesToRadians(GeometricFK5EclipticLongitude(JD));
            double Latitude = AASCoordinateTransformation.DegreesToRadians(GeometricFK5EclipticLatitude(JD));
            double R = AASEarth.RadiusVector(JD);
            double epsilon = AASCoordinateTransformation.DegreesToRadians(AASNutation.MeanObliquityOfEcliptic(JD));

            AAS3DCoordinate value = new AAS3DCoordinate()
            {
            X = R * Math.Cos(Latitude) * Math.Cos(Longitude),
            Y = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Cos(epsilon) - Math.Sin(Latitude) * Math.Sin(epsilon)),
            Z = R * (Math.Cos(Latitude) * Math.Sin(Longitude) * Math.Sin(epsilon) + Math.Sin(Latitude) * Math.Cos(epsilon))
            };

            return value;
        }

        public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(double JD)
        {
            double Longitude = GeometricEclipticLongitudeJ2000(JD);
            Longitude = AASCoordinateTransformation.DegreesToRadians(Longitude);
            double Latitude = GeometricEclipticLatitudeJ2000(JD);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);
            double R = AASEarth.RadiusVector(JD);

            double coslatitude = Math.Cos(Latitude);
            AAS3DCoordinate value = new AAS3DCoordinate()
            {
            X = R * coslatitude * Math.Cos(Longitude),
            Y = R * coslatitude * Math.Sin(Longitude),
            Z = R * Math.Sin(Latitude)
            };

            return value;
        }


        public static AAS3DCoordinate EquatorialRectangularCoordinatesJ2000(double JD)
        {
            AAS3DCoordinate value = EclipticRectangularCoordinatesJ2000(JD);
            value = AASFK5.ConvertVSOPToFK5J2000(value);

            return value;
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesB1950(double JD)
        {
            AAS3DCoordinate value = EclipticRectangularCoordinatesJ2000(JD);
            value = AASFK5.ConvertVSOPToFK5B1950(value);

            return value;
        }

        public static AAS3DCoordinate EquatorialRectangularCoordinatesAnyEquinox(double JD, double JDEquinox)
        {
            AAS3DCoordinate value = EquatorialRectangularCoordinatesJ2000(JD);
            value = AASFK5.ConvertVSOPToFK5AnyEquinox(value, JDEquinox);

            return value;
        }
    }
}
