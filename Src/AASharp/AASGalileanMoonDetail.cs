namespace AASharp
{
    public class AASGalileanMoonDetail
    {
        public AASGalileanMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        public double MeanLongitude { get; set; }
        public double TrueLongitude { get; set; }
        public double TropicalLongitude { get; set; }
        public double EquatorialLatitude { get; set; }
        public double r { get; set; }
        public AAS3DCoordinate TrueRectangularCoordinates { get; set; }
        public AAS3DCoordinate ApparentRectangularCoordinates { get; set; }
        public bool bInTransit { get; set; }
        public bool bInOccultation { get; set; }
        public bool bInEclipse { get; set; }
        public bool bInShadowTransit { get; set; }
    }
}
