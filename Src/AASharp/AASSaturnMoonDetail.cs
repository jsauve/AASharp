namespace AASharp
{
    public class AASSaturnMoonDetail
    {
        public AASSaturnMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        public AAS3DCoordinate TrueRectangularCoordinates { get; set; }
        public AAS3DCoordinate ApparentRectangularCoordinates { get; set; }
        public bool bInTransit { get; set; }
        public bool bInOccultation { get; set; }
        public bool bInEclipse { get; set; }
        public bool bInShadowTransit { get; set; }
    }
}