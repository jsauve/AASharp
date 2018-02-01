using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class RiseTransitSetTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
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
                    Rise = 12.423760186853372,
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