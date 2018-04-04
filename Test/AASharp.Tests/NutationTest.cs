using Xunit;

namespace AASharp.Tests
{
    public class NutationTest
    {
        [Fact]
        public void MeanObliquityOfEclipticTest()
        {
            var date = new AASDate(1987, 4, 10, 0, 0, 0, true);
            double obliquity = AASNutation.MeanObliquityOfEcliptic(date.Julian);
            Assert.Equal(23.440946290957317, obliquity);
        }

        [Fact]
        public void NutationInLongitudeTest()
        {
            var date = new AASDate(1987, 4, 10, 0, 0, 0, true);
            double nutationInLongitude = AASNutation.NutationInLongitude(date.Julian);
            Assert.Equal(-3.7879310766037446, nutationInLongitude);
        }

        [Fact]
        public void NutationInObliquityTest()
        {
            var date = new AASDate(1987, 4, 10, 0, 0, 0, true);
            double nutationInEcliptic = AASNutation.NutationInObliquity(date.Julian);
            Assert.Equal(9.4425206987573933, nutationInEcliptic);
        }

        [Theory]
        [InlineData(2.7703708972967989, 49.350341568596946, 23.435537658653519, 14.86082643658615, 2.7045840278585449, 15.84404874104284)]
        public void NutationInRightAscensionTest(double x, double y, double obliquity, double nutationInLongitude, double nutationInEcliptic, double expectedAlphaNutation)
        {
            double alphaNutation = AASNutation.NutationInRightAscension(x, y, obliquity, nutationInLongitude, nutationInEcliptic);
            Assert.Equal(expectedAlphaNutation, alphaNutation);
        }

        [Theory]
        [InlineData(2.7703708972967989, 23.435537658653519, 14.86082643658615, 2.7045840278585449, 6.2169060366603022)]
        public void NutationInDeclinationTest(double x, double obliquity, double nutationInLongitude, double nutationInEcliptic, double expectedDeltaNutation)
        {
            double deltaNutation = AASNutation.NutationInDeclination(x, obliquity, nutationInLongitude, nutationInEcliptic);
            Assert.Equal(expectedDeltaNutation, deltaNutation);
        }

        [Theory]
        [InlineData(2454364.5007565268, 23.440731110914815)]
        public void TrueObliquityOfEclipticTest(double jd, double expectedTrueObliquity)
        {
            double trueObliquity = AASNutation.TrueObliquityOfEcliptic(jd);
            Assert.Equal(expectedTrueObliquity, trueObliquity);
        }
    }
}