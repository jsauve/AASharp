namespace AASharp
{
    public class AASMoonPerigeeApogeeDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            Perigee = 1,
            Apogee = 2,
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
        /// The actual distance in KM
        /// </summary>
        public double Value { get; set; } = 0;
    }
}