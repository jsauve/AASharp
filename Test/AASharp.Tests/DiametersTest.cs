using Xunit;
 
namespace AASharp.Tests 
{
    public class DiametersTest
    {
        [Theory]
        [InlineData(1, 959.63)]
        [InlineData(2, 479.815)]
        public void SunSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.SunSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 3.34)]
        [InlineData(2, 1.67)]
        public void MercurySemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.MercurySemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 3.36)]
        [InlineData(2, 1.68)]
        public void MercurySemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.MercurySemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }
        
        [Theory]
        [InlineData(1, 8.41)]
        [InlineData(2, 4.205)]
        public void VenusSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.VenusSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 8.34)]
        [InlineData(2, 4.17)]
        public void VenusSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.VenusSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 4.68)]
        [InlineData(2, 2.34)]
        public void MarsSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.MarsSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 4.68)]
        [InlineData(2, 2.34)]
        public void MarsSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.MarsSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 98.47)]
        [InlineData(2, 49.235)]
        public void JupiterSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.JupiterEquatorialSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 98.44)]
        [InlineData(2, 49.22)]
        public void JupiterSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.JupiterEquatorialSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 91.91)]
        [InlineData(2, 45.955)]
        public void JupiterPolarSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.JupiterPolarSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 92.06)]
        [InlineData(2, 46.03)]
        public void JupiterPolarSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.JupiterPolarSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 83.33)]
        [InlineData(2, 41.665)]
        public void SaturnSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.SaturnEquatorialSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 82.73)]
        [InlineData(2, 41.365)]
        public void SaturnSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.SaturnEquatorialSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 74.57)]
        [InlineData(2, 37.285)]
        public void SaturnPolarSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.SaturnPolarSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 73.82)]
        [InlineData(2, 36.91)]
        public void SaturnPolarSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.SaturnPolarSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 16.442, 67.392532474481243)]
        [InlineData(2, 16.442, 33.696266237240621)]
        public void ApparentSaturnPolarSemidiameterATest(double delta, double B, double expectedApparentDiameter)
        {
            double apparentDiameter = AASDiameters.ApparentSaturnPolarSemidiameterA(delta, B);
            Assert.Equal(expectedApparentDiameter, apparentDiameter);
        }
        
        [Theory]
        [InlineData(1, 16.442, 66.541565948420924)]
        [InlineData(2, 16.442, 33.270782974210462)]
        public void ApparentSaturnPolarSemidiameterBTest(double delta, double B, double expectedApparentDiameter)
        {
            double apparentDiameter = AASDiameters.ApparentSaturnPolarSemidiameterB(delta, B);
            Assert.Equal(expectedApparentDiameter, apparentDiameter);
        }

        [Theory]
        [InlineData(1, 34.28)]
        [InlineData(2, 17.14)]
        public void UranusSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.UranusSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 35.02)]
        [InlineData(2, 17.51)]
        public void UranusSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.UranusSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 36.56)]
        [InlineData(2, 18.28)]
        public void NeptuneSemidiameterATest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.NeptuneSemidiameterA(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 33.5)]
        [InlineData(2, 16.75)]
        public void NeptuneSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.NeptuneSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 2.07)]
        [InlineData(2, 1.035)]
        public void PlutoSemidiameterBTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.PlutoSemidiameterB(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(368407.9, 973.03053884954136)]
        [InlineData(368407.9 - 10000, 1000.1792300153762)]
        public void GeocentricMoonSemidiameterTest(double delta, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.GeocentricMoonSemidiameter(delta);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(368407.9, 5, 0, 33.356111, 1706, 988.06452138709551)]
        [InlineData(368407.9, 5, 6, 33.356111, 1706, 973.6885085414757)]
        [InlineData(368407.9 - 10000, 5, 0, 33.356111, 1706, 1016.0696859571749)]
        [InlineData(368407.9 - 10000, 5, 6, 33.356111, 1706, 1000.8701466945373)]
        public void TopocentricMoonSemidiameterTest(double DistanceDelta, double Delta, double H, double Latitude, double Height, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.TopocentricMoonSemidiameter(DistanceDelta, Delta, H, Latitude, Height);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(4, 0.04, 1044.6461998233406)]
        [InlineData(4, 0.08, 738.67669590581181)]
        [InlineData(6, 0.04, 415.88114284113351)]
        [InlineData(6, 0.08, 294.07248936086864)]
        public void AsteroidDiameterTest(double H, double A, double expectedSemidiameter)
        {
            double semidiameter = AASDiameters.AsteroidDiameter(H, A);
            Assert.Equal(expectedSemidiameter, semidiameter);
        }

        [Theory]
        [InlineData(1, 250, 0.34469999999999995)]
        [InlineData(1, 1000, 1.3787999999999998)]
        public void ApparentAsteroidDiameterTest(double Delta, double d, double expectedApparentDiameter)
        {
            double apparentDiameter = AASDiameters.ApparentAsteroidDiameter(Delta, d);
            Assert.Equal(expectedApparentDiameter, apparentDiameter);
        }
    }
}