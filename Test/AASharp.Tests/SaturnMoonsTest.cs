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
                        TrueRectangularCoordinates= new AAS3DCoordinate
                        {
                            X = 3.1017339399666213,
                            Y = -0.20395517974093325,
                            Z = 0.29545825805745385
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.1016922931265998,
                            Y = -0.20395233460428333,
                            Z = 0.29545825805745385
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite2 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.8232139062752344,
                            Y = 0.31810705002433137,
                            Z = -0.832551262140742
                        },
                        ApparentRectangularCoordinates= new AAS3DCoordinate
                        {
                            X = 3.8233721684882589,
                            Y = 0.3181195549082847,
                            Z = -0.832551262140742
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite3 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates= new AAS3DCoordinate
                        {
                            X = 4.0275686838325768,
                            Y = -1.0613373337000822,
                            Z = 2.5448762321789888
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 4.027139292080129,
                            Y = -1.0612098231136384,
                            Z = 2.5448762321789888
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite4 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.365967893375406,
                            Y = -1.1483455626227268,
                            Z = 3.0044855879356374
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.3651551091479535,
                            Y = -1.1481826857452817,
                            Z = 3.0044855879356374
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite5 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates= new AAS3DCoordinate
                        {
                            X = -0.97242823299125458,
                            Y = -3.137242797082691,
                            Z = 8.0800588301999774
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -0.9718300951973845,
                            Y = -3.1360464000734387,
                            Z = 8.0800588301999774
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite6 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates= new AAS3DCoordinate
                        {
                            X = 14.558765779389741,
                            Y = 4.7355572559134487,
                            Z = -12.75482495470677
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 14.567700565871437,
                            Y = 4.73841080619133,
                            Z = -12.75482495470677
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite7 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.014131017851074,
                            Y = -5.3320287700632889,
                            Z = 15.120957920106436
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.001109672984395,
                            Y = -5.3282247731283539,
                            Z = 15.120957920106436
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite8 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.835871580943447,
                            Y = 4.1434542606149058,
                            Z = 32.737986433012466
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.760302278653896,
                            Y = 4.1370595329899205,
                            Z = 32.737986433012466
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false
                    }
                }
            };
            yield return new object[]
            {
                2451439.50074,
                true,
                new AASSaturnMoonsDetails
                {
                    Satellite1 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.1017342525489844,
                            Y = -0.20395333469601007,
                            Z = 0.29545514689493207
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.10169260667136,
                            Y = -0.2039504896508581,
                            Z = 0.29545514689493207
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite2 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.823213821469357,
                            Y = 0.31810564462639634,
                            Z = -0.83255203873865125
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 3.8233720819374235,
                            Y = 0.31811814930940324,
                            Z = -0.83255203873865125
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite3 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 4.0275666335179254,
                            Y = -1.06133392896936,
                            Z = 2.5448808969764283
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 4.0271372473723837,
                            Y = -1.0612064201626392,
                            Z = 2.5448808969764283
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite4 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.3659723472927521,
                            Y = -1.1483375245382268,
                            Z = 3.0044806721031088
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -5.3651595734589543,
                            Y = -1.1481746511166289,
                            Z = 3.0044806721031088
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite5 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -0.9724451111090896,
                            Y = -3.1372276719967873,
                            Z = 8.080062662295763
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -0.97184697130855846,
                            Y = -3.136031295237764,
                            Z = 8.080062662295763
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite6 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 14.558800712190628,
                            Y = 4.7355211592204123,
                            Z = -12.754798683947838
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 14.567735390401236,
                            Y = 4.7383746459364682,
                            Z = -12.754798683947838
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite7 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.014172683700174,
                            Y = -5.33198474202644,
                            Z = 15.120922945624709
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -18.001151501311433,
                            Y = -5.3281808331284921,
                            Z = 15.120922945624709
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                    },
                    Satellite8 = new AASSaturnMoonDetail
                    {
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.835951923571493,
                            Y = 4.1435608547047078,
                            Z = 32.737852943980187
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -48.760383752635391,
                            Y = 4.1371660689520811,
                            Z = 32.737852943980187
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