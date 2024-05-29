using System;

namespace AASharp
{
    /// <summary>
    /// This class provides for calculation of the time of passages from the orbital elements of a planet or comet through the nodes of its orbit. This refers to Chapter 39 in the book.
    /// </summary>
    public static class AASNodes
    {
        /// <param name="elements">An instance of the AASEllipticalObjectElements class containing the orbital elements.</param>
        /// <returns>An instance of AASNodeObjectDetails class with the details.</returns>
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

        /// <param name="elements">An instance of the AASEllipticalObjectElements class containing the orbital elements.</param>
        /// <returns>An instance of AASNodeObjectDetails class with the details.</returns>
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

        /// <param name="elements">An instance of the AASParabolicObjectElements class containing the orbital elements.</param>
        /// <returns>An instance of AASNodeObjectDetails class with the details.</returns>
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

        /// <param name="elements">An instance of the AASParabolicObjectElements class containing the orbital elements.</param>
        /// <returns>An instance of AASNodeObjectDetails class with the details.</returns>
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
