using Xunit;

namespace AASharp.Tests.VSOP87.C
{
    public class VSOP87CNeptuneTest
    {
        [Theory]
        [InlineData(2195870.0, -27.259851311888312)]
        public void XTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.X(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -13.218533583988256)]
        public void YTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.Y(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.96032819503780642)]
        public void ZTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.Z(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 0.0013584200336685388)]
        public void XDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.X_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, -0.0028161503364351752)]
        public void YDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.Y_DASH(jd);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2195870.0, 1.4439726919401307e-005)]
        public void ZDashTest(double jd, double expectedResult)
        {
            double result = AASVSOP87C_Neptune.Z_DASH(jd);
            Assert.Equal(expectedResult, result);
        }
    }
}