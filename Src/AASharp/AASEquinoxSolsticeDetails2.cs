namespace AASharp
{
    public class  AASEquinoxSolsticeDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            NorthwardEquinox = 1,
            NorthernSolstice = 2,
            SouthwardEquinox = 3,
            SouthernSolstice = 4,
        };

        /// <summary>
        /// The type of the event which has occurred
        /// </summary>
        public Type type { get; set; } = Type.NotDefined;
        
        /// <summary>
        /// When the event occurred in TT
        /// </summary>
        public double JD { get; set; } = 0; 
     
        /// <summary>
        /// Applicable for solstices only, the apparent declination of the Sun
        /// </summary>
        public double Declination { get; set; } = 0;
    };
}