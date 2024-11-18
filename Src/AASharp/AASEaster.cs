namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of the date of Easter in both the Julian and Gregorian calendars. This refers to Chapter 8 in the book.
    /// </summary>
    public static class AASEaster {
        /// <param name="nYear">The year to perform the calculation for.</param>
        /// <param name="GregorianCalendar">true if the calculation is to be performed for the Gregorian calendar, false implies the Julian Calendar</param>
        /// <returns>A class containing
        /// <para>
        /// Month - The month on which Easter Sunday occurs.
        /// </para>
        /// <para>
        /// Day - The day of the month on which Easter Sunday occurs.
        /// </para>
        /// </returns>
        public static AASEasterDetails Calculate(long nYear, bool GregorianCalendar)
        {
            AASEasterDetails details = null;

            if (GregorianCalendar)
            {
                int a = (int)(nYear % 19);
                int b = (int)(nYear / 100);
                int c = (int)(nYear % 100);
                int d = b / 4;
                int e = b % 4;
                int f = (b + 8) / 25;
                int g = (b - f + 1) / 3;
                int h = (19 * a + b - d - g + 15) % 30;
                int i = c / 4;
                int k = c % 4;
                int l = (32 + 2 * e + 2 * i - h - k) % 7;
                int m = (a + 11 * h + 22 * l) / 451;
                int n = (h + l - 7 * m + 114) / 31;
                int p = (h + l - 7 * m + 114) % 31;
                details = new AASEasterDetails(n, p + 1);
            }
            else
            {
                int a = (int)(nYear % 4);
                int b = (int)(nYear % 7);
                int c = (int)(nYear % 19);
                int d = (19 * c + 15) % 30;
                int e = (2 * a + 4 * b - d + 34) % 7;
                int f = (d + e + 114) / 31;
                int g = (d + e + 114) % 31;
                details = new AASEasterDetails(f, g + 1);
            }

            return details;
        }
    }
}
