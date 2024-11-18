namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASDate.JulianToGregorian and AASDate.GregorianToJulian methods.
    /// </summary>
    public class AASCalendarDate
    {
        /// <summary>
        /// The year in the Gregorian/Julian Calendar. (Years are counted astronomically i.e. 1 BC = Year 0)
        /// </summary>
        public long Year { get; set; }
        /// <summary>
        /// The month of the year in the Gregorian/Julian Calendar (1 for January to 12 for December).
        /// </summary>
        public long Month { get; set; }
        /// <summary>
        /// The day of the month in the Gregorian/Julian Calendar.
        /// </summary>
        public long Day { get; set; }
    }
}
