namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASRiseTransitSet.Calculate method.
    /// </summary>
    public class AASRiseTransitSetDetails
    {
        /// <summary>
        /// true if the object actually rises for the specified date.
        /// </summary>
        public bool bRiseValid { get; set; }
        /// <summary>
        /// The time in decimal hours when the object rises
        /// </summary>
        public double Rise { get; set; }
        /// <summary>
        /// true if the object transits for the specified date.
        /// </summary>
        public bool bTransitValid { get; set; }
        /// <summary>
        /// true if the object transits above the horizon, false indicates it transits below the horizon.
        /// </summary>
        public bool bTransitAboveHorizon { get; set; }
        /// <summary>
        /// The time in hours when the object transits
        /// </summary>
        public double Transit { get; set; }
        /// <summary>
        /// true if the object actually sets for the specified date.
        /// </summary>
        public bool bSetValid { get; set; }
        /// <summary>
        /// The time in hours when the object sets
        /// </summary>
        public double Set { get; set; }
    }
}