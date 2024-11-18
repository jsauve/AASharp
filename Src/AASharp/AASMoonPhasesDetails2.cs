namespace AASharp
{
    /// <summary>
    /// Instances of this class are returned by AASMoonPhases2.Calculate method.
    /// </summary>
    public class AASMoonPhasesDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            NewMoon = 1,
            FirstQuarter = 2,
            FullMoon = 3,
            LastQuarter = 4
        }

        /// <summary>
        /// The type of the event which has occurred
        /// </summary>
        public Type type { get; set; } = Type.NotDefined;

        /// <summary>
        /// When the event occurred in TT
        /// </summary>
        public double JD { get; set; }
    }
}