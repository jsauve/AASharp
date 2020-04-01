using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class MoonPerigeeApogee2Test
    {
        [Theory]
        [InlineData(AASMoonPerigeeApogee2.Algorithm.MeeusTruncated, 2458492.6872172798, 406114.10658343369, 2458505.3333187373, 357343.6023941451)]
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