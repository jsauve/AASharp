namespace AASharp
{
    public class AASRiseTransitSetDetails2
    {
        public enum Type
        {
            NotDefined = 0,
            Rise = 1,
            Set = 2,
            SouthernTransit = 3,
            NorthernTransit = 4,
            EndCivilTwilight = 5,
            EndNauticalTwilight = 6,
            EndAstronomicalTwilight = 7,
            StartAstronomicalTwilight = 8,
            StartNauticalTwilight = 9,
            StartCivilTwilight = 10
        };

        /// <summary>
        /// The type of the event which has occurred
        /// </summary>
        public Type type { get; set; } = Type.NotDefined;

        /// <summary>
        /// When the event occurred in TT
        /// </summary>
        public double JD { get; set; }

        /// <summary>
        /// Applicable for rise or sets only, this will be the bearing (degrees west of south) of the event
        /// </summary>
        public double Bearing { get; set; }

        /// <summary>
        /// For transits only, this will contain the geometric altitude in degrees of the center of the object not including correction for refraction
        /// </summary>
        public double GeometricAltitude { get; set; }

        /// <summary>
        /// For transits only, this will be true if the transit is visible
        /// </summary>
        public bool bAboveHorizon { get; set; }
    }
}