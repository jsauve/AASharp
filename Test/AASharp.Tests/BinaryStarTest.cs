using Xunit;

namespace AASharp.Tests
{
    public class BinaryStarTest
    {
        [Theory]
        [InlineData(1980, 41.623, 1934.008, 0.2763, 0.907, 59.025, 23.717, 219.907, 0.74556816470441822, 0.41101776646245863, 318.42425648604956)]
        public void CalculateTest(double t, double P, double T, double e, double a, double i, double omega, double w, double expectedR, double expectedRho, double expectedTheta)
        {
            AASBinaryStarDetails bsdetails = AASBinaryStar.Calculate(t, P, T, e, a, i, omega, w);
            Assert.Equal(expectedR, bsdetails.r);
            Assert.Equal(expectedRho, bsdetails.Rho);
            Assert.Equal(expectedTheta, bsdetails.Theta);
        }


        [Theory]
        [InlineData(0.2763, 59.025, 219.907, 0.85993743694935332)]
        public void ApparentEccentricityTest(double e, double i, double w, double expectedApparentEccentricity)
        {
            double apparentEccentricity = AASBinaryStar.ApparentEccentricity(e, i, w);
            Assert.Equal(expectedApparentEccentricity, apparentEccentricity);
        }
    }
}