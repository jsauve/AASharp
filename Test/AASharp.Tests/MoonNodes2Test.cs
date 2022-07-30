using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class MoonNodes2Test
    {
        [Theory]
        [InlineData(AASMoonNodes2.Algorithm.MeeusTruncated, 2458490.5064761746, 2458504.4509121077)]
        public void CalculateTest(AASMoonNodes2.Algorithm algorithm, double expectedMoonNodeDescendingJD, double expectedMoonNodeAscendingJD)
        {
            double startJD = 2458484.5008011586;
            double endJD = 2458515.5008014492;
            double stepInterval = 0.007;

            List<AASMoonNodesDetails2> result = AASMoonNodes2.Calculate(startJD, endJD, stepInterval, algorithm);

            var moonNodeDescending = result.First(e => e.type == AASMoonNodesDetails2.Type.Descending);
            var moonNodeAscending = result.First(e => e.type == AASMoonNodesDetails2.Type.Ascending);
            
            Assert.Equal(expectedMoonNodeDescendingJD, moonNodeDescending.JD);
            Assert.Equal(expectedMoonNodeAscendingJD, moonNodeAscending.JD);
        }
    }
}