using System;

namespace AASharp.Constellations
{
    public class ConstellationsBoundary
    {
        public ConstellationsBoundary(double lowerRightAscension, double upperRightAscension, double lowerDeclination,
            string constellationAbbreviation)
        {
            LowerRightAscension = lowerRightAscension;
            UpperRightAscension = upperRightAscension;
            LowerDeclination = lowerDeclination;
            ConstellationAbbreviation = constellationAbbreviation ?? throw new ArgumentNullException(nameof(constellationAbbreviation));
        }

        public double LowerRightAscension { get; }
        public double UpperRightAscension { get; }
        public double LowerDeclination { get; }
        public string ConstellationAbbreviation { get; }
    }
}