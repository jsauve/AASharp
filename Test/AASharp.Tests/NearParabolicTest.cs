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
                    i = 0 /*unknown*/,
                    omega = 0 /*unknown*/,
                    w = 0 /*unknown*/,
                    T = 0,
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = 23.098606214589584,
                    AstrometricGeocentricDistance = 2.6613647328080909,
                    AstrometricGeocentricLightTime = 0.01537076071730774,
                    AstrometricGeocentricRA = 5.3041148492292463,
                    Elongation = 62.149390472359528,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 102.74425863922758,
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
                    PhaseAngle = 22.344708416954273,
                    TrueGeocentricDeclination = 23.098976177381818,
                    TrueGeocentricDistance = 2.6614827718929805,
                    TrueGeocentricLightTime = 0.015371442454202635,
                    TrueGeocentricRA = 5.3044455522272953
                }
            };
            yield return new object[] 
            {
                254.9, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.1,
                    e = 0.987, 
                    i = 0 /*unknown*/, 
                    omega = 0 /*unknown*/, 
                    w = 0 /*unknown*/, 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = 8.8342494682050656,
                    AstrometricGeocentricDistance = 4.9196589119624088,
                    AstrometricGeocentricLightTime = 0.028413580075796981,
                    AstrometricGeocentricRA = 10.683253109801687,
                    Elongation = 25.694416005997343,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 164.47768124259119,
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 1.0852106941438309,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -3.9072324371744021,
                        Y = 0.990233230722867,
                        Z = 0.44398243147256239
                    },
                    PhaseAngle = 6.0440072299379919,
                    TrueGeocentricDeclination = 8.8338665133565346,
                    TrueGeocentricDistance = 4.9199383558235859,
                    TrueGeocentricLightTime = 0.028415194008931031,
                    TrueGeocentricRA = 10.683313028559333
                }
            };
            yield return new object[] 
            {
                -30.47, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.123456,
                    e = 0.99997, 
                    i = 0 /*unknown*/, 
                    omega = 0 /*unknown*/, 
                    w = 0 /*unknown*/, 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = -13.811678056691255,
                    AstrometricGeocentricDistance = 1.9471926948979787,
                    AstrometricGeocentricLightTime = 0.011246047043009593,
                    AstrometricGeocentricRA = 14.389123886179437,
                    Elongation = 3.8506776953781676,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 221.91189883131085,
                    HeliocentricRectangularEcliptical = new AAS3DCoordinate
                    {
                        X = -0.71816617831646989,
                        Y = -0.64464292236130749,
                        Z = 0
                    },
                    HeliocentricRectangularEquatorial = new AAS3DCoordinate
                    {
                        X = -0.71816617831647,
                        Y = -0.58822387865988268,
                        Z = -0.2637369255998302
                    },
                    PhaseAngle = 3.9348544008524788,
                    TrueGeocentricDeclination = -13.812368603193736,
                    TrueGeocentricDistance = 1.946926625387857,
                    TrueGeocentricLightTime = 0.011244510353684813,
                    TrueGeocentricRA = 14.389282652530095
                }
            };
            yield return new object[] 
            {
                1237.1, 
                new AASNearParabolicObjectElements 
                {
                    q = 3.363943,
                    e = 1.05731, 
                    i = 0 /*unknown*/, 
                    omega = 0 /*unknown*/, 
                    w = 0 /*unknown*/, 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = 23.221659493168353,
                    AstrometricGeocentricDistance = 10.743012635866876,
                    AstrometricGeocentricLightTime = 0.062046466075580377,
                    AstrometricGeocentricRA = 7.0159735428473384,
                    Elongation = 83.006675959437388,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 109.402277526441,
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
                    PhaseAngle = 5.4247676134366811,
                    TrueGeocentricDeclination = 23.221493239728474,
                    TrueGeocentricDistance = 10.74339052957621,
                    TrueGeocentricLightTime = 0.062048648607614096,
                    TrueGeocentricRA = 7.0160890791054467
                }
            };
            yield return new object[] 
            {
                20, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.5871018,
                    e = 0.9672746, 
                    i = 0 /*unknown*/, 
                    omega = 0 /*unknown*/, 
                    w = 0 /*unknown*/, 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = -17.454105757156558,
                    AstrometricGeocentricDistance = 0.54219141060071152,
                    AstrometricGeocentricLightTime = 0.0031314364140272236,
                    AstrometricGeocentricRA = 20.816309657376003,
                    Elongation = 45.201930630683506,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 52.85302378180149,
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
                    PhaseAngle = 102.9476385994906,
                    TrueGeocentricDeclination = -17.453395233656185,
                    TrueGeocentricDistance = 0.54210539386545664,
                    TrueGeocentricLightTime = 0.0031309396227986526,
                    TrueGeocentricRA = 20.816448020518372
                }
            };
            yield return new object[] 
            {
                0, 
                new AASNearParabolicObjectElements 
                {
                    q = 0.5871018,
                    e = 0.9672746, 
                    i = 0 /*unknown*/, 
                    omega = 0 /*unknown*/, 
                    w = 0 /*unknown*/, 
                    T = 0, 
                    JDEquinox = 0
                },
                false,
                new AASNearParabolicObjectDetails
                {
                    AstrometricGeocentricDeclination = -22.596136522994502,
                    AstrometricGeocentricDistance = 0.91627564708666909,
                    AstrometricGeocentricLightTime = 0.0052919667675933989,
                    AstrometricGeocentricRA = 18.751489436321119,
                    Elongation = 35.478960770567916,
                    HeliocentricEclipticLatitude = 0,
                    HeliocentricEclipticLongitude = 0,
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
                    PhaseAngle = 79.586752127829541,
                    TrueGeocentricDeclination = -22.595783487885349,
                    TrueGeocentricDistance = 0.9161118102778506,
                    TrueGeocentricLightTime = 0.0052910205251058542,
                    TrueGeocentricRA = 18.751623696586776
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