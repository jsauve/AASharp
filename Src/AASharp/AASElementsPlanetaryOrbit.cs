namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms to calculate the elements of the planetary orbits. This refers to Chapter 31 in the book.
    /// </summary>
    public static class AASElementsPlanetaryOrbit
    {
        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MercuryMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(252.250906 + 149474.0722491 * T + 0.00030350 * Tsquared +
                                                              0.000000018 * Tcubed);
        }

        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double MercurySemimajorAxis( /*JD*/)
        {
            return 0.387098310;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double MercuryEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.20563175 + 0.000020407 * T - 0.0000000283 * Tsquared - 0.00000000018 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MercuryInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(7.004986 + 0.0018215 * T - 0.00001810 * Tsquared +
                                                              0.000000056 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MercuryLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(48.330893 + 1.1861883 * T + 0.00017542 * Tsquared +
                                                              0.000000215 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MercuryLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(77.456119 + 1.5564776 * T + 0.00029544 * Tsquared +
                                                              0.000000009 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double VenusMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(181.979801 + 58519.2130302 * T + 0.00031014 * Tsquared +
                                                              0.000000015 * Tcubed);
        }

        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double VenusSemimajorAxis( /*double JD*/)
        {
            return 0.723329820;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double VenusEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.00677192 - 0.000047765 * T + 0.0000000981 * Tsquared + 0.00000000046 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double VenusInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(3.394662 + 0.0010037 * T - 0.00000088 * Tsquared -
                                                              0.000000007 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double VenusLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(76.679920 + 0.9011206 * T + 0.00040618 * Tsquared -
                                                              0.000000093 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double VenusLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(131.563703 + 1.4022288 * T - 0.00107618 * Tsquared -
                                                              0.000005678 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double EarthMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(100.466457 + 36000.7698278 * T + 0.00030322 * Tsquared +
                                                              0.000000020 * Tcubed);
        }

        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double EarthSemimajorAxis( /*double JD*/)
        {
            return 1.000001018;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double EarthEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.01670863 - 0.000042037 * T - 0.0000001267 * Tsquared + 0.00000000014 * Tcubed;
        }

        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double EarthInclination( /*double JD*/)
        {
            return 0;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double EarthLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(102.937348 + 1.17195366 * T + 0.00045688 * Tsquared -
                                                              0.000000018 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MarsMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(355.433000 + 19141.6964471 * T + 0.00031052 * Tsquared +
                                                              0.000000016 * Tcubed);
        }

        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double MarsSemimajorAxis( /*double JD*/)
        {
            return 1.523679342;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double MarsEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.09340065 + 0.000090484 * T - 0.0000000806 * Tsquared - 0.00000000025 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MarsInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.849726 - 0.0006011 * T + 0.00001276 * Tsquared -
                                                              0.000000007 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MarsLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(49.588093 + 0.7720959 * T + 0.00001557 * Tsquared +
                                                              0.000002267 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double MarsLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(336.060234 + 1.8410449 * T + 0.00013477 * Tsquared +
                                                              0.000000536 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double JupiterMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(34.351519 + 3036.3027748 * T + 0.00022330 * Tsquared +
                                                              0.000000037 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double JupiterSemimajorAxis(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
    
            return 5.202603209 + 0.0000001913 * T;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double JupiterEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.04849793 + 0.000163225 * T - 0.0000004714 * Tsquared - 0.00000000201 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double JupiterInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.303267 - 0.0054965 * T + 0.00000466 * Tsquared -
                                                              0.000000002 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double JupiterLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(100.464407 + 1.0209774 * T + 0.00040315 * Tsquared +
                                                              0.000000404 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double JupiterLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(14.331207 + 1.6126352 * T + 0.00103042 * Tsquared -
                                                              0.000004464 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double SaturnMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(50.077444 + 1223.5110686 * T + 0.00051908 * Tsquared -
                                                              0.000000030 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double SaturnSemimajorAxis(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
    
            return 9.554909192 - 0.0000021390 * T + 0.000000004 * Tsquared;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double SaturnEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.05554814 - 0.0003446641 * T - 0.0000006436 * Tsquared + 0.00000000340 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double SaturnInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(2.488879 - 0.0037362 * T - 0.00001519 * Tsquared +
                                                              0.000000087 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double SaturnLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(113.665503 + 0.8770880 * T - 0.00012176 * Tsquared -
                                                              0.000002249 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double SaturnLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(93.057237 + 1.9637613 * T + 0.00083753 * Tsquared +
                                                              0.000004928 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double UranusMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(314.055005 + 429.8640561 * T + 0.00030390 * Tsquared +
                                                              0.000000026 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double UranusSemimajorAxis(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
    
            return 19.218446062 - 0.0000000372 * T + 0.00000000098 * Tsquared;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double UranusEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.04638122 - 0.000027293 * T + 0.0000000789 * Tsquared + 0.00000000024 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double UranusInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(0.773197 + 0.0007744 * T + 0.00003749 * Tsquared -
                                                              0.000000092 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double UranusLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(74.005957 + 0.5211278 * T + 0.00133947 * Tsquared +
                                                              0.000018484 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double UranusLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(173.005291 + 1.4863790 * T + 0.00021406 * Tsquared +
                                                              0.000000434 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double NeptuneMeanLongitude(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(304.348665 + 219.8833092 * T + 0.00030882 * Tsquared +
                                                              0.000000018 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the semi major axis of the planet in astronomical units.</returns>
        public static double NeptuneSemimajorAxis(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
    
            return 30.110386869 - 0.0000001663 * T + 0.00000000069 * Tsquared;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the eccentricity of the orbit.</returns>
        public static double NeptuneEccentricity(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tcubed = T * T * T;
    
            return 0.00945575 + 0.000006033 * T - 0.00000000005 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double NeptuneInclination(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.769953 - 0.0093082 * T - 0.00000708 * Tsquared +
                                                              0.000000027 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double NeptuneLongitudeAscendingNode(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(131.784057 + 1.1022039 * T + 0.00025952 * Tsquared -
                                                              0.000000637 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the ecliptic and mean equinox of the date.</returns>
        public static double NeptuneLongitudePerihelion(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(48.120276 + 1.4262957 * T + 0.00038434 * Tsquared +
                                                              0.000000020 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MercuryMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(252.250906 + 149472.6746358 * T - 0.00000536 * Tsquared +
                                                              0.000000002 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MercuryInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(7.004986 - 0.0059516 * T + 0.00000080 * Tsquared +
                                                              0.000000043 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MercuryLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(48.330893 - 0.1254227 * T - 0.00008833 * Tsquared -
                                                              0.000000200 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MercuryLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(77.456119 + 0.1588643 * T - 0.00001342 * Tsquared -
                                                              0.000000007 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double VenusMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(181.979801 + 58517.8156760 * T + 0.00000165 * Tsquared -
                                                              0.000000002 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double VenusInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(3.394662 - 0.0008568 * T - 0.00003244 * Tsquared +
                                                              0.000000009 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double VenusLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(76.679920 - 0.2780134 * T - 0.00014257 * Tsquared -
                                                              0.000000164 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double VenusLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(131.563703 + 0.0048746 * T - 0.00138467 * Tsquared -
                                                              0.000005695 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double EarthMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(100.466457 + 35999.3728565 * T - 0.00000568 * Tsquared -
                                                              0.000000001 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double EarthInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return 0.0130548 * T - 0.00000931 * Tsquared - 0.000000034 * Tcubed;
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double EarthLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(174.873176 - 0.241098 * T + 0.00004262 * Tsquared +
                                                              0.000000001 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double EarthLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(102.937348 + 0.3225654 * T + 0.00014799 * Tsquared -
                                                              0.000000039 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MarsMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(355.433000 + 19140.2993039 * T + 0.00000262 * Tsquared -
                                                              0.000000003 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MarsInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.849726 - 0.0081477 * T - 0.00002255 * Tsquared -
                                                              0.000000029 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MarsLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(49.588093 - 0.2950250 * T - 0.00064048 * Tsquared -
                                                              0.000001964 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double MarsLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(336.060234 + 0.4439016 * T - 0.00017313 * Tsquared +
                                                              0.000000518 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double JupiterMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(34.351519 + 3034.9056606 * T - 0.00008501 * Tsquared +
                                                              0.000000016 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double JupiterInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.303267 - 0.0019877 * T + 0.00003320 * Tsquared +
                                                              0.000000097 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double JupiterLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(100.464407 + 0.1767232 * T + 0.00090700 * Tsquared -
                                                              0.000007272 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double JupiterLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(14.331207 + 0.2155209 * T + 0.00072211 * Tsquared -
                                                              0.000004485 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double SaturnMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(50.077444 + 1222.1138488 * T + 0.00021004 * Tsquared -
                                                              0.000000046 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double SaturnInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(2.488879 + 0.0025514 * T - 0.00004906 * Tsquared +
                                                              0.000000017 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double SaturnLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(113.665503 - 0.2566722 * T - 0.00018399 * Tsquared +
                                                              0.000000480 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double SaturnLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(93.057237 + 0.5665415 * T + 0.00052850 * Tsquared +
                                                              0.000004912 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double UranusMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(314.055005 + 428.4669983 * T - 0.00000486 * Tsquared +
                                                              0.000000006 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double UranusInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(0.773197 - 0.0016869 * T + 0.00000349 * Tsquared +
                                                              0.000000016 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double UranusLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(74.005957 + 0.0741431 * T + 0.00040539 * Tsquared +
                                                              0.000000119 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double UranusLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(173.005291 + 0.0893212 * T - 0.00009470 * Tsquared +
                                                              0.000000414 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the mean longitude of the planet in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double NeptuneMeanLongitudeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(304.348665 + 218.4862002 * T + 0.00000059 * Tsquared -
                                                              0.000000002 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the inclination on the plane of the ecliptic in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double NeptuneInclinationJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(1.769953 + 0.0002256 * T + 0.00000023 * Tsquared);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the ascending node in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double NeptuneLongitudeAscendingNodeJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
            double Tcubed = Tsquared * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(131.784057 - 0.0061651 * T - 0.00000219 * Tsquared -
                                                              0.000000078 * Tcubed);
        }

        /// <param name="JD">The date in Dynamical time to calculate for.</param>
        /// <returns>the longitude of the perihelion in degrees with respect to the fixed ecliptic of J2000.</returns>
        public static double NeptuneLongitudePerihelionJ2000(double JD)
        {
            double T = (JD - 2451545.0) / 36525;
            double Tsquared = T * T;
    
            return AASCoordinateTransformation.MapTo0To360Range(48.120276 + 0.0291866 * T + 0.00007610 * Tsquared);
        }
    }
}
