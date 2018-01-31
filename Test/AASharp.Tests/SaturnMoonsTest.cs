using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class SaturnMoonsTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[]
            {
                2451439.50074,
                false,
                new AASSaturnMoonsDetails
                {
                    Satellite1 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.1016923918387653,
                            Y = -0.20395175511871336,
                            Z = 0.29545761940405935,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.1017340385922103,
                            Y = -0.20395460024101164,
                            Z = 0.29545761940405935,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite2 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.8233719188388666,
                            Y = 0.31811918896949964,
                            Z = -0.83255254903769371,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.8232136563876677,
                            Y = 0.31810668408111975,
                            Z = -0.83255254903769371,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite3 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 4.0271400578123515,
                            Y = -1.0612071369846079,
                            Z = 2.5448761405762617,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 4.0275694496434147,
                            Y = -1.0613346472384262,
                            Z = 2.5448761405762617,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite4 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.3651542210991146,
                            Y = -1.1481805137670529,
                            Z = 3.0044880031708163,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.3659670058462456,
                            Y = -1.1483433904605758,
                            Z = 3.0044880031708163,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite5 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -0.97182771885777874,
                            Y = -3.1360392351283313,
                            Z = 8.0800618990774318,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -0.97242585596389619,
                            Y = -3.1372356298090152,
                            Z = 8.0800618990774318,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite6 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 14.56769686305441,
                            Y = 4.7384007528600094,
                            Z = -12.75483291620292,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 14.558762073541747,
                            Y = 4.7355472069734361,
                            Z = -12.75483291620292,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite7 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.001105304122031,
                            Y = -5.3282129379908509,
                            Z = 15.120967292536452,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.014126653460256,
                            Y = -5.3320169286765573,
                            Z = 15.120967292536452,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite8 = new AASSaturnMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.760294363014452,
                            Y = 4.1370841818818356,
                            Z = 32.737995108725315,
                        },
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.835863670043935,
                            Y = 4.1434789490368349,
                            Z = 32.737995108725315,
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void TheoryTest(double JD, bool bHighPrecision, AASSaturnMoonsDetails expectedSaturnMoonsDetails)
        {
            AASSaturnMoonsDetails saturnMoons = AASSaturnMoons.Calculate(JD, bHighPrecision);
            
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.TrueRectangularCoordinates.X, saturnMoons.Satellite1.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.TrueRectangularCoordinates.Y, saturnMoons.Satellite1.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.TrueRectangularCoordinates.Z, saturnMoons.Satellite1.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.ApparentRectangularCoordinates.X, saturnMoons.Satellite1.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.ApparentRectangularCoordinates.Y, saturnMoons.Satellite1.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.ApparentRectangularCoordinates.Z, saturnMoons.Satellite1.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.bInTransit, saturnMoons.Satellite1.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.bInOccultation, saturnMoons.Satellite1.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.bInEclipse, saturnMoons.Satellite1.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite1.bInShadowTransit, saturnMoons.Satellite1.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.TrueRectangularCoordinates.X, saturnMoons.Satellite2.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.TrueRectangularCoordinates.Y, saturnMoons.Satellite2.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.TrueRectangularCoordinates.Z, saturnMoons.Satellite2.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.ApparentRectangularCoordinates.X, saturnMoons.Satellite2.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.ApparentRectangularCoordinates.Y, saturnMoons.Satellite2.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.ApparentRectangularCoordinates.Z, saturnMoons.Satellite2.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.bInTransit, saturnMoons.Satellite2.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.bInOccultation, saturnMoons.Satellite2.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.bInEclipse, saturnMoons.Satellite2.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite2.bInShadowTransit, saturnMoons.Satellite2.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.TrueRectangularCoordinates.X, saturnMoons.Satellite3.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.TrueRectangularCoordinates.Y, saturnMoons.Satellite3.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.TrueRectangularCoordinates.Z, saturnMoons.Satellite3.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.ApparentRectangularCoordinates.X, saturnMoons.Satellite3.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.ApparentRectangularCoordinates.Y, saturnMoons.Satellite3.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.ApparentRectangularCoordinates.Z, saturnMoons.Satellite3.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.bInTransit, saturnMoons.Satellite3.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.bInOccultation, saturnMoons.Satellite3.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.bInEclipse, saturnMoons.Satellite3.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite3.bInShadowTransit, saturnMoons.Satellite3.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.TrueRectangularCoordinates.X, saturnMoons.Satellite4.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.TrueRectangularCoordinates.Y, saturnMoons.Satellite4.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.TrueRectangularCoordinates.Z, saturnMoons.Satellite4.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.ApparentRectangularCoordinates.X, saturnMoons.Satellite4.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.ApparentRectangularCoordinates.Y, saturnMoons.Satellite4.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.ApparentRectangularCoordinates.Z, saturnMoons.Satellite4.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.bInTransit, saturnMoons.Satellite4.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.bInOccultation, saturnMoons.Satellite4.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.bInEclipse, saturnMoons.Satellite4.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite4.bInShadowTransit, saturnMoons.Satellite4.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.TrueRectangularCoordinates.X, saturnMoons.Satellite5.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.TrueRectangularCoordinates.Y, saturnMoons.Satellite5.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.TrueRectangularCoordinates.Z, saturnMoons.Satellite5.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.ApparentRectangularCoordinates.X, saturnMoons.Satellite5.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.ApparentRectangularCoordinates.Y, saturnMoons.Satellite5.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.ApparentRectangularCoordinates.Z, saturnMoons.Satellite5.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.bInTransit, saturnMoons.Satellite5.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.bInOccultation, saturnMoons.Satellite5.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.bInEclipse, saturnMoons.Satellite5.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite5.bInShadowTransit, saturnMoons.Satellite5.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.TrueRectangularCoordinates.X, saturnMoons.Satellite6.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.TrueRectangularCoordinates.Y, saturnMoons.Satellite6.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.TrueRectangularCoordinates.Z, saturnMoons.Satellite6.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.ApparentRectangularCoordinates.X, saturnMoons.Satellite6.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.ApparentRectangularCoordinates.Y, saturnMoons.Satellite6.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.ApparentRectangularCoordinates.Z, saturnMoons.Satellite6.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.bInTransit, saturnMoons.Satellite6.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.bInOccultation, saturnMoons.Satellite6.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.bInEclipse, saturnMoons.Satellite6.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite6.bInShadowTransit, saturnMoons.Satellite6.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.TrueRectangularCoordinates.X, saturnMoons.Satellite7.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.TrueRectangularCoordinates.Y, saturnMoons.Satellite7.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.TrueRectangularCoordinates.Z, saturnMoons.Satellite7.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.ApparentRectangularCoordinates.X, saturnMoons.Satellite7.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.ApparentRectangularCoordinates.Y, saturnMoons.Satellite7.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.ApparentRectangularCoordinates.Z, saturnMoons.Satellite7.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.bInTransit, saturnMoons.Satellite7.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.bInOccultation, saturnMoons.Satellite7.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.bInEclipse, saturnMoons.Satellite7.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite7.bInShadowTransit, saturnMoons.Satellite7.bInShadowTransit);

            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.TrueRectangularCoordinates.X, saturnMoons.Satellite8.TrueRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.TrueRectangularCoordinates.Y, saturnMoons.Satellite8.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.TrueRectangularCoordinates.Z, saturnMoons.Satellite8.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.ApparentRectangularCoordinates.X, saturnMoons.Satellite8.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.ApparentRectangularCoordinates.Y, saturnMoons.Satellite8.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.ApparentRectangularCoordinates.Z, saturnMoons.Satellite8.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.bInTransit, saturnMoons.Satellite8.bInTransit);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.bInOccultation, saturnMoons.Satellite8.bInOccultation);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.bInEclipse, saturnMoons.Satellite8.bInEclipse);
            Assert.Equal(expectedSaturnMoonsDetails.Satellite8.bInShadowTransit, saturnMoons.Satellite8.bInShadowTransit);
        }
    }
}