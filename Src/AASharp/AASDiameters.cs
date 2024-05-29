using System;

namespace AASharp
{
    /// <summary>
    /// This class provides the algorithms for the semi diameters of the Sun, Moon, Planets and Asteroids. This refers to Chapter 55 in the book.
    /// </summary>
    public static class AASDiameters
    {
        /// <param name="Delta">The distance to the Sun in astronomical units.</param>
        /// <returns>The suns semi diameter in arc seconds.</returns>
        public static double SunSemidiameterA(double Delta)
        {
            return 959.63 / Delta;
        }

        /// <param name="Delta">The distance to Mercury in astronomical units.</param>
        /// <returns>Mercury's semi diameter in arc seconds.</returns>
        public static double MercurySemidiameterA(double Delta)
        {
            return 3.34 / Delta;
        }

        /// <param name="Delta">The distance to Venus in astronomical units.</param>
        /// <returns>Venus's semi diameter in arc seconds.</returns>
        public static double VenusSemidiameterA(double Delta)
        {
            return 8.41 / Delta;
        }

        /// <param name="Delta">The distance to Mars in astronomical units.</param>
        /// <returns>Mars's semi diameter in arc seconds.</returns>
        public static double MarsSemidiameterA(double Delta)
        {
            return 4.68 / Delta;
        }

        /// <param name="Delta">The distance to Jupiter in astronomical units.</param>
        /// <returns>Jupiter's equatorial semi diameter in arc seconds.</returns>
        public static double JupiterEquatorialSemidiameterA(double Delta)
        {
            return 98.47 / Delta;
        }

        /// <param name="Delta">The distance to Jupiter in astronomical units.</param>
        /// <returns>Jupiter's polar semi diameter in arc seconds.</returns>
        public static double JupiterPolarSemidiameterA(double Delta)
        {
            return 91.91 / Delta;
        }

        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <returns>Saturn's equatorial semi diameter in arc seconds.</returns>
        public static double SaturnEquatorialSemidiameterA(double Delta)
        {
            return 83.33 / Delta;
        }

        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <returns>Saturn's polar semi diameter in arc seconds.</returns>
        public static double SaturnPolarSemidiameterA(double Delta)
        {
            return 74.57 / Delta;
        }

        /// <summary>
        /// Due to the large inclinations of Saturn, the apparent polar semi diameter can be different to the true polar semi diameter.
        /// </summary>
        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <param name="B">The Saturnicentric latitude of the Earth in degrees.</param>
        /// <returns>Saturn's polar semi diameter in arc seconds.</returns>
        public static double ApparentSaturnPolarSemidiameterA(double Delta, double B)
        {
            double cosB = Math.Cos(AASCoordinateTransformation.DegreesToRadians(B));
            return SaturnPolarSemidiameterA(Delta) * Math.Sqrt(1 - 0.199197 * cosB * cosB);
        }

        /// <param name="Delta">The distance to Uranus in astronomical units.</param>
        /// <returns>Uranus's semi diameter in arc seconds.</returns>
        public static double UranusSemidiameterA(double Delta)
        {
            return 34.28 / Delta;
        }

        /// <param name="Delta">The distance to Neptune in astronomical units.</param>
        /// <returns>Neptune's semi diameter in arc seconds.</returns>
        public static double NeptuneSemidiameterA(double Delta)
        {
            return 36.56 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Mercury in astronomical units.</param>
        /// <returns>Mercury's semi diameter in arc seconds.</returns>
        public static double MercurySemidiameterB(double Delta)
        {
            return 3.36 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Venus in astronomical units.</param>
        /// <returns>Venus's semi diameter in arc seconds.</returns>
        public static double VenusSemidiameterB(double Delta)
        {
            return 8.34 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Mars in astronomical units.</param>
        /// <returns>Mars's semi diameter in arc seconds.</returns>
        public static double MarsSemidiameterB(double Delta)
        {
            return 4.68 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Jupiter in astronomical units.</param>
        /// <returns>Jupiter's equatorial semi diameter in arc seconds.</returns>
        public static double JupiterEquatorialSemidiameterB(double Delta)
        {
            return 98.44 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Jupiter in astronomical units.</param>
        /// <returns>Jupiter's polar semi diameter in arc seconds.</returns>
        public static double JupiterPolarSemidiameterB(double Delta)
        {
            return 92.06 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <returns>Saturn's equatorial semi diameter in arc seconds.</returns>
        public static double SaturnEquatorialSemidiameterB(double Delta)
        {
            return 82.73 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <returns>Saturn's polar semi diameter in arc seconds.</returns>
        public static double SaturnPolarSemidiameterB(double Delta)
        {
            return 73.82 / Delta;
        }

        /// <summary>
        /// Due to the large inclinations of Saturn, the apparent polar semi diameter can be different to the true polar semi diameter. Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Saturn in astronomical units.</param>
        /// <param name="B">The Saturnicentric latitude of the Earth in degrees.</param>
        /// <returns>Saturn's polar semi diameter in arc seconds.</returns>
        public static double ApparentSaturnPolarSemidiameterB(double Delta, double B)
        {
            double cosB = Math.Cos(AASCoordinateTransformation.DegreesToRadians(B));
            return SaturnPolarSemidiameterB(Delta) * Math.Sqrt(1 - 0.203800 * cosB * cosB);
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Uranus in astronomical units.</param>
        /// <returns>Uranus's semi diameter in arc seconds.</returns>
        public static double UranusSemidiameterB(double Delta)
        {
            return 35.02 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Neptune in astronomical units.</param>
        /// <returns>Neptune's semi diameter in arc seconds.</returns>
        public static double NeptuneSemidiameterB(double Delta)
        {
            return 33.50 / Delta;
        }

        /// <summary>
        /// Uses the updated Astronomical Almanac for 1984 size.
        /// </summary>
        /// <param name="Delta">The distance to Pluto in astronomical units.</param>
        /// <returns>Pluto's semi diameter in arc seconds.</returns>
        public static double PlutoSemidiameterB(double Delta)
        {
            return 2.07 / Delta;
        }

        /// <param name="Delta">The distance to the Moon in kilometres.</param>
        /// <returns>The Moon's semi diameter in arc seconds.</returns>
        public static double GeocentricMoonSemidiameter(double Delta)
        {
            return AASCoordinateTransformation.RadiansToDegrees (0.272481 * 6378.14 / Delta) * 3600;
        }

        /// <param name="DistanceDelta">The distance to the Moon in kilometres.</param>
        /// <param name="Delta">The geocentric declination of the Moon in degrees.</param>
        /// <param name="H">The geocentric hour angle of the Moon.</param>
        /// <param name="Latitude">The latitude of the position in degrees.</param>
        /// <param name="Height">The observer's height above sea level in meters</param>
        /// <returns>The Moon's semi diameter in arc seconds.</returns>
        public static double TopocentricMoonSemidiameter(double DistanceDelta, double Delta, double H, double Latitude, double Height)
        {
            //Convert to radians
            H = AASCoordinateTransformation.HoursToRadians(H);
            Delta = AASCoordinateTransformation.DegreesToRadians(Delta);

            double pi = Math.Asin(6378.14 / DistanceDelta);
            double A = Math.Cos(Delta) * Math.Sin(H);
            double B = Math.Cos(Delta) * Math.Cos(H) - AASGlobe.RhoCosThetaPrime(Latitude, Height) * Math.Sin(pi);
            double C = Math.Sin(Delta) - AASGlobe.RhoSinThetaPrime(Latitude, Height) * Math.Sin(pi);
            double q = Math.Sqrt(A * A + B * B + C * C);

            double s = AASCoordinateTransformation.DegreesToRadians(GeocentricMoonSemidiameter(DistanceDelta) / 3600);
            return AASCoordinateTransformation.RadiansToDegrees(Math.Asin(Math.Sin(s) / q)) * 3600;
        }

        /// <param name="H">The absolute magnitude of the asteroid.</param>
        /// <param name="A">The albedo of the asteroid.</param>
        /// <returns>The asteroid's diameter in kilometres.</returns>
        public static double AsteroidDiameter(double H, double A)
        {
            double x = 3.12 - H / 5 - 0.217147 * Math.Log(A);
            return Math.Pow(10.0, x);
        }

        /// <param name="Delta">The distance to the asteroid in astronomical units.</param>
        /// <param name="d">The diameter of the asteroid in kilometres.</param>
        /// <returns>The asteroid's apparent diameter in arc seconds.</returns>
        public static double ApparentAsteroidDiameter(double Delta, double d)
        {
            return 0.0013788 * d / Delta;
        }
    }
}
