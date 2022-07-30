using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASRiseTransitSet2
    {
        //TODO rename
        public enum Objects
        {
            SUN,
            MOON,
            MERCURY,
            VENUS,
            MARS,
            JUPITER,
            SATURN,
            URANUS,
            NEPTUNE,
            PLUTO,
            STAR
        };

        static void AddEvents(List<AASRiseTransitSetDetails2> events, double LastAltitudeForDetectingRiseSet, double AltitudeForDetectingRiseSet,
            double LastAltitudeForInterpolation, double h0, AAS2DCoordinate Horizontal, double LastJD, double StepInterval, double LastBearing,
            Objects @object, double LastAltitudeForDetectingTwilight, double AltitudeForTwilight)
        {
            if ((@object == Objects.SUN) && (LastAltitudeForDetectingTwilight != -90))
            {
                if ((LastAltitudeForDetectingTwilight < -18) && (AltitudeForTwilight >= -18)) //We have just ended astronomical twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.EndAstronomicalTwilight;
                    double fraction = (-18 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingTwilight < -12) && (AltitudeForTwilight >= -12)) //We have just ended nautical twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.EndNauticalTwilight;
                    double fraction = (-12 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingTwilight < -6) && (AltitudeForTwilight >= -6)) //We have just ended civil twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.EndCivilTwilight;
                    double fraction = (-6 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingTwilight > -18) && (AltitudeForTwilight <= -18)) //We have just started astronomical twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.StartAstronomicalTwilight;
                    double fraction = (-18 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingTwilight > -12) && (AltitudeForTwilight <= -12)) //We have just started nautical twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.StartNauticalTwilight;
                    double fraction = (-12 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingTwilight > -6) && (AltitudeForTwilight <= -6)) //We have just started nautical twilight
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.StartCivilTwilight;
                    double fraction = (-6 - LastAltitudeForInterpolation) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
            }

            if (LastAltitudeForDetectingRiseSet != -90)
            {
                if ((LastAltitudeForDetectingRiseSet < 0) && (AltitudeForDetectingRiseSet >= 0)) //We have just rose above the horizon
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.Rise;
                    double fraction = (0 - LastAltitudeForInterpolation + h0) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((LastAltitudeForDetectingRiseSet > 0) && (AltitudeForDetectingRiseSet <= 0)) //We have just set below the horizon
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.Set;
                    double fraction = (0 - LastAltitudeForInterpolation + h0) / (Horizontal.Y - LastAltitudeForInterpolation);
                    @event.JD = LastJD + (fraction * StepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = LastBearing;
                    double HorizontalX2 = Horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing = AASCoordinateTransformation.MapTo0To360Range(LastBearing2 + (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
            }

            if (LastBearing != -1)
            {
                if ((LastBearing > 270) && (Horizontal.X >= 0) && (Horizontal.X <= 90)) //We have just crossed the southern meridian from east to west
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.SouthernTransit;
                    double fraction = (360 - LastBearing) / (Horizontal.X + (360 - LastBearing));
                    @event.JD = LastJD + (fraction * StepInterval);
                    @event.GeometricAltitude = LastAltitudeForInterpolation + (fraction * (Horizontal.Y - LastAltitudeForInterpolation));
                    @event.bAboveHorizon = (AltitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if ((LastBearing < 90) && (Horizontal.X >= 270) && (Horizontal.X <= 360)
                ) //We have just crossed the southern meridian from west to east
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.SouthernTransit;
                    double fraction = LastBearing / (360 - Horizontal.X + LastBearing);
                    @event.JD = LastJD + (fraction * StepInterval);
                    @event.GeometricAltitude = LastAltitudeForInterpolation + (fraction * (Horizontal.Y - LastAltitudeForInterpolation));
                    @event.bAboveHorizon = (AltitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if ((LastBearing < 180) && (Horizontal.X >= 180)) //We have just crossed the northern meridian from west to east
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.NorthernTransit;
                    double fraction = (180 - LastBearing) / (Horizontal.X - LastBearing);
                    @event.JD = LastJD + (fraction * StepInterval);
                    @event.GeometricAltitude = LastAltitudeForInterpolation + (fraction * (Horizontal.Y - LastAltitudeForInterpolation));
                    @event.bAboveHorizon = (AltitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if ((LastBearing > 180) && (Horizontal.X <= 180)) //We have just crossed the northern meridian from east to west
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.type = AASRiseTransitSetDetails2.Type.NorthernTransit;
                    double fraction = ((LastBearing - 180) / (LastBearing - Horizontal.X));
                    @event.JD = LastJD + (fraction * StepInterval);
                    @event.GeometricAltitude = LastAltitudeForInterpolation + (fraction * (Horizontal.Y - LastAltitudeForInterpolation));
                    @event.bAboveHorizon = (AltitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
            }
        }

        public static List<AASRiseTransitSetDetails2> Calculate(double StartJD, double EndJD, Objects @object, double Longitude, double Latitude, double h0,
            double Height = 0, double StepInterval = 0.007, bool bHighPrecision = false)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();

            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double JD = StartJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastAltitudeForDetectingTwilight = -90;
            double LastBearing = -1;
            while (JD < EndJD)
            {
                AASEllipticalPlanetaryDetails details = new AASEllipticalPlanetaryDetails();
                AAS2DCoordinate Topo;
                switch (@object)
                {
                    case Objects.SUN:
                    {
                        double Long = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
                        double Lat = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat, AASNutation.TrueObliquityOfEcliptic(JD));
                        double SunRad = AASEarth.RadiusVector(JD, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.MOON:
                    {
                        double Long = AASMoon.EclipticLongitude(JD);
                        double Lat = AASMoon.EclipticLatitude(JD);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat, AASNutation.TrueObliquityOfEcliptic(JD));
                        double MoonRad = AASMoon.RadiusVector(JD) / 149597871; //Convert Kms to AUs
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.MERCURY:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MERCURY, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.VENUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.VENUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.MARS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MARS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.JUPITER:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.JUPITER, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.SATURN:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.SATURN, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.URANUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.URANUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.NEPTUNE:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.NEPTUNE, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case Objects.PLUTO:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.PLUTO, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    default:
                        throw new Exception($"{@object} is not a valid object");
                }

                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - Topo.X;
                AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, Topo.Y, Latitude);
                double AltitudeForDetectingRiseSet = (Horizontal.Y - h0);

                //Call the helper method to add any found events
                AddEvents(events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet, LastAltitudeForInterpolation, h0, Horizontal, LastJD,
                    StepInterval, LastBearing, @object, LastAltitudeForDetectingTwilight, Horizontal.Y);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastAltitudeForDetectingTwilight = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += StepInterval;
            }

            return events;
        }

//The higher accuracy version for the moon where the "standard altitude" is not treated as a constant
        static List<AASRiseTransitSetDetails2> CalculateMoon(double StartJD, double EndJD, double Longitude, double Latitude, double Height,
            double StepInterval)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();

            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double JD = StartJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastBearing = -1;
            while (JD < EndJD)
            {
                double Long = AASMoon.EclipticLongitude(JD);
                double Lat = AASMoon.EclipticLatitude(JD);
                AAS2DCoordinate Equatorial = AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat, AASNutation.TrueObliquityOfEcliptic(JD));
                double MoonRad = AASMoon.RadiusVector(JD);
                AAS2DCoordinate Topo =
                    AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad / 149597871, Longitude, Latitude, Height, JD);
                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - Topo.X;
                AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, Topo.Y, Latitude);
                double h0 = 0.7275 * AASMoon.RadiusVectorToHorizontalParallax(MoonRad) - AASCoordinateTransformation.DMSToDegrees(0, 34, 0);
                double AltitudeForDetectingRiseSet = (Horizontal.Y - h0);

                //Call the helper method to add any found events
                AddEvents(events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet, LastAltitudeForInterpolation, h0, Horizontal, LastJD,
                    StepInterval, LastBearing, Objects.MOON, 0, 0);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += StepInterval;
            }

            return events;
        }


//A version for a stationary object such as a star
        static List<AASRiseTransitSetDetails2> CalculateStationary(double StartJD, double EndJD, double Alpha, double Delta, double Longitude,
            double Latitude, double h0, double StepInterval)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();

            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(Longitude);
            double JD = StartJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastBearing = -1;
            while (JD < EndJD)
            {
                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - Alpha;
                AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, Delta, Latitude);
                double AltitudeForDetectingRiseSet = (Horizontal.Y - h0);

                //Call the helper method to add any found event
                AddEvents(events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet, LastAltitudeForInterpolation, h0, Horizontal, LastJD,
                    StepInterval, LastBearing, Objects.STAR, 0, 0);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += StepInterval;
            }

            return events;
        }
    }
}