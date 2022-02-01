using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AASharp
{
    public enum AASRiseSetObject
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
        STAR,
    }

    public enum MoonAlgorithm
    {
        MeeusTruncated = 0,
        ELP2000 = 1,
        ELPMPP02Nominal = 2,
        ELPMPP02LLR = 3,
        ELPMPP02DE405 = 4,
        ELPMPP02DE406 = 5
    };

    public class AASRiseTransitSetDetails2
    {
        public AASRiseTransitSetType Type { get; set; }

        public enum AASRiseTransitSetType
        {
            NotDefined = 0,
            Rise = 1,
            Set = 2,
            SouthernTransit = 3,
            NorthernTransit = 4,
            CivilDusk = 5,
            NauticalDusk = 6,
            AstronomicalDusk = 7,
            AstronomicalDawn = 8,
            NauticalDawn = 9,
            CivilDawn = 10
        }

        public double JD { get; set; }

        public double Bearing { get; set; }

        public double GeometricAltitude { get; set; }

        public bool AboveHorizon { get; set; }
    }

    public class AASRiseTransitSet2
    {
        public static List<AASRiseTransitSetDetails2> Calculate(double startJD, double endJD, AASRiseSetObject @object,
            double longitude, double latitude, double h0, double stepInterval, bool bHighPrecision)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();


            double LongtitudeAsHourAngle =
                AASCoordinateTransformation
                    .DegreesToHours(longitude); //  AA CAACoordinateTransformation::DegreesToHours(Longitude);
            double JD = startJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastAltitudeForDetectingTwilight = -90;
            double LastBearing = -1;
            while (JD < endJD)
            {
                AASEllipticalPlanetaryDetails details;
                AAS2DCoordinate Topo;
                switch (@object)
                {
                    case AASRiseSetObject.SUN:
                    {
                        double Long = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
                        double Lat = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat,
                                AASNutation.TrueObliquityOfEcliptic(JD));
                        double SunRad = AASEarth.RadiusVector(JD, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, SunRad, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.MOON:
                    {
                        double Long = AASMoon.EclipticLongitude(JD);
                        double Lat = AASMoon.EclipticLatitude(JD);
                        AAS2DCoordinate Equatorial =
                            AASCoordinateTransformation.Ecliptic2Equatorial(Long, Lat,
                                AASNutation.TrueObliquityOfEcliptic(JD));
                        double MoonRad = AASMoon.RadiusVector(JD) / 149597871; //Convert Kms to AUs
                        Topo = AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y, MoonRad, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.MERCURY:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MERCURY, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.VENUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.VENUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.MARS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.MARS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.JUPITER:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.JUPITER, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.SATURN:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.SATURN, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.URANUS:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.URANUS, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    case AASRiseSetObject.NEPTUNE:
                    {
                        details = AASElliptical.Calculate(JD, AASEllipticalObject.NEPTUNE, bHighPrecision);
                        Topo = AASParallax.Equatorial2Topocentric(details.ApparentGeocentricRA,
                            details.ApparentGeocentricDeclination, details.ApparentGeocentricDistance, longitude,
                            latitude, 0, JD);
                        break;
                    }
                    default:
                    {
                        throw new InvalidEnumArgumentException("Invalid parameter: 'object'.");
                    }
                }

                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - Topo.X;
                AAS2DCoordinate Horizontal =
                    AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, Topo.Y, latitude);
                double AltitudeForDetectingRiseSet = Horizontal.Y - h0;

                //Call the helper method to add any found events
                AddEvents(ref events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet,
                    LastAltitudeForInterpolation, h0, ref Horizontal, LastJD, stepInterval, LastBearing, @object,
                    LastAltitudeForDetectingTwilight, Horizontal.Y);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastAltitudeForDetectingTwilight = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += stepInterval;
            }

            return events;
        }

        public static void AddEvents(ref List<AASRiseTransitSetDetails2> events, double lastAltitudeForDetectingRiseSet,
            double altitudeForDetectingRiseSet,
            double lastAltitudeForInterpolation, double h0, ref AAS2DCoordinate horizontal, double lastJD,
            double stepInterval, double lastBearing,
            AASRiseSetObject @object, double lastAltitudeForDetectingTwilight, double altitudeForTwilight)
        {
            if ((@object == AASRiseSetObject.SUN) && (lastAltitudeForDetectingTwilight != -90))
            {
                if ((lastAltitudeForDetectingTwilight < -18) && (altitudeForTwilight >= -18))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.AstronomicalDawn;
                    double fraction = (-18 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingTwilight < -12) && (altitudeForTwilight >= -12))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.NauticalDawn;
                    double fraction = (-12 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingTwilight < -6) && (altitudeForTwilight >= -6))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.CivilDawn;
                    double fraction = (-6 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingTwilight > -18) && (altitudeForTwilight <= -18))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.AstronomicalDusk;
                    double fraction = (-18 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingTwilight > -12) && (altitudeForTwilight <= -12))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.NauticalDusk;
                    double fraction = (-12 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingTwilight > -6) && (altitudeForTwilight <= -6))
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.CivilDusk;
                    double fraction = (-6 - lastAltitudeForInterpolation) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
            }

            if (lastAltitudeForDetectingRiseSet != -90)
            {
                if ((lastAltitudeForDetectingRiseSet < 0) &&
                    (altitudeForDetectingRiseSet >= 0)) //We have just rose above the horizon
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.Rise;
                    double fraction = (0 - lastAltitudeForInterpolation + h0) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
                else if ((lastAltitudeForDetectingRiseSet > 0) &&
                         (altitudeForDetectingRiseSet <= 0)) //We have just set below the horizon
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.Set;
                    double fraction = (0 - lastAltitudeForInterpolation + h0) /
                                      (horizontal.Y - lastAltitudeForInterpolation);
                    @event.JD = lastJD + (fraction * stepInterval);

                    //Ensure the LastBearing and Horizontal.X values are correct for interpolation
                    double LastBearing2 = lastBearing;
                    double HorizontalX2 = horizontal.X;
                    if (Math.Abs(HorizontalX2 - LastBearing2) > 180)
                    {
                        if (HorizontalX2 > LastBearing2)
                            LastBearing2 += 360;
                        else
                            HorizontalX2 += 360;
                    }

                    @event.Bearing =
                        AASCoordinateTransformation.MapTo0To360Range(LastBearing2 +
                                                                     (fraction * (HorizontalX2 - LastBearing2)));
                    events.Add(@event);
                }
            }

            if (lastBearing != -1)
            {
                if ((lastBearing > 270) && (horizontal.X >= 0) &&
                    (horizontal.X <= 90)) //We have just crossed the southern meridian from east to west
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.SouthernTransit;
                    double fraction = (360 - lastBearing) / (horizontal.X + (360 - lastBearing));
                    @event.JD = lastJD + (fraction * stepInterval);
                    @event.GeometricAltitude = lastAltitudeForInterpolation +
                                               (fraction * (horizontal.Y - lastAltitudeForInterpolation));
                    @event.AboveHorizon = (altitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if ((lastBearing < 90) && (horizontal.X >= 270) &&
                         (horizontal.X <= 360)) //We have just crossed the southern meridian from west to east
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.SouthernTransit;
                    double fraction = lastBearing / (360 - horizontal.X + lastBearing);
                    @event.JD = lastJD + (fraction * stepInterval);
                    @event.GeometricAltitude = lastAltitudeForInterpolation +
                                               (fraction * (horizontal.Y - lastAltitudeForInterpolation));
                    @event.AboveHorizon = (altitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if
                    ((lastBearing < 180) &&
                     (horizontal.X >= 180)) //We have just crossed the northern meridian from west to east
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.NorthernTransit;
                    double fraction = (180 - lastBearing) / (horizontal.X - lastBearing);
                    @event.JD = lastJD + (fraction * stepInterval);
                    @event.GeometricAltitude = lastAltitudeForInterpolation +
                                               (fraction * (horizontal.Y - lastAltitudeForInterpolation));
                    @event.AboveHorizon = (altitudeForDetectingRiseSet > 0);
                    events.Add(@event);
                }
                else if
                    ((lastBearing > 180) &&
                     (horizontal.X <= 180)) //We have just crossed the northern meridian from east to west
                {
                    AASRiseTransitSetDetails2 @event = new AASRiseTransitSetDetails2();
                    @event.Type = AASRiseTransitSetDetails2.AASRiseTransitSetType.NorthernTransit;
                    double fraction = ((lastBearing - 180) / (lastBearing - horizontal.X));
                    @event.JD = lastJD + (fraction * stepInterval);
                    @event.GeometricAltitude = lastAltitudeForInterpolation +
                                               (fraction * (horizontal.Y - lastAltitudeForInterpolation));
                    @event.AboveHorizon = (altitudeForDetectingRiseSet > 0);
                    @events.Add(@event);
                }
            }
        }


        //The higher accuracy version for the moon where the "standard altitude" is not treated as a constant
        public static List<AASRiseTransitSetDetails2> CalculateMoon(double startJD, double endJD, double longitude,
            double latitude, double refractionAtHorizon, double stepInterval, MoonAlgorithm algorithm)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();

            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double JD = startJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastBearing = -1;
            while (JD < endJD)
            {
                AAS2DCoordinate MoonPos = new AAS2DCoordinate();
                double MoonRad = 0;
                switch (algorithm)
                {
                    case MoonAlgorithm.MeeusTruncated:
                    {
                        MoonPos.X = AASMoon.EclipticLongitude(JD);
                        MoonPos.Y = AASMoon.EclipticLatitude(JD);
                        MoonRad = AASMoon.RadiusVector(JD);
                        break;
                    }
                    case MoonAlgorithm.ELP2000:
                    {
                        throw new NotImplementedException($"{nameof(MoonAlgorithm)}.{nameof(MoonAlgorithm.ELP2000)}");
                        /*
                          MoonPos = AASPrecession.PrecessEcliptic(CAAELP2000::EclipticLongitude(JD), CAAELP2000::EclipticLatitude(JD), 2451545.0, JD);
                          MoonRad = CAAELP2000::RadiusVector(JD);
                          break;
                        */
                    }
                    case MoonAlgorithm.ELPMPP02Nominal:
                    {
                        throw new NotImplementedException(
                            $"{nameof(MoonAlgorithm)}.{nameof(MoonAlgorithm.ELPMPP02Nominal)}");
                        /*
                          MoonPos = AASPrecession.PrecessEcliptic(CAAELPMPP02::EclipticLongitude(JD, CAAELPMPP02::Correction::Nominal), CAAELPMPP02::EclipticLatitude(JD, CAAELPMPP02::Correction::Nominal), 2451545.0, JD);
                          MoonRad = CAAELPMPP02::RadiusVector(JD, CAAELPMPP02::Correction::Nominal);
                          break;
                        */
                    }
                    case MoonAlgorithm.ELPMPP02LLR:
                    {
                        throw new NotImplementedException(
                            $"{nameof(MoonAlgorithm)}.{nameof(MoonAlgorithm.ELPMPP02LLR)}");
                        /*
                          MoonPos = AASPrecession.PrecessEcliptic(CAAELPMPP02::EclipticLongitude(JD, CAAELPMPP02::Correction::LLR), CAAELPMPP02::EclipticLatitude(JD, CAAELPMPP02::Correction::LLR), 2451545.0, JD);
                          MoonRad = CAAELPMPP02::RadiusVector(JD, CAAELPMPP02::Correction::LLR);
                          break;
                        */
                    }
                    case MoonAlgorithm.ELPMPP02DE405:
                    {
                        throw new NotImplementedException(
                            $"{nameof(MoonAlgorithm)}.{nameof(MoonAlgorithm.ELPMPP02DE405)}");
                        /*
                            MoonPos = CAAPrecession::PrecessEcliptic(CAAELPMPP02::EclipticLongitude(JD, CAAELPMPP02::Correction::DE405), CAAELPMPP02::EclipticLatitude(JD, CAAELPMPP02::Correction::DE405), 2451545.0, JD);
                            MoonRad = CAAELPMPP02::RadiusVector(JD, CAAELPMPP02::Correction::DE405);
                            break;
                        */
                    }
                    case MoonAlgorithm.ELPMPP02DE406:
                    {
                        throw new NotImplementedException(
                            $"{nameof(MoonAlgorithm)}.{nameof(MoonAlgorithm.ELPMPP02DE406)}");
                        /*
                          MoonPos = CAAPrecession::PrecessEcliptic(CAAELPMPP02::EclipticLongitude(JD, CAAELPMPP02::Correction::DE406), CAAELPMPP02::EclipticLatitude(JD, CAAELPMPP02::Correction::DE406), 2451545.0, JD);
                          MoonRad = CAAELPMPP02::RadiusVector(JD, CAAELPMPP02::Correction::DE406);
                          break;
                        */
                    }
                    default:
                    {
                        throw new InvalidEnumArgumentException("Invalid parameter: 'algorithm'.");
                    }
                }

                AAS2DCoordinate Equatorial =
                    AASharp.AASCoordinateTransformation.Ecliptic2Equatorial(MoonPos.X, MoonPos.Y,
                        AASNutation.TrueObliquityOfEcliptic(JD));
                AAS2DCoordinate Topo = AASharp.AASParallax.Equatorial2Topocentric(Equatorial.X, Equatorial.Y,
                    MoonRad / 149597871, longitude, latitude, 0, JD);
                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - Topo.X;
                AAS2DCoordinate Horizontal =
                    AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, Topo.Y, latitude);
                double h0 = refractionAtHorizon -
                            AASCoordinateTransformation.RadiansToDegrees(Math.Asin(1737.4 / MoonRad));
                double AltitudeForDetectingRiseSet = (Horizontal.Y - h0);

                //Call the helper method to add any found events
                AddEvents(ref events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet,
                    LastAltitudeForInterpolation, h0, ref Horizontal, LastJD, stepInterval, LastBearing,
                    AASRiseSetObject.MOON, 0, 0);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += stepInterval;
            }

            return events;
        }

        //A version for a stationary object such as a star
        public static List<AASRiseTransitSetDetails2> CalculateStationary(double startJD, double endJD, double alpha,
            double delta, double longitude, double latitude, double h0, double stepInterval)
        {
            //What will be the return value
            List<AASRiseTransitSetDetails2> events = new List<AASRiseTransitSetDetails2>();


            double LongtitudeAsHourAngle = AASCoordinateTransformation.DegreesToHours(longitude);
            double JD = startJD;
            double LastJD = 0;
            double LastAltitudeForDetectingRiseSet = -90;
            double LastAltitudeForInterpolation = -90;
            double LastBearing = -1;
            while (JD < endJD)
            {
                double AST = AASSidereal.ApparentGreenwichSiderealTime(JD);
                double LocalHourAngle = AST - LongtitudeAsHourAngle - alpha;
                AAS2DCoordinate Horizontal =
                    AASharp.AASCoordinateTransformation.Equatorial2Horizontal(LocalHourAngle, delta, latitude);
                double AltitudeForDetectingRiseSet = (Horizontal.Y - h0);

                //Call the helper method to add any found event
                AddEvents(ref events, LastAltitudeForDetectingRiseSet, AltitudeForDetectingRiseSet,
                    LastAltitudeForInterpolation, h0, ref Horizontal, LastJD, stepInterval, LastBearing,
                    AASRiseSetObject.STAR, 0,
                    0);

                //Prepare for the next loop
                LastAltitudeForDetectingRiseSet = AltitudeForDetectingRiseSet;
                LastAltitudeForInterpolation = Horizontal.Y;
                LastBearing = Horizontal.X;
                LastJD = JD;
                JD += stepInterval;
            }

            return events;
        }
    }
}