namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASEaster.Calculate method.
    /// </summary>
    public class AASEasterDetails
    {
        public AASEasterDetails(long month, long day)
        {
            Month = month;
            Day = day;
        }
        /// <summary>
        /// The month on which Easter Sunday occurs.
        /// </summary>
        public long Month { get; }
        /// <summary>
        /// The day of the month on which Easter Sunday occurs.
        /// </summary>
        public long Day { get; }
    }
}