using System;

namespace AASharp
{
    /// <summary>
    /// This class provides algorithms to calculate the times when the Moon reaches its maximum Northerly and Southerly declinations. This refers to Chapter 52 in the book.
    /// </summary>
    public class AASMoonMaxDeclinations
    {
        /// <summary>
        /// Please note that the return value from this method must be rounded to an integer by client code before calling other methods in this class with this K value. Any other value of K will give meaningless values.
        /// </summary>
        /// <param name="Year">The Year including decimals to calculate the K value for.</param>
        /// <returns>Returns the approximate value of K (required by the other methods of CAAMoonMaxDeclinations) for calculation of the Moon's max declination.</returns>
        public static double K(double Year)
        {
            return 13.3686 * (Year - 2000.03);
        }

        /// <param name="k">The K value to calculate the max declination for. This K value must be an integer value. Any other value of K will give meaningless values.</param>
        /// <param name="bNortherly">true if this is a calculation for a maximum northerly declination, false implies a calculation of the a maximum southerly declination.</param>
        /// <returns>Returns the date in Dynamical time when the mean maximum declination occurs.</returns>
        public static double MeanGreatestDeclination(double k, bool bNortherly)
        {
            //convert from K to T
            double T = k / 1336.86;
            double T2 = T * T;
            double T3 = T2 * T;

            double value = bNortherly ? 2451562.5897 : 2451548.9289;
            return value + 27.321582247 * k + 0.000119804 * T2 - 0.000000141 * T3;
        }

        /// <param name="k">The K value to calculate the max declination for. This K value must be an integer value. Any other value of K will give meaningless values.</param>
        /// <returns>Returns the mean maximum declination in degrees.</returns>
        public static double MeanGreatestDeclinationValue(double k)
        {
            //convert from K to T
            double T = k / 1336.86;
            return 23.6961 - 0.013004 * T;
        }

        /// <param name="k">The K value to calculate the max declination for. This K value must be an integer value. Any other value of K will give meaningless values.</param>
        /// <param name="bNortherly">true if this is a calculation for a maximum northerly declination, false implies a calculation of the a maximum southerly declination.</param>
        /// <returns>Returns the date in Dynamical time when the true maximum declination occurs.</returns>
        public static double TrueGreatestDeclination(double k, bool bNortherly)
        {
            //convert from K to T
            double T = k / 1336.86;
            double T2 = T * T;
            double T3 = T2 * T;

            double D = bNortherly ? 152.2029 : 345.6676;
            D = AASCoordinateTransformation.MapTo0To360Range(D + 333.0705546 * k - 0.0004214 * T2 + 0.00000011 * T3);
            double M = bNortherly ? 14.8591 : 1.3951;
            M = AASCoordinateTransformation.MapTo0To360Range(M + 26.9281592 * k - 0.0000355 * T2 - 0.00000010 * T3);
            double Mdash = bNortherly ? 4.6881 : 186.2100;
            Mdash = AASCoordinateTransformation.MapTo0To360Range(Mdash + 356.9562794 * k + 0.0103066 * T2 + 0.00001251 * T3);
            double F = bNortherly ? 325.8867 : 145.1633;
            F = AASCoordinateTransformation.MapTo0To360Range(F + 1.4467807 * k - 0.0020690 * T2 - 0.00000215 * T3);
            double E = 1 - 0.002516 * T - 0.0000074 * T2;

            //convert to radians
            D = AASCoordinateTransformation.DegreesToRadians(D);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            F = AASCoordinateTransformation.DegreesToRadians(F);


            double DeltaJD;
            if (bNortherly)
            {
                DeltaJD = 0.8975 * Math.Cos(F) +
                -0.4726 * Math.Sin(Mdash) +
                -0.1030 * Math.Sin(2 * F) +
                -0.0976 * Math.Sin(2 * D - Mdash) +
                -0.0462 * Math.Cos(Mdash - F) +
                -0.0461 * Math.Cos(Mdash + F) +
                -0.0438 * Math.Sin(2 * D) +
                0.0162 * E * Math.Sin(M) +
                -0.0157 * Math.Cos(3 * F) +
                0.0145 * Math.Sin(Mdash + 2 * F) +
                0.0136 * Math.Cos(2 * D - F) +
                -0.0095 * Math.Cos(2 * D - Mdash - F) +
                -0.0091 * Math.Cos(2 * D - Mdash + F) +
                -0.0089 * Math.Cos(2 * D + F) +
                0.0075 * Math.Sin(2 * Mdash) +
                -0.0068 * Math.Sin(Mdash - 2 * F) +
                0.0061 * Math.Cos(2 * Mdash - F) +
                -0.0047 * Math.Sin(Mdash + 3 * F) +
                -0.0043 * E * Math.Sin(2 * D - M - Mdash) +
                -0.0040 * Math.Cos(Mdash - 2 * F) +
                -0.0037 * Math.Sin(2 * D - 2 * Mdash) +
                0.0031 * Math.Sin(F) +
                0.0030 * Math.Sin(2 * D + Mdash) +
                -0.0029 * Math.Cos(Mdash + 2 * F) +
                -0.0029 * E * Math.Sin(2 * D - M) +
                -0.0027 * Math.Sin(Mdash + F) +
                0.0024 * E * Math.Sin(M - Mdash) +
                -0.0021 * Math.Sin(Mdash - 3 * F) +
                0.0019 * Math.Sin(2 * Mdash + F) +
                0.0018 * Math.Cos(2 * D - 2 * Mdash - F) +
                0.0018 * Math.Sin(3 * F) +
                0.0017 * Math.Cos(Mdash + 3 * F) +
                0.0017 * Math.Cos(2 * Mdash) +
                -0.0014 * Math.Cos(2 * D - Mdash) +
                0.0013 * Math.Cos(2 * D + Mdash + F) +
                0.0013 * Math.Cos(Mdash) +
                0.0012 * Math.Sin(3 * Mdash + F) +
                0.0011 * Math.Sin(2 * D - Mdash + F) +
                -0.0011 * Math.Cos(2 * D - 2 * Mdash) +
                0.0010 * Math.Cos(D + F) +
                0.0010 * E * Math.Sin(M + Mdash) +
                -0.0009 * Math.Sin(2 * D - 2 * F) +
                0.0007 * Math.Cos(2 * Mdash + F) +
                -0.0007 * Math.Cos(3 * Mdash + F);
            }
            else
            {
                DeltaJD = -0.8975 * Math.Cos(F) +
                -0.4726 * Math.Sin(Mdash) +
                -0.1030 * Math.Sin(2 * F) +
                -0.0976 * Math.Sin(2 * D - Mdash) +
                0.0541 * Math.Cos(Mdash - F) +
                0.0516 * Math.Cos(Mdash + F) +
                -0.0438 * Math.Sin(2 * D) +
                0.0112 * E * Math.Sin(M) +
                0.0157 * Math.Cos(3 * F) +
                0.0023 * Math.Sin(Mdash + 2 * F) +
                -0.0136 * Math.Cos(2 * D - F) +
                0.0110 * Math.Cos(2 * D - Mdash - F) +
                0.0091 * Math.Cos(2 * D - Mdash + F) +
                0.0089 * Math.Cos(2 * D + F) +
                0.0075 * Math.Sin(2 * Mdash) +
                -0.0030 * Math.Sin(Mdash - 2 * F) +
                -0.0061 * Math.Cos(2 * Mdash - F) +
                -0.0047 * Math.Sin(Mdash + 3 * F) +
                -0.0043 * E * Math.Sin(2 * D - M - Mdash) +
                0.0040 * Math.Cos(Mdash - 2 * F) +
                -0.0037 * Math.Sin(2 * D - 2 * Mdash) +
                -0.0031 * Math.Sin(F) +
                0.0030 * Math.Sin(2 * D + Mdash) +
                0.0029 * Math.Cos(Mdash + 2 * F) +
                -0.0029 * E * Math.Sin(2 * D - M) +
                -0.0027 * Math.Sin(Mdash + F) +
                0.0024 * E * Math.Sin(M - Mdash) +
                -0.0021 * Math.Sin(Mdash - 3 * F) +
                -0.0019 * Math.Sin(2 * Mdash + F) +
                -0.0006 * Math.Cos(2 * D - 2 * Mdash - F) +
                -0.0018 * Math.Sin(3 * F) +
                -0.0017 * Math.Cos(Mdash + 3 * F) +
                0.0017 * Math.Cos(2 * Mdash) +
                0.0014 * Math.Cos(2 * D - Mdash) +
                -0.0013 * Math.Cos(2 * D + Mdash + F) +
                -0.0013 * Math.Cos(Mdash) +
                0.0012 * Math.Sin(3 * Mdash + F) +
                0.0011 * Math.Sin(2 * D - Mdash + F) +
                0.0011 * Math.Cos(2 * D - 2 * Mdash) +
                0.0010 * Math.Cos(D + F) +
                0.0010 * E * Math.Sin(M + Mdash) +
                -0.0009 * Math.Sin(2 * D - 2 * F) +
                -0.0007 * Math.Cos(2 * Mdash + F) +
                -0.0007 * Math.Cos(3 * Mdash + F);
            }

            return MeanGreatestDeclination(k, bNortherly) + DeltaJD;
        }

        /// <param name="k">The K value to calculate the max declination for. This K value must be an integer value. Any other value of K will give meaningless values.</param>
        /// <param name="bNortherly">true if this is a calculation for a maximum northerly declination, false implies a calculation of the a maximum southerly declination.</param>
        /// <returns>Returns the true maximum declination in degrees.</returns>
        public static double TrueGreatestDeclinationValue(double k, bool bNortherly)
        {
            //convert from K to T
            double T = k / 1336.86;
            double T2 = T * T;
            double T3 = T2 * T;

            double D = bNortherly ? 152.2029 : 345.6676;
            D = AASCoordinateTransformation.MapTo0To360Range(D + 333.0705546 * k - 0.0004214 * T2 + 0.00000011 * T3);
            double M = bNortherly ? 14.8591 : 1.3951;
            M = AASCoordinateTransformation.MapTo0To360Range(M + 26.9281592 * k - 0.0000355 * T2 - 0.00000010 * T3);
            double Mdash = bNortherly ? 4.6881 : 186.2100;
            Mdash = AASCoordinateTransformation.MapTo0To360Range(Mdash + 356.9562794 * k + 0.0103066 * T2 + 0.00001251 * T3);
            double F = bNortherly ? 325.8867 : 145.1633;
            F = AASCoordinateTransformation.MapTo0To360Range(F + 1.4467807 * k - 0.0020690 * T2 - 0.00000215 * T3);
            double E = 1 - 0.002516 * T - 0.0000074 * T2;

            //convert to radians
            D = AASCoordinateTransformation.DegreesToRadians(D);
            M = AASCoordinateTransformation.DegreesToRadians(M);
            Mdash = AASCoordinateTransformation.DegreesToRadians(Mdash);
            F = AASCoordinateTransformation.DegreesToRadians(F);

            double DeltaValue;
            if (bNortherly)
            {
                DeltaValue = 5.1093 * Math.Sin(F) +
                0.2658 * Math.Cos(2 * F) +
                0.1448 * Math.Sin(2 * D - F) +
                -0.0322 * Math.Sin(3 * F) +
                0.0133 * Math.Cos(2 * D - 2 * F) +
                0.0125 * Math.Cos(2 * D) +
                -0.0124 * Math.Sin(Mdash - F) +
                -0.0101 * Math.Sin(Mdash + 2 * F) +
                0.0097 * Math.Cos(F) +
                -0.0087 * E * Math.Sin(2 * D + M - F) +
                0.0074 * Math.Sin(Mdash + 3 * F) +
                0.0067 * Math.Sin(D + F) +
                0.0063 * Math.Sin(Mdash - 2 * F) +
                0.0060 * E * Math.Sin(2 * D - M - F) +
                -0.0057 * Math.Sin(2 * D - Mdash - F) +
                -0.0056 * Math.Cos(Mdash + F) +
                0.0052 * Math.Cos(Mdash + 2 * F) +
                0.0041 * Math.Cos(2 * Mdash + F) +
                -0.0040 * Math.Cos(Mdash - 3 * F) +
                0.0038 * Math.Cos(2 * Mdash - F) +
                -0.0034 * Math.Cos(Mdash - 2 * F) +
                -0.0029 * Math.Sin(2 * Mdash) +
                0.0029 * Math.Sin(3 * Mdash + F) +
                -0.0028 * E * Math.Cos(2 * D + M - F) +
                -0.0028 * Math.Cos(Mdash - F) +
                -0.0023 * Math.Cos(3 * F) +
                -0.0021 * Math.Sin(2 * D + F) +
                0.0019 * Math.Cos(Mdash + 3 * F) +
                0.0018 * Math.Cos(D + F) +
                0.0017 * Math.Sin(2 * Mdash - F) +
                0.0015 * Math.Cos(3 * Mdash + F) +
                0.0014 * Math.Cos(2 * D + 2 * Mdash + F) +
                -0.0012 * Math.Sin(2 * D - 2 * Mdash - F) +
                -0.0012 * Math.Cos(2 * Mdash) +
                -0.0010 * Math.Cos(Mdash) +
                -0.0010 * Math.Sin(2 * F) +
                0.0006 * Math.Sin(Mdash + F);
            }
            else
            {
                DeltaValue = -5.1093 * Math.Sin(F) +
                0.2658 * Math.Cos(2 * F) +
                -0.1448 * Math.Sin(2 * D - F) +
                0.0322 * Math.Sin(3 * F) +
                0.0133 * Math.Cos(2 * D - 2 * F) +
                0.0125 * Math.Cos(2 * D) +
                -0.0015 * Math.Sin(Mdash - F) +
                0.0101 * Math.Sin(Mdash + 2 * F) +
                -0.0097 * Math.Cos(F) +
                0.0087 * E * Math.Sin(2 * D + M - F) +
                0.0074 * Math.Sin(Mdash + 3 * F) +
                0.0067 * Math.Sin(D + F) +
                -0.0063 * Math.Sin(Mdash - 2 * F) +
                -0.0060 * E * Math.Sin(2 * D - M - F) +
                0.0057 * Math.Sin(2 * D - Mdash - F) +
                -0.0056 * Math.Cos(Mdash + F) +
                -0.0052 * Math.Cos(Mdash + 2 * F) +
                -0.0041 * Math.Cos(2 * Mdash + F) +
                -0.0040 * Math.Cos(Mdash - 3 * F) +
                -0.0038 * Math.Cos(2 * Mdash - F) +
                0.0034 * Math.Cos(Mdash - 2 * F) +
                -0.0029 * Math.Sin(2 * Mdash) +
                0.0029 * Math.Sin(3 * Mdash + F) +
                0.0028 * E * Math.Cos(2 * D + M - F) +
                -0.0028 * Math.Cos(Mdash - F) +
                0.0023 * Math.Cos(3 * F) +
                0.0021 * Math.Sin(2 * D + F) +
                0.0019 * Math.Cos(Mdash + 3 * F) +
                0.0018 * Math.Cos(D + F) +
                -0.0017 * Math.Sin(2 * Mdash - F) +
                0.0015 * Math.Cos(3 * Mdash + F) +
                0.0014 * Math.Cos(2 * D + 2 * Mdash + F) +
                0.0012 * Math.Sin(2 * D - 2 * Mdash - F) +
                -0.0012 * Math.Cos(2 * Mdash) +
                0.0010 * Math.Cos(Mdash) +
                -0.0010 * Math.Sin(2 * F) +
                0.0037 * Math.Sin(Mdash + F);
            }

            return MeanGreatestDeclinationValue(k) + DeltaValue;
        }
    }
}
