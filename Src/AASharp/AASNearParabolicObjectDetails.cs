namespace AASharp
{
    public class AASNearParabolicObjectDetails
    {
        public AASNearParabolicObjectDetails()
        {
            HeliocentricRectangularEquatorial = new AAS3DCoordinate();
            HeliocentricRectangularEcliptical = new AAS3DCoordinate();
        }

        public AAS3DCoordinate HeliocentricRectangularEquatorial { get; set; }
        public AAS3DCoordinate HeliocentricRectangularEcliptical { get; set; }
        public double HeliocentricEclipticLongitude { get; set; }
        public double HeliocentricEclipticLatitude { get; set; }
        public double TrueGeocentricRA { get; set; }
        public double TrueGeocentricDeclination { get; set; }
        public double TrueGeocentricDistance { get; set; }
        public double TrueGeocentricLightTime { get; set; }
        public double AstrometricGeocentricRA { get; set; }
        public double AstrometricGeocentricDeclination { get; set; }
        public double AstrometricGeocentricDistance { get; set; }
        public double AstrometricGeocentricLightTime { get; set; }
        public double Elongation { get; set; }
        public double PhaseAngle { get; set; }
    }
}