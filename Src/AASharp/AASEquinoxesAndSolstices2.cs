using System.Collections.Generic;

namespace AASharp
{
    public static class AASEquinoxesAndSolstices2
    {
        public static List<AASEquinoxSolsticeDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, bool bHighPrecision = false)
        {
            //What will be the return value
            List<AASEquinoxSolsticeDetails2> events = new List<AASEquinoxSolsticeDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
            double LastJD1 = 0;
            double LastLatitude0 = -90;
            double LastLatitude1 = -90;
  
            while (JD < EndJD)
            {
                double lambda = AASSun.ApparentEclipticLongitude(JD, bHighPrecision);
                double beta = AASSun.ApparentEclipticLatitude(JD, bHighPrecision);
                double epsilon = AASNutation.TrueObliquityOfEcliptic(JD);
                AAS2DCoordinate Solarcoord = AASCoordinateTransformation.Ecliptic2Equatorial(lambda, beta, epsilon);
                
                if (LastLatitude0 != -90)
                {
                    if ((LastLatitude0 < 0) && (Solarcoord.Y >= 0))
                    {
                        AASEquinoxSolsticeDetails2 @event = new AASEquinoxSolsticeDetails2();
                        @event.type = AASEquinoxSolsticeDetails2.Type.NorthwardEquinox;
                        double fraction = (0 - LastLatitude0) / (Solarcoord.Y - LastLatitude0);
                        @event.JD = LastJD0 + (fraction * StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastLatitude0 > 0) && (Solarcoord.Y <= 0))
                    {
                        AASEquinoxSolsticeDetails2 @event = new AASEquinoxSolsticeDetails2();
                        @event.type = AASEquinoxSolsticeDetails2.Type.SouthwardEquinox;
                        double fraction = (0 - LastLatitude0) / (Solarcoord.Y - LastLatitude0);
                        @event.JD = LastJD0 + (fraction * StepInterval);
                        events.Add(@event);
                    }
                }
    
                if ((LastLatitude0 != -90) && (LastLatitude1 != -90))
                {
                    if ((LastLatitude0 > Solarcoord.Y) && (LastLatitude0 > LastLatitude1))
                    {
                        AASEquinoxSolsticeDetails2 @event = new AASEquinoxSolsticeDetails2();
                        @event.type = AASEquinoxSolsticeDetails2.Type.NorthernSolstice;
                        double fraction = 0;
                        @event.Declination = AASInterpolate.Extremum(LastLatitude1, LastLatitude0, Solarcoord.Y, ref fraction);
                        @event.JD = JD - StepInterval + (fraction*StepInterval);
                        events.Add(@event);
                    }
                    else if ((LastLatitude0 < Solarcoord.Y) && (LastLatitude0 < LastLatitude1))
                    {
                        AASEquinoxSolsticeDetails2 @event = new AASEquinoxSolsticeDetails2();
                        @event.type = AASEquinoxSolsticeDetails2.Type.SouthernSolstice;
                        double fraction = 0;
                        @event.Declination = AASInterpolate.Extremum(LastLatitude1, LastLatitude0, Solarcoord.Y, ref fraction);
                        @event.JD = JD - StepInterval + (fraction*StepInterval);
                        events.Add(@event);
                    }
                }

                //Prepare for the next loop
                LastLatitude1 = LastLatitude0;
                LastLatitude0 = Solarcoord.Y;
                LastJD0 = JD;
                LastJD1 = LastJD0;
                JD += StepInterval;
            }
            
            return events; 
        }
    }
}