namespace AASharp
{
    /// <summary>
    /// Instances of this class are returned as an array by the AASMoonMaxDeclinations2.Calculate method.
    /// </summary>
    public class AASMoonMaxDeclinationsDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            MaxNorthernDeclination = 1,
            MaxSouthernDeclination = 2,
        }

        /// <summary>
        /// The type of the event which has occurred
        /// </summary>
        public Type type { get; set; } = Type.NotDefined;

        /// <summary>
        /// When the event occurred in TT
        /// </summary>
        public double JD { get; set; }

        /// <summary>
        /// The actual max declination value in degrees
        /// </summary>
        public double Declination { get; set; }

        /// <summary>
        /// The Right ascension at the time of the event
        /// </summary>
        public double RA { get; set; }
    };
}