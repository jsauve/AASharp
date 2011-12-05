using System;
using System.Collections.Generic;
using System.Linq;

namespace AASharp
{
    public class AASGalileanMoonsDetails
    {
        public AASGalileanMoonsDetails()
        {
            Satellite1 = new AASGalileanMoonDetail();
            Satellite2 = new AASGalileanMoonDetail();
            Satellite3 = new AASGalileanMoonDetail();
            Satellite4 = new AASGalileanMoonDetail();
        }

        public AASGalileanMoonDetail Satellite1 { get; set; }
        public AASGalileanMoonDetail Satellite2 { get; set; }
        public AASGalileanMoonDetail Satellite3 { get; set; }
        public AASGalileanMoonDetail Satellite4 { get; set; }
    }
}
