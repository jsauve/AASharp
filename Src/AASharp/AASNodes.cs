using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public class AASNodeObjectDetails
    {
        public double t;
        public double radius;
    }

    public static class AASNodes
    {
        public static AASNodeObjectDetails PassageThroAscendingNode(ref AASEllipticalObjectElements elements)
        {
            double v = AASCoordinateTransformation.MapTo0To360Range(-elements.w);
            v = AASCoordinateTransformation.DegreesToRadians(v);
            double E = Math.Atan(Math.Sqrt((1 - elements.e) / (1 + elements.e)) * Math.Tan(v / 2)) * 2;
            double M = E - elements.e * Math.Sin(E);
            M = AASCoordinateTransformation.RadiansToDegrees(M);
            double n = AASElliptical.MeanMotionFromSemiMajorAxis(elements.a);

            AASNodeObjectDetails details = new AASNodeObjectDetails();
            details.t = elements.T + M / n;
            details.radius = elements.a * (1 - elements.e * Math.Cos(E));

            return details;
        }

        public static AASNodeObjectDetails PassageThroDescendingNode(ref AASEllipticalObjectElements elements)
        {
            double v = AASCoordinateTransformation.MapTo0To360Range(180 - elements.w);
            v = AASCoordinateTransformation.DegreesToRadians(v);
            double E = Math.Atan(Math.Sqrt((1 - elements.e) / (1 + elements.e)) * Math.Tan(v / 2)) * 2;
            double M = E - elements.e * Math.Sin(E);
            M = AASCoordinateTransformation.RadiansToDegrees(M);
            double n = AASElliptical.MeanMotionFromSemiMajorAxis(elements.a);

            AASNodeObjectDetails details = new AASNodeObjectDetails();
            details.t = elements.T + M / n;
            details.radius = elements.a * (1 - elements.e * Math.Cos(E));

            return details;
        }

        public static AASNodeObjectDetails PassageThroAscendingNode(ref AASParabolicObjectElements elements)
        {
            double v = AASCoordinateTransformation.MapTo0To360Range(-elements.w);
            v = AASCoordinateTransformation.DegreesToRadians(v);
            double s = Math.Tan(v / 2);
            double s2 = s * s;

            AASNodeObjectDetails details = new AASNodeObjectDetails();
            details.t = elements.T + 27.403895 * (s2 * s + 3 * s) * elements.q * Math.Sqrt(elements.q);
            details.radius = elements.q * (1 + s2);

            return details;
        }

        public static AASNodeObjectDetails PassageThroDescendingNode(ref AASParabolicObjectElements elements)
        {
            double v = AASCoordinateTransformation.MapTo0To360Range(180 - elements.w);
            v = AASCoordinateTransformation.DegreesToRadians(v);

            double s = Math.Tan(v / 2);
            double s2 = s * s;

            AASNodeObjectDetails details = new AASNodeObjectDetails();
            details.t = elements.T + 27.403895 * (s2 * s + 3 * s) * elements.q * Math.Sqrt(elements.q);
            details.radius = elements.q * (1 + s2);

            return details;
        }
    }
}
