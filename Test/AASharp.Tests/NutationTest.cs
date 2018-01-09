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
    }
}