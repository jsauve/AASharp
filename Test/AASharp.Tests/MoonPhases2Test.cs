using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class MoonPhases2Test
    {
        [Fact]
        public void CalculateTest()
        {
            var expectedResults = new List<AASMoonPhasesDetails2>
            {
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458489.5619604844
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458497.7823786549
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458504.7203073632
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458511.3829867421
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458519.3782974519
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458527.4356105193
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458534.1628304105
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458540.9783908213
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458549.1701938417
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458556.9361851322
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458563.5720674871
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458570.6742321607
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458578.8690733975
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458586.2964651524
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458592.9675798919
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458600.4301614016
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458608.4490044825
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458615.5508841164
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458622.3836968979
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458630.1907517551
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458637.918819645
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458644.7502821418
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458651.85535414
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458659.9080222426
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458667.3037716579
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458673.9555514446
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458681.4022743274
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458689.5550246607
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458696.6341551398
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458703.230598717
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458711.021091931
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458719.1230821158
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458725.9433440254
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458732.6330665392
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458740.6901402837
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458748.6125348224
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458755.2692174544
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458762.2002913435
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458770.3812133935
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458778.0281246216
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458784.6526279785
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458791.9335201201
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458800.0664103813
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458807.3833897407
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458814.1297512031
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FirstQuarter,
                    JD = 2458821.791176253
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.FullMoon,
                    JD = 2458829.7176884646
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.LastQuarter,
                    JD = 2458836.7071799911
                },
                new AASMoonPhasesDetails2
                {
                    type = AASMoonPhasesDetails2.Type.NewMoon,
                    JD = 2458843.7182696876
                }
            };

            List<AASMoonPhasesDetails2> moonPhases = AASMoonPhases2.Calculate(2458484.5, 2458848.5, 0.007, AASMoonPhases2.Algorithm.MeeusTruncated);

            Assert.Equal(expectedResults.Count, moonPhases.Count);

            for (int i = 0; i < moonPhases.Count; i++)
            {
                var moonPhase = moonPhases[i];
                var expectedResult = expectedResults[i];

                Assert.Equal(expectedResult.type, moonPhase.type);
                Assert.Equal(expectedResult.JD, moonPhase.JD);
            }
        }
    }
}