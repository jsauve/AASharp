using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASNearParabolicObjectElements
    {
        public double q;
        public double i;
        public double w;
        public double omega;
        public double JDEquinox;
        public double T;
        public double e;
    }

    public class AASNearParabolicObjectDetails
    {
        public AASNearParabolicObjectDetails()
        {
            HeliocentricRectangularEquatorial = new AAS3DCoordinate();
            HeliocentricRectangularEcliptical = new AAS3DCoordinate();
        }

        public AAS3DCoordinate HeliocentricRectangularEquatorial;
        public AAS3DCoordinate HeliocentricRectangularEcliptical;
        public double HeliocentricEclipticLongitude;
        public double HeliocentricEclipticLatitude;
        public double TrueGeocentricRA;
        public double TrueGeocentricDeclination;
        public double TrueGeocentricDistance;
        public double TrueGeocentricLightTime;
        public double AstrometricGeocentricRA;
        public double AstrometricGeocentricDeclination;
        public double AstrometricGeocentricDistance;
        public double AstrometricGeocentricLightTime;
        public double Elongation;
        public double PhaseAngle;
    }
    public static class AASNearParabolic
    {
        private static double Cbrt(double x)
        {
            return Math.Pow(x, 1.0 / 3);
        }

        public static void CalulateTrueAnnomalyAndRadius(double JD, ref AASNearParabolicObjectElements elements, ref double v, ref double r)
        {
            double k = 0.01720209895;
            double a = 0.75 * (JD - elements.T) * k * Math.Sqrt((1 + elements.e) / (elements.q * elements.q * elements.q));
            double b = Math.Sqrt(1 + a * a);
            double W = Cbrt(b + a) - Cbrt(b - a);
            double W2 = W * W;
            double W4 = W2 * W2;
            double f = (1 - elements.e) / (1 + elements.e);
            double a1 = (2.0 / 3) + (0.4) * W2;
            double a2 = (7.0 / 5) + (33.0 / 35) * W2 + (37.0 / 175) * W4;
            double a3 = W2 * ((432.0 / 175) + (956.0 / 1125) * W2 + (84.0 / 1575) * W4);
            double C = W2 / (1 + W2);
            double g = f * C * C;
            double w = W * (1 + f * C * (a1 + a2 * g + a3 * g * g));
            double w2 = w * w;
            v = 2 * Math.Atan(w);
            r = elements.q * (1 + w2) / (1 + w2 * f);
        }

        public static AASNearParabolicObjectDetails Calculate(double JD, ref AASNearParabolicObjectElements elements)
        {
            double Epsilon = AASNutation.MeanObliquityOfEcliptic(elements.JDEquinox);

            double JD0 = JD;

            //What will be the return value
            AASNearParabolicObjectDetails details = new AASNearParabolicObjectDetails();

            Epsilon = AASCoordinateTransformation.DegreesToRadians(Epsilon);
            double omega = AASCoordinateTransformation.DegreesToRadians(elements.omega);
            double w = AASCoordinateTransformation.DegreesToRadians(elements.w);
            double i = AASCoordinateTransformation.DegreesToRadians(elements.i);

            double sinEpsilon = Math.Sin(Epsilon);
            double cosEpsilon = Math.Cos(Epsilon);
            double sinOmega = Math.Sin(omega);
            double cosOmega = Math.Cos(omega);
            double cosi = Math.Cos(i);
            double sini = Math.Sin(i);

            double F = cosOmega;
            double G = sinOmega * cosEpsilon;
            double H = sinOmega * sinEpsilon;
            double P = -sinOmega * cosi;
            double Q = cosOmega * cosi * cosEpsilon - sini * sinEpsilon;
            double R = cosOmega * cosi * sinEpsilon + sini * cosEpsilon;
            double a = Math.Sqrt(F * F + P * P);
            double b = Math.Sqrt(G * G + Q * Q);
            double c = Math.Sqrt(H * H + R * R);
            double A = Math.Atan2(F, P);
            double B = Math.Atan2(G, Q);
            double C = Math.Atan2(H, R);

            AAS3DCoordinate SunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, elements.JDEquinox);

            for (int j = 0; j < 2; j++)
            {
                double v = 0;
                double r = 0;
                CalulateTrueAnnomalyAndRadius(JD0, ref elements, ref v, ref r);

                double x = r * a * Math.Sin(A + w + v);
                double y = r * b * Math.Sin(B + w + v);
                double z = r * c * Math.Sin(C + w + v);

                if (j == 0)
                {
                    details.HeliocentricRectangularEquatorial.X = x;
                    details.HeliocentricRectangularEquatorial.Y = y;
                    details.HeliocentricRectangularEquatorial.Z = z;

                    //Calculate the heliocentric ecliptic coordinates also
                    double u = w + v;
                    double cosu = Math.Cos(u);
                    double sinu = Math.Sin(u);

                    details.HeliocentricRectangularEcliptical.X = r * (cosOmega * cosu - sinOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Y = r * (sinOmega * cosu + cosOmega * sinu * cosi);
                    details.HeliocentricRectangularEcliptical.Z = r * sini * sinu;

                    details.HeliocentricEclipticLongitude = Math.Atan2(y, x);
                    details.HeliocentricEclipticLongitude = AASCoordinateTransformation.MapTo0To24Range(AASCoordinateTransformation.RadiansToDegrees(details.HeliocentricEclipticLongitude) / 15);
                    details.HeliocentricEclipticLatitude = Math.Asin(z / r);
                    details.HeliocentricEclipticLatitude = AASCoordinateTransformation.RadiansToDegrees(details.HeliocentricEclipticLatitude);
                }

                double psi = SunCoord.X + x;
                double nu = SunCoord.Y + y;
                double sigma = SunCoord.Z + z;

                double Alpha = Math.Atan2(nu, psi);
                Alpha = AASCoordinateTransformation.RadiansToDegrees(Alpha);
                double Delta = Math.Atan2(sigma, Math.Sqrt(psi * psi + nu * nu));
                Delta = AASCoordinateTransformation.RadiansToDegrees(Delta);
                double Distance = Math.Sqrt(psi * psi + nu * nu + sigma * sigma);

                if (j == 0)
                {
                    details.TrueGeocentricRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.TrueGeocentricDeclination = Delta;
                    details.TrueGeocentricDistance = Distance;
                    details.TrueGeocentricLightTime = AASElliptical.DistanceToLightTime(Distance);
                }
                else
                {
                    details.AstrometricGeocentricRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.AstrometricGeocentricDeclination = Delta;
                    details.AstrometricGeocentricDistance = Distance;
                    details.AstrometricGeocentricLightTime = AASElliptical.DistanceToLightTime(Distance);

                    double RES = Math.Sqrt(SunCoord.X * SunCoord.X + SunCoord.Y * SunCoord.Y + SunCoord.Z * SunCoord.Z);

                    details.Elongation = AASCoordinateTransformation.RadiansToDegrees(Math.Acos((RES * RES + Distance * Distance - r * r) / (2 * RES * Distance)));
                    details.PhaseAngle = AASCoordinateTransformation.RadiansToDegrees(Math.Acos((r * r + Distance * Distance - RES * RES) / (2 * r * Distance)));
                }

                if (j == 0)
                    //Prepare for the next loop around
                    JD0 = JD - details.TrueGeocentricLightTime;
            }

            return details;
        }
    }
}
