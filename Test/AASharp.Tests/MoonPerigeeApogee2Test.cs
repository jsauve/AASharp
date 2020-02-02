using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class MoonPerigeeApogee2Test
    {
        [Theory]
        //[InlineData(AASMoonPerigeeApogee2.Algorithm.MeeusTruncated, 2458492.6872172798, 406114.10658343369, 2458505.3333187373, 357343.6023941451)]
        //TODO Tests cases to check, following algorithms produce StackOverflowException
        [InlineData(AASMoonPerigeeApogee2.Algorithm.ELP2000, 2458492.6873049531, 406117.4358543175, 2458505.3337862561, 357342.26667280978)]
        //[InlineData(AASMoonPerigeeApogee2.Algorithm.ELPMPP02Nominal, 2458492.6873064428, 406117.38501540705, 2458505.3337862738, 357342.27224775526)]
        //[InlineData(AASMoonPerigeeApogee2.Algorithm.ELPMPP02DE405, 2458492.6873085788, 406117.41804792883, 2458505.333789947, 357342.24787207792)]
        //[InlineData(AASMoonPerigeeApogee2.Algorithm.ELPMPP02DE406, 2458492.6873085829, 406117.4180467485, 2458505.3337899488, 357342.24787600152)]
        //[InlineData(AASMoonPerigeeApogee2.Algorithm.ELPMPP02LLR, 2458492.6873083874, 406117.41825929971, 2458505.3337897616, 357342.24764431961)]
        public void CalculateTest(AASMoonPerigeeApogee2.Algorithm algorithm, double expectedApogeeJD, double expectedApogeeValue, double expectedPerigeeJD, double expectedPerigeeValue)
        {
            double startJD = 2458484.5008011586;
            double endJD = 2458515.5008014492;
            double stepInterval = 0.007;

            List<AASMoonPerigeeApogeeDetails2> result = AASMoonPerigeeApogee2.Calculate(startJD, endJD, stepInterval, algorithm);
            
            var apogee = result.First(e => e.type == AASMoonPerigeeApogeeDetails2.Type.Apogee);
            var perigee = result.First(e => e.type == AASMoonPerigeeApogeeDetails2.Type.Perigee);
            
            Assert.Equal(expectedApogeeJD, apogee.JD);
            Assert.Equal(expectedApogeeValue, apogee.Value);
            Assert.Equal(expectedPerigeeJD, perigee.JD);
            Assert.Equal(expectedPerigeeValue, perigee.Value);
        }
    }
}