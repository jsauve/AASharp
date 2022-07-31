namespace AASharp
{
    public class AASEasterDetails
    {
        public AASEasterDetails(long month, long day)
        {
            Month = month;
            Day = day;
        }

        public long Month { get; }
        public long Day { get; }
    }
}