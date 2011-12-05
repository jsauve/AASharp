using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASEllipticalObjectElements
    {
        public double a;
        public double e;
        public double i;
        public double w;
        public double omega;
        public double JDEquinox;
        public double T;
    }

    public class AASEllipticalPlanetaryDetails
    {
        public AASEllipticalPlanetaryDetails()
        {
        }

        public double ApparentGeocentricLongitude;
        public double ApparentGeocentricLatitude;
        public double ApparentGeocentricDistance;
        public double ApparentLightTime;
        public double ApparentGeocentricRA;
        public double ApparentGeocentricDeclination;
    }

    public class AASEllipticalObjectDetails
    {
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

    public enum AASEllipticalObject
    {
        SUN,
        MERCURY,
        VENUS,
        MARS,
        JUPITER,
        SATURN,
        URANUS,
        NEPTUNE,
        PLUTO
    }
    public static class AASElliptical
    {
        public static double DistanceToLightTime(double Distance)
        {
            return Distance * 0.0057755183;
        }

        public static AASEllipticalPlanetaryDetails Calculate(double JD, AASEllipticalObject ellipticalObject)
        {
            //What will the the return value
            AASEllipticalPlanetaryDetails details = new AASEllipticalPlanetaryDetails();

            double JD0 = JD;
            double L0 = 0;
            double B0 = 0;
            double R0 = 0;
            double cosB0 = 0;
            if (ellipticalObject != AASEllipticalObject.SUN)
            {
                L0 = AASEarth.EclipticLongitude(JD0);
                B0 = AASEarth.EclipticLatitude(JD0);
                R0 = AASEarth.RadiusVector(JD0);
                L0 = AASCoordinateTransformation.DegreesToRadians(L0);
                B0 = AASCoordinateTransformation.DegreesToRadians(B0);
                cosB0 = Math.Cos(B0);
            }


            //Calculate the initial values
            double L = 0;
            double B = 0;
            double R = 0;
            switch (ellipticalObject)
            {
                case AASEllipticalObject.SUN:
                    {
                        L = AASSun.GeometricEclipticLongitude(JD0);
                        B = AASSun.GeometricEclipticLatitude(JD0);
                        R = AASEarth.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.MERCURY:
                    {
                        L = AASMercury.EclipticLongitude(JD0);
                        B = AASMercury.EclipticLatitude(JD0);
                        R = AASMercury.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.VENUS:
                    {
                        L = AASVenus.EclipticLongitude(JD0);
                        B = AASVenus.EclipticLatitude(JD0);
                        R = AASVenus.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.MARS:
                    {
                        L = AASMars.EclipticLongitude(JD0);
                        B = AASMars.EclipticLatitude(JD0);
                        R = AASMars.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.JUPITER:
                    {
                        L = AASJupiter.EclipticLongitude(JD0);
                        B = AASJupiter.EclipticLatitude(JD0);
                        R = AASJupiter.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.SATURN:
                    {
                        L = AASSaturn.EclipticLongitude(JD0);
                        B = AASSaturn.EclipticLatitude(JD0);
                        R = AASSaturn.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.URANUS:
                    {
                        L = AASUranus.EclipticLongitude(JD0);
                        B = AASUranus.EclipticLatitude(JD0);
                        R = AASUranus.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.NEPTUNE:
                    {
                        L = AASNeptune.EclipticLongitude(JD0);
                        B = AASNeptune.EclipticLatitude(JD0);
                        R = AASNeptune.RadiusVector(JD0);
                        break;
                    }
                case AASEllipticalObject.PLUTO:
                    {
                        L = AASPluto.EclipticLongitude(JD0);
                        B = AASPluto.EclipticLatitude(JD0);
                        R = AASPluto.RadiusVector(JD0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            bool bRecalc = true;
            bool bFirstRecalc = true;
            double LPrevious = 0;
            double BPrevious = 0;
            double RPrevious = 0;
            while (bRecalc)
            {
                switch (ellipticalObject)
                {
                    case AASEllipticalObject.SUN:
                        {
                            L = AASSun.GeometricEclipticLongitude(JD0);
                            B = AASSun.GeometricEclipticLatitude(JD0);
                            R = AASEarth.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.MERCURY:
                        {
                            L = AASMercury.EclipticLongitude(JD0);
                            B = AASMercury.EclipticLatitude(JD0);
                            R = AASMercury.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.VENUS:
                        {
                            L = AASVenus.EclipticLongitude(JD0);
                            B = AASVenus.EclipticLatitude(JD0);
                            R = AASVenus.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.MARS:
                        {
                            L = AASMars.EclipticLongitude(JD0);
                            B = AASMars.EclipticLatitude(JD0);
                            R = AASMars.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.JUPITER:
                        {
                            L = AASJupiter.EclipticLongitude(JD0);
                            B = AASJupiter.EclipticLatitude(JD0);
                            R = AASJupiter.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.SATURN:
                        {
                            L = AASSaturn.EclipticLongitude(JD0);
                            B = AASSaturn.EclipticLatitude(JD0);
                            R = AASSaturn.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.URANUS:
                        {
                            L = AASUranus.EclipticLongitude(JD0);
                            B = AASUranus.EclipticLatitude(JD0);
                            R = AASUranus.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.NEPTUNE:
                        {
                            L = AASNeptune.EclipticLongitude(JD0);
                            B = AASNeptune.EclipticLatitude(JD0);
                            R = AASNeptune.RadiusVector(JD0);
                            break;
                        }
                    case AASEllipticalObject.PLUTO:
                        {
                            L = AASPluto.EclipticLongitude(JD0);
                            B = AASPluto.EclipticLatitude(JD0);
                            R = AASPluto.RadiusVector(JD0);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                if (!bFirstRecalc)
                {
                    bRecalc = ((Math.Abs(L - LPrevious) > 0.00001) || (Math.Abs(B - BPrevious) > 0.00001) || (Math.Abs(R - RPrevious) > 0.000001));
                    LPrevious = L;
                    BPrevious = B;
                    RPrevious = R;
                }
                else
                    bFirstRecalc = false;

                //Calculate the new value
                if (bRecalc)
                {
                    double distance;
                    if (ellipticalObject != AASEllipticalObject.SUN)
                    {
                        double Lrad = AASCoordinateTransformation.DegreesToRadians(L);
                        double Brad = AASCoordinateTransformation.DegreesToRadians(B);
                        double cosB = Math.Cos(Brad);
                        double cosL = Math.Cos(Lrad);
                        double x = R * cosB * cosL - R0 * cosB0 * Math.Cos(L0);
                        double y = R * cosB * Math.Sin(Lrad) - R0 * cosB0 * Math.Sin(L0);
                        double z = R * Math.Sin(Brad) - R0 * Math.Sin(B0);
                        distance = Math.Sqrt(x * x + y * y + z * z);
                    }
                    else
                        distance = R; //Distance to the sun from the earth is in fact the radius vector

                    //Prepare for the next loop around
                    JD0 = JD - AASElliptical.DistanceToLightTime(distance);
                }
            }
            {
                double Lrad = AASCoordinateTransformation.DegreesToRadians(L);
                double Brad = AASCoordinateTransformation.DegreesToRadians(B);
                double cosB = Math.Cos(Brad);
                double cosL = Math.Cos(Lrad);
                double x = R * cosB * cosL - R0 * cosB0 * Math.Cos(L0);
                double y = R * cosB * Math.Sin(Lrad) - R0 * cosB0 * Math.Sin(L0);
                double z = R * Math.Sin(Brad) - R0 * Math.Sin(B0);
                double x2 = x * x;
                double y2 = y * y;

                details.ApparentGeocentricLatitude = AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(z, Math.Sqrt(x2 + y2)));
                details.ApparentGeocentricDistance = Math.Sqrt(x2 + y2 + z * z);
                details.ApparentGeocentricLongitude = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(y, x)));
                details.ApparentLightTime = AASElliptical.DistanceToLightTime(details.ApparentGeocentricDistance);

                //Adjust for Aberration
                AAS2DCoordinate Aberration = AASAberration.EclipticAberration(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, JD);
                details.ApparentGeocentricLongitude += Aberration.X;
                details.ApparentGeocentricLatitude += Aberration.Y;

                //convert to the FK5 system
                double DeltaLong = AASFK5.CorrectionInLongitude(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, JD);
                details.ApparentGeocentricLatitude += AASFK5.CorrectionInLatitude(details.ApparentGeocentricLongitude, JD);
                details.ApparentGeocentricLongitude += DeltaLong;

                //Correct for nutation
                double NutationInLongitude = AASNutation.NutationInLongitude(JD);
                double Epsilon = AASNutation.TrueObliquityOfEcliptic(JD);
                details.ApparentGeocentricLongitude += AASCoordinateTransformation.DMSToDegrees(0, 0, NutationInLongitude);

                //Convert to RA and Dec
                AAS2DCoordinate ApparentEqu = AASCoordinateTransformation.Ecliptic2Equatorial(details.ApparentGeocentricLongitude, details.ApparentGeocentricLatitude, Epsilon);
                details.ApparentGeocentricRA = ApparentEqu.X;
                details.ApparentGeocentricDeclination = ApparentEqu.Y;
            }

            return details;
        }

        public static double SemiMajorAxisFromPerihelionDistance(double q, double e)
        {
            return q / (1 - e);
        }

        public static double MeanMotionFromSemiMajorAxis(double a)
        {
            return 0.9856076686 / (a * Math.Sqrt(a));
        }

        public static AASEllipticalObjectDetails Calculate(double JD, ref AASEllipticalObjectElements elements)
        {
            double Epsilon = AASNutation.MeanObliquityOfEcliptic(elements.JDEquinox);

            double JD0 = JD;

            //What will be the return value
            AASEllipticalObjectDetails details = new AASEllipticalObjectDetails();

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
            double n = AASElliptical.MeanMotionFromSemiMajorAxis(elements.a);

            AAS3DCoordinate SunCoord = AASSun.EquatorialRectangularCoordinatesAnyEquinox(JD, elements.JDEquinox);

            for (int j = 0; j < 2; j++)
            {
                double M = n * (JD0 - elements.T);
                double E = AASKepler.Calculate(M, elements.e);
                E = AASCoordinateTransformation.DegreesToRadians(E);
                double v = 2 * Math.Atan(Math.Sqrt((1 + elements.e) / (1 - elements.e)) * Math.Tan(E / 2));
                double r = elements.a * (1 - elements.e * Math.Cos(E));
                double x = r * a * Math.Sin(A + w + v);
                double y = r * b * Math.Sin(B + w + v);
                double z = r * c * Math.Sin(C + w + v);

                if (j == 0)
                {
                    details.HeliocentricRectangularEquatorial = new AAS3DCoordinate() { X = x, Y = y, Z = z };

                    //Calculate the heliocentric ecliptic coordinates also
                    double u = w + v;
                    double cosu = Math.Cos(u);
                    double sinu = Math.Sin(u);

                    details.HeliocentricRectangularEcliptical = new AAS3DCoordinate()
                    {
                        X = r * (cosOmega * cosu - sinOmega * sinu * cosi),
                        Y = r * (sinOmega * cosu + cosOmega * sinu * cosi),
                        Z = r * sini * sinu
                    };

                    details.HeliocentricEclipticLongitude = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(details.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.X)));
                    details.HeliocentricEclipticLatitude = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(details.HeliocentricRectangularEcliptical.Z / r));
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
                    details.TrueGeocentricLightTime = DistanceToLightTime(Distance);
                }
                else
                {
                    details.AstrometricGeocentricRA = AASCoordinateTransformation.MapTo0To24Range(Alpha / 15);
                    details.AstrometricGeocentricDeclination = Delta;
                    details.AstrometricGeocentricDistance = Distance;
                    details.AstrometricGeocentricLightTime = DistanceToLightTime(Distance);

                    double RES = Math.Sqrt(SunCoord.X * SunCoord.X + SunCoord.Y * SunCoord.Y + SunCoord.Z * SunCoord.Z);

                    details.Elongation = Math.Acos((RES * RES + Distance * Distance - r * r) / (2 * RES * Distance));
                    details.Elongation = AASCoordinateTransformation.RadiansToDegrees(details.Elongation);

                    details.PhaseAngle = Math.Acos((r * r + Distance * Distance - RES * RES) / (2 * r * Distance));
                    details.PhaseAngle = AASCoordinateTransformation.RadiansToDegrees(details.PhaseAngle);
                }

                if (j == 0)
                    //Prepare for the next loop around
                    JD0 = JD - details.TrueGeocentricLightTime;
            }

            return details;
        }

        public static double InstantaneousVelocity(double r, double a)
        {
            return 42.1219 * Math.Sqrt((1 / r) - (1 / (2 * a)));
        }

        public static double VelocityAtPerihelion(double e, double a)
        {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 + e) / (1 - e));
        }

        public static double VelocityAtAphelion(double e, double a)
        {
            return 29.7847 / Math.Sqrt(a) * Math.Sqrt((1 - e) / (1 + e));
        }

        public static double LengthOfEllipse(double e, double a)
        {
            double b = a * Math.Sqrt(1 - e * e);
            return AASCoordinateTransformation.PI() * (3 * (a + b) - Math.Sqrt((a + 3 * b) * (3 * a + b)));
        }

        public static double CometMagnitude(double g, double delta, double k, double r)
        {
            return g + 5 * Math.Log10(delta) + k * Math.Log10(r);
        }

        public static double MinorPlanetMagnitude(double H, double delta, double G, double r, double PhaseAngle)
        {
            //Convert from degrees to radians
            PhaseAngle = AASCoordinateTransformation.DegreesToRadians(PhaseAngle);

            double phi1 = Math.Exp(-3.33 * Math.Pow(Math.Tan(PhaseAngle / 2), 0.63));
            double phi2 = Math.Exp(-1.87 * Math.Pow(Math.Tan(PhaseAngle / 2), 1.22));

            return H + 5 * Math.Log10(r * delta) - 2.5 * Math.Log10((1 - G) * phi1 + G * phi2);
        }
    }
}
