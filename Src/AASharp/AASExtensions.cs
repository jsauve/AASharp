using System;
using System.Diagnostics;

namespace AASharp {
    public static class AASExtensions {
        /// <summary>
        /// Converts System.DateTime to AASDate
        /// </summary>
        /// <param name="date">Date to convert from</param>
        /// <param name="IsGregorian">True if the input date is given in Gregorian calendar, false otherwise (Julian calendar)</param>
        /// <returns>An instance of AASDate class representing the input date</returns>
        public static AASDate ToAASDate(this DateTime date, bool IsGregorian = true) {
            var TotalSeconds = date.Second + date.Millisecond / 1000.0;
            return new AASDate(date.Year, date.Month, date.Day, date.Hour, date.Minute, TotalSeconds, IsGregorian);
        }

        /// <summary>
        /// Converts Julian Day to System.DateTime
        /// </summary>
        /// <param name="JD">Julian Day in Local/UTC timeframe to convert from</param>
        /// <param name="IsGregorian">True if the output date is given in Gregorian calendar, false otherwise (Julian calendar)</param>
        /// <param name="KindOfDate">Whether the output is Local or UTC</param>
        /// <returns>An instance of System.DateTime struct representing the input Julian Day</returns>
        public static DateTime ToDateTime(this double JD, bool IsGregorian = true, DateTimeKind KindOfDate = DateTimeKind.Utc) {
            var jdn = new AASDate(JD, IsGregorian);
            var secs = Math.Truncate(jdn.Second);
            var milis = (jdn.Second - secs) * 1000;
            return new DateTime((int)jdn.Year, (int)jdn.Month, (int)jdn.Day, (int)jdn.Hour, (int)jdn.Minute, (int)secs, (int)milis, KindOfDate);
        }

        /// <summary>
        /// Converts System.DateTime to TT (Terrestrial Dynamical Time) and returns in JDN (Julian Day)
        /// </summary>
        /// <param name="date">Date to convert from</param>
        /// <param name="IsGregorian">True if the input date is given in Gregorian calendar, false otherwise (Julian calendar)</param>
        /// <returns>A new JDN expressed in TT timeframe</returns>
        public static double ToTerrestrialDynamical(this DateTime date, bool IsGregorian = true) {
            Debug.Assert(date.Kind == DateTimeKind.Utc, "Input date/time is expected to be in UTC!");
            var jdn = ToAASDate(date, IsGregorian).Julian;
            return AASDynamicalTime.UTC2TT(jdn);
        }

        /// <summary>
        /// Converts TT (Terrestrial Dynamical Time) to System.DateTime
        /// </summary>
        /// <param name="JD">Julian Day in TT timeframe to convert from</param>
        /// <param name="IsGregorian">True if the output date is given in Gregorian calendar, false otherwise (Julian calendar)</param>
        /// <param name="KindOfDate">Whether the output is Local or UTC</param>
        /// <returns>An instance of System.DateTime struct representing the input Julian Day</returns>
        public static DateTime FromTerrestrialDynamical(this double JD, bool IsGregorian = true, DateTimeKind KindOfDate = DateTimeKind.Utc) {
            var jdn = AASDynamicalTime.TT2UTC(JD);
            return ToDateTime(jdn, IsGregorian, KindOfDate);
        }
    }
}
