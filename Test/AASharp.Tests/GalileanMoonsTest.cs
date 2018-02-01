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
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.4502564722299685,
                            Y = 0.21371217530300798,
                            Z = -4.8189035218121994
                        },
                        EquatorialLatitude = 0.043408227813483045,
                        MeanLongitude = 335.60626717563719,
                        TropicalLongitude = 336.19975819826635,
                        TrueLongitude = 335.59973558364436,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = -3.449081238196583,
                            Y = 0.21362534128063418,
                            Z = -4.8189035218121994
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                        r = 5.9298927753080806
                    },
                    Satellite2 = new AASGalileanMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.4418153413194643,
                            Y = 0.27526299741507493,
                            Z = -5.74717181971092
                        },
                        EquatorialLatitude = 0.1565404248556195,
                        MeanLongitude = 62.342115081846714,
                        TropicalLongitude = 64.042247171784283,
                        TrueLongitude = 63.442224557162262,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.4380480123533257,
                            Y = 0.27512961012830561,
                            Z = -5.74717181971092
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                        r = 9.4037353462186477
                    },
                    Satellite3 = new AASGalileanMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.200997491935045,
                            Y = 0.59002913211257169,
                            Z = -14.940588946681506
                        },
                        EquatorialLatitude = -0.22552637142857754,
                        MeanLongitude = 15.710046048974618,
                        TropicalLongitude = 16.350457716305257,
                        TrueLongitude = 15.750435101683252,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 1.1989441339310929,
                            Y = 0.58928585014760482,
                            Z = -14.940588946681506
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                        r = 15.000197429473175
                    },
                    Satellite4 = new AASGalileanMoonDetail
                    {
                        ApparentRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0719669844021213,
                            Y = 1.029033711455297,
                            Z = -25.224432929377556
                        },
                        EquatorialLatitude = -0.14812913482639536,
                        MeanLongitude = 26.191039809840731,
                        TropicalLongitude = 27.382100732365373,
                        TrueLongitude = 26.782078117743367,
                        TrueRectangularCoordinates = new AAS3DCoordinate
                        {
                            X = 7.0562613798518408,
                            Y = 1.026845126361184,
                            Z = -25.224432929377556
                        },
                        bInEclipse = false,
                        bInOccultation = false,
                        bInShadowTransit = false,
                        bInTransit = false,
                        r = 26.212921473635607
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