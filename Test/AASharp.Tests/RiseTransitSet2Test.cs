using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AASharp.Tests
{
    public class RiseTransitSet2Test
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[] //Sun, North Pole, 2019-01-01
            {
                2458484.5,
                2458485.5,
                AASRiseSetObject.SUN,
                0,
                90,
                -0.8333,
                new List<AASRiseTransitSetDetails2>
                {
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.NorthernTransit,
                        JD = 2458484.5022199615,
                        Bearing = 0,
                        GeometricAltitude = -23.041100711204674,
                        bAboveHorizon = false
                    },
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.SouthernTransit,
                        JD = 2458485.0023847371,
                        Bearing = 0,
                        GeometricAltitude = -23.000897279237272,
                        bAboveHorizon = false
                    }
                }
            };
            yield return new object[] //Sun, North Pole, 2019-01-01
            {
                2458484.5,
                2458485.5,
                AASRiseSetObject.SUN,
                0,
                -90,
                -0.8333,
                new List<AASRiseTransitSetDetails2>
                {
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.SouthernTransit,
                        JD = 2458484.5022199615,
                        Bearing = 0,
                        GeometricAltitude = 23.036543857169843,
                        bAboveHorizon = true
                    },
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.NorthernTransit,
                        JD = 2458485.0023847371,
                        Bearing = 0,
                        GeometricAltitude = 22.996339047696516,
                        bAboveHorizon = true
                    }
                }
            };
            yield return new object[] // Moon, North Pole, 2019-03-08
            {
                2458550.5,
                2458551.5,
                AASRiseSetObject.MOON,
                0,
                90,
                0.125,
                new List<AASRiseTransitSetDetails2>
                {
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.NorthernTransit,
                        JD = 2458550.5516985329,
                        Bearing = 0,
                        GeometricAltitude = -4.2544507253369162,
                        bAboveHorizon = false
                    },
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.SouthernTransit,
                        JD = 2458551.0664017373,
                        Bearing = 0,
                        GeometricAltitude = -1.9653599673717754,
                        bAboveHorizon = false
                    }
                }
            };
            yield return new object[] // Moon, North Pole, 2019-03-09
            {
                2458551.5,
                2458552.5,
                AASRiseSetObject.MOON,
                0,
                90,
                0.125,
                new List<AASRiseTransitSetDetails2>
                {
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.Rise,
                        JD = 2458551.5313235857,
                        Bearing = 162.57104298204268,
                        GeometricAltitude = 0,
                        bAboveHorizon = false
                    },
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.NorthernTransit,
                        JD = 2458551.5811722688,
                        Bearing = 0,
                        GeometricAltitude = 0.34968336890685836,
                        bAboveHorizon = true
                    },
                    new AASRiseTransitSetDetails2
                    {
                        type = AASRiseTransitSetDetails2.Type.SouthernTransit,
                        JD = 2458552.0960749616,
                        Bearing = 0,
                        GeometricAltitude = 2.6684231775090845,
                        bAboveHorizon = true
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void CalculateTest(double startJD, double endJD, AASRiseSetObject aasRiseSetObject, double longitude, double latitude, double h0, List<AASRiseTransitSetDetails2> expectedResults)
        {
            List<AASRiseTransitSetDetails2> results = AASRiseTransitSet2.Calculate(startJD, endJD, aasRiseSetObject, longitude, latitude, h0);

            foreach (AASRiseTransitSetDetails2 expectedResult in expectedResults)
            {
                AASRiseTransitSetDetails2 result = results.FirstOrDefault(r => r.type == expectedResult.type);
                Assert.NotNull(result);
                Assert.Equal(expectedResult.type, result.type);
                Assert.Equal(expectedResult.Bearing, result.Bearing);
                Assert.Equal(expectedResult.GeometricAltitude, result.GeometricAltitude);
                Assert.Equal(expectedResult.JD, result.JD);
                Assert.Equal(expectedResult.bAboveHorizon, result.bAboveHorizon);
            }
        }
    }
}