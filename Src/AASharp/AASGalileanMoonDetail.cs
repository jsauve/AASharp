namespace AASharp
{
    /// <summary>
    /// Instances of this class are held by the AASGalileanMoonsDetails class.
    /// </summary>
    public class AASGalileanMoonDetail
    {
        public AASGalileanMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        /// <summary>
        /// The mean longitude of the moon in degrees.
        /// </summary>
        public double MeanLongitude { get; set; }
        /// <summary>
        /// The true longitude of the moon in degrees.
        /// </summary>
        public double TrueLongitude { get; set; }
        /// <summary>
        /// The tropical longitude of the moon in degrees.
        /// </summary>
        public double TropicalLongitude { get; set; }
        /// <summary>
        /// The latitude in degrees of the moon with respect to Jupiter's equatorial plane.
        /// </summary>
        public double EquatorialLatitude { get; set; }
        /// <summary>
        /// The radius vector of the moon in equatorial radii of Jupiter.
        /// </summary>
        public double r { get; set; }
        /// <summary>
        /// The true 3D rectangular coordinates of the moon.
        /// </summary>
        public AAS3DCoordinate TrueRectangularCoordinates { get; set; }
        /// <summary>
        /// The apparent 3D rectangular coordinates of the moon.
        /// </summary>
        public AAS3DCoordinate ApparentRectangularCoordinates { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is in front of Jupiter as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInTransit { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is behind Jupiter as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInOccultation { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is behind Jupiter as viewed from the Sun otherwise false.
        /// </summary>
        public bool bInEclipse { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is in front of Jupiter as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInShadowTransit { get; set; }
    }
}
