using System;

namespace AASharp
{
    public static partial class AASELPMPP02
    {
        public enum Correction
        {
            Nominal = 0,
            LLR,
            DE405,
            DE406
        };

        public static readonly double[][] g_W_Nominal =
        {
            new double[]
            {
                3.8103440873402215, //AASCoordinateTransformation.DegreesToRadians(218 + 18/60.0 + 59.95571/3600.0 - 0.0708/3600.0)
                8399.6847317739157, //AASCoordinateTransformation.DegreesToRadians(1732559343.73604 / 3600.0),
                -3.3008054664661645e-05, //AASCoordinateTransformation.DegreesToRadians(-6.8084 / 3600.0)
                3.2017095500473753e-08, //AASCoordinateTransformation.DegreesToRadians(0.006604 / 3600.0),
                -1.5363745554361199e-10 //AASCoordinateTransformation.DegreesToRadians(-0.00003169 / 3600.0),
            },
            new double[]
            {
                1.4547885323225087, //AASCoordinateTransformation.DegreesToRadians(83 + 21/60.0 + 11.67475/3600.0)
                70.993305079674201, //AASCoordinateTransformation.DegreesToRadians(14643420.3171 / 3600.0),
                -0.00018550425880294177, //AASCoordinateTransformation.DegreesToRadians(-38.263 / 3600.0),
                -2.1839401892941267e-07, //AASCoordinateTransformation.DegreesToRadians(-0.045047 / 3600.0),
                1.0327016221314225e-09 //AASCoordinateTransformation.DegreesToRadians(0.00021301 / 3600.0)
            },
            new double[]
            {
                2.1824391972168398, //AASCoordinateTransformation.DegreesToRadians(125 + 2/60.0 + 40.39816/3600.0),
                -33.781427210382816, //AASCoordinateTransformation.DegreesToRadians(-6967919.5383 / 3600.0)
                3.0829301981755397e-05, //AASCoordinateTransformation.DegreesToRadians(6.359 / 3600.0),
                3.6967043184602122e-08, //AASCoordinateTransformation.DegreesToRadians(0.007625 / 3600.0),
                -1.7385418604587962e-10 //AASCoordinateTransformation.DegreesToRadians(-0.00003586 / 3600.0)
            }
        };

        public static readonly double[][] g_W_LLR =
        {
            new double[]
            {
                3.8103439203219081,
                8399.6847302074329,
                -3.3189520425500942e-05,
                3.2017095500473753e-08,
                -1.5363745554361197e-10
            },
            new double[]
            {
                1.4547893480700087,
                70.99330548230661,
                -0.00018550474361662286,
                -2.1839401892941265e-07,
                1.0327016221314225e-09
            },
            new double[]
            {
                2.1824386755573193,
                -33.781427433053146,
                3.082930198175539e-05,
                3.6967043184602116e-08,
                -1.738541860458796e-10
            }
        };

        public static readonly double[][] g_W_DE405 =
        {
            new double[]
            {
                3.8103440908308803,
                8399.68473007193,
                -3.3189520425500942e-05,
                3.2017095500473753e-08,
                -1.5363745554361197e-10
            },
            new double[]
            {
                1.4547895404440776,
                70.993305448479248,
                -0.00018550474361662286,
                -2.1839401892941265e-07,
                1.0327016221314225e-09
            },
            new double[]
            {
                2.1824388474237688,
                -33.781427419672326,
                3.082930198175539e-05,
                3.6967043184602116e-08,
                -1.738541860458796e-10
            }
        };

        public static readonly double[][] g_W_DE406 =
        {
            new double[]
            {
                3.8103440908308803,
                8399.68473007193,
                -3.3189520425500942e-05,
                3.1102494491060616e-08,
                -2.0328237648922842e-10
            },
            new double[]
            {
                1.4547895404440776,
                70.993305448479248,
                -0.00018548192818782712,
                -2.1961637966359414e-07,
                1.0327016221314225e-09
            },
            new double[]
            {
                2.1824388474237688,
                -33.781427419672326,
                3.0816644950982666e-05,
                3.6447710769397583e-08,
                -1.738541860458796e-10
            }
        };

        public static readonly double[] g_ZETA_Nominal =
        {
            3.8103440873402215,
            8399.7091120695241,
            -3.3008054664661645e-05,
            3.2017095500473753e-08,
            -1.5363745554361199e-10
        };

        public static readonly double[] g_ZETA_LLR =
        {
            3.8103439203219081,
            8399.7091105030413,
            -3.3189520425500942e-05,
            3.2017095500473753e-08,
            -1.5363745554361197e-10
        };

        public static readonly double[] g_ZETA_DE405 =
        {
            3.8103440908308803,
            8399.7091103675375,
            -3.3189520425500942e-05,
            3.2017095500473753e-08,
            -1.5363745554361197e-10
        };

        public static readonly double[] g_ZETA_DE406 =
        {
            3.8103440908308803,
            8399.7091103675375,
            -3.3189520425500942e-05,
            3.1102494491060616e-08,
            -2.0328237648922842e-10
        };

        public static readonly double[] g_EARTH_Nominal =
        {
            1.7534699468639550, //AASCoordinateTransformation.DegreesToRadians(100 + 27/60.0 + 59.13885/3600.0),
            628.30758504554331, //AASCoordinateTransformation.DegreesToRadians(129597742.293 / 3600.0),
            -9.7932363584126268e-08, //AASCoordinateTransformation.DegreesToRadians(-0.0202 / 3600.0),
            4.3633231299858238e-11, //AASCoordinateTransformation.DegreesToRadians(0.000009 / 3600.0),
            7.2722052166430391e-13 //AASCoordinateTransformation.DegreesToRadians(0.00000015 / 3600.0)
        };

        public static readonly double[] g_EARTH_LLR =
        {
            1.753469752356706,
            628.30758511545343,
            -9.7932363584126268e-08,
            4.3633231299858238e-11,
            7.2722052166430391e-13
        };

        public static readonly double[] g_EARTH_DE405 =
        {
            1.7534699452640696,
            628.30758508103156,
            -9.7932363584126268e-08,
            4.3633231299858238e-11,
            7.2722052166430391e-13
        };

        public static readonly double[] g_EARTH_DE406 = g_EARTH_DE405;

        public static readonly double[] g_PERI_Nominal =
        {
            1.7965956117694057, //AASCoordinateTransformation.DegreesToRadians(102 + 56/60.0 + 14.445766/3600.0),
            0.0056298669711442699, //AASCoordinateTransformation.DegreesToRadians(1161.24342 / 3600.0),
            2.5659491293243858e-06, //AASCoordinateTransformation.DegreesToRadians(0.529265 / 3600.0),
            -5.7275888286280579e-10, //AASCoordinateTransformation.DegreesToRadians(-0.00011814 / 3600.0),
            5.5166948773454099e-11 //AASCoordinateTransformation.DegreesToRadians(0.000011379 / 3600.0)
        };

        public static readonly double[] g_PERI_LLR =
        {
            1.7965954341045842,
            0.00562986697114427,
            2.5659491293243853e-06,
            -5.7275888286280579e-10,
            5.51669487734541e-11
        };

        public static readonly double[] g_PERI_DE405 =
        {
            1.7965956331206,
            0.00562986697114427,
            2.5659491293243853e-06,
            -5.7275888286280579e-10,
            5.51669487734541e-11
        };

        public static readonly double[] g_PERI_DE406 =
        {
            1.7965956331206,
            0.00562986697114427,
            2.5659491293243853e-06,
            -5.7275888286280579e-10,
            5.51669487734541e-11
        };

        public static readonly double[][] g_P =
        {
            new[]
            {
                4.4026086342191189, 2608.7903141569259
            }, //{ AASCoordinateTransformation.DegreesToRadians(252 + 15/60.0 + 3.216919/3600.0),  AASCoordinateTransformation.DegreesToRadians(538101628.68888 / 3600.0) },
            new[]
            {
                3.1761344571511088, 1021.3285547385308
            }, //{ AASCoordinateTransformation.DegreesToRadians(181 + 58/60.0 + 44.758419/3600.0), AASCoordinateTransformation.DegreesToRadians(210664136.45777 / 3600.0) },
            new[]
            {
                1.7534699468639550, 628.30758504554331
            }, //{ AASCoordinateTransformation.DegreesToRadians(100 + 27/60.0 + 59.13885/3600.0),  AASCoordinateTransformation.DegreesToRadians(129597742.293 / 3600.0)   },
            new[]
            {
                6.2034995986912955, 334.06124347172772
            }, //{ AASCoordinateTransformation.DegreesToRadians(355 + 26/60.0 + 3.642778/3600.0),  AASCoordinateTransformation.DegreesToRadians(68905077.65936 / 3600.0)  },
            new[]
            {
                0.59954667808842876, 52.969097211191368
            }, //{ AASCoordinateTransformation.DegreesToRadians(34  + 21/60.0 + 5.379392/3600.0),  AASCoordinateTransformation.DegreesToRadians(10925660.57335 / 3600.0)  },
            new[]
            {
                0.87401678344988065, 21.329907977851814
            }, //{ AASCoordinateTransformation.DegreesToRadians(50  + 4/60.0  + 38.902495/3600.0), AASCoordinateTransformation.DegreesToRadians(4399609.33632 / 3600.0)   },
            new[]
            {
                5.4812276258103312, 7.4781665690567305
            }, //{ AASCoordinateTransformation.DegreesToRadians(314 + 3/60.0  + 4.354234/3600.0),  AASCoordinateTransformation.DegreesToRadians(1542482.57845 / 3600.0)   },
            new[]
            {
                5.3118941049906994, 3.8132918131353417
            } //{ AASCoordinateTransformation.DegreesToRadians(304 + 20/60.0 + 56.808371/3600.0), AASCoordinateTransformation.DegreesToRadians(786547.89700 / 3600.0)    }
        };

        public static readonly ELPMPP02Pertubations[] g_PERT_S1 =
        {
            new ELPMPP02Pertubations(g_PERT_S1_1, g_PERT_S1_1.Length ),
            new ELPMPP02Pertubations(g_PERT_S1_2, g_PERT_S1_2.Length ),
            new ELPMPP02Pertubations(g_PERT_S1_3, g_PERT_S1_3.Length ),
            new ELPMPP02Pertubations(g_PERT_S1_4, g_PERT_S1_4.Length )
        };

        public static readonly ELPMPP02Pertubations[] g_PERT_S2 =
        {
            new ELPMPP02Pertubations(g_PERT_S2_1, g_PERT_S2_1.Length ),
            new ELPMPP02Pertubations(g_PERT_S2_2, g_PERT_S2_2.Length ),
            new ELPMPP02Pertubations(g_PERT_S2_3, g_PERT_S2_3.Length )
        };

        public static readonly ELPMPP02Pertubations[] g_PERT_S3 =
        {
            new ELPMPP02Pertubations(g_PERT_S3_1, g_PERT_S3_1.Length ),
            new ELPMPP02Pertubations(g_PERT_S3_2, g_PERT_S3_2.Length ),
            new ELPMPP02Pertubations(g_PERT_S3_3, g_PERT_S3_3.Length ),
            new ELPMPP02Pertubations(g_PERT_S3_4, g_PERT_S3_4.Length )
        };


        //public static double EclipticLongitude(double* pT, int nTSize, Correction correction, double* pDerivative)
        public static double EclipticLongitude(ref double[] pT, int nTSize, Correction correction, ref double pDerivative)
        {
            //Validate our parameters
            //assert(pT);
            //assert(nTSize == 5);
            //UNREFERENCED_PARAMETER(nTSize);

            //Work out the right data arrays to use
            //double (*g_pW)[3][5] = nullptr;
            //double(*g_pEARTH)[5] = nullptr;
            //double(*g_pPERI)[5] = nullptr;
            //double(*g_pZETA)[5] = nullptr;
            //double* g_MAIN_S1_Coeff = nullptr;

            double[][] g_pW = new double[3][];
            double[] g_pEARTH = new double[5];
            double[] g_pPERI = new double[5];
            double[] g_pZETA = new double[5];
            double[] g_MAIN_S1_Coeff = null;
            switch (correction)
            {
                case Correction.Nominal:
                {
                    g_pW = g_W_Nominal;
                    g_pEARTH = g_EARTH_Nominal;
                    g_pPERI = g_PERI_Nominal;
                    g_pZETA = g_ZETA_Nominal;
                    g_MAIN_S1_Coeff = g_MAIN_S1_Nominal;
                    break;
                }
                case Correction.LLR:
                {
                    g_pW = g_W_LLR;
                    g_pEARTH = g_EARTH_LLR;
                    g_pPERI = g_PERI_LLR;
                    g_pZETA = g_ZETA_LLR;
                    g_MAIN_S1_Coeff = g_MAIN_S1_LLR;
                    break;
                }
                case Correction.DE405:
                {
                    g_pW = g_W_DE405;
                    g_pEARTH = g_EARTH_DE405;
                    g_pPERI = g_PERI_DE405;
                    g_pZETA = g_ZETA_DE405;
                    g_MAIN_S1_Coeff = g_MAIN_S1_DE405;
                    break;
                }
                case Correction.DE406:
                {
                    g_pW = g_W_DE406;
                    g_pEARTH = g_EARTH_DE406;
                    g_pPERI = g_PERI_DE406;
                    g_pZETA = g_ZETA_DE406;
                    g_MAIN_S1_Coeff = g_MAIN_S1_DE406;
                    break;
                }
                default:
                {
                    throw new ArgumentException($"{correction} is not a valid value", nameof(correction));
                }
            }
            //assert(g_pW);
            //assert(g_pPERI);
            //assert(g_pEARTH);
            //assert(g_pZETA);

            double[][] g_W = g_pW;
            double[] g_EARTH = g_pEARTH;
            double[] g_PERI = g_pPERI;
            double[] g_ZETA = g_pZETA;

            //Setup the Delaunay array

            double[,] fDelaunay = new double[4, 5];
            for (int i = 0; i < 5; i++)
            {
                fDelaunay[0, i] = g_W[0][i] - g_EARTH[i]; //D
                fDelaunay[1, i] = g_W[0][i] - g_W[2][i]; //F
                fDelaunay[2, i] = g_W[0][i] - g_W[1][i]; //l
                fDelaunay[3, i] = g_EARTH[i] - g_PERI[i]; //l'
            }

            fDelaunay[0, 0] += AASCoordinateTransformation.PI();

            //What will be the return value from this method
            double fResult = 0;

            //Set the output parameter to a default value if required
            //if (pDerivative)
            pDerivative = 0;

            //First the main problem
            int nEndI = g_MAIN_S1.Length; //g_MAIN_S1[0]);
            for (int i = 0; i < nEndI; i++)
            {
                double[] fFi = new double[5];
                for (int a = 0; a < 5; a++)
                {
                    for (int j = 0; j < 4; j++)
                        fFi[a] += g_MAIN_S1[i].m_I[j] * fDelaunay[j, a];
                }

                double y = fFi[0];
                double yp = 0;
                for (int k = 1; k <= 4; k++)
                {
                    y += fFi[k] * pT[k];
                    yp += k * fFi[k] * pT[k - 1];
                }

                fResult += g_MAIN_S1_Coeff[i] * Math.Sin(y);
                //if (pDerivative)
                pDerivative += g_MAIN_S1_Coeff[i] * Math.Cos(y) * yp;
            }

            //Then the perturbations
            int nEndk = g_PERT_S1.Length; //g_PERT_S1[0]);
            for (int k = 0; k < nEndk; k++)
            {
                int nEndP = g_PERT_S1[k].m_nTableSize;
                for (int p = 0; p < nEndP; p++)
                {
                    double[] fFi = new double[5];
                    fFi[0] = Math.Atan2(g_PERT_S1[k].m_pTable[p].m_C, g_PERT_S1[k].m_pTable[p].m_S);
                    if (fFi[0] < 0)
                        fFi[0] += (AASCoordinateTransformation.PI() * 2);
                    for (int a = 0; a < 5; a++)
                    {
                        for (int i = 0; i < 4; i++)
                            fFi[a] += g_PERT_S1[k].m_pTable[p].m_I[i] * fDelaunay[i, a];
                        if (a < 2)
                        {
                            for (int i = 4; i < 12; i++)
                                fFi[a] += g_PERT_S1[k].m_pTable[p].m_I[i] * g_P[i - 4][a];
                        }

                        fFi[a] += g_PERT_S1[k].m_pTable[p].m_I[12] * g_ZETA[a];
                    }

                    double y = fFi[0];
                    double yp = 0;
                    for (int i = 1; i <= 4; i++)
                    {
                        y += fFi[i] * pT[i];
                        yp += i * fFi[i] * pT[i - 1];
                    }

                    double x = Math.Sqrt(g_PERT_S1[k].m_pTable[p].m_S * g_PERT_S1[k].m_pTable[p].m_S +
                                         g_PERT_S1[k].m_pTable[p].m_C * g_PERT_S1[k].m_pTable[p].m_C);
                    fResult += x * pT[k] * Math.Sin(y);
                    //if (pDerivative)
                    //{
                    if (k == 0)
                        pDerivative += x * pT[k] * yp * Math.Cos(y);
                    else
                        pDerivative += (k * x * pT[k - 1]) * Math.Sin(y) + x * pT[k] * yp * Math.Cos(y);
                    ///}
                }
            }

            fResult = AASCoordinateTransformation.MapTo0To360Range(
                fResult / 3600.0 + AASCoordinateTransformation.RadiansToDegrees(
                    g_W[0][0] + g_W[0][1] * pT[1] + g_W[0][2] * pT[2] + g_W[0][3] * pT[3] + g_W[0][4] * pT[4]));
            //if (pDerivative)
            //{
            pDerivative = pDerivative / 3600.0 +
                          AASCoordinateTransformation.RadiansToDegrees(
                              g_W[0][1] + 2 * g_W[0][2] * pT[1] + 3 * g_W[0][3] * pT[2] + 4 * g_W[0][4] * pT[3]);
            pDerivative /= 36525.0;
            //}
            return fResult;
        }

        public static double EclipticLongitude(double JD, Correction correction, ref double pDerivative)
        {
            //Calculate Julian centuries array
            double[] t = new double[5];
            t[0] = 1;
            t[1] = (JD - 2451545.0) / 36525.0;
            t[2] = t[1] * t[1];
            t[3] = t[2] * t[1];
            t[4] = t[3] * t[1];

            //Delegate to the other version of the method
            return EclipticLongitude(ref t, 5, correction, ref pDerivative);
        }

        public static double EclipticLatitude(ref double[] pT, int nTSize, Correction correction, ref double pDerivative)
        {
            //Validate our parameters
            //assert(pT);
            //assert(nTSize == 5);
            //UNREFERENCED_PARAMETER(nTSize);

            //Work out the right data arrays to use
            double[][] g_pW = new double[3][];
            double[] g_pEARTH = new double[5];
            double[] g_pPERI = new double[5];
            double[] g_pZETA = new double[5];
            double[] g_MAIN_S2_Coeff = new double[0];
            switch (correction)
            {
                case Correction.Nominal:
                {
                    g_pW = g_W_Nominal;
                    g_pEARTH = g_EARTH_Nominal;
                    g_pPERI = g_PERI_Nominal;
                    g_pZETA = g_ZETA_Nominal;
                    g_MAIN_S2_Coeff = g_MAIN_S2_Nominal;
                    break;
                }
                case Correction.LLR:
                {
                    g_pW = g_W_LLR;
                    g_pEARTH = g_EARTH_LLR;
                    g_pPERI = g_PERI_LLR;
                    g_pZETA = g_ZETA_LLR;
                    g_MAIN_S2_Coeff = g_MAIN_S2_LLR;
                    break;
                }
                case Correction.DE405:
                {
                    g_pW = g_W_DE405;
                    g_pEARTH = g_EARTH_DE405;
                    g_pPERI = g_PERI_DE405;
                    g_pZETA = g_ZETA_DE405;
                    g_MAIN_S2_Coeff = g_MAIN_S2_DE405;
                    break;
                }
                case Correction.DE406:
                {
                    g_pW = g_W_DE406;
                    g_pEARTH = g_EARTH_DE406;
                    g_pPERI = g_PERI_DE406;
                    g_pZETA = g_ZETA_DE406;
                    g_MAIN_S2_Coeff = g_MAIN_S2_DE406;
                    break;
                }
                default:
                {
                    //assert(false);
                    break;
                }
            }
            //assert(g_pW);
            //assert(g_pPERI);
            //assert(g_pEARTH);
            //assert(g_pZETA);

            double[][] g_W = g_pW;
            double[] g_EARTH = g_pEARTH;
            double[] g_PERI = g_pPERI;
            double[] g_ZETA = g_pZETA;

            //Setup the Delaunay array
            double[,] fDelaunay = new double[4, 5];
            ;
            for (int i = 0; i < 5; i++)
            {
                fDelaunay[0, i] = g_W[0][i] - g_EARTH[i]; //D
                fDelaunay[1, i] = g_W[0][i] - g_W[2][i]; //F
                fDelaunay[2, i] = g_W[0][i] - g_W[1][i]; //l
                fDelaunay[3, i] = g_EARTH[i] - g_PERI[i]; //l'
            }

            fDelaunay[0, 0] += AASCoordinateTransformation.PI();

            //What will be the return value from this method
            double fResult = 0;

            //Set the output parameter to a default value if required
            //if (pDerivative)
            //  pDerivative = 0;

            //First the main problem
            int nEndI = g_MAIN_S2.Length; //g_MAIN_S2[0]);
            for (int i = 0; i < nEndI; i++)
            {
                double[] fFi = new double[5];
                for (int a = 0; a < 5; a++)
                {
                    for (int j = 0; j < 4; j++)
                        fFi[a] += g_MAIN_S2[i].m_I[j] * fDelaunay[j, a];
                }

                double y = fFi[0];
                double yp = 0;
                for (int k = 1; k <= 4; k++)
                {
                    y += fFi[k] * pT[k];
                    yp += k * fFi[k] * pT[k - 1];
                }

                fResult += g_MAIN_S2_Coeff[i] * Math.Sin(y);
                //if (pDerivative) 
                pDerivative += g_MAIN_S2_Coeff[i] * Math.Cos(y) * yp;
            }

            //Then the perturbations
            int nEndk = g_PERT_S2.Length; //g_PERT_S2[0]);
            for (int k = 0; k < nEndk; k++)
            {
                int nEndP = g_PERT_S2[k].m_nTableSize;
                for (int p = 0; p < nEndP; p++)
                {
                    double[] fFi = new double[5];
                    fFi[0] = Math.Atan2(g_PERT_S2[k].m_pTable[p].m_C, g_PERT_S2[k].m_pTable[p].m_S);
                    if (fFi[0] < 0)
                        fFi[0] += (AASCoordinateTransformation.PI() * 2);
                    for (int a = 0; a < 5; a++)
                    {
                        for (int i = 0; i < 4; i++)
                            fFi[a] += g_PERT_S2[k].m_pTable[p].m_I[i] * fDelaunay[i, a];
                        if (a < 2)
                        {
                            for (int i = 4; i < 12; i++)
                                fFi[a] += g_PERT_S2[k].m_pTable[p].m_I[i] * g_P[i - 4][a];
                        }

                        fFi[a] += g_PERT_S2[k].m_pTable[p].m_I[12] * g_ZETA[a];
                    }

                    double y = fFi[0];
                    double yp = 0;
                    for (int i = 1; i <= 4; i++)
                    {
                        y += fFi[i] * pT[i];
                        yp += i * fFi[i] * pT[i - 1];
                    }

                    double x = Math.Sqrt(g_PERT_S2[k].m_pTable[p].m_S * g_PERT_S2[k].m_pTable[p].m_S +
                                         g_PERT_S2[k].m_pTable[p].m_C * g_PERT_S2[k].m_pTable[p].m_C);
                    fResult += x * pT[k] * Math.Sin(y);
                    //if (pDerivative)
                    //{
                    if (k == 0)
                        pDerivative += x * pT[k] * yp * Math.Cos(y);
                    else
                        pDerivative += (k * x * pT[k - 1]) * Math.Sin(y) + x * pT[k] * yp * Math.Cos(y);
                    //}
                }
            }

            fResult = AASCoordinateTransformation.MapToMinus90To90Range(fResult / 3600.0);
            //if (pDerivative)
            pDerivative = pDerivative / (3600.0 * 36525.0);
            return fResult;
        }

        public static double EclipticLatitude(double JD, Correction correction, ref double pDerivative)
        {
            //Calculate Julian centuries array
            double[] t = new double[5];
            t[0] = 1;
            t[1] = (JD - 2451545.0) / 36525.0;
            t[2] = t[1] * t[1];
            t[3] = t[2] * t[1];
            t[4] = t[3] * t[1];

            //Delegate to the other version of this method
            return EclipticLatitude(ref t, 5, correction, ref pDerivative);
        }

        public static double RadiusVector(ref double[] pT, int nTSize, Correction correction, ref double pDerivative)
        {
            //Validate our parameters
            //assert(pT);
            //assert(nTSize == 5);
            //UNREFERENCED_PARAMETER(nTSize);

            //Work out the right data arrays to use
            double[][] g_pW = new double[3][];
            double[] g_pEARTH = new double[5];
            double[] g_pPERI = new double[5];
            double[] g_pZETA = new double[5];
            double[] g_MAIN_S3_Coeff = new double[0];

            switch (correction)
            {
                case Correction.Nominal:
                {
                    g_pW = g_W_Nominal;
                    g_pEARTH = g_EARTH_Nominal;
                    g_pPERI = g_PERI_Nominal;
                    g_pZETA = g_ZETA_Nominal;
                    g_MAIN_S3_Coeff = g_MAIN_S3_Nominal;
                    break;
                }
                case Correction.LLR:
                {
                    g_pW = g_W_LLR;
                    g_pEARTH = g_EARTH_LLR;
                    g_pPERI = g_PERI_LLR;
                    g_pZETA = g_ZETA_LLR;
                    g_MAIN_S3_Coeff = g_MAIN_S3_LLR;
                    break;
                }
                case Correction.DE405:
                {
                    g_pW = g_W_DE405;
                    g_pEARTH = g_EARTH_DE405;
                    g_pPERI = g_PERI_DE405;
                    g_pZETA = g_ZETA_DE405;
                    g_MAIN_S3_Coeff = g_MAIN_S3_DE405;
                    break;
                }
                case Correction.DE406:
                {
                    g_pW = g_W_DE406;
                    g_pEARTH = g_EARTH_DE406;
                    g_pPERI = g_PERI_DE406;
                    g_pZETA = g_ZETA_DE406;
                    g_MAIN_S3_Coeff = g_MAIN_S3_DE406;
                    break;
                }
                default:
                {
                    throw new ArgumentException($"{correction} is not a valid value", nameof(correction));
                }
            }
            //assert(g_pW);
            //assert(g_pPERI);
            //assert(g_pEARTH);
            //assert(g_pZETA);

            double[][] g_W = g_pW;
            double[] g_EARTH = g_pEARTH;
            double[] g_PERI = g_pPERI;
            double[] g_ZETA = g_pZETA;

            //Setup the Delaunay array
            double[,] fDelaunay = new double[4, 5];
            for (int i = 0; i < 5; i++)
            {
                fDelaunay[0, i] = g_W[0][i] - g_EARTH[i]; //D
                fDelaunay[1, i] = g_W[0][i] - g_W[2][i]; //F
                fDelaunay[2, i] = g_W[0][i] - g_W[1][i]; //l
                fDelaunay[3, i] = g_EARTH[i] - g_PERI[i]; //l'
            }

            fDelaunay[0, 0] += AASCoordinateTransformation.PI();

            //What will be the return value from this method
            double fResult = 0;

            //Set the output parameter to a default value if required
            //if (pDerivative)
            pDerivative = 0;

            //First the main problem
            int nEndI = g_MAIN_S3.Length; //g_MAIN_S3[0]);
            for (int i = 0; i < nEndI; i++)
            {
                double[] fFi = new double[5];
                for (int a = 0; a < 5; a++)
                {
                    for (int j = 0; j < 4; j++)
                        fFi[a] += g_MAIN_S3[i].m_I[j] * fDelaunay[j, a];
                }

                double y = fFi[0];
                double yp = 0;
                for (int k = 1; k <= 4; k++)
                {
                    y += fFi[k] * pT[k];
                    yp += k * fFi[k] * pT[k - 1];
                }

                fResult += g_MAIN_S3_Coeff[i] * Math.Cos(y);
                //if (pDerivative)

                pDerivative -= g_MAIN_S3_Coeff[i] * Math.Sin(y) * yp;
            }

            //Then the perturbations
            int nEndk = g_PERT_S3.Length; //g_PERT_S3[0]);
            for (int k = 0; k < nEndk; k++)
            {
                int nEndP = g_PERT_S3[k].m_nTableSize;
                for (int p = 0; p < nEndP; p++)
                {
                    double[] fFi = new double[5];
                    fFi[0] = Math.Atan2(g_PERT_S3[k].m_pTable[p].m_C, g_PERT_S3[k].m_pTable[p].m_S);
                    if (fFi[0] < 0)
                        fFi[0] += (AASCoordinateTransformation.PI() * 2);
                    for (int a = 0; a < 5; a++)
                    {
                        for (int i = 0; i < 4; i++)
                            fFi[a] += g_PERT_S3[k].m_pTable[p].m_I[i] * fDelaunay[i, a];
                        if (a < 2)
                        {
                            for (int i = 4; i < 12; i++)
                                fFi[a] += g_PERT_S3[k].m_pTable[p].m_I[i] * g_P[i - 4][a];
                        }

                        fFi[a] += g_PERT_S3[k].m_pTable[p].m_I[12] * g_ZETA[a];
                    }

                    double y = fFi[0];
                    double yp = 0;
                    for (int i = 1; i <= 4; i++)
                    {
                        y += fFi[i] * pT[i];
                        yp += i * fFi[i] * pT[i - 1];
                    }

                    double x = Math.Sqrt(g_PERT_S3[k].m_pTable[p].m_S * g_PERT_S3[k].m_pTable[p].m_S +
                                         g_PERT_S3[k].m_pTable[p].m_C * g_PERT_S3[k].m_pTable[p].m_C);
                    fResult += x * pT[k] * Math.Sin(y);
                    //if (pDerivative)
                    //{
                    if (k == 0)
                        pDerivative += x * pT[k] * yp * Math.Cos(y);
                    else
                        pDerivative += (k * x * pT[k - 1]) * Math.Sin(y) + x * pT[k] * yp * Math.Cos(y);
                    //}
                }
            }

            fResult *= 0.99999994982652029474691585875733;
            //if (pDerivative)
            pDerivative /= 36525.0;

            return fResult;
        }

        public static double RadiusVector(double JD, Correction correction, ref double pDerivative)
        {
            //Calculate Julian centuries array
            double[] t = new double[5];
            t[0] = 1;
            t[1] = (JD - 2451545.0) / 36525.0;
            t[2] = t[1] * t[1];
            t[3] = t[2] * t[1];
            t[4] = t[3] * t[1];

            //Delegate to the other version of this method
            return RadiusVector(ref t, 5, correction, ref pDerivative);
        }

        public static AAS3DCoordinate EclipticRectangularCoordinates(ref double[] pT, int nTSize, Correction correction, ref AAS3DCoordinate pDerivative)
        {
            double fLongitudeDerivative = 0;
            double fLongitude = EclipticLongitude(ref pT, nTSize, correction, ref fLongitudeDerivative);
            fLongitudeDerivative *= 36525.0;
            double fLatitudeDerivative = 0;
            double fLatitude = EclipticLatitude(ref pT, nTSize, correction, ref fLatitudeDerivative);
            fLatitudeDerivative *= 36525.0;
            double fRadiusDerivative = 0;
            double fRadius = RadiusVector(ref pT, nTSize, correction, ref fRadiusDerivative);
            fRadiusDerivative *= 36525.0;
            fLongitude = AASCoordinateTransformation.DegreesToRadians(fLongitude);
            fLongitudeDerivative = AASCoordinateTransformation.DegreesToRadians(fLongitudeDerivative);
            fLatitude = AASCoordinateTransformation.DegreesToRadians(fLatitude);
            fLatitudeDerivative = AASCoordinateTransformation.DegreesToRadians(fLatitudeDerivative);
            double fCosLong = Math.Cos(fLongitude);
            double fSinLong = Math.Sin(fLongitude);
            double fCosLat = Math.Cos(fLatitude);
            double fSinLat = Math.Sin(fLatitude);
            double fRCosLat = fRadius * fCosLat;
            double fRSinLat = fRadius * fSinLat;
            AAS3DCoordinate value = new AAS3DCoordinate();
            value.X = fRCosLat * fCosLong;
            value.Y = fRCosLat * fSinLong;
            value.Z = fRSinLat;

            //if (pDerivative)
            //{
            pDerivative.X = ((fRadiusDerivative * fCosLat - fLatitudeDerivative * fRSinLat) * fCosLong -
                             fLongitudeDerivative * value.Y) / 36525.0;
            pDerivative.Y = ((fRadiusDerivative * fCosLat - fLatitudeDerivative * fRSinLat) * fSinLong +
                             fLongitudeDerivative * value.X) / 36525.0;
            pDerivative.Z = (fRadiusDerivative * fSinLat + fLatitudeDerivative * fRCosLat) / 36525.0;
            //}

            return value;
        }

        public static AAS3DCoordinate EclipticRectangularCoordinates(double JD, Correction correction, ref AAS3DCoordinate pDerivative)
        {
            //Calculate Julian centuries array
            double[] t = new double[5];
            t[0] = 1;
            t[1] = (JD - 2451545.0) / 36525.0;
            t[2] = t[1] * t[1];
            t[3] = t[2] * t[1];
            t[4] = t[3] * t[1];

            //Delegate to the other version of this method
            return EclipticRectangularCoordinates(ref t, 5, correction, ref pDerivative);
        }

        public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(ref double[] pT, int nTSize,
            Correction correction, ref AAS3DCoordinate pDerivative)
        {
            //Validate our parameters
            //assert(pT);
            //assert(nTSize == 5);


            double[] LaskarsP = new[]
            {
                1.0180391e-5,
                4.7020439e-7,
                -5.417367e-10,
                -2.507948e-12,
                4.63486e-15
            };

            double[] LaskarsQ = new[]
            {
                -1.13469002e-4,
                1.2372674e-7,
                1.265417e-9,
                -1.371808e-12,
                -3.20334e-15
            };

            AAS3DCoordinate EclipticDerivative = new AAS3DCoordinate();
            AAS3DCoordinate Ecliptic =
                EclipticRectangularCoordinates(ref pT, nTSize, correction, ref EclipticDerivative);
            EclipticDerivative.X *= 36525.0;
            EclipticDerivative.Y *= 36525.0;
            EclipticDerivative.Z *= 36525.0;
            double fP = (LaskarsP[0] + LaskarsP[1] * pT[1] + LaskarsP[2] * pT[2] + LaskarsP[3] * pT[3] +
                         LaskarsP[4] * pT[4]) * pT[1];
            double fQ = (LaskarsQ[0] + LaskarsQ[1] * pT[1] + LaskarsQ[2] * pT[2] + LaskarsQ[3] * pT[3] +
                         LaskarsQ[4] * pT[4]) * pT[1];
            double fTwoP = 2 * fP;
            double fP2 = fP * fP;
            double fQ2 = fQ * fQ;
            double fOneMinus2P2 = 1 - 2 * fP2;
            double fOneMinus2Q2 = 1 - 2 * fQ2;
            double fTwoPQ = fTwoP * fQ;
            double fTwosqrt1MinusPart = 2 * Math.Sqrt(1 - fP2 - fQ2);
            double fPTwosqrt1MinusPart = fP * fTwosqrt1MinusPart;
            double fQTwosqrt1MinusPart = fQ * fTwosqrt1MinusPart;
            AAS3DCoordinate J2000 = new AAS3DCoordinate();
            J2000.X = fOneMinus2P2 * Ecliptic.X + fTwoPQ * Ecliptic.Y + fPTwosqrt1MinusPart * Ecliptic.Z;
            J2000.Y = fTwoPQ * Ecliptic.X + fOneMinus2Q2 * Ecliptic.Y - fQTwosqrt1MinusPart * Ecliptic.Z;
            J2000.Z = -fPTwosqrt1MinusPart * Ecliptic.X + fQTwosqrt1MinusPart * Ecliptic.Y +
                      (fOneMinus2P2 + fOneMinus2Q2 - 1) * Ecliptic.Z;
            //if (pDerivative)
            //{
            double fPp = LaskarsP[0] +
                         (2 * LaskarsP[1] + 3 * LaskarsP[2] * pT[1] + 4 * LaskarsP[3] * pT[2] +
                          5 * LaskarsP[3] * pT[4]) * pT[1];
            double fQp = LaskarsQ[0] +
                         (2 * LaskarsQ[1] + 3 * LaskarsQ[2] * pT[1] + 4 * LaskarsQ[3] * pT[2] +
                          5 * LaskarsQ[3] * pT[4]) * pT[1];
            double fMinus4PPp = -4 * fP * fPp;
            double fMinus4QQp = -4 * fQ * fQp;
            double fTwoPpQpQp = 2 * (fPp * fQ + fP * fQp);
            double fK1 = (fMinus4PPp + fMinus4QQp) / fTwosqrt1MinusPart;
            double fK2 = fPp * fTwosqrt1MinusPart + fP * fK1;
            double fK3 = fQp * fTwosqrt1MinusPart + fQ * fK1;
            pDerivative.X = (fOneMinus2P2 * EclipticDerivative.X + fTwoPQ * EclipticDerivative.Y +
                             fPTwosqrt1MinusPart * EclipticDerivative.Z + fMinus4PPp * Ecliptic.X +
                             fTwoPpQpQp * Ecliptic.Y + fK2 * Ecliptic.Z) / 36525.0;
            pDerivative.Y = (fTwoPQ * EclipticDerivative.X + fOneMinus2Q2 * EclipticDerivative.Y -
                             fQTwosqrt1MinusPart * EclipticDerivative.Z + fTwoPpQpQp * Ecliptic.X +
                             fMinus4QQp * Ecliptic.Y - fK3 * Ecliptic.Z) / 36525.0;
            pDerivative.Z = (-fPTwosqrt1MinusPart * EclipticDerivative.X + fQTwosqrt1MinusPart * EclipticDerivative.Y +
                             (fOneMinus2P2 + fOneMinus2Q2 - 1) * EclipticDerivative.Z - fK2 * Ecliptic.X +
                             fK3 * Ecliptic.Y + (fMinus4PPp + fMinus4QQp) * Ecliptic.Z) / 36525.0;
            //}
            return J2000;
        }

        public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(double JD, Correction correction,
            ref AAS3DCoordinate pDerivative)
        {
            //Calculate Julian centuries array
            double[] t = new double[5];
            t[0] = 1;
            t[1] = (JD - 2451545.0) / 36525.0;
            t[2] = t[1] * t[1];
            t[3] = t[2] * t[1];
            t[4] = t[3] * t[1];

            //Delegate to the other version of this method
            return EclipticRectangularCoordinatesJ2000(ref t, 5, correction, ref pDerivative);
        }
    }
}