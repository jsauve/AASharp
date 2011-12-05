using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public static class AASCoordinateTransformation
    {
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

        public static AAS2DCoordinate Equatorial2Galactic(double Alpha, double Delta)
        {
            Alpha = 192.25 - HoursToDegrees(Alpha);
            Alpha = DegreesToRadians(Alpha);
            Delta = DegreesToRadians(Delta);

            AAS2DCoordinate Galactic = new AAS2DCoordinate() { X = RadiansToDegrees(Math.Atan2(Math.Sin(Alpha), Math.Cos(Alpha) * Math.Sin(DegreesToRadians(27.4)) - Math.Tan(Delta) * Math.Cos(DegreesToRadians(27.4)))) };
            Galactic.X = 303 - Galactic.X;
            if (Galactic.X >= 360)
                Galactic.X -= 360;
            Galactic.Y = RadiansToDegrees(Math.Asin(Math.Sin(Delta) * Math.Sin(DegreesToRadians(27.4)) + Math.Cos(Delta) * Math.Cos(DegreesToRadians(27.4)) * Math.Cos(Alpha)));

            return Galactic;
        }

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

        public static double DegreesToRadians(double Degrees)
        {
            return Degrees * 0.017453292519943295769236907684886;
        }

        public static double RadiansToDegrees(double Radians)
        {
            return Radians * 57.295779513082320876798154814105;
        }

        public static double RadiansToHours(double Radians)
        {
            return Radians * 3.8197186342054880584532103209403;
        }

        public static double HoursToRadians(double Hours)
        {
            return Hours * 0.26179938779914943653855361527329;
        }

        public static double HoursToDegrees(double Hours)
        {
            return Hours * 15;
        }

        public static double DegreesToHours(double Degrees)
        {
            return Degrees / 15;
        }

        public static double PI()
        {
            return 3.1415926535897932384626433832795;
        }

        public static double MapTo0To360Range(double Degrees)
        {
            double Value = Degrees;

            //map it to the range 0 - 360
            while (Value < 0)
                Value += 360;
            while (Value > 360)
                Value -= 360;

            return Value;
        }

        public static double MapTo0To24Range(double HourAngle)
        {
            double Value = HourAngle;

            //map it to the range 0 - 24
            while (Value < 0)
                Value += 24;
            while (Value > 24)
                Value -= 24;

            return Value;
        }
    }
}
