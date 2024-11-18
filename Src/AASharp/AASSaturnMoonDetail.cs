namespace AASharp
{
    /// <summary>
    /// Details of one of the following Saturn moons: Mimas, Enceladus, Tethys, Dione, Rhea, Titan, Hyperion, Iapetus.
    /// </summary>
    public class AASSaturnMoonDetail
    {
        public AASSaturnMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        /// <summary>
        /// The true 3D rectangular coordinates of the moon.
        /// </summary>
        public AAS3DCoordinate TrueRectangularCoordinates { get; set; }
        /// <summary>
        /// The apparent 3D rectangular coordinates of the moon.
        /// </summary>
        public AAS3DCoordinate ApparentRectangularCoordinates { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is in front of Saturn as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInTransit { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is behind Saturn as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInOccultation { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is behind Saturn as viewed from the Sun otherwise false.
        /// </summary>
        public bool bInEclipse { get; set; }
        /// <summary>
        /// A Boolean which if true means that the moon is in front of Saturn as viewed from the Earth otherwise false.
        /// </summary>
        public bool bInShadowTransit { get; set; }
    }
}