using Xunit;

namespace AASharp.Tests.VSOP87.E
{
    public class VSOP87EEarthTest
    {
        [Theory]
        [InlineData(2195870.0, -0.25441504491853534)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.94661732681090127)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0014906848386002202)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.016905774668535396)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0045082712736346604)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -8.669948843016596e-006)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87E_Earth.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}