using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class NearParabolicTest
    {
        public static IEnumerable<object[]> Parameters()
        {
            yield return new object[]
            {
                138.4783,
                new AASNearParabolicObjectElements
                {
                    q = 0.921326,
                    e = 1,
                    i = 0 , //unknown
                    omega = 0 , //unknown
                    w = 0 , //unknown
                    T = 0,
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.52154005622609589,
                        Y = 2.3059488390843055,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.52154005622609578,
                        Y = 2.1041325717948158,
                        Z = 0.94341198253275849
                    },
                    HeliocentricEclipticLongitude = 102.74425863922758,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 5.3000012451911234,
                    TrueGeocentricDeclination = 23.779135889435157,
                    TrueGeocentricDistance = 2.66146406029076,
                    TrueGeocentricLightTime = 0.015371334385001588,
                    AstrometricGeocentricRA = 5.2996686501045049,
                    AstrometricGeocentricDeclination = 23.778793977296502,
                    AstrometricGeocentricDistance = 2.6613460521307175,
                    AstrometricGeocentricLightTime = 0.015370652826713713,
                    Elongation = 62.150368965384125,
                    PhaseAngle = 22.344920911392716
                }
            };
            yield return new object[]
            {
                138.4783,
                new AASNearParabolicObjectElements
                {
                    q = 0.921326,
                    e = 1,
                    i = 0 , //unknown
                    omega = 0 , //unknown
                    w = 0 , //unknown
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.52154005622609589,
                        Y = 2.3059488390843055,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.52154005622609578,
                        Y = 2.1041325717948158,
                        Z = 0.94341198253275849
                    },
                    HeliocentricEclipticLongitude = 102.74425863922758,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 5.30000108656476,
                    TrueGeocentricDeclination = 23.779364182976316,
                    TrueGeocentricDistance = 2.6614397938423493,
                    TrueGeocentricLightTime = 0.015371194233684715,
                    AstrometricGeocentricRA = 5.2996684908876182,
                    AstrometricGeocentricDeclination = 23.779022280883993,
                    AstrometricGeocentricDistance = 2.6613217867031165,
                    AstrometricGeocentricLightTime = 0.015370512681292546,
                    Elongation = 62.15157509131064,
                    PhaseAngle = 22.344905986778794
                }
            };
            yield return new object[] 
            {
                254.9, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.1,
                    e = 0.987, 
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 1.0852106941438309,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 0.99023323072286695,
                        Z = 0.44398243147256239
                    },
                    HeliocentricEclipticLongitude = 164.47768124259119,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 10.678138784379653,
                    TrueGeocentricDeclination = 8.6453967161741208,
                    TrueGeocentricDistance = 4.9201491235967172,
                    TrueGeocentricLightTime = 0.028416411302061802,
                    AstrometricGeocentricRA = 10.678078596842985,
                    AstrometricGeocentricDeclination = 8.6457687823009266,
                    AstrometricGeocentricDistance = 4.9198696634932686,
                    AstrometricGeocentricLightTime = 0.028414797275120213,
                    Elongation = 25.671223810525834,
                    PhaseAngle = 6.0389031230865617
                }
            };
            yield return new object[]
            {
                254.9,
                new AASNearParabolicObjectElements
                {
                    q = 0.1,
                    e = 0.987,
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {

                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 1.0852106941438309,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 0.99023323072286695,
                        Z = 0.44398243147256239
                    },
                    HeliocentricEclipticLongitude = 164.47768124259119,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 10.678152272069015,
                    TrueGeocentricDeclination = 8.6452497598274345,
                    TrueGeocentricDistance = 4.9201437406804232,
                    TrueGeocentricLightTime = 0.028416380212930237,
                    AstrometricGeocentricRA = 10.678092085335205,
                    AstrometricGeocentricDeclination = 8.6456218180809596,
                    AstrometricGeocentricDistance = 4.9198642805329182,
                    AstrometricGeocentricLightTime = 0.028414766185734203,
                    Elongation = 25.670514681007177,
                    PhaseAngle = 6.0386619602887333
                }
            };
            yield return new object[] 
            {
                -30.47, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.123456,
                    e = 0.99997, 
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.71816617831646989,
                        Y = -0.64464292236130749,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.71816617831647001,
                        Y = -0.58822387865988268,
                        Z = -0.2637369255998302
                    },
                    HeliocentricEclipticLongitude = 221.91189883131085,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 14.369935505213427,
                    TrueGeocentricDeclination = -14.592107260666516,
                    TrueGeocentricDistance = 1.9471203240484376,
                    TrueGeocentricLightTime = 0.011245629063843682,
                    AstrometricGeocentricRA = 14.369778903496911,
                    AstrometricGeocentricDeclination = -14.591307310325023,
                    AstrometricGeocentricDistance = 1.947386457993455,
                    AstrometricGeocentricLightTime = 0.011247166125313381,
                    Elongation = 3.7668897799113212,
                    PhaseAngle = 3.8492292343158248
                }
            };
            yield return new object[]
            {
                -30.47,
                new AASNearParabolicObjectElements
                {
                    q = 0.123456,
                    e = 0.99997,
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {

                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.71816617831646989,
                        Y = -0.64464292236130749,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.71816617831647001,
                        Y = -0.58822387865988268,
                        Z = -0.2637369255998302
                    },
                    HeliocentricEclipticLongitude = 221.91189883131085,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 14.370017108451128,
                    TrueGeocentricDeclination = -14.592478754251276,
                    TrueGeocentricDistance = 1.9471162056072444,
                    TrueGeocentricLightTime = 0.011245605277711204,
                    AstrometricGeocentricRA = 14.369860495021639,
                    AstrometricGeocentricDeclination = -14.591678765374397,
                    AstrometricGeocentricDistance = 1.9473823372158852,
                    AstrometricGeocentricLightTime = 0.011247142325687116,
                    Elongation = 3.7657024132125985,
                    PhaseAngle = 3.847988956409838
                }
            };
            yield return new object[] 
            {
                1237.1, 
                new AASNearParabolicObjectElements 
                {
                    q = 3.363943,
                    e = 1.05731, 
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -3.5437255069978746,
                        Y = 10.061677404852786,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -3.5437255069978741,
                        Y = 9.1810810351064625,
                        Z = 4.1164430308378526
                    },
                    HeliocentricEclipticLongitude = 109.402277526441,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 7.0172009541590503,
                    TrueGeocentricDeclination = 23.388287066036192,
                    TrueGeocentricDistance = 10.743311177125426,
                    TrueGeocentricLightTime = 0.06204819030608244,
                    AstrometricGeocentricRA = 7.0170853134712381,
                    AstrometricGeocentricDeclination = 23.388459369857745,
                    AstrometricGeocentricDistance = 10.742933298791533,
                    AstrometricGeocentricLightTime = 0.062046007862849868,
                    Elongation = 83.011131800927885,
                    PhaseAngle = 5.424819501023407
                }
            };
            yield return new object[]
            {
                1237.1,
                new AASNearParabolicObjectElements
                {
                    q = 3.363943,
                    e = 1.05731,
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -3.5437255069978746,
                        Y = 10.061677404852786,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -3.5437255069978741,
                        Y = 9.1810810351064625,
                        Z = 4.1164430308378526
                    },
                    HeliocentricEclipticLongitude = 109.402277526441,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 7.0172032115251053,
                    TrueGeocentricDeclination = 23.388330847495663,
                    TrueGeocentricDistance = 10.743291794456784,
                    TrueGeocentricLightTime = 0.062048078361124998,
                    AstrometricGeocentricRA = 7.0170875708814133,
                    AstrometricGeocentricDeclination = 23.388503153230712,
                    AstrometricGeocentricDistance = 10.742913916667421,
                    AstrometricGeocentricLightTime = 0.062045895921037361,
                    Elongation = 83.012209232257746,
                    PhaseAngle = 5.4247932937413701
                }
            };
            yield return new object[] 
            {
                20, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.5871018,
                    e = 0.9672746, 
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.44028437363222478,
                        Y = 0.58116927196480073,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.44028437363222495,
                        Y = 0.53030543182086154,
                        Z = 0.23776852537160187
                    },
                    HeliocentricEclipticLongitude = 52.85302378180149,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 20.831358902655062,
                    TrueGeocentricDeclination = -18.237544209853144,
                    TrueGeocentricDistance = 0.54198122965543638,
                    TrueGeocentricLightTime = 0.0031302225101314755,
                    AstrometricGeocentricRA = 20.831217612055376,
                    AstrometricGeocentricDeclination = -18.238132706803853,
                    AstrometricGeocentricDistance = 0.5420672406041892,
                    AstrometricGeocentricLightTime = 0.003130719267939998,
                    Elongation = 45.198912942525595,
                    PhaseAngle = 102.96066908865025
                }
            };
            yield return new object[]
            {
                20,
                new AASNearParabolicObjectElements
                {
                    q = 0.5871018,
                    e = 0.9672746,
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.44028437363222478,
                        Y = 0.58116927196480073,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.44028437363222495,
                        Y = 0.53030543182086154,
                        Z = 0.23776852537160187
                    },
                    HeliocentricEclipticLongitude = 52.85302378180149,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 20.831348946392577,
                    TrueGeocentricDeclination = -18.236631359902979,
                    TrueGeocentricDistance = 0.54200504196874522,
                    TrueGeocentricLightTime = 0.0031303600385827559,
                    AstrometricGeocentricRA = 20.831207658079762,
                    AstrometricGeocentricDeclination = -18.23722000005926,
                    AstrometricGeocentricDistance = 0.54209105665490565,
                    AstrometricGeocentricLightTime = 0.0031308568179767445,
                    Elongation = 45.198017911008364,
                    PhaseAngle = 102.96055276511544
                }
            };
            yield return new object[] 
            {
                0, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.5871018,
                    e = 0.9672746, 
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.5871018,
                        Y = 0,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.5871018,
                        Y = 0,
                        Z = 0
                    },
                    HeliocentricEclipticLongitude = 0,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 18.756713163999741,
                    TrueGeocentricDeclination = -23.689893149721648,
                    TrueGeocentricDistance = 0.91593200964403976,
                    TrueGeocentricLightTime = 0.0052899820832549285,
                    AstrometricGeocentricRA = 18.756576899374217,
                    AstrometricGeocentricDeclination = -23.690051495938196,
                    AstrometricGeocentricDistance = 0.91609585581814668,
                    AstrometricGeocentricLightTime = 0.0052909283798318676,
                    Elongation = 35.481025455403632,
                    PhaseAngle = 79.602526806060055
                }
            };
            yield return new object[]
            {
                0,
                new AASNearParabolicObjectElements
                {
                    q = 0.5871018,
                    e = 0.9672746,
                    i = 0 , //unknown 
                    omega = 0 , //unknown 
                    w = 0 , //unknown 
                    T = 0,
                    JDEquinox = 0
                },
                true,
                new AASNearParabolicObjectDetails
                {
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = 0.5871018,
                        Y = 0,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = 0.5871018,
                        Y = 0,
                        Z = 0
                    },
                    HeliocentricEclipticLongitude = 0,
                    HeliocentricEclipticLatitude = 0,
                    TrueGeocentricRA = 18.756802140273805,
                    TrueGeocentricDeclination = -23.689476763151259,
                    TrueGeocentricDistance = 0.91595472261839694,
                    TrueGeocentricLightTime = 0.0052901132624539752,
                    AstrometricGeocentricRA = 18.756665860275621,
                    AstrometricGeocentricDeclination = -23.68963520135674,
                    AstrometricGeocentricDistance = 0.91611857219873838,
                    AstrometricGeocentricLightTime = 0.0052910595787036847,
                    Elongation = 35.480579289455989,
                    PhaseAngle = 79.60127492648482
                }
            };
        }

        [Theory]
        [MemberData(nameof(Parameters))]
        public void CalculateParameters(double JD, ref AASNearParabolicObjectElements elements, bool bHighPrecision, AASNearParabolicObjectDetails expectedDetails)
        {
            AASNearParabolicObjectDetails details = AASNearParabolic.Calculate(JD, ref elements, bHighPrecision);
            Assert.Equal(expectedDetails.HeliocentricRectangularEquatorial.X, details.HeliocentricRectangularEquatorial.X);
            Assert.Equal(expectedDetails.HeliocentricRectangularEquatorial.Y, details.HeliocentricRectangularEquatorial.Y);
            Assert.Equal(expectedDetails.HeliocentricRectangularEquatorial.Z, details.HeliocentricRectangularEquatorial.Z);
            Assert.Equal(expectedDetails.HeliocentricRectangularEcliptical.X, details.HeliocentricRectangularEcliptical.X);
            Assert.Equal(expectedDetails.HeliocentricRectangularEcliptical.Y, details.HeliocentricRectangularEcliptical.Y);
            Assert.Equal(expectedDetails.HeliocentricRectangularEcliptical.Z, details.HeliocentricRectangularEcliptical.Z);
            Assert.Equal(expectedDetails.TrueGeocentricRA, details.TrueGeocentricRA);
            Assert.Equal(expectedDetails.TrueGeocentricDeclination, details.TrueGeocentricDeclination);
            Assert.Equal(expectedDetails.TrueGeocentricDistance, details.TrueGeocentricDistance);
            Assert.Equal(expectedDetails.TrueGeocentricLightTime, details.TrueGeocentricLightTime);
            Assert.Equal(expectedDetails.AstrometricGeocentricRA, details.AstrometricGeocentricRA);
            Assert.Equal(expectedDetails.AstrometricGeocentricDeclination, details.AstrometricGeocentricDeclination);
            Assert.Equal(expectedDetails.AstrometricGeocentricDistance, details.AstrometricGeocentricDistance);
            Assert.Equal(expectedDetails.AstrometricGeocentricLightTime, details.AstrometricGeocentricLightTime);
            Assert.Equal(expectedDetails.Elongation, details.Elongation);
            Assert.Equal(expectedDetails.PhaseAngle, details.PhaseAngle);
        }
    }
}