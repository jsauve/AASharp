using System;
using System.Collections.Generic;

namespace AASharp
{
    public static class AASMoonPhases2
    {
        public enum Algorithm
        {
            MeeusTruncated = 0
        }

        public static List<AASMoonPhasesDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007,
            Algorithm algorithm = Algorithm.MeeusTruncated)
        {
            //What will be the return value
            List<AASMoonPhasesDetails2> events = new List<AASMoonPhasesDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastExcessApparentGeocentricLongitude = -360;
            while (JD < EndJD)
            {
                double ExcessApparentGeocentricLongitude = 0;
                AAS2DCoordinate MoonPos;
                switch (algorithm)
                {
                    case Algorithm.MeeusTruncated:
                        ExcessApparentGeocentricLongitude = AASCoordinateTransformation.MapTo0To360Range(AASMoon.EclipticLongitude(JD) - AASSun.ApparentEclipticLongitude(JD, false));
                        break;

                    default:
                        throw new Exception($"{algorithm} is not a valid value");
                }

                if (LastExcessApparentGeocentricLongitude != -360)
                {
                    if ((LastExcessApparentGeocentricLongitude > 270) && (ExcessApparentGeocentricLongitude >= 0) && (ExcessApparentGeocentricLongitude < 90))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.NewMoon;
                        double fraction = (360 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude + (360 - LastExcessApparentGeocentricLongitude));
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                    }
                     if ((LastExcessApparentGeocentricLongitude< 90) && (ExcessApparentGeocentricLongitude >= 90))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.FirstQuarter;
                        double fraction = (90 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                     }
                     else if ((LastExcessApparentGeocentricLongitude< 180) && (ExcessApparentGeocentricLongitude >= 180))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.FullMoon;
                        double fraction = (180 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastExcessApparentGeocentricLongitude< 270) && (ExcessApparentGeocentricLongitude >= 270))
                    {
                        AASMoonPhasesDetails2 @event = new AASMoonPhasesDetails2();
                        @event.type = AASMoonPhasesDetails2.Type.LastQuarter;
                        double fraction = (270 - LastExcessApparentGeocentricLongitude) / (ExcessApparentGeocentricLongitude - LastExcessApparentGeocentricLongitude);
                        @event.JD = LastJD0 + (fraction* StepInterval);
                        events.Add(@event);
                     }
                }
                
                //Prepare for the next loop
                LastExcessApparentGeocentricLongitude = ExcessApparentGeocentricLongitude;
                LastJD0 = JD;
                JD += StepInterval;
            }

            return events;
        }
    }
}