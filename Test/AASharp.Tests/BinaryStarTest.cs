using Xunit;

namespace AASharp.Tests
{
    public class BinaryStarTest
    {
        [Fact]
        public void CalculateTest()
        {
            AASBinaryStarDetails bsdetails = AASBinaryStar.Calculate(1980, 41.623, 1934.008, 0.2763, 0.907, 59.025, 23.717, 219.907);
            Assert.Equal(0.74556816470441822, bsdetails.r);
            Assert.Equal(0.41101776646245863, bsdetails.Rho);
            Assert.Equal(318.42425648604956, bsdetails.Theta);
        }


        [Fact]
        public void ApparentEccentricityTest()
        {
            double apparentE = AASBinaryStar.ApparentEccentricity(0.2763, 59.025, 219.907);
            Assert.Equal(0.85993743694935332, apparentE);
        }
    }
}