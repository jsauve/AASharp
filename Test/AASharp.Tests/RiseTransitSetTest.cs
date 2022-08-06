using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class RiseTransitSetTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            //Venus rise for Reykjavík 
            yield return new object[] {
                2458950.5,
                4.1805065838501578,
                25.31917565151549,
                4.2392717862910745,
                25.522975131091489,
                4.2972706379370376,
                25.718064841766768,
                21.9267,
                64.1417,
                -0.56669999999999998,
                new AASRiseTransitSetDetails
                {
                    bRiseValid = false,
                    Rise = 0,
                    bTransitValid= true,
                    bTransitAboveHorizon = true,
                    Transit = 16.384745033921234,
                    bSetValid = false,
                    Set = 0
                }
            };
            //Venus rise for Boston
            yield return new object[] {
                2447240.5,
                2.7120138888888889,
                18.047611111111113,
                2.782086111111111,
                18.440916666666666,
                2.8521361111111112,
                18.827416666666668,
                71.0833,
                42.3333,
                -0.5667,
                new AASRiseTransitSetDetails
                {
                    bRiseValid = true,
                    Rise = 12.423760188032768,
                    bTransitValid= true,
                    bTransitAboveHorizon = true,
                    Transit = 19.675106843620839,
                    bSetValid = true,
                    Set = 2.9110969883523952
                }
            };
            //Moon rise for Palomar Observatory
            yield return new object[] {
                2455783.5,
                17.164631754879572,
                -23.269277043321491,
                17.164631754879572,
                -22.56438135426172,
                19.069958332931705,
                -20.621024655519513,
                116.8625,
                33.356111111111112,
                0.125,
                new AASRiseTransitSetDetails
                {
                    bRiseValid = false,
                    Rise = 0,
                    bTransitValid= true,
                    bTransitAboveHorizon = true,
                    Transit = 4.8967468638700478,
                    bSetValid = true,
                    Set = 10.050749701783564
                }
            };

            //An interesting case is Rise, Transit and Set for the Moon on October 30 2012 at the specified position
            yield return new object[] {
                2456230.5,
                1.5976289429725621,
                12.747046266735165,
                2.3985777701007418,
                15.932310081432496,
                3.2150249893175635,
                18.414729299199248,
                -5.6306649983214818,
                71.646778771324804,
                0.125,
                new AASRiseTransitSetDetails
                {
                    bRiseValid = true,
                    Rise = 13.220188661532028,
                    bTransitValid= false,
                    bTransitAboveHorizon = true,
                    Transit = 0,
                    bSetValid = true,
                    Set = 10.183674235316074
                }
            };
            //An interesting case is Rise, Transit and Set for the Moon on October 31 2012 at the specified position
            yield return new object[] {
                2456231.5,
                2.3985777701007418,
                15.932310081432496,
                3.2150249893175635,
                18.414729299199248,
                4.0456211083291276,
                20.085012606344936,
                -5.6306649983214818,
                71.646778771324804,
                0.125,
                new AASRiseTransitSetDetails
                {
                    bRiseValid = false,
                    Rise = 0,
                    bTransitValid= true,
                    bTransitAboveHorizon = true,
                    Transit = 0.19990251869228498,
                    bSetValid = true,
                    Set = 11.685600518729544
                }
            };
        }


        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void CalculateTest(double JD, 
                                double alpha1, double delta1, 
                                double alpha2, double delta2, 
                                double alpha3, double delta3, 
                                double longitude, double latitude, 
                                double h0,
                                AASRiseTransitSetDetails expectedDetails
                                )
        {
            AASRiseTransitSetDetails riseTransitSetTime = AASRiseTransitSet.Calculate(JD, alpha1, delta1, alpha2, delta2, alpha3, delta3, longitude, latitude, h0);
            Assert.Equal(expectedDetails.Rise, riseTransitSetTime.Rise);
        }
    }
}