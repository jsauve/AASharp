using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class CAAPhysicalJupiterDetails
    {
        public double DE;
        public double DS;
        public double Geometricw1;
        public double Geometricw2;
        public double Apparentw1;
        public double Apparentw2;
        public double P;
    }

    public static class AASPhysicalJupiter
    {
        public static CAAPhysicalJupiterDetails Calculate(double JD)
        {
            //What will be the return value
            CAAPhysicalJupiterDetails details = new CAAPhysicalJupiterDetails();

            //Step 1
            double d = JD - 2433282.5;
            double T1 = d / 36525;
            double alpha0 = 268.00 + 0.1061 * T1;
            double alpha0rad = AASCoordinateTransformation.DegreesToRadians(alpha0);
            double delta0 = 64.50 - 0.0164 * T1;
            double delta0rad = AASCoordinateTransformation.DegreesToRadians(delta0);

            //Step 2
            double W1 = AASCoordinateTransformation.MapTo0To360Range(17.710 + 877.90003539 * d);
            double W2 = AASCoordinateTransformation.MapTo0To360Range(16.838 + 870.27003539 * d);

            //Step 3
            double l0 = AASEarth.EclipticLongitude(JD);
            double l0rad = AASCoordinateTransformation.DegreesToRadians(l0);
            double b0 = AASEarth.EclipticLatitude(JD);
            double b0rad = AASCoordinateTransformation.DegreesToRadians(b0);
            double R = AASEarth.RadiusVector(JD);

            //Step 4
            double l = AASJupiter.EclipticLongitude(JD);
            double lrad = AASCoordinateTransformation.DegreesToRadians(l);
            double b = AASJupiter.EclipticLatitude(JD);
            double brad = AASCoordinateTransformation.DegreesToRadians(b);
            double r = AASJupiter.RadiusVector(JD);

            //Step 5
            double x = r * Math.Cos(brad) * Math.Cos(lrad) - R * Math.Cos(l0rad);
            double y = r * Math.Cos(brad) * Math.Sin(lrad) - R * Math.Sin(l0rad);
            double z = r * Math.Sin(brad) - R * Math.Sin(b0rad);
            double DELTA = Math.Sqrt(x * x + y * y + z * z);

            //Step 6
            l -= 0.012990 * DELTA / (r * r);
            lrad = AASCoordinateTransformation.DegreesToRadians(l);

            //Step 7
            x = r * Math.Cos(brad) * Math.Cos(lrad) - R * Math.Cos(l0rad);
            y = r * Math.Cos(brad) * Math.Sin(lrad) - R * Math.Sin(l0rad);
            z = r * Math.Sin(brad) - R * Math.Sin(b0rad);
            DELTA = Math.Sqrt(x * x + y * y + z * z);

            //Step 8
            double e0 = AASNutation.MeanObliquityOfEcliptic(JD);
            double e0rad = AASCoordinateTransformation.DegreesToRadians(e0);

            //Step 9
            double alphas = Math.Atan2(Math.Cos(e0rad) * Math.Sin(lrad) - Math.Sin(e0rad) * Math.Tan(brad), Math.Cos(lrad));
            double deltas = Math.Asin(Math.Cos(e0rad) * Math.Sin(brad) + Math.Sin(e0rad) * Math.Cos(brad) * Math.Sin(lrad));

            //Step 10
            details.DS = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(-Math.Sin(delta0rad) * Math.Sin(deltas) - Math.Cos(delta0rad) * Math.Cos(deltas) * Math.Cos(alpha0rad - alphas)));

            //Step 11
            double u = y * Math.Cos(e0rad) - z * Math.Sin(e0rad);
            double v = y * Math.Sin(e0rad) + z * Math.Cos(e0rad);
            double alpharad = Math.Atan2(u, x);
            double alpha = AASCoordinateTransformation.RadiansToDegrees(alpharad);
            double deltarad = Math.Atan2(v, Math.Sqrt(x * x + u * u));
            double delta = AASCoordinateTransformation.RadiansToDegrees(deltarad);
            double xi = Math.Atan2(Math.Sin(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad) - Math.Sin(deltarad) * Math.Cos(delta0rad), Math.Cos(deltarad) * Math.Sin(alpha0rad - alpharad));

            //Step 12
            details.DE = AASCoordinateTransformation.RadiansToDegrees(Math.Asin(-Math.Sin(delta0rad) * Math.Sin(deltarad) - Math.Cos(delta0rad) * Math.Cos(deltarad) * Math.Cos(alpha0rad - alpharad)));

            //Step 13
            details.Geometricw1 = AASCoordinateTransformation.MapTo0To360Range(W1 - AASCoordinateTransformation.RadiansToDegrees(xi) - 5.07033 * DELTA);
            details.Geometricw2 = AASCoordinateTransformation.MapTo0To360Range(W2 - AASCoordinateTransformation.RadiansToDegrees(xi) - 5.02626 * DELTA);

            //Step 14
            double C = 57.2958 * (2 * r * DELTA + R * R - r * r - DELTA * DELTA) / (4 * r * DELTA);
            if (Math.Sin(lrad - l0rad) > 0)
            {
                details.Apparentw1 = AASCoordinateTransformation.MapTo0To360Range(details.Geometricw1 + C);
                details.Apparentw2 = AASCoordinateTransformation.MapTo0To360Range(details.Geometricw2 + C);
            }
            else
            {
                details.Apparentw1 = AASCoordinateTransformation.MapTo0To360Range(details.Geometricw1 - C);
                details.Apparentw2 = AASCoordinateTransformation.MapTo0To360Range(details.Geometricw2 - C);
            }

            //Step 15
            double NutationInLongitude = AASNutation.NutationInLongitude(JD);
            double NutationInObliquity = AASNutation.NutationInObliquity(JD);
            e0 += NutationInObliquity / 3600;
            e0rad = AASCoordinateTransformation.DegreesToRadians(e0);

            //Step 16
            alpha += 0.005693 * (Math.Cos(alpharad) * Math.Cos(l0rad) * Math.Cos(e0rad) + Math.Sin(alpharad) * Math.Sin(l0rad)) / Math.Cos(deltarad);
            alpha = AASCoordinateTransformation.MapTo0To360Range(alpha);
            alpharad = AASCoordinateTransformation.DegreesToRadians(alpha);
            delta += 0.005693 * (Math.Cos(l0rad) * Math.Cos(e0rad) * (Math.Tan(e0rad) * Math.Cos(deltarad) - Math.Sin(alpharad) * Math.Sin(deltarad)) + Math.Cos(alpharad) * Math.Sin(deltarad) * Math.Sin(l0rad));

            //Step 17
            double NutationRA = AASNutation.NutationInRightAscension(alpha / 15, delta, e0, NutationInLongitude, NutationInObliquity);
            double alphadash = alpha + NutationRA / 3600;
            double alphadashrad = AASCoordinateTransformation.DegreesToRadians(alphadash);
            double NutationDec = AASNutation.NutationInDeclination(alpha / 15, e0, NutationInLongitude, NutationInObliquity);
            double deltadash = delta + NutationDec / 3600;
            double deltadashrad = AASCoordinateTransformation.DegreesToRadians(deltadash);
            NutationRA = AASNutation.NutationInRightAscension(alpha0 / 15, delta0, e0, NutationInLongitude, NutationInObliquity);
            double alpha0dash = alpha0 + NutationRA / 3600;
            double alpha0dashrad = AASCoordinateTransformation.DegreesToRadians(alpha0dash);
            NutationDec = AASNutation.NutationInDeclination(alpha0 / 15, e0, NutationInLongitude, NutationInObliquity);
            double delta0dash = delta0 + NutationDec / 3600;
            double delta0dashrad = AASCoordinateTransformation.DegreesToRadians(delta0dash);

            //Step 18
            details.P = AASCoordinateTransformation.MapTo0To360Range(AASCoordinateTransformation.RadiansToDegrees(Math.Atan2(Math.Cos(delta0dashrad) * Math.Sin(alpha0dashrad - alphadashrad), Math.Sin(delta0dashrad) * Math.Cos(deltadashrad) - Math.Cos(delta0dashrad) * Math.Sin(deltadashrad) * Math.Cos(alpha0dashrad - alphadashrad))));

            return details;
        }
    }
}
