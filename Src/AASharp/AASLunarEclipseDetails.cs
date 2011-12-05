using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class AASLunarEclipseDetails
    {
        public bool bEclipse { get; set; }
        public double F { get; set; }
        public double gamma { get; set; }
        public double PartialPhasePenumbraSemiDuration { get; set; }
        public double PartialPhaseSemiDuration { get; set; }
        public double PenumbralMagnitude { get; set; }
        public double PenumbralRadii { get; set; }
        public double TimeOfMaximumEclipse { get; set; }
        public double TotalPhaseSemiDuration { get; set; }
        public double u { get; set; }
        public double UmbralMagnitude { get; set; }
        public double UmbralRadii { get; set; }
    }
}
