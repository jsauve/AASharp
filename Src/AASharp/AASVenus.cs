using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASVenus
    {
        static readonly VSOP87Coefficient[] g_L0VenusCoefficients =
        {
        new VSOP87Coefficient( 317614667, 0,         0 ),
        new VSOP87Coefficient( 1353968,   5.5931332, 10213.2855462 ),
        new VSOP87Coefficient( 89892,     5.30650,   20426.57109 ),
        new VSOP87Coefficient( 5477,      4.4163,    7860.4194 ),
        new VSOP87Coefficient( 3456,      2.6996,    11790.6291 ),
        new VSOP87Coefficient( 2372,      2.9938,    3930.2097 ),
        new VSOP87Coefficient( 1664,      4.2502,    1577.3435 ),
        new VSOP87Coefficient( 1438,      4.1575,    9683.5946 ),
        new VSOP87Coefficient( 1317,      5.1867,    26.2983 ),
        new VSOP87Coefficient( 1201,      6.1536,    30639.8566 ),
        new VSOP87Coefficient( 769,       0.816,     9437.763 ),
        new VSOP87Coefficient( 761,       1.950,     529.691 ),
        new VSOP87Coefficient( 708,       1.065,     775.523 ),
        new VSOP87Coefficient( 585,       3.998,     191.448 ),
        new VSOP87Coefficient( 500,       4.123,     15720.839 ),
        new VSOP87Coefficient( 429,       3.586,     19367.189 ),
        new VSOP87Coefficient( 327,       5.677,     5507.553 ),
        new VSOP87Coefficient( 326,       4.591,     10404.734 ),
        new VSOP87Coefficient( 232,       3.163,     9153.904 ),
        new VSOP87Coefficient( 180,       4.653,     1109.379 ),
        new VSOP87Coefficient( 155,       5.570,     19651.048 ),
        new VSOP87Coefficient( 128,       4.226,     20.775 ),
        new VSOP87Coefficient( 128,       0.962,     5661.332 ),
        new VSOP87Coefficient( 106,       1.537,     801.821 )
        };

        static readonly VSOP87Coefficient[] g_L1VenusCoefficients =
        {
        new VSOP87Coefficient( 1021352943053.0, 0,       0 ),
        new VSOP87Coefficient( 95708,           2.46424, 10213.28555 ),
        new VSOP87Coefficient( 14445,           0.51625, 20426.57109 ),
        new VSOP87Coefficient( 213,             1.795,   30639.857 ),
        new VSOP87Coefficient( 174,             2.655,   26.298 ),
        new VSOP87Coefficient( 152,             6.106,   1577.344 ),
        new VSOP87Coefficient( 82,              5.70,    191.45 ),
        new VSOP87Coefficient( 70,              2.68,    9437.76 ),
        new VSOP87Coefficient( 52,              3.60,    775.52 ),
        new VSOP87Coefficient( 38,              1.03,    529.69 ),
        new VSOP87Coefficient( 30,              1.25,    5507.55 ),
        new VSOP87Coefficient( 25,              6.11,    10404.73 )
        };

        static readonly VSOP87Coefficient[] g_L2VenusCoefficients =
        {
        new VSOP87Coefficient( 54127, 0,      0 ),
        new VSOP87Coefficient( 3891,  0.3451, 10213.2855 ),
        new VSOP87Coefficient( 1338,  2.0201, 20426.5711 ),
        new VSOP87Coefficient( 24,    2.05,   26.30 ),
        new VSOP87Coefficient( 19,    3.54,   30639.86 ),
        new VSOP87Coefficient( 10,    3.97,   775.52 ),
        new VSOP87Coefficient( 7,     1.52,   1577.34 ),
        new VSOP87Coefficient( 6,     1.00,   191.45 )
        };

        static readonly VSOP87Coefficient[] g_L3VenusCoefficients =
        {
        new VSOP87Coefficient( 136, 4.804, 10213.286 ),
        new VSOP87Coefficient( 78,  3.67,  20426.57),
        new VSOP87Coefficient( 26,  0,     0 )
        };

        static readonly VSOP87Coefficient[] g_L4VenusCoefficients =
        {
        new VSOP87Coefficient( 114, 3.1416, 0 ),
        new VSOP87Coefficient( 3,   5.21,   20426.57 ),
        new VSOP87Coefficient( 2,   2.51,   10213.29 )
        };

        static readonly VSOP87Coefficient[] g_L5VenusCoefficients =
        {
        new VSOP87Coefficient( 1, 3.14, 0 ) };


        static readonly VSOP87Coefficient[] g_B0VenusCoefficients =
        {
        new VSOP87Coefficient( 5923638, 0.2670278, 10213.2855462 ),
        new VSOP87Coefficient( 40108,   1.14737,   20426.57109 ),
        new VSOP87Coefficient( 32815,   3.14737,   0 ),
        new VSOP87Coefficient( 1011,    1.0895,    30639.8566 ),
        new VSOP87Coefficient( 149,     6.254,     18073.705 ),
        new VSOP87Coefficient( 138,     0.860,     1577.344 ),
        new VSOP87Coefficient( 130,     3.672,     9437.763 ),
        new VSOP87Coefficient( 120,     3.705,     2352.866 ),
        new VSOP87Coefficient( 108,     4.539,     22003.915 )
        };

        static readonly VSOP87Coefficient[] g_B1VenusCoefficients =
        {
        new VSOP87Coefficient( 513348, 1.803643, 10213.285546 ),
        new VSOP87Coefficient( 4380,   3.3862,   20426.5711 ),
        new VSOP87Coefficient( 199,    0,        0 ),
        new VSOP87Coefficient( 197,    2.530,    30639.857 )
        };

        static readonly VSOP87Coefficient[] g_B2VenusCoefficients =
        {
        new VSOP87Coefficient( 22378, 3.38509, 10213.28555 ),
        new VSOP87Coefficient( 282,   0,       0 ),
        new VSOP87Coefficient( 173,   5.256,   20426.571 ),
        new VSOP87Coefficient( 27,    3.87,    30639.86 )
        };

        static readonly VSOP87Coefficient[] g_B3VenusCoefficients =
        {
        new VSOP87Coefficient( 647, 4.992, 10213.286 ),
        new VSOP87Coefficient( 20,  3.14,  0 ),
        new VSOP87Coefficient( 6,   0.77,  20426.57 ),
        new VSOP87Coefficient( 3,   5.44,  30639.86 )
        };

        static readonly VSOP87Coefficient[] g_B4VenusCoefficients =
        {
        new VSOP87Coefficient( 14, 0.32, 10213.29 )
        };


        static readonly VSOP87Coefficient[] g_R0VenusCoefficients =
        {
        new VSOP87Coefficient( 72334821, 0,        0 ),
        new VSOP87Coefficient( 489824,   4.021518, 10213.285546 ),
        new VSOP87Coefficient( 1658,     4.9021,   20426.5711 ),
        new VSOP87Coefficient( 1632,     2.8455,   7860.4194 ),
        new VSOP87Coefficient( 1378,     1.1285,   11790.6291 ),
        new VSOP87Coefficient( 498,      2.587,    9683.595 ),
        new VSOP87Coefficient( 374,      1.423,    3930.210 ),
        new VSOP87Coefficient( 264,      5.529,    9437.763 ),
        new VSOP87Coefficient( 237,      2.551,    15720.839 ),
        new VSOP87Coefficient( 222,      2.013,    19367.189 ),
        new VSOP87Coefficient( 126,      2.728,    1577.344 ),
        new VSOP87Coefficient( 119,      3.020,    10404.734 )
        };

        static readonly VSOP87Coefficient[] g_R1VenusCoefficients =
        {
        new VSOP87Coefficient( 34551, 0.89199, 10213.28555 ),
        new VSOP87Coefficient( 234,   1.772,   20426.571 ),
        new VSOP87Coefficient( 234,   3.142,   0 )
        };

        static readonly VSOP87Coefficient[] g_R2VenusCoefficients =
        {
        new VSOP87Coefficient( 1407, 5.0637, 10213.2855 ),
        new VSOP87Coefficient( 16,   5.47,   20426.57 ),
        new VSOP87Coefficient( 13,   0,      0 )
        };

        static readonly VSOP87Coefficient[] g_R3VenusCoefficients =
        {
        new VSOP87Coefficient( 50, 3.22, 10213.29 )
        };

        static readonly VSOP87Coefficient[] g_R4VenusCoefficients =
        {
        new VSOP87Coefficient( 1, 0.92, 10213.29 )
        };

        public static double EclipticLongitude(double JD)
        {
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;
            double rho5 = rho4 * rho;

            //Calculate L0
            int nL0Coefficients = g_L0VenusCoefficients.Length;
            double L0 = 0;
            int i;
            for (i = 0; i < nL0Coefficients; i++)
                L0 += g_L0VenusCoefficients[i].A * Math.Cos(g_L0VenusCoefficients[i].B + g_L0VenusCoefficients[i].C * rho);

            //Calculate L1
            int nL1Coefficients = g_L1VenusCoefficients.Length;
            double L1 = 0;
            for (i = 0; i < nL1Coefficients; i++)
                L1 += g_L1VenusCoefficients[i].A * Math.Cos(g_L1VenusCoefficients[i].B + g_L1VenusCoefficients[i].C * rho);

            //Calculate L2
            int nL2Coefficients = g_L2VenusCoefficients.Length;
            double L2 = 0;
            for (i = 0; i < nL2Coefficients; i++)
                L2 += g_L2VenusCoefficients[i].A * Math.Cos(g_L2VenusCoefficients[i].B + g_L2VenusCoefficients[i].C * rho);

            //Calculate L3
            int nL3Coefficients = g_L3VenusCoefficients.Length;
            double L3 = 0;
            for (i = 0; i < nL3Coefficients; i++)
                L3 += g_L3VenusCoefficients[i].A * Math.Cos(g_L3VenusCoefficients[i].B + g_L3VenusCoefficients[i].C * rho);

            //Calculate L4
            int nL4Coefficients = g_L4VenusCoefficients.Length;
            double L4 = 0;
            for (i = 0; i < nL4Coefficients; i++)
                L4 += g_L4VenusCoefficients[i].A * Math.Cos(g_L4VenusCoefficients[i].B + g_L4VenusCoefficients[i].C * rho);

            //Calculate L5
            int nL5Coefficients = g_L5VenusCoefficients.Length;
            double L5 = 0;
            for (i = 0; i < nL5Coefficients; i++)
                L5 += g_L5VenusCoefficients[i].A * Math.Cos(g_L5VenusCoefficients[i].B + g_L5VenusCoefficients[i].C * rho);

            double value = (L0 + L1 * rho + L2 * rhosquared + L3 * rhocubed + L4 * rho4 + L5 * rho5) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(value));
            return value;
        }

        public static double EclipticLatitude(double JD)
        {
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;

            //Calculate B0
            int nB0Coefficients = g_B0VenusCoefficients.Length;
            double B0 = 0;
            int i;
            for (i = 0; i < nB0Coefficients; i++)
                B0 += g_B0VenusCoefficients[i].A * Math.Cos(g_B0VenusCoefficients[i].B + g_B0VenusCoefficients[i].C * rho);

            //Calculate B1
            int nB1Coefficients = g_B1VenusCoefficients.Length;
            double B1 = 0;
            for (i = 0; i < nB1Coefficients; i++)
                B1 += g_B1VenusCoefficients[i].A * Math.Cos(g_B1VenusCoefficients[i].B + g_B1VenusCoefficients[i].C * rho);

            //Calculate B2
            int nB2Coefficients = g_B2VenusCoefficients.Length;
            double B2 = 0;
            for (i = 0; i < nB2Coefficients; i++)
                B2 += g_B2VenusCoefficients[i].A * Math.Cos(g_B2VenusCoefficients[i].B + g_B2VenusCoefficients[i].C * rho);

            //Calculate B3
            int nB3Coefficients = g_B3VenusCoefficients.Length;
            double B3 = 0;
            for (i = 0; i < nB3Coefficients; i++)
                B3 += g_B3VenusCoefficients[i].A * Math.Cos(g_B3VenusCoefficients[i].B + g_B3VenusCoefficients[i].C * rho);

            //Calculate B4
            int nB4Coefficients = g_B4VenusCoefficients.Length;
            double B4 = 0;
            for (i = 0; i < nB4Coefficients; i++)
                B4 += g_B4VenusCoefficients[i].A * Math.Cos(g_B4VenusCoefficients[i].B + g_B4VenusCoefficients[i].C * rho);

            double value = (B0 + B1 * rho + B2 * rhosquared + B3 * rhocubed + B4 * rho4) / 100000000;

            //convert results back to degrees
            value = AASCoordinateTransformation.RadiansToDegrees(value);
            return value;
        }

        public static double RadiusVector(double JD)
        {
            double rho = (JD - 2451545) / 365250;
            double rhosquared = rho * rho;
            double rhocubed = rhosquared * rho;
            double rho4 = rhocubed * rho;

            //Calculate R0
            int nR0Coefficients = g_R0VenusCoefficients.Length;
            double R0 = 0;
            int i;
            for (i = 0; i < nR0Coefficients; i++)
                R0 += g_R0VenusCoefficients[i].A * Math.Cos(g_R0VenusCoefficients[i].B + g_R0VenusCoefficients[i].C * rho);

            //Calculate R1
            int nR1Coefficients = g_R1VenusCoefficients.Length;
            double R1 = 0;
            for (i = 0; i < nR1Coefficients; i++)
                R1 += g_R1VenusCoefficients[i].A * Math.Cos(g_R1VenusCoefficients[i].B + g_R1VenusCoefficients[i].C * rho);

            //Calculate R2
            int nR2Coefficients = g_R2VenusCoefficients.Length;
            double R2 = 0;
            for (i = 0; i < nR2Coefficients; i++)
                R2 += g_R2VenusCoefficients[i].A * Math.Cos(g_R2VenusCoefficients[i].B + g_R2VenusCoefficients[i].C * rho);

            //Calculate R3
            int nR3Coefficients = g_R3VenusCoefficients.Length;
            double R3 = 0;
            for (i = 0; i < nR3Coefficients; i++)
                R3 += g_R3VenusCoefficients[i].A * Math.Cos(g_R3VenusCoefficients[i].B + g_R3VenusCoefficients[i].C * rho);

            //Calculate R4
            int nR4Coefficients = g_R4VenusCoefficients.Length;
            double R4 = 0;
            for (i = 0; i < nR4Coefficients; i++)
                R4 += g_R4VenusCoefficients[i].A * Math.Cos(g_R4VenusCoefficients[i].B + g_R4VenusCoefficients[i].C * rho);

            return (R0 + R1 * rho + R2 * rhosquared + R3 * rhocubed + R4 * rho4) / 100000000;
        }
    }
}
