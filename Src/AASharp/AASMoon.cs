using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASMoon
    {
        static readonly MoonCoefficient1[] g_MoonCoefficients1 =
        {
        new MoonCoefficient1( 0, 0,  1,  0 ),
        new MoonCoefficient1( 2, 0,  -1, 0 ),
        new MoonCoefficient1( 2, 0,  0,  0 ),
        new MoonCoefficient1( 0, 0,  2,  0 ),
        new MoonCoefficient1( 0, 1,  0,  0 ),
        new MoonCoefficient1( 0, 0,  0,  2 ),
        new MoonCoefficient1( 2, 0,  -2, 0 ),
        new MoonCoefficient1( 2, -1, -1, 0 ),
        new MoonCoefficient1( 2, 0,  1,  0 ),
        new MoonCoefficient1( 2, -1, 0,  0 ),
        new MoonCoefficient1( 0, 1,  -1, 0 ),
        new MoonCoefficient1( 1, 0,  0,  0 ),
        new MoonCoefficient1( 0, 1,  1,  0 ),
        new MoonCoefficient1( 2, 0,  0,  -2 ),
        new MoonCoefficient1( 0, 0,  1,  2 ),
        new MoonCoefficient1( 0, 0,  1,  -2 ),
        new MoonCoefficient1( 4, 0,  -1, 0 ),
        new MoonCoefficient1( 0, 0,  3,  0 ),
        new MoonCoefficient1( 4, 0,  -2, 0 ),
        new MoonCoefficient1( 2, 1,  -1, 0 ),
        new MoonCoefficient1( 2, 1,  0,  0 ),
        new MoonCoefficient1( 1, 0,  -1, 0 ),
        new MoonCoefficient1( 1, 1,  0,  0 ),
        new MoonCoefficient1( 2, -1, 1,  0 ),
        new MoonCoefficient1( 2, 0,  2,  0 ),
        new MoonCoefficient1( 4, 0,  0,  0 ),
        new MoonCoefficient1( 2, 0,  -3, 0 ),
        new MoonCoefficient1( 0, 1,  -2, 0 ),
        new MoonCoefficient1( 2, 0,  -1, 2 ),
        new MoonCoefficient1( 2, -1, -2, 0 ),
        new MoonCoefficient1( 1, 0,  1,  0 ),
        new MoonCoefficient1( 2, -2, 0,  0 ),
        new MoonCoefficient1( 0, 1,  2,  0 ),
        new MoonCoefficient1( 0, 2,  0,  0 ),
        new MoonCoefficient1( 2, -2, -1, 0 ),
        new MoonCoefficient1( 2, 0,  1,  -2 ),
        new MoonCoefficient1( 2, 0,  0,  2 ),
        new MoonCoefficient1( 4, -1, -1, 0 ),
        new MoonCoefficient1( 0, 0,  2,  2 ),
        new MoonCoefficient1( 3, 0,  -1, 0 ),
        new MoonCoefficient1( 2, 1,  1,  0 ),
        new MoonCoefficient1( 4, -1, -2, 0 ),
        new MoonCoefficient1( 0, 2,  -1, 0 ),
        new MoonCoefficient1( 2, 2,  -1, 0 ),
        new MoonCoefficient1( 2, 1,  -2, 0 ),
        new MoonCoefficient1( 2, -1, 0,  -2 ),
        new MoonCoefficient1( 4, 0,  1,  0 ),
        new MoonCoefficient1( 0, 0,  4,  0 ),
        new MoonCoefficient1( 4, -1, 0,  0 ),
        new MoonCoefficient1( 1, 0,  -2, 0 ),
        new MoonCoefficient1( 2, 1,  0,  -2 ),
        new MoonCoefficient1( 0, 0,  2,  -2 ),
        new MoonCoefficient1( 1, 1,  1,  0 ),
        new MoonCoefficient1( 3, 0,  -2, 0 ),
        new MoonCoefficient1( 4, 0,  -3, 0 ),
        new MoonCoefficient1( 2, -1, 2,  0 ),
        new MoonCoefficient1( 0, 2,  1,  0 ),
        new MoonCoefficient1( 1, 1,  -1, 0 ),
        new MoonCoefficient1( 2, 0,  3,  0 ),
        new MoonCoefficient1( 2, 0,  -1, -2 )
        };

        static readonly MoonCoefficient2[] g_MoonCoefficients2 =
        {
        new MoonCoefficient2( 6288774, -20905355 ),
        new MoonCoefficient2( 1274027, -3699111 ),
        new MoonCoefficient2( 658314,  -2955968 ),
        new MoonCoefficient2( 213618,  -569925 ),
        new MoonCoefficient2( -185116, 48888 ),
        new MoonCoefficient2( -114332, -3149 ),
        new MoonCoefficient2( 58793,  246158 ),
        new MoonCoefficient2( 57066,  -152138 ),
        new MoonCoefficient2( 53322,  -170733 ),
        new MoonCoefficient2( 45758,  -204586 ),
        new MoonCoefficient2( -40923,  -129620 ),
        new MoonCoefficient2( -34720,  108743 ),
        new MoonCoefficient2( -30383,  104755 ),
        new MoonCoefficient2( 15327,  10321 ),
        new MoonCoefficient2( -12528,  0 ),
        new MoonCoefficient2( 10980,  79661 ),
        new MoonCoefficient2( 10675,  -34782 ),
        new MoonCoefficient2( 10034,  -23210 ),
        new MoonCoefficient2( 8548,    -21636 ),
        new MoonCoefficient2( -7888,  24208 ),
        new MoonCoefficient2( -6766,  30824 ),
        new MoonCoefficient2( -5163,  -8379 ),
        new MoonCoefficient2( 4987,    -16675 ),
        new MoonCoefficient2( 4036,    -12831 ),
        new MoonCoefficient2( 3994,    -10445 ),
        new MoonCoefficient2( 3861,    -11650 ),
        new MoonCoefficient2( 3665,    14403 ),
        new MoonCoefficient2( -2689,  -7003 ),
        new MoonCoefficient2( -2602,  0 ),
        new MoonCoefficient2( 2390,    10056 ),
        new MoonCoefficient2( -2348,  6322 ),
        new MoonCoefficient2( 2236,    -9884 ),
        new MoonCoefficient2( -2120,  5751 ),
        new MoonCoefficient2( -2069,  0 ),
        new MoonCoefficient2( 2048,    -4950 ),
        new MoonCoefficient2( -1773,  4130 ),
        new MoonCoefficient2( -1595,  0 ),
        new MoonCoefficient2( 1215,    -3958 ),
        new MoonCoefficient2( -1110,  0 ),
        new MoonCoefficient2( -892,    3258 ),
        new MoonCoefficient2( -810,    2616 ),
        new MoonCoefficient2( 759,    -1897 ),
        new MoonCoefficient2( -713,    -2117 ),
        new MoonCoefficient2( -700,    2354 ),
        new MoonCoefficient2( 691,    0 ),
        new MoonCoefficient2( 596,    0 ),
        new MoonCoefficient2( 549,    -1423 ),
        new MoonCoefficient2( 537,    -1117 ),
        new MoonCoefficient2( 520,    -1571 ),
        new MoonCoefficient2( -487,    -1739 ),
        new MoonCoefficient2( -399,    0 ),
        new MoonCoefficient2( -381,    -4421 ),
        new MoonCoefficient2( 351,    0 ),
        new MoonCoefficient2( -340,    0 ),
        new MoonCoefficient2( 330,    0 ) ,
        new MoonCoefficient2( 327,    0 ),
        new MoonCoefficient2( -323,    1165 ),
        new MoonCoefficient2( 299,    0 ),
        new MoonCoefficient2( 294,    0 ),
        new MoonCoefficient2( 0,      8752 )
        };

        static readonly MoonCoefficient1[] g_MoonCoefficients3 =
        {
        new MoonCoefficient1( 0, 0,  0,  1  ),
        new MoonCoefficient1( 0, 0,  1,  1  ),
        new MoonCoefficient1( 0, 0,  1,  -1  ),
        new MoonCoefficient1( 2, 0,  0,  -1  ),
        new MoonCoefficient1( 2, 0,  -1, 1  ),
        new MoonCoefficient1( 2, 0,  -1, -1 ),
        new MoonCoefficient1( 2, 0,  0,  1  ),
        new MoonCoefficient1( 0, 0,  2,  1 ),
        new MoonCoefficient1( 2, 0,  1,  -1  ),
        new MoonCoefficient1( 0, 0,  2,  -1 ),
        new MoonCoefficient1( 2, -1, 0,  -1 ),
        new MoonCoefficient1( 2, 0,  -2, -1 ),
        new MoonCoefficient1( 2, 0,  1,  1 ),
        new MoonCoefficient1( 2, 1,  0,  -1  ),
        new MoonCoefficient1( 2, -1, -1, 1 ),
        new MoonCoefficient1( 2, -1, 0,  1  ),
        new MoonCoefficient1( 2, -1, -1, -1  ),
        new MoonCoefficient1( 0, 1,  -1, -1 ),
        new MoonCoefficient1( 4, 0,  -1, -1  ) ,
        new MoonCoefficient1( 0, 1,  0,  1  ),
        new MoonCoefficient1( 0, 0,  0,  3 ),
        new MoonCoefficient1( 0, 1,  -1, 1  ),
        new MoonCoefficient1( 1, 0,  0,  1 ),
        new MoonCoefficient1( 0, 1,  1,  1 ),
        new MoonCoefficient1( 0, 1,  1,  -1  ),
        new MoonCoefficient1( 0, 1,  0,  -1  ),
        new MoonCoefficient1( 1, 0,  0,  -1  ),
        new MoonCoefficient1( 0, 0,  3,  1  ),
        new MoonCoefficient1( 4, 0,  0,  -1  ),
        new MoonCoefficient1( 4, 0,  -1, 1 ),
        new MoonCoefficient1( 0, 0,  1,  -3 ),
        new MoonCoefficient1( 4, 0,  -2, 1  ),
        new MoonCoefficient1( 2, 0,  0,  -3 ),
        new MoonCoefficient1( 2, 0,  2,  -1 ),
        new MoonCoefficient1( 2, -1, 1,  -1 ),
        new MoonCoefficient1( 2, 0,  -2, 1  ),
        new MoonCoefficient1( 0, 0,  3,  -1 ),
        new MoonCoefficient1( 2, 0,  2,  1  ),
        new MoonCoefficient1( 2, 0,  -3, -1 ),
        new MoonCoefficient1( 2, 1,  -1, 1  ),
        new MoonCoefficient1( 2, 1,  0,  1  ),
        new MoonCoefficient1( 4, 0,  0,  1  ),
        new MoonCoefficient1( 2, -1, 1,  1  ),
        new MoonCoefficient1( 2, -2, 0,  -1 ),
        new MoonCoefficient1( 0, 0,  1,  3  ),
        new MoonCoefficient1( 2, 1,  1,  -1 ),
        new MoonCoefficient1( 1, 1,  0,  -1 ),
        new MoonCoefficient1( 1, 1,  0,  1  ),
        new MoonCoefficient1( 0, 1,  -2, -1 ),
        new MoonCoefficient1( 2, 1,  -1, -1 ),
        new MoonCoefficient1( 1, 0,  1,  1  ),
        new MoonCoefficient1( 2, -1, -2, -1 ),
        new MoonCoefficient1( 0, 1,  2,  1  ),
        new MoonCoefficient1( 4, 0,  -2, -1 ),
        new MoonCoefficient1( 4, -1, -1, -1 ),
        new MoonCoefficient1( 1, 0,  1,  -1 ),
        new MoonCoefficient1( 4, 0,  1,  -1 ),
        new MoonCoefficient1( 1, 0,  -1, -1 ),
        new MoonCoefficient1( 4, -1, 0,  -1 ),
        new MoonCoefficient1( 2, -2, 0,  1  ) };

        static readonly double[] g_MoonCoefficients4 =
        {
        5128122,
        280602,
        277693,
        173237,
        55413,
        46271,
        32573,
        17198,
        9266,
        8822,
        8216,
        4324,
        4200,
        -3359,
        2463,
        2211,
        2065,
        -1870,
        1828,
        -1794,
        -1749,
        -1565,
        -1491,
        -1475,
        -1410,
        -1344,
        -1335,
        1107,
        1021,
        833,
        777,
        671,
        607,
        596,
        491,
        -451,
        439,
        422,
        421,
        -366,
        -351,
        331,
        315,
        302,
        -283,
        -229,
        223,
        223,
        -220,
        -220,
        -185,
        181,
        -177,
        176,
        166,
        -164,
        132,
        -119,
        115,
        107 };

        public static double MeanLongitude(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(218.3164477 + 481267.88123421 * T - 0.0015786 * Tsquared + Tcubed / 538841 - T4 / 65194000);
        }

        public static double MeanElongation(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(297.8501921 + 445267.1114034 * T - 0.0018819 * Tsquared + Tcubed / 545868 - T4 / 113065000);
        }

        public static double MeanAnomaly(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(134.9633964 + 477198.8675055 * T + 0.0087414 * Tsquared + Tcubed / 69699 - T4 / 14712000);
        }

        public static double ArgumentOfLatitude(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(93.2720950 + 483202.0175233 * T - 0.0036539 * Tsquared - Tcubed / 3526000 + T4 / 863310000);
        }

        public static double EclipticLongitude(double JD)
        {
            double Ldash = MeanLongitude(JD);
            double LdashDegrees = Ldash;
            Ldash = AASCoordinateTransformation.DegreesToRadians(Ldash);
            double D = MeanElongation(JD);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASEarth.SunMeanAnomaly(JD);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = MeanAnomaly(JD);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double F = ArgumentOfLatitude(JD);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            double E = AASEarth.Eccentricity(JD);
            double Esquared = E * E;
            double T = (JD - 2451545) / 36525;

            double A1 = AASCoordinateTransformation.MapTo0To360Range(119.75 + 131.849 * T);
            A1 = AASCoordinateTransformation.DegreesToRadians(A1);
            double A2 = AASCoordinateTransformation.MapTo0To360Range(53.09 + 479264.290 * T);
            A2 = AASCoordinateTransformation.DegreesToRadians(A2);

            int nLCoefficients = g_MoonCoefficients1.Length;
            double SigmaL = 0;
            for (int i = 0; i < nLCoefficients; i++)
            {
                double ThisSigma = g_MoonCoefficients2[i].A * Math.Sin(g_MoonCoefficients1[i].D * D + g_MoonCoefficients1[i].M * M + g_MoonCoefficients1[i].Mdash * Mdash + g_MoonCoefficients1[i].F * F);

                if ((g_MoonCoefficients1[i].M == 1) || (g_MoonCoefficients1[i].M == -1))
                    ThisSigma *= E;
                else
                    if ((g_MoonCoefficients1[i].M == 2) || (g_MoonCoefficients1[i].M == -2))
                        ThisSigma *= Esquared;

                SigmaL += ThisSigma;
            }

            //Finally the additive terms
            SigmaL += 3958 * Math.Sin(A1);
            SigmaL += 1962 * Math.Sin(Ldash - F);
            SigmaL += 318 * Math.Sin(A2);

            //And finally apply the nutation in longitude
            double NutationInLong = AASNutation.NutationInLongitude(JD);

            return AASCoordinateTransformation.MapTo0To360Range(LdashDegrees + SigmaL / 1000000 + NutationInLong / 3600);
        }

        public static double RadiusVector(double JD)
        {
            double D = MeanElongation(JD);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASEarth.SunMeanAnomaly(JD);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = MeanAnomaly(JD);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double F = ArgumentOfLatitude(JD);
            F = AASCoordinateTransformation.DegreesToRadians(F);
            double E = AASEarth.Eccentricity(JD);

            int nRCoefficients = g_MoonCoefficients1.Length;
            double SigmaR = 0;
            for (int i = 0; i < nRCoefficients; i++)
            {
                double ThisSigma = g_MoonCoefficients2[i].B * Math.Cos(g_MoonCoefficients1[i].D * D + g_MoonCoefficients1[i].M * M + g_MoonCoefficients1[i].Mdash * Mdash + g_MoonCoefficients1[i].F * F);
                if (g_MoonCoefficients1[i].M == 1)
                    // in the C++, this was "if (g_MoonCoefficients1[i].M)", because 0 and 1 are used to represent false and true in C++
                    ThisSigma *= E;

                SigmaR += ThisSigma;
            }

            return 385000.56 + SigmaR / 1000;
        }

        public static double EclipticLatitude(double JD)
        {
            double Ldash = MeanLongitude(JD);
            Ldash = AASCoordinateTransformation.DegreesToRadians(Ldash);
            double D = MeanElongation(JD);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASEarth.SunMeanAnomaly(JD);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = MeanAnomaly(JD);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double F = ArgumentOfLatitude(JD);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            double E = AASEarth.Eccentricity(JD);
            double T = (JD - 2451545) / 36525;

            double A1 = AASCoordinateTransformation.MapTo0To360Range(119.75 + 131.849 * T);
            A1 = AASCoordinateTransformation.DegreesToRadians(A1);
            double A3 = AASCoordinateTransformation.MapTo0To360Range(313.45 + 481266.484 * T);
            A3 = AASCoordinateTransformation.DegreesToRadians(A3);

            int nBCoefficients = g_MoonCoefficients3.Length;
            double SigmaB = 0;
            for (int i = 0; i < nBCoefficients; i++)
            {
                double ThisSigma = g_MoonCoefficients4[i] * Math.Sin(g_MoonCoefficients3[i].D * D + g_MoonCoefficients3[i].M * M + g_MoonCoefficients3[i].Mdash * Mdash + g_MoonCoefficients3[i].F * F);

                if (g_MoonCoefficients3[i].M == 1)
                    ThisSigma *= E;

                SigmaB += ThisSigma;
            }

            //Finally the additive terms
            SigmaB -= 2235 * Math.Sin(Ldash);
            SigmaB += 382 * Math.Sin(A3);
            SigmaB += 175 * Math.Sin(A1 - F);
            SigmaB += 175 * Math.Sin(A1 + F);
            SigmaB += 127 * Math.Sin(Ldash - Mdash);
            SigmaB -= 115 * Math.Sin(Ldash + Mdash);

            return SigmaB / 1000000;
        }

        public static double RadiusVectorToHorizontalParallax(double RadiusVector)
        {
            return AASCoordinateTransformation.RadiansToDegrees(Math.Asin(6378.14 / RadiusVector));
        }

        public static double HorizontalParallaxToRadiusVector(double Parallax)
        {
            return 6378.14 / Math.Sin(AASCoordinateTransformation.DegreesToRadians(Parallax));
        }

        public static double MeanLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(125.0445479 - 1934.1362891 * T + 0.0020754 * Tsquared + Tcubed / 467441 - T4 / 60616000);
        }

        public static double MeanLongitudePerigee(double JD)
        {
            double T = (JD - 2451545) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
            double T4 = Tcubed * T;
            return AASCoordinateTransformation.MapTo0To360Range(83.3532465 + 4069.0137287 * T - 0.0103200 * Tsquared - Tcubed / 80053 + T4 / 18999000);
        }

        public static double TrueLongitudeAscendingNode(double JD)
        {
            double TrueAscendingNode = MeanLongitudeAscendingNode(JD);

            double D = MeanElongation(JD);
            D = AASCoordinateTransformation.DegreesToRadians(D);
            double M = AASEarth.SunMeanAnomaly(JD);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            double Mdash = MeanAnomaly(JD);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            double F = ArgumentOfLatitude(JD);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            //Add the principal additive terms
            TrueAscendingNode -= 1.4979 * Math.Sin(2 * (D - F));
            TrueAscendingNode -= 0.1500 * Math.Sin(M);
            TrueAscendingNode -= 0.1226 * Math.Sin(2 * D);
            TrueAscendingNode += 0.1176 * Math.Sin(2 * F);
            TrueAscendingNode -= 0.0801 * Math.Sin(2 * (Mdash - F));

            return AASCoordinateTransformation.MapTo0To360Range(TrueAscendingNode);
        }
    }
}
