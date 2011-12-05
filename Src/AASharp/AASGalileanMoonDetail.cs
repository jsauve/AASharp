using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class AASGalileanMoonDetail
    {
        public AASGalileanMoonDetail()
        {
            TrueRectangularCoordinates = new AAS3DCoordinate();
            ApparentRectangularCoordinates = new AAS3DCoordinate();
        }

        public double MeanLongitude;
        public double TrueLongitude;
        public double TropicalLongitude;
        public double EquatorialLatitude;
        public double r;
        public AAS3DCoordinate TrueRectangularCoordinates;
        public AAS3DCoordinate ApparentRectangularCoordinates;
        public bool bInTransit;
        public bool bInOccultation;
        public bool bInEclipse;
        public bool bInShadowTransit;
    }
}
