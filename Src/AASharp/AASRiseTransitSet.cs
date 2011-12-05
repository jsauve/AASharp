using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASRiseTransitSetDetails
    {
        public AASRiseTransitSetDetails()
        {
        }

        public bool bRiseValid { get; set; }
        public double Rise { get; set; }
        public bool bTransitAboveHorizon { get; set; }
        public double Transit { get; set; }
        public bool bSetValid { get; set; }
        public double Set { get; set; }
    }

    public static class AASRiseTransitSet
    {
        public static AASRiseTransitSetDetails Calculate(double JD, double Alpha1, double Delta1, double Alpha2, double Delta2, double Alpha3, double Delta3, double Longitude, double Latitude, double h0)
        {
            //What will be the return value
            AASRiseTransitSetDetails details = new AASRiseTransitSetDetails();
            details.bRiseValid = false;
            details.bSetValid = false;
            details.bTransitAboveHorizon = false;

            //Calculate the sidereal time
            double theta0 = AASSidereal.ApparentGreenwichSiderealTime(JD);
            theta0 *= 15; //Express it as degrees

            //Calculate deltat
            double deltaT = AASDynamicalTime.DeltaT(JD);

            //Convert values to radians
            double Delta2Rad = AASCoordinateTransformation.DegreesToRadians(Delta2);
            double LatitudeRad = AASCoordinateTransformation.DegreesToRadians(Latitude);

            //Convert the standard latitude to radians
            double h0Rad = AASCoordinateTransformation.DegreesToRadians(h0);

            double cosH0 = (Math.Sin(h0Rad) - Math.Sin(LatitudeRad) * Math.Sin(Delta2Rad)) / (Math.Cos(LatitudeRad) * Math.Cos(Delta2Rad));

            //Calculate and ensure the M0 is in the range 0 to +1
            double M0 = (Alpha2 * 15 + Longitude - theta0) / 360;
            while (M0 > 1)
                M0 -= 1;
            while (M0 < 0)
                M0 += 1;

            //Check that the object actually rises
            double M1 = 0;
            double M2 = 0;
            if ((cosH0 > -1) && (cosH0 < 1))
            {
                details.bRiseValid = true;
                details.bSetValid = true;
                details.bTransitAboveHorizon = true;

                double H0 = Math.Acos(cosH0);
                H0 = AASCoordinateTransformation.RadiansToDegrees(H0);

                //Calculate and ensure the M1 and M2 is in the range 0 to +1
                M1 = M0 - H0 / 360;
                M2 = M0 + H0 / 360;

                while (M1 > 1)
                    M1 -= 1;
                while (M1 < 0)
                    M1 += 1;

                while (M2 > 1)
                    M2 -= 1;
                while (M2 < 0)
                    M2 += 1;
            }
            else
                if (cosH0 < 1)
                    details.bTransitAboveHorizon = true;

            //Ensure the RA values are corrected for interpolation. Due to important Remark 2 by Meeus on Interopolation of RA values
            if ((Alpha2 - Alpha1) > 12.0)
                Alpha1 += 24;
            else
                if ((Alpha2 - Alpha1) < -12.0)
                    Alpha2 += 24;
            if ((Alpha3 - Alpha2) > 12.0)
                Alpha2 += 24;
            else
                if ((Alpha3 - Alpha2) < -12.0)
                    Alpha3 += 24;

            for (int i = 0; i < 2; i++)
            {
                //Calculate the details of rising
                if (details.bRiseValid)
                {
                    double theta1 = theta0 + 360.985647 * M1;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M1 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);
                    double Delta = AASInterpolate.Interpolate(n, Delta1, Delta2, Delta3);

                    double H = theta1 - Longitude - Alpha * 15;
                    AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(H / 15, Delta, Latitude);

                    double DeltaM = (Horizontal.Y - h0) / (360 * Math.Cos(AASCoordinateTransformation.DegreesToRadians(Delta)) * Math.Cos(LatitudeRad) * Math.Sin(AASCoordinateTransformation.DegreesToRadians(H)));
                    M1 += DeltaM;
                }

                //Calculate the details of setting
                if (details.bSetValid)
                {
                    double theta1 = theta0 + 360.985647 * M2;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M2 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);
                    double Delta = AASInterpolate.Interpolate(n, Delta1, Delta2, Delta3);

                    double H = theta1 - Longitude - Alpha * 15;
                    AAS2DCoordinate Horizontal = AASCoordinateTransformation.Equatorial2Horizontal(H / 15, Delta, Latitude);

                    double DeltaM = (Horizontal.Y - h0) / (360 * Math.Cos(AASCoordinateTransformation.DegreesToRadians(Delta)) * Math.Cos(LatitudeRad) * Math.Sin(AASCoordinateTransformation.DegreesToRadians(H)));
                    M2 += DeltaM;
                }

                {
                    //Calculate the details of transit
                    double theta1 = theta0 + 360.985647 * M0;
                    theta1 = AASCoordinateTransformation.MapTo0To360Range(theta1);

                    double n = M0 + deltaT / 86400;

                    double Alpha = AASInterpolate.Interpolate(n, Alpha1, Alpha2, Alpha3);

                    double H = theta1 - Longitude - Alpha * 15;
                    H = AASCoordinateTransformation.MapTo0To360Range(H);
                    if (H > 180)
                        H -= 360;

                    double DeltaM = -H / 360;
                    M0 += DeltaM;
                }
            }

            details.Rise = details.bRiseValid ? (M1 * 24) : 0.0;
            details.Set = details.bSetValid ? (M2 * 24) : 0.0;
            details.Transit = M0 * 24; //We always return the transit time even if it occurs below the horizon

            return details;
        }
    }
}
