using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for the transformations of the coordinates as well as helper angle methods. This refers to Chapter 13 and parts of Chapter 1 in the book.
    /// </summary>
    public static class AASCoordinateTransformation
    {
        /// <summary>
        /// The transformation of coordinates from Equatorial to Ecliptic. This refers to algorithm 13.1 and 13.2 on page 93.
        /// </summary>
        /// <param name="Alpha">The right ascension expressed as decimal hours.</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <param name="Epsilon">The obliquity of the ecliptic in degrees.</param>
        /// <returns>Returns the converted ecliptic coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the ecliptic longitude in degrees and the y value corresponds to the ecliptic latitude in degrees.</returns>
        public static AAS2DCoordinate Equatorial2Ecliptic(double Alpha, double Delta, double Epsilon)
        {
            Alpha = HoursToRadians(Alpha);
            Delta = DegreesToRadians(Delta);
            Epsilon = DegreesToRadians(Epsilon);

            AAS2DCoordinate Ecliptic = new AAS2DCoordinate { X = RadiansToDegrees(Math.Atan2(Math.Sin(Alpha) * Math.Cos(Epsilon) + Math.Tan(Delta) * Math.Sin(Epsilon), Math.Cos(Alpha))) };
            if (Ecliptic.X < 0)
                Ecliptic.X += 360;
            Ecliptic.Y = RadiansToDegrees(Math.Asin(Math.Sin(Delta) * Math.Cos(Epsilon) - Math.Cos(Delta) * Math.Sin(Epsilon) * Math.Sin(Alpha)));

            return Ecliptic;
        }

        /// <summary>
        /// The transformation of coordinates from Ecliptic to Equatorial. This refers to algorithm 13.3 and 13.4 on page 93.
        /// </summary>
        /// <param name="Lambda">The ecliptic longitude in degrees.</param>
        /// <param name="Beta">The ecliptic latitude in degrees.</param>
        /// <param name="Epsilon">The obliquity of the ecliptic in degrees.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the right ascension in decimal hours and the y value corresponds to the declination in degrees.</returns>
        public static AAS2DCoordinate Ecliptic2Equatorial(double Lambda, double Beta, double Epsilon)
        {
            Lambda = DegreesToRadians(Lambda);
            Beta = DegreesToRadians(Beta);
            Epsilon = DegreesToRadians(Epsilon);

            AAS2DCoordinate Equatorial = new AAS2DCoordinate { X = RadiansToHours(Math.Atan2(Math.Sin(Lambda) * Math.Cos(Epsilon) - Math.Tan(Beta) * Math.Sin(Epsilon), Math.Cos(Lambda))) };
            if (Equatorial.X < 0)
                Equatorial.X += 24;
            Equatorial.Y = RadiansToDegrees(Math.Asin(Math.Sin(Beta) * Math.Cos(Epsilon) + Math.Cos(Beta) * Math.Sin(Epsilon) * Math.Sin(Lambda)));

            return Equatorial;
        }

        /// <summary>
        /// The transformation of coordinates from Equatorial to Horizontal. This refers to algorithm 13.5 and 13.6 on page 93.
        /// </summary>
        /// <param name="LocalHourAngle">The local hour angle in decimal hours, measured westwards from the South. To convert a equatorial right ascension to a local hour angle you can use the formula as mentioned on page 92: Local hour angle (H) = apparent sidereal time at Greenwich (theta) - observer's longitude (L, positive west, negative east from Greenwich) - right ascension. You should of course make sure that all the values used in this formula are expressed as decimal hours before applying the formula (in particular the observer's longitude "L" value).</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <param name="Latitude">The standard latitude of the position in degrees.</param>
        /// <returns>Returns the converted horizontal coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the azimuth in degrees west of south and the y value corresponds to the altitude in degrees.</returns>
        public static AAS2DCoordinate Equatorial2Horizontal(double LocalHourAngle, double Delta, double Latitude)
        {
            LocalHourAngle = HoursToRadians(LocalHourAngle);
            Delta = DegreesToRadians(Delta);
            Latitude = DegreesToRadians(Latitude);

            AAS2DCoordinate Horizontal = new AAS2DCoordinate { X = RadiansToDegrees(Math.Atan2(Math.Sin(LocalHourAngle), Math.Cos(LocalHourAngle) * Math.Sin(Latitude) - Math.Tan(Delta) * Math.Cos(Latitude))) };
            if (Horizontal.X < 0)
                Horizontal.X += 360;
            Horizontal.Y = RadiansToDegrees(Math.Asin(Math.Sin(Latitude) * Math.Sin(Delta) + Math.Cos(Latitude) * Math.Cos(Delta) * Math.Cos(LocalHourAngle)));

            return Horizontal;
        }

        /// <summary>
        /// The transformation of coordinates from Horizontal to Equatorial. This refers to the two algorithms on the top of page 94. To convert the returned local hour angle back to a right ascension in decimal hours you can use the formula as mentioned on page 92: right ascension (alpha) = apparent sidereal time at Greenwich (theta) - Local hour angle (H) - observer's longitude (L, positive west, negative east from Greenwich). You should of course make sure that all the values used in this formula are expressed as decimal hours before applying the formula (in particular the observer's longitude "L" value).
        /// </summary>
        /// <param name="Azimuth">The azimuth in degrees west of south.</param>
        /// <param name="Altitude">The altitude in degrees</param>
        /// <param name="Latitude">The standard latitude of the position in degrees.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the local hour angle in decimal hours and the y value corresponds to the declination in degrees.</returns>
        public static AAS2DCoordinate Horizontal2Equatorial(double Azimuth, double Altitude, double Latitude)
        {
            //Convert from degress to radians
            Azimuth = DegreesToRadians(Azimuth);
            Altitude = DegreesToRadians(Altitude);
            Latitude = DegreesToRadians(Latitude);

            AAS2DCoordinate Equatorial = new AAS2DCoordinate { X = RadiansToHours(Math.Atan2(Math.Sin(Azimuth), Math.Cos(Azimuth) * Math.Sin(Latitude) + Math.Tan(Altitude) * Math.Cos(Latitude))) };
            if (Equatorial.X < 0)
                Equatorial.X += 24;
            Equatorial.Y = RadiansToDegrees(Math.Asin(Math.Sin(Latitude) * Math.Sin(Altitude) - Math.Cos(Latitude) * Math.Cos(Altitude) * Math.Cos(Azimuth)));

            return Equatorial;
        }

        /// <summary>
        /// The transformation of coordinates from Equatorial to Galactic. This refers to algorithm 13.7 and 13.8 on page 94.
        /// </summary>
        /// <param name="Alpha">The right ascension in decimal hours.</param>
        /// <param name="Delta">The declination in degrees.</param>
        /// <returns>Returns the converted galactic coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the galactic longitude in degrees and the y value corresponds to the galactic latitude in degrees.</returns>
        public static AAS2DCoordinate Equatorial2Galactic(double Alpha, double Delta)
        {
            Alpha = 192.25 - HoursToDegrees(Alpha);
            Alpha = DegreesToRadians(Alpha);
            Delta = DegreesToRadians(Delta);

            AAS2DCoordinate Galactic = new AAS2DCoordinate { X = RadiansToDegrees(Math.Atan2(Math.Sin(Alpha), Math.Cos(Alpha) * Math.Sin(DegreesToRadians(27.4)) - Math.Tan(Delta) * Math.Cos(DegreesToRadians(27.4)))) };
            Galactic.X = 303 - Galactic.X;
            if (Galactic.X >= 360)
                Galactic.X -= 360;
            Galactic.Y = RadiansToDegrees(Math.Asin(Math.Sin(Delta) * Math.Sin(DegreesToRadians(27.4)) + Math.Cos(Delta) * Math.Cos(DegreesToRadians(27.4)) * Math.Cos(Alpha)));

            return Galactic;
        }

        /// <summary>
        /// The transformation of coordinates from Galactic to Equatorial. This refers to the last two algorithms on page 94.
        /// </summary>
        /// <param name="l">The galactic longitude expressed in degrees.</param>
        /// <param name="b">The galactic latitude expressed in degrees.</param>
        /// <returns>Returns the converted equatorial coordinates in a AAS2DCoordinate class. The x value in the class corresponds to the right ascension in decimal hours and the y value corresponds to the declination in degrees.</returns>
        public static AAS2DCoordinate Galactic2Equatorial(double l, double b)
        {
            l -= 123;
            l = DegreesToRadians(l);
            b = DegreesToRadians(b);

            AAS2DCoordinate Equatorial = new AAS2DCoordinate { X = RadiansToDegrees(Math.Atan2(Math.Sin(l), Math.Cos(l) * Math.Sin(DegreesToRadians(27.4)) - Math.Tan(b) * Math.Cos(DegreesToRadians(27.4)))) };
            Equatorial.X += 12.25;
            if (Equatorial.X < 0)
                Equatorial.X += 360;
            Equatorial.X = DegreesToHours(Equatorial.X);
            Equatorial.Y = RadiansToDegrees(Math.Asin(Math.Sin(b) * Math.Sin(DegreesToRadians(27.4)) + Math.Cos(b) * Math.Cos(DegreesToRadians(27.4)) * Math.Cos(l)));

            return Equatorial;
        }

        /// <summary>
        /// To convert the angle 21° 44' 07" you would use DMSToDegrees(21, 44, 7, true).
        /// To convert the angle -12° 47' 22" you would use DMSToDegrees(12, 47, 22, false) or DMSToDegrees(-12, -47, -22, true).
        /// To convert the angle -0° 32' 41" you must use DMSToDegrees(0, 32, 41, false).
        /// </summary>
        /// <param name="Degrees">The degree part of the angular value to convert.</param>
        /// <param name="Minutes">The minute part of the angular value to convert.</param>
        /// <param name="Seconds">The second part of the angular value to convert.</param>
        /// <param name="bPositive">true if the input value corresponds to a non-negative value with false implying the value is positive</param>
        /// <returns>Returns the value in degrees which was converted from degrees, minutes and seconds.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static double DMSToDegrees(double Degrees, double Minutes, double Seconds, bool bPositive = true)
        {
            //validate our parameters
            if (!bPositive)
            {
                if (Degrees < 0)
                    throw new ArgumentOutOfRangeException("Degrees", "Degrees must be greater than 0");
                if (Minutes < 0)
                    throw new ArgumentOutOfRangeException("Minutes", "Minutes must be greater than 0");
                if (Seconds < 0)
                    throw new ArgumentOutOfRangeException("Seconds", "Seconds must be greater than 0");
            }

            if (bPositive)
                return Degrees + Minutes / 60 + Seconds / 3600;
            else
                return -Degrees - Minutes / 60 - Seconds / 3600;
        }

        /// <param name="Degrees">The angular value to convert measured in degrees.</param>
        /// <returns>Returns the value in radians which was converted from degrees.</returns>
        public static double DegreesToRadians(double Degrees)
        {
            return Degrees * 0.017453292519943295769236907684886;
        }

        /// <param name="Radians">The angular value to convert measured in radians.</param>
        /// <returns>Returns the value in degrees which was converted from radians.</returns>
        public static double RadiansToDegrees(double Radians)
        {
            return Radians * 57.295779513082320876798154814105;
        }

        /// <param name="Radians">The angular value to convert measured in radians.</param>
        /// <returns>Returns the value expressed as an hour angle which was converted from radians.</returns>
        public static double RadiansToHours(double Radians)
        {
            return Radians * 3.8197186342054880584532103209403;
        }

        /// <param name="Hours">The numeric value to convert measured in hours.</param>
        /// <returns>Returns the value in radians which was converted from hours.</returns>
        public static double HoursToRadians(double Hours)
        {
            return Hours * 0.26179938779914943653855361527329;
        }

        /// <param name="Hours">The numeric value to convert measured in hours.</param>
        /// <returns>Returns the value in degrees which was converted from hours.</returns>
        public static double HoursToDegrees(double Hours)
        {
            return Hours * 15;
        }

        /// <param name="Degrees">The angular value to convert measured in degrees.</param>
        /// <returns>Returns the value in hours which was converted from degrees.</returns>
        public static double DegreesToHours(double Degrees)
        {
            return Degrees / 15;
        }

        /// <returns>Returns the constant value of pi i.e 3.1415926...</returns>
        public static double PI()
        {
            return 3.1415926535897932384626433832795;
        }

        /// <param name="Degrees">The angular value.</param>
        /// <returns>Maps an arbitrary angular value to the range 0 to 360. i.e. inputting the value -2 will return a value of 258.</returns>
        public static double MapTo0To360Range(double Degrees)
        {
            double fResult = Math.IEEERemainder(Degrees, 360);
            
            if (fResult < 0)
            {
                fResult += 360;
            }
            
            return fResult;
        }

        /// <param name="Degrees">The angular value.</param>
        /// <returns>Maps an arbitrary angular value to the range -90 to 90.</returns>
        public static double MapToMinus90To90Range(double Degrees)
        {
            double fResult = MapTo0To360Range(Degrees);

            if (fResult > 270)
            {
                fResult = fResult - 360;
            }
            else if (fResult > 180)
            {
                fResult = 180 - fResult;
            }
            else if (fResult > 90)
            {
                fResult = 180 - fResult;
            }
            
            return fResult;
        }

        /// <param name="HourAngle">The hour angle.</param>
        /// <returns>Maps an arbitrary value to the range 0 to 24. i.e. inputting the value -2 will return a value of 22.</returns>
        public static double MapTo0To24Range(double HourAngle)
        {
            double fResult = Math.IEEERemainder(HourAngle, 24);
            
            if (fResult < 0)
            {
                fResult += 24;
            }
            
            return fResult;
        }

        /// <param name="Angle">The angle in radians.</param>
        /// <returns>Maps an arbitrary value to the range 0 to 2*PI. i.e. inputting the value -1 will return a value of 5.2831853071795862.</returns>
        public static double MapTo0To2PIRange(double Angle)
        {
            double fResult = Math.IEEERemainder(Angle, 2 * PI());
            
            if (fResult < 0)
            {
                fResult += 2 * PI();
            }
            
            return fResult;
        }
    }
}
