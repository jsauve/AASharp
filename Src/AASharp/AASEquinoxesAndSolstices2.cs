using System.Collections.Generic;

namespace AASharp
{
    /// <summary>
    /// This class uses interpolation to calculate the same details as those provided with the existing AASEquinoxesAndSolstices class.
    /// </summary>
    public static class AASEquinoxesAndSolstices2
    {
        /// <param name="StartJD">The Julian Day corresponding to the Dynamical Time for the date when you want to start the calculation for.</param>
        /// <param name="EndJD">The Julian Day corresponding to the Dynamical Time for the date when you want to end the calculation for.</param>
        /// <param name="StepInterval">The step interval in fractions of days to do the calculation for. The default value of 0.007 corresponds to roughly 10 minutes which is a reasonable tradeoff between performance and accuracy.</param>
        /// <param name="bHighPrecision">If true then use the full VSOP87 theory instead of the truncated version as provided in Meeus's book.</param>
        /// <returns>A list of instances of the class AASEquinoxSolsticeDetails2.</returns>
        public static List<AASEquinoxSolsticeDetails2> Calculate(double StartJD, double EndJD, double StepInterval = 0.007, bool bHighPrecision = false)
        {
            //What will be the return value
            List<AASEquinoxSolsticeDetails2> events = new List<AASEquinoxSolsticeDetails2>();

            double JD = StartJD;
            double LastJD0 = 0;
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
                JD += StepInterval;
            }
            
            return events; 
        }
    }
}