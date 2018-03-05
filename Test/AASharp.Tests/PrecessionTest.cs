using Xunit;

namespace AASharp.Tests
{
    public class PrecessionTest
    {
        [Theory]
        [InlineData(2.7369374156837019, 49.227748999730018, 2451545, 2462088.69, 2.7698141731675268, 49.348482112865824)]
        public void PrecessEquatorialTest(double alpha, double delta, double jd0, double jd, double expectedX, double expectedY)
        {
            AAS2DCoordinate precessed = AASPrecession.PrecessEquatorial(alpha, delta, jd0, jd);
            Assert.Equal(expectedX, precessed.X);
            Assert.Equal(expectedY, precessed.Y);
        }

        [Fact]
        public void EquatorialPmToEclipticTest()
        {
            AAS2DCoordinate pm = AASPrecession.EquatorialPMToEcliptic(0, 0, 0, 1, 1, 23);
            Assert.Equal(1.3112359819417141, pm.X);
            Assert.Equal(0.52977372496316666, pm.Y);
        }


        [Theory]
        [InlineData(2.64, -7.6, -1000, 6.7524641666666669, -16.716108333333331, -0.03847, -1.2053, 6.7631002602340775, -16.382229594821446)]
        public void AdjustPositionUsingMotionInSpaceTest(double r, double deltaR, double t, double alpha, double delta, double pmAlpha, double pmDelta, double expectedX, double expectedY)
        {
            var pa = AASPrecession.AdjustPositionUsingMotionInSpace(r, deltaR, t, alpha, delta, pmAlpha, pmDelta);
            Assert.Equal(expectedX, pa.X);
            Assert.Equal(expectedY, pa.Y);
        }

        [Theory]
        [InlineData((2462088.69 - 2451545) / 365.25, 2.7366627777777777, 49.228466666666669, 0.03425, -0.0895, 2.7369374156837019, 49.227748999730018)]
        [InlineData((2415020.3135 - 2451545) / 365.25, 2.5301955555555553, 89.264088888888892, 0.19877, -0.0152, 2.5246742140576428, 89.26451110748711)]
        [InlineData(-1000, 6.7524641666666669, -16.716108333333331, -0.03847, -1.2053, 6.7631502777777781, -16.381302777777776)]
        [InlineData(-12000, 6.7524641666666669, -16.716108333333331, -0.03847, -1.2053, 6.8806975, -12.698441666666664)]
        public void AdjustPositionUsingUniformProperMotionTest(double t, double alpha, double delta, double PMAlpha, double PMDelta, double expectedX, double expectedY)
        {
            AAS2DCoordinate pa = AASPrecession.AdjustPositionUsingUniformProperMotion(t, alpha, delta, PMAlpha, PMDelta);
            Assert.Equal(expectedX, pa.X);
            Assert.Equal(expectedY, pa.Y);
           
        }
    }
}