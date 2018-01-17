using Xunit;

namespace AASharp.Tests
{
    public class EclipticalElementsTest
    {
        [Theory]
        [InlineData(47.1220, 151.4486, 45.7481, 2358042.5305, 2433282.4235, 47.137958358613126, 48.60368966442325, 151.47823843363773)]
        [InlineData(11.93911, 186.24444, 334.04096, 2433282.4235, 2451545.0, 11.945236762994311, 334.75005964187261, 186.23351531669641)]
        public void CalculateTest(double i0, double w0, double omega0, double JD0, double JD, double expectedI, double expectedOmega, double expectedW)
        {
            AASEclipticalElementDetails eclipticalElementDetails = AASEclipticalElements.Calculate(i0, w0, omega0, JD0, JD);
            Assert.Equal(expectedI, eclipticalElementDetails.i);
            Assert.Equal(expectedW, eclipticalElementDetails.w);
            Assert.Equal(expectedOmega, eclipticalElementDetails.omega);
        }

        [Theory]
        [InlineData(11.93911, 186.24444, 334.04096, 11.945206561406815, 334.75042895869086, 186.23327459848559)]
        [InlineData(145, 186.24444, 334.04096, 145.00609627453511, 334.73620417536313, 186.24041033090865)]
        public void FK4B1950ToFK5J2000Test(double i0, double w0, double omega0, double expectedI, double expectedOmega, double expectedW)
        {
            AASEclipticalElementDetails eclipticalElementDetails = AASEclipticalElements.FK4B1950ToFK5J2000(i0, w0, omega0);
            Assert.Equal(expectedI, eclipticalElementDetails.i);
            Assert.Equal(expectedW, eclipticalElementDetails.w);
            Assert.Equal(expectedOmega, eclipticalElementDetails.omega);
        }

    }
}