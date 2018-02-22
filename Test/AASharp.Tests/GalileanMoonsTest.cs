using System.Collections.Generic;
using Xunit;

namespace AASharp.Tests
{
    public class GalileanMoonsTest
    {
        public static IEnumerable<object[]> CalculateParameters()
        {
            yield return new object[]
            {
                2448972.50068,
                false,
                new AASGalileanMoonsDetails
                {
                    Satellite1 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 335.60626733023673,
                        TrueLongitude = 335.59973573707975,
                        TropicalLongitude = 336.19975835170175,
                        EquatorialLatitude = 0.043408227809023953,
                        r = 5.9298927753013668,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.4490813910570162,
                            Y = 0.21362017673481865,
                            Z = -4.8189036413407695
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.4502566252193989,
                            Y = 0.21370700866208928,
                            Z = -4.8189036413407695
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite2 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 62.342115158913657,
                        TrueLongitude = 63.442224633996375,
                        TropicalLongitude = 64.042247248618395,
                        EquatorialLatitude = 0.15654042431693294,
                        r = 9.4037353463390598,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.4380478224177313,
                            Y = 0.27512346695153911,
                            Z = -5.747172359808431
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.44181515173665,
                            Y = 0.27525685127563637,
                            Z = -5.747172359808431
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite3 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 15.710046087217052,
                        TrueLongitude = 15.750435139867477,
                        TropicalLongitude = 16.350457754489483,
                        EquatorialLatitude = -0.22552637138457696,
                        r = 15.000197429479821,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.1989436300131768,
                            Y = 0.58926985438348312,
                            Z = -14.940589618021729
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.2009969875105402,
                            Y = 0.59001311622328478,
                            Z = -14.940589618021729
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite4 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 26.191039826226188,
                        TrueLongitude = 26.782078134317999,
                        TropicalLongitude = 27.382100748940008,
                        EquatorialLatitude = -0.14812913485433721,
                        r = 26.212921473671862,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0562605195199213,
                            Y = 1.026818127896195,
                            Z = -25.224434269132296
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0719661234287843,
                            Y = 1.0290066556140467,
                            Z = -25.224434269132296
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    }
                }
            };

            yield return new object[]
            {
                2448972.50068,
                true,
                new AASGalileanMoonsDetails
                {
                    Satellite1 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 335.60628391383216,
                        TrueLongitude = 335.59975218493491,
                        TropicalLongitude = 336.19977479955691,
                        EquatorialLatitude = 0.043408227331144397,
                        r = 5.929892774580698,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.4490806454612022,
                            Y = 0.21361371684697658,
                            Z = -4.818904460466519
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.4502558829909833,
                            Y = 0.21370054637972258,
                            Z = -4.818904460466519
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite2 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 62.342123420559801,
                        TrueLongitude = 63.442232881905511,
                        TropicalLongitude = 64.042255496527517,
                        EquatorialLatitude = 0.15654036649066402,
                        r = 9.4037353592618889,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.4380478980702511,
                            Y = 0.27511572246154625,
                            Z = -5.747172653775027
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.4418152366091173,
                            Y = 0.27524910337043162,
                            Z = -5.747172653775027
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite3 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 15.710050187888555,
                        TrueLongitude = 15.750439234543592,
                        TropicalLongitude = 16.350461849165601,
                        EquatorialLatitude = -0.22552636666623282,
                        r = 15.000197430193158,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.1989427162113895,
                            Y = 0.5892497591178314,
                            Z = -14.940590484629332
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.2009960764538665,
                            Y = 0.58999299750898071,
                            Z = -14.940590484629332
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    },
                    Satellite4 = new AASGalileanMoonDetail
                    {
                        MeanLongitude = 26.191041584184859,
                        TrueLongitude = 26.78207991279487,
                        TropicalLongitude = 27.38210252741688,
                        EquatorialLatitude = -0.14812913785252982,
                        r = 26.21292147756688,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0562579570535888,
                            Y = 1.0267842230921995,
                            Z = -25.224436370151338
                        },
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0719635944006294,
                            Y = 1.0289726841955222,
                            Z = -25.224436370151338
                        },
                        bInTransit = false,
                        bInOccultation = false,
                        bInEclipse = false,
                        bInShadowTransit = false
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(CalculateParameters))]
        public void CalculateTest(double JD, bool bHighPrecision, AASGalileanMoonsDetails expectedGalileanMoonsDetails)
        {
            AASGalileanMoonsDetails galileanDetails = AASGalileanMoons.Calculate(JD, bHighPrecision);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.TrueRectangularCoordinates.X, galileanDetails.Satellite1.TrueRectangularCoordinates.X);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.TrueRectangularCoordinates.Y, galileanDetails.Satellite1.TrueRectangularCoordinates.Y);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.TrueRectangularCoordinates.Z, galileanDetails.Satellite1.TrueRectangularCoordinates.Z);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.ApparentRectangularCoordinates.X, galileanDetails.Satellite1.ApparentRectangularCoordinates.X);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.ApparentRectangularCoordinates.Y, galileanDetails.Satellite1.ApparentRectangularCoordinates.Y);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.ApparentRectangularCoordinates.Z, galileanDetails.Satellite1.ApparentRectangularCoordinates.Z);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.MeanLongitude, galileanDetails.Satellite1.MeanLongitude);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.TrueLongitude, galileanDetails.Satellite1.TrueLongitude);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.TropicalLongitude, galileanDetails.Satellite1.TropicalLongitude);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.EquatorialLatitude, galileanDetails.Satellite1.EquatorialLatitude);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.r, galileanDetails.Satellite1.r);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.bInTransit, galileanDetails.Satellite1.bInTransit);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.bInOccultation, galileanDetails.Satellite1.bInOccultation);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.bInEclipse, galileanDetails.Satellite1.bInEclipse);
            Assert.Equal(expectedGalileanMoonsDetails.Satellite1.bInShadowTransit, galileanDetails.Satellite1.bInShadowTransit);
        }
    }
}