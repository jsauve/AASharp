using System;
using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class provides for revised algorithms to address issues with the existing AASRiseTransitSet class which as of v2.02 is now considered deprecated. This class and its methods are designed as an improvement on the AASRiseTransitSet class algorithms as provided by in the book. In Q3 2019, some users of AA+ reported that if you used the existing class with a location of either the North or South Poles, that it would fail to find the single sun rise and set times during a whole year. At the poles of course there is just one sun rise and one sun set per year. Each of these events occur quite close to the Equinoxes. Following a private email conversation with Jean Meeus, he confirmed that the AASRiseTransitSet algorithms as presented in the book fail under certain circumstances. In fact the issues which have been reported with this class over the years are almost all a result of the deficiencies of Meeus's algorithms for calculating rise / transit and set. This class is a ground up rewrite with a new step based interpolation algorithm. They will work for any Dynamical Time date range and as such will handle the issue of looking for events when referred to a local time zone day range. It will also detect all types of events during the requested search interval. It will also return northern transits in addition to southern transits and can return multiple occurrences of the same type of event in a 24 hour interval. The code has also been extensively tested for various locations such as the North Pole, South Pole etc. and spot checked against other sources. This class will also return the altitude of transit events and the bearing / azimuth at which rise and set events occur.
    /// </summary>
    public static class AASRiseTransitSet2
    {
        static void AddEvents(List<AASRiseTransitSetDetails2> events, double LastAltitudeForDetectingRiseSet, double AltitudeForDetectingRiseSet,
            double LastAltitudeForInterpolation, double h0, AAS2DCoordinate Horizontal, double LastJD, double StepInterval, double LastBearing,
            AASRiseSetObject @object, double LastAltitudeForDetectingTwilight, double AltitudeForTwilight)
        {
            if ((@object == AASRiseSetObject.SUN) && (LastAltitudeForDetectingTwilight != -90))
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

        /// <summary>
        /// Set is defined when the apparent top edge of the object is exacly on the horizon and the altitude of the object is decreasing.
        /// <para>
        /// Rise is defined when the apparent top edge of the object is exacly on the horizon and the altitude of the object is increasing.
        /// </para>
        /// <para>
        /// Civil Dusk is defined when the geometric center of the Sun is 6 degress below the horizon and the altitude of the Sun is decreasing (i.e. in the local evening time after the Sun has set).
        /// </para>
        /// <para>
        /// Nautical Dusk is defined when the geometric center of the Sun is 12 degress below the horizon and the altitude of the Sun is decreasing (i.e. in the local evening time after the Sun has set).
        /// </para>
        /// <para>
        /// Astronomical Dusk is defined when the geometric center of the Sun is 18 degress below the horizon and the altitude of the Sun is decreasing (i.e. in the local evening time after the Sun has set).
        /// </para>
        /// <para>
        /// Civil Dawn is defined when the geometric center of the Sun is 6 degress below the horizon and the altitude of the Sun is increasing (i.e. in the local morning time before the Sun has risen).
        /// </para>
        /// <para>
        /// Nautical Dawn is defined when the geometric center of the Sun is 12 degress below the horizon and the altitude of the Sun is increasing (i.e. in the local morning time before the Sun has risen).
        /// </para>
        /// <para>
        /// Astronomical Dawn is defined when the geometric center of the Sun is 18 degress below the horizon and the altitude of the Sun is increasing (i.e. in the local morning time before the Sun has risen).
        /// </para>
        /// <para>
        /// Please note that this method calculates the times of dusk and dawn for an observer at sea level and does not take atmospheric refraction or altitude of the observer into account. This is unlike the calculation of rise and set which does take this into account due to the presence and usage of the h0 parameter.
        /// </para>
        /// </summary>
        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="object">The object type you want to calculate for. This is an enum class of type Object inside the AASRiseTransitSet2 class and can be SUN, MOON, MERCURY, VENUS, MARS, JUPITER, SATURN, URANUS, or NEPTUNE.</param>
        /// <param name="Longitude">The geographic longitude of the observer in degrees (Positive west, negative east from Greenwich).</param>
        /// <param name="Latitude">The geographic latitude of the observer in degrees.</param>
        /// <param name="h0">The "standard" altitude in degrees i.e. the geometric altitude of the center of the body at the time of the apparent rising or setting. For stars and planets, you would normally use -0.5667, for the Sun you would use -0.8333 and for the Moon you would use -0.825. The value to use for the Moon should be -0.825 and not 0.125 as described in Meeus's book. This is because this method already applies parallax corrections for the Moon when converting the geocentric position of the Moon to topocentric coordinates. If you would like to take atmospheric pressure &amp; temperature into account for the amount of refraction to use for this parameter, you can use the AASRefraction class to calculate a custom value. If you would like to take the altitude of the observer into account for calculating Sun rise and Sun sets (such as an observer flying in a plane), then you could use the formulae: double H0 = -0.8333 - AASCoordinateTransformation.RadiansToDegrees(acos(6371008 / (6371008 + Height))) where Height is the altitude above sea-level in meters (assuming you also do not want to account for variable temperature and pressure). For the moon you could use: double H0 = -0.825 - AASCoordinateTransformation.RadiansToDegrees(acos(6371008 / (6371008 + Height))).</param>
        /// <param name="Height">TBD</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy for calculating rise / transit and set times.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book. This parameter is not used if you specify Moon for the "object" parameter. This parameter is only used when calculating events for the Sun or planets. This method always uses the truncated Meeus ELP2000 theory when calculating events for the Moon. If you would like to specify the theory used to calculate the position of the Moon to find events, you can use the CalculateMoon method.</param>
        /// <returns>A list of AASRiseTransitSetDetails2 instances with the details.</returns>
        /// <exception cref="Exception"></exception>
        public static List<AASRiseTransitSetDetails2> Calculate(double StartJD, double EndJD, AASRiseSetObject @object, double Longitude, double Latitude, double h0,
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
                    case AASRiseSetObject.SUN:
                    {
                        double Long = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
                        double Lat = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat, AASNutation.TrueObliquityOfEcliptic(JD));
                        double SunRad = AASEarth.RadiusVector(JD, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.MOON:
                    {
                        double Long = AASMoon.EclipticLongitude(JD);
                        double Lat = AASMoon.EclipticLatitude(JD);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat, AASNutation.TrueObliquityOfEcliptic(JD));
                        double MoonRad = AASMoon.RadiusVector(JD) / 149597871; //Convert Kms to AUs
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.MERCURY:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MERCURY, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.VENUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.VENUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.MARS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MARS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.JUPITER:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.JUPITER, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.SATURN:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.SATURN, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.URANUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.URANUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.NEPTUNE:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.NEPTUNE, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA, details.ApparentGeocentricDeclination,
                            details.ApparentGeocentricDistance, Longitude, Latitude, Height, JD);
                        break;
                    }
                    case AASRiseSetObject.PLUTO:
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
        /// <summary>
        /// This version of the algorithm provides a higher precision method to calculate the rise / transit and set times of the Moon compared to the Calculate method. This is necessary because the "standard" altitude value for the Moon is not constant and depends significantly on the Moon's distance / parallax as well as the "RefractionAtHorizon" parameter. Internally this method calculates the apparent topocentric semidiameter of the moon in degrees and subtracts that value from the RefractionAtHorizon parameter to arrive at the "standard" altitude used to calculate events. In addition this method allows you to specify the theory to use to calculate the position of the Moon.
        /// </summary>
        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="Longitude">The geographic longitude of the observer in degrees (Positive west, negative east from Greenwich).</param>
        /// <param name="Latitude">The geographic latitude of the observer in degrees.</param>
        /// <param name="Height">TBD</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy for calculating rise / transit and set times.</param>
        /// <returns>A list of AASRiseTransitSetDetails2 instances with the details.</returns>
        public static List<AASRiseTransitSetDetails2> CalculateMoon(double StartJD, double EndJD, double Longitude, double Latitude, double Height,
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
                    StepInterval, LastBearing, AASRiseSetObject.MOON, 0, 0);

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
        /// <summary>
        /// This version of the algorithm allows you to calculate the rise / transit and set times of an object which is stationary in the sky with fixed Right Ascension and Declination e.g. a star.
        /// </summary>
        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="Alpha">The right ascension of the object expressed as decimal hours.</param>
        /// <param name="Delta">The declination of the object in degrees.</param>
        /// <param name="Longitude">The geographic longitude of the observer in degrees (Positive west, negative east from Greenwich).</param>
        /// <param name="Latitude">The geographic latitude of the observer in degrees.</param>
        /// <param name="h0">The "standard" altitude in degrees i.e. the geometric altitude of the center of the body at the time of the apparent rising or setting. This defaults to -0.5667 which is appropriate for a star. If you would like to take atmospheric pressure &amp; temperature into account for the amount of refraction to use for this parameter, you can use the AASRefraction class to calculate a custom value. If you would like to take the altitude of the observer into account for calculating rise and sets (such as an observer flying in a plane), then you could use the formulae: double h0 = -0.5667 - AASCoordinateTransformation.RadiansToDegrees(acos(6371008 / (6371008 + Height))) where Height is the altitude above sea-level in meters (assuming you also do not want to account for variable temperature and pressure).</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy for calculating rise / transit and set times.</param>
        /// <returns>A list of AASRiseTransitSetDetails2 instances with the details.</returns>
        public static List<AASRiseTransitSetDetails2> CalculateStationary(double StartJD, double EndJD, double Alpha, double Delta, double Longitude,
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
                    StepInterval, LastBearing, AASRiseSetObject.STAR, 0, 0);

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