using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASFK5
    {
        public static double CorrectionInLongitude(double Longitude, double Latitude, double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Ldash = Longitude - 1.397 * T - 0.00031 * T * T;

            //Convert to radians
            Ldash = AASCoordinateTransformation.DegreesToRadians(Ldash);
            Latitude = AASCoordinateTransformation.DegreesToRadians(Latitude);

            double value = -0.09033 + 0.03916 * (Math.Cos(Ldash) + Math.Sin(Ldash)) * Math.Tan(Latitude);
            return AASCoordinateTransformation.DMSToDegrees(0, 0, value);
        }

        public static double CorrectionInLatitude(double Longitude, double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Ldash = Longitude - 1.397 * T - 0.00031 * T * T;

            //Convert to radians
            Ldash = AASCoordinateTransformation.DegreesToRadians(Ldash);

            double value = 0.03916 * (Math.Cos(Ldash) - Math.Sin(Ldash));
            return AASCoordinateTransformation.DMSToDegrees(0, 0, value);
        }

        public static AAS3DCoordinate ConvertVSOPToFK5J2000(AAS3DCoordinate value)
        {
            AAS3DCoordinate result = new AAS3DCoordinate()
            {
            X = value.X + 0.000000440360 * value.Y - 0.000000190919 * value.Z,
            Y = -0.000000479966 * value.X + 0.917482137087 * value.Y - 0.397776982902 * value.Z,
            Z = 0.397776982902 * value.Y + 0.917482137087 * value.Z
            };

            return result;
        }

        public static AAS3DCoordinate ConvertVSOPToFK5B1950(AAS3DCoordinate value)
        {
            AAS3DCoordinate result = new AAS3DCoordinate()
            {
            X = 0.999925702634 * value.X + 0.012189716217 * value.Y + 0.000011134016 * value.Z,
            Y = -0.011179418036 * value.X + 0.917413998946 * value.Y - 0.397777041885 * value.Z,
            Z = -0.004859003787 * value.X + 0.397747363646 * value.Y + 0.917482111428 * value.Z
            };

            return result;
        }

        public static AAS3DCoordinate ConvertVSOPToFK5AnyEquinox(AAS3DCoordinate value, double JDEquinox)
        {
            double t = (JDEquinox - 2451545.0) / 36525;
            double tsquared = t * t;
            double tcubed = tsquared * t;

            double sigma = 2306.2181 * t + 0.30188 * tsquared + 0.017988 * tcubed;
            sigma = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, sigma));

            double zeta = 2306.2181 * t + 1.09468 * tsquared + 0.018203 * tcubed;
            zeta = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, zeta));

            double phi = 2004.3109 * t - 0.42665 * tsquared - 0.041833 * tcubed;
            phi = AASCoordinateTransformation.DegreesToRadians(AASCoordinateTransformation.DMSToDegrees(0, 0, phi));

            double cossigma = Math.Cos(sigma);
            double coszeta = Math.Cos(zeta);
            double cosphi = Math.Cos(phi);
            double sinsigma = Math.Sin(sigma);
            double sinzeta = Math.Sin(zeta);
            double sinphi = Math.Sin(phi);

            double xx = cossigma * coszeta * cosphi - sinsigma * sinzeta;
            double xy = sinsigma * coszeta + cossigma * sinzeta * cosphi;
            double xz = cossigma * sinphi;
            double yx = -cossigma * sinzeta - sinsigma * coszeta * cosphi;
            double yy = cossigma * coszeta - sinsigma * sinzeta * cosphi;
            double yz = -sinsigma * sinphi;
            double zx = -coszeta * sinphi;
            double zy = -sinzeta * sinphi;
            double zz = cosphi;

            AAS3DCoordinate result = new AAS3DCoordinate()
            {
            X = xx * value.X + yx * value.Y + zx * value.Z,
            Y = xy * value.X + yy * value.Y + zy * value.Z,
            Z = xz * value.X + yz * value.Y + zz * value.Z
            };

            return result;
        }
    }
}
