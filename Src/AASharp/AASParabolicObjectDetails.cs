namespace AASharp
{
    /// <summary>
    /// An instance of this class is returned by AASParabolic.Calculate method.
    /// </summary>
    public class AASParabolicObjectDetails
    {
        public AASParabolicObjectDetails()
        {
            HeliocentricRectangularEquatorial = new AAS3DCoordinate();
            HeliocentricRectangularEcliptical = new AAS3DCoordinate();
        }

        /// <summary>
        /// 3D rectangular heliocentric equatorial coordinates of the object.
        /// </summary>
        public AAS3DCoordinate HeliocentricRectangularEquatorial { get; set; }
        /// <summary>
        /// 3D rectangular heliocentric ecliptical coordinates of the object.
        /// </summary>
        public AAS3DCoordinate HeliocentricRectangularEcliptical { get; set; }
        /// <summary>
        /// The heliocentric ecliptical longitude in degrees of the object.
        /// </summary>
        public double HeliocentricEclipticLongitude { get; set; }
        /// <summary>
        /// The heliocentric ecliptical latitude in degrees of the object.
        /// </summary>
        public double HeliocentricEclipticLatitude { get; set; }
        /// <summary>
        /// The geocentric right ascension of the object as an hour angle (i.e. without light time correction applied).
        /// </summary>
        public double TrueGeocentricRA { get; set; }
        /// <summary>
        /// The geocentric declination of the object in degrees (i.e. without light time correction applied).
        /// </summary>
        public double TrueGeocentricDeclination { get; set; }
        /// <summary>
        /// The true distance in astronomical units between the Earth and the object.
        /// </summary>
        public double TrueGeocentricDistance { get; set; }
        /// <summary>
        /// The light travel time in days from the Earth to the object.
        /// </summary>
        public double TrueGeocentricLightTime { get; set; }
        /// <summary>
        /// The geocentric right ascension of the object as an hour angle (i.e. with light time correction applied)
        /// </summary>
        public double AstrometricGeocenticRA { get; set; }
        /// <summary>
        /// The geocentric declination of the object in degrees (i.e. with light time correction applied)
        /// </summary>
        public double AstrometricGeocentricDeclination { get; set; }
        /// <summary>
        /// The observed distance of the object in astronomical units.
        /// </summary>
        public double AstrometricGeocentricDistance { get; set; }
        /// <summary>
        /// The observed light travel time of the object in days.
        /// </summary>
        public double AstrometricGeocentricLightTime { get; set; }
        /// <summary>
        /// The elongation of the object to the Sun in degrees.
        /// </summary>
        public double Elongation { get; set; }
        /// <summary>
        /// The phase angle (the angle Sun - object - Earth) in degrees.
        /// </summary>
        public double PhaseAngle { get; set; }
    }
}