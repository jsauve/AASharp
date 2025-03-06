using System;
using System.Diagnostics;

namespace AASharp {
    /// <summary>
    /// Various useful extension methods.
    /// </summary>
    public static class AASExtensions {
        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Principal phase: DIFF = 0° (or 360°).
        /// Set to any message for the New Moon phase or use the default.
        /// </summary>
        public static string MsgNewMoon = "🌑︎ New Moon";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Intermediate phase: 0° &lt; DIFF &lt; 90°.
        /// Set to any message for the Waxing Crescent phase or use the default.
        /// </summary>
        public static string MsgWaxingCrescent = "🌒 Waxing Crescent";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Principal phase: DIFF = 90°.
        /// Set to any message for the First Quarter phase or use the default.
        /// </summary>
        public static string MsgFirstQuarter = "🌓︎ First Quarter";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Intermediate phase: 90° &lt; DIFF &lt; 180°.
        /// Set to any message for the Waxing Gibbous phase or use the default.
        /// </summary>
        public static string MsgWaxingGibbous = "🌔 Waxing Gibbous";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Principal phase: DIFF = 180°.
        /// Set to any message for the Full Moon phase or use the default.
        /// </summary>
        public static string MsgFullMoon = "🌕︎ Full Moon";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Intermediate phase: 180° &lt; DIFF &lt; 270°.
        /// Set to any message for the Waning Gibbous phase or use the default.
        /// </summary>
        public static string MsgWaningGibbous = "🌖 Waning Gibbous";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Principal phase: DIFF = 270°.
        /// Set to any message for the Last Quarter phase or use the default.
        /// </summary>
        public static string MsgLastQuarter = "🌗 Last Quarter";

        /// <summary>
        /// DIFF = (Moon ecliptic longitude - Sun ecliptic longitude).
        /// Intermediate phase: 270° &lt; DIFF &lt; 360° (or 0°).
        /// Set to any message for the Waning Crescent phase or use the default.
        /// </summary>
        public static string MsgWaningCrescent = "🌘 Waning Crescent";

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

        /// <summary>
        /// Returns the current Lunar phase as a customizable message.
        /// For each principal and intermediate phase the message can be changed to anything by setting the values of static string members of AASExtensions:
        /// MsgNewMoon, MsgWaxingCrescent, MsgFirstQuarter, MsgWaxingGibbous, MsgFullMoon, MsgWaningGibbous, MsgLastQuarter, MsgWaningCrescent.
        /// </summary>
        /// <param name="date">Any UTC date</param>
        /// <param name="IsGregorian">True if the output date is given in Gregorian calendar, false otherwise (Julian calendar)</param>
        /// <returns>The lunar phase name or message at the given date.</returns>
        public static string GetLunarPhaseMessage(this DateTime date, bool IsGregorian = true) {
            Debug.Assert(date.Kind == DateTimeKind.Utc, "Input date/time is expected to be in UTC!");
            var jdtt = ToTerrestrialDynamical(date, IsGregorian);
            var MoonELong = AASMoon.EclipticLongitude(jdtt);
            var SunELong = AASSun.ApparentEclipticLongitude(jdtt, true);
            var angle = AASCoordinateTransformation.MapTo0To360Range(MoonELong - SunELong);
            var msg = "Lunar phase";
            if (angle == 0 || angle == 360)      msg = MsgNewMoon;
            else if (angle > 0 && angle < 90)    msg = MsgWaxingCrescent;
            else if (angle == 90)                msg = MsgFirstQuarter;
            else if (angle > 90 && angle < 180)  msg = MsgWaxingGibbous;
            else if (angle == 180)               msg = MsgFullMoon;
            else if (angle > 180 && angle < 270) msg = MsgWaningGibbous;
            else if (angle == 270)               msg = MsgLastQuarter;
            else if (angle > 270 && angle < 360) msg = MsgWaningCrescent;
            return msg;
        }
    }
}
