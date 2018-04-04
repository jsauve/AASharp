using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class InterpolateTest
    {
        public static IEnumerable<object[]> LagrangeInterpolateParameters()
        {
            yield return new object[] { 30, 6, new[] { 29.43, 30.97, 27.69, 28.11, 31.58, 33.05 },
                                                new[] { 0.4913598528, 0.5145891926, 0.4646875083, 0.4711658342, 0.5236885653, 0.5453707057 }, 0.50000000001805556 };
            yield return new object[] { 0, 6, new[] { 29.43, 30.97, 27.69, 28.11, 31.58, 33.05 },
                                                new[] { 0.4913598528, 0.5145891926, 0.4646875083, 0.4711658342, 0.5236885653, 0.5453707057 }, 5.1224662456661463E-05 };
            yield return new object[] { 90, 6, new[] { 29.43, 30.97, 27.69, 28.11, 31.58, 33.05 },
                                                new[] { 0.4913598528, 0.5145891926, 0.4646875083, 0.4711658342, 0.5236885653, 0.5453707057 }, 0.99996480997651815 };
        }

        [Theory]
        [MemberData(nameof(LagrangeInterpolateParameters))]
        public void LagrangeInterpolateTest(double x, int n, double[] pX, double[] pY, double expectedY)
        {
            double y = AASInterpolate.LagrangeInterpolate(x, n, pX, pY);
            Assert.Equal(expectedY, y);
        }


        [Theory]
        [InlineData(1128.732, 1402.835, 1677.247, 1951.983, 1540.0014375000003)]
        public void InterpolateToHalvesTest(double y1, double y2, double y3, double y4, double expectedY)
        {
            double y = AASInterpolate.InterpolateToHalves(y1, y2, y3, y4);
            Assert.Equal(expectedY, y);
        }


        [Theory]
        [InlineData(-1.1892305555555556, -0.47008611111111109, 0.26861666666666667, 1.0167027777777777, 1.7628694444444444, -0.36141305312723865)]
        public void ZeroY5Test(double y1, double y2, double y3, double y4, double y5, double expectedN)
        {
            double n = AASInterpolate.Zero(y1, y2, y3, y4, y5);
            Assert.Equal(expectedN, n);
        }

        [Theory]
        [InlineData(-1693.4, 406.3, 2303.2, -0.20126729503148003)]
        [InlineData(-0.47008611111111109, 0.26861666666666667, 1.0167027777777777, -0.36216580143033333)]
        public void ZeroTest(double y1, double y2, double y3, double expectedN)
        {
            double n = AASInterpolate.Zero(y1, y2, y3);
            Assert.Equal(expectedN, n);
        }

        [Theory]
        [InlineData(-2, 3, 2, -0.72075922005612636)]
        public void Zero2Test(double y1, double y2, double y3, double expectedN)
        {
            double n = AASInterpolate.Zero2(y1, y2, y3);
            Assert.Equal(expectedN, n);
        }

        [Theory]
        [InlineData(-13, -2, 3, 2, -5, -0.72075922005612647)]
        public void Zero2Y5Test(double y1, double y2, double y3, double y4, double y5, double expectedN)
        {
            double n = AASInterpolate.Zero2(y1, y2, y3, y4, y5);
            Assert.Equal(expectedN, n);
        }

        [Theory]
        [InlineData(0.18125, 0.884226, 0.877366, 0.870531, 0.87612530126953125)]
        public void Interpolate_Test(double n, double y1, double y2, double y3, double expectedY)
        {
            double y = AASInterpolate.Interpolate(n, y1, y2, y3);
            Assert.Equal(expectedY, y);
        }

        [Theory]
        [InlineData(0.2777778, 36.125, 24.606, 15.486, 8.694, 4.133, 13.369480613585395)]
        public void Interpolate2Test(double n, double y1, double y2, double y3, double y4, double y5, double expectedY)
        {
            double y = AASInterpolate.Interpolate(n, y1, y2, y3, y4, y5);
            Assert.Equal(expectedY, y);
        }

        [Theory]
        [InlineData(1.3814294, 1.3812213, 1.3812453, 1.3812030466555363, 0.39659629470086655)]
        public void ExtremumTest(double y1, double y2, double y3, double expectedYm, double expectedNm)
        {
            double nm = 0;
            double ym = AASInterpolate.Extremum(y1, y2, y3, ref nm);
            Assert.Equal(expectedYm, ym);
            Assert.Equal(expectedNm, nm);
        }
    }
}