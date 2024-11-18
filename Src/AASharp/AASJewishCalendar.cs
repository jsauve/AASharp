namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms which convert between the Gregorian, Julian and Jewish calendars. This refers to Chapter 9 in the book.
    /// </summary>
    public static class AASJewishCalendar
    {
        /// <param name="Year">The year in the Julian or Gregorian Calendar to calculate Jewish Easter or Pesach for. (Years are counted astronomically i.e. 1 BC = Year 0)</param>
        /// <param name="bGregorianCalendar">true to imply a date in the Gregorian Calendar, false means use the Julian Calendar.</param>
        /// <returns>An instance of the AASCalendarDate class with details.</returns>
        public static AASCalendarDate DateOfPesach(long Year, bool bGregorianCalendar = true)
        {
            //What will be the return value
            AASCalendarDate Pesach = new AASCalendarDate();

            long C = AASDate.INT(Year / 100.0);
            long S = AASDate.INT((3 * C - 5) / 4.0);
            if (bGregorianCalendar == false)
                S = 0;
            long A = Year + 3760;
            long a = (12 * Year + 12) % 19;
            long b = Year % 4;
            double Q = -1.904412361576 + 1.554241796621 * a + 0.25 * b - 0.003177794022 * Year + S;
            long INTQ = AASDate.INT(Q);
            long j = (INTQ + 3 * Year + 5 * b + 2 - S) % 7;
            double r = Q - INTQ;

            if ((j == 2) || (j == 4) || (j == 6))
                Pesach.Day = INTQ + 23;
            else if ((j == 1) && (a > 6) && (r >= 0.632870370))
                Pesach.Day = INTQ + 24;
            else if ((j == 0) && (a > 11) && (r >= 0.897723765))
                Pesach.Day = INTQ + 23;
            else
                Pesach.Day = INTQ + 22;

            if (Pesach.Day > 31)
            {
                Pesach.Month = 4;
                Pesach.Day -= 31;
            }
            else
                Pesach.Month = 3;

            Pesach.Year = A;

            return Pesach;
        }

        /// <param name="Year">The year in the Jewish calendar.</param>
        /// <returns>true if the specified year is leap otherwise false.</returns>
        public static bool IsLeap(long Year)
        {
            long ymod19 = Year % 19;

            return (ymod19 == 0) || (ymod19 == 3) || (ymod19 == 6) || (ymod19 == 8) || (ymod19 == 11) || (ymod19 == 14) || (ymod19 == 17);
        }

        /// <param name="Year">The year in the Jewish Calendar.</param>
        /// <returns>The number of days in the specified Jewish Year</returns>
        public static long DaysInYear(long Year)
        {
            //Find the previous civil year corresponding to the specified jewish year
            long CivilYear = Year - 3761;

            //Find the date of the next Jewish Year in that civil year
            AASCalendarDate CurrentPesach = DateOfPesach(CivilYear);
            bool bGregorian = AASDate.AfterPapalReform(CivilYear, CurrentPesach.Month, CurrentPesach.Day);
            AASDate CurrentYear = new AASDate(CivilYear, CurrentPesach.Month, CurrentPesach.Day, bGregorian);
            
            AASCalendarDate NextPesach = DateOfPesach(CivilYear + 1);
            AASDate NextYear = new AASDate(CivilYear + 1, NextPesach.Month, NextPesach.Day, bGregorian);

            return (long)(NextYear.Julian - CurrentYear.Julian);
        }
    }
}
