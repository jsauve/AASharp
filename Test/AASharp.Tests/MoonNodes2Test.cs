using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class MoonNodes2Test
    {
        [Theory]
        [InlineData(AASMoonNodes2.Algorithm.MeeusTruncated, 2458490.5064761746, 2458504.4509121077)]
        //TODO Tests cases to check, following algorithm produce StackOverflowException
        //[InlineData(AASMoonNodes2.Algorithm.ELP2000, 2458490.5064648255, 2458504.4510548702)]
        //[InlineData(AASMoonNodes2.Algorithm.ELPMPP02Nominal, 2458490.5064674695, 2458504.4510566676)]
        //[InlineData(AASMoonNodes2.Algorithm.ELPMPP02DE405, 2458490.5064665722, 2458504.4510570574)]
        //[InlineData(AASMoonNodes2.Algorithm.ELPMPP02DE406, 2458490.5064665698, 2458504.451057056)]
        //[InlineData(AASMoonNodes2.Algorithm.ELPMPP02LLR, 2458490.5064664446, 2458504.4510569191)]
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