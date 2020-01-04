using System;

namespace AASharp
{
    internal static partial class AASELP2000
    {
        //Lunar constants
        static double AM = 0.074801329518;
        static double DTASM = 0.022921886117733679; //ALFA * 2.0 / (AM * 3.0) where ALFA .002571881335

        //Lunar arguments
        public static readonly double[] g_W =
        {
            3.8103444305883079, //AASCoordinateTransformation.DegreesToRadians(218 + 18/60.0 + 59.95571/3600.0),
            1.4547885323225087, //AASCoordinateTransformation.DegreesToRadians(83 + 21/60.0 + 11.67475/3600.0),
            2.1824391972168398, //AASCoordinateTransformation.DegreesToRadians(125 + 2/60.0 + 40.39816/3600.0),
            8399.6847317739139, //1732559343.73604"
            70.993304818359618, //14643420.2632"
            -33.781426356625921, //-6967919.3622"
            -2.8547283984772807e-5, //-5.8883"
            -0.00018557504160038375, //-38.2776"
            3.0844816019550893e-5, //6.3622"
            3.2017095500473753e-8, //0.006604"
            -2.1839401892941265e-7, //-0.045047"
            3.6967043184602116e-8, //0.007625"
            -1.5363745554361197e-10, //-0.00003169"
            1.0327016221314225e-9, //0.00021301"
            -1.7385418604587960e-10 //-0.00003586"
        };

        public static readonly double[] g_EARTH =
        {
            1.7534703431506580, //AASCoordinateTransformation.DegreesToRadians(100 + 27/60.0 + 59.22059/3600.0)
            628.30758496215537, //129597742.2758"
            -9.7932363584126268e-8, //-0.0202"
            4.3633231299858238e-11, //0.000009"
            7.2722052166430391e-13 //0.00000015"
        };

        public static readonly double[] g_PERI =
        {
            1.7965955233587829, //AASCoordinateTransformation.DegreesToRadians(102 + 56/60.0 + 14.42753/3600.0),
            0.0056297936673156855, //1161.2283"
            2.5826024792704977e-6, //0.5327"
            -6.6904287993115966e-10, //-0.000138"
            0.0
        };

        //Planetary arguments
        public static readonly double[][] g_P =
        {
            new double[]
            {
                4.4026088424029615, 2608.7903141574106
            }, //AASCoordinateTransformation.DegreesToRadians(252 + 15/60.0 + 3.25986/3600.0),   538101628.68898"
            new double[]
            {
                3.1761466969075944, 1021.3285546211089
            }, //AASCoordinateTransformation.DegreesToRadians(181 + 58/60.0 + 47.28305/3600.0),  210664136.43355"
            new double[]
            {
                1.7534703431506580, 628.30758496215537
            }, //g_EARTH[0],                                                                      g_EARTH[1]
            new double[]
            {
                6.2034809133999449, 334.06124314922965
            }, //AASCoordinateTransformation.DegreesToRadians(355 + 25/60.0 + 59.78866/3600.0),  68905077.59284"
            new double[]
            {
                0.59954649738867349, 52.969096509472053
            }, //AASCoordinateTransformation.DegreesToRadians(34  + 21/60.0 + 5.34212/3600.0),   10925660.42861"
            new double[]
            {
                0.87401675651848076, 21.329909543800007
            }, //AASCoordinateTransformation.DegreesToRadians(50  + 4/60.0  + 38.89694/3600.0),  4399609.65932"
            new double[]
            {
                5.4812938716049908, 7.4781598567143535
            }, //AASCoordinateTransformation.DegreesToRadians(314 + 3/60.0  + 18.01841/3600.0),  1542481.19393"
            new double[]
            {
                5.3118862867834666, 3.8133035637584558
            } //AASCoordinateTransformation.DegreesToRadians(304 + 20/60.0 + 55.19575/3600.0),  786550.32074"
        };

        //Corrections of the constants (fit to DE200/LE200)
        static double g_DELNU = 3.2093561586235289e-10; //0.55604" / g_W[3]
        static double g_DELE = 8.6733167550495987e-8; //0.01789"
        static double g_DELG = -3.9105071518295170e-7; //-0.08066"
        static double g_DELNP = -3.7078095034525493e-11; //-0.06424" / g_W[3]
        static double g_DELEP = -6.2439153990097128e-7; //-0.12879"

        public static readonly double[] g_ZETA =
        {
            3.8103444305883079, //g_W[0]
            8399.7091135222672 //g_W[3] + 5029.0966"
        };
        
        public static double MoonMeanLongitude(double[] pT, int nTSize) //Aka W1
        {   
          //Validate our parameters
          ////assert(pT);
          ////assert((nTSize == 5) || (nTSize == 2));

          double fValue = g_W[0] + g_W[3] * pT[1];

          if (nTSize == 5)
          {
            fValue += g_W[6] * pT[2] + g_W[9] * pT[3] + g_W[12] * pT[4];
          }

          return fValue;
        }

        public static double MoonMeanLongitude(double JD) //Aka W1
        {
          //Calculate Julian centuries
          double[] t = new double[5];
          t[0] = 1;
          t[1] = (JD - 2451545.0) / 36525.0;
          t[2] = t[1] * t[1];
          t[3] = t[2] * t[1];
          t[4] = t[3] * t[1];

          return MoonMeanLongitude(t, 5);
        }

        public static double MoonMeanLongitudeLunarPerigee(double[] pT, int nTSize) //Aka W2
        {
            //Validate our parameters
            //assert(pT);
            //assert((nTSize == 5) || (nTSize == 2));

            double fValue = g_W[1] + g_W[4] * pT[1];
            if (nTSize == 5)
            {
              fValue += g_W[7] * pT[2] + g_W[10] * pT[3] + g_W[13] * pT[4];

            }

            return fValue;
        }

public static double MoonMeanLongitudeLunarPerigee(double JD) //Aka W2
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return MoonMeanLongitudeLunarPerigee(t, 5);
}

public static double MoonMeanLongitudeLunarAscendingNode(double[] pT, int nTSize) //Aka W3
{
  //Validate our parameters
  //assert(pT);
  //assert((nTSize == 5) || (nTSize == 2));

  double fValue = g_W[2] + g_W[5] * pT[1];
  if (nTSize == 5)
    fValue += g_W[8] * pT[2] + g_W[11] * pT[3] + g_W[14] * pT[4];
  return fValue;
}

public static double MoonMeanLongitudeLunarAscendingNode(double JD) //Aka W3
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return MoonMeanLongitudeLunarAscendingNode(t, 5);
}

public static double EarthMoonBarycentreMeanLongitude(double[] pT, int nTSize) //Aka T
{
  //Validate our parameters
  //assert(pT);
  //assert((nTSize == 5) || (nTSize == 2));

  double fValue = g_EARTH[0] + g_EARTH[1] * pT[1];
  
  if (nTSize == 5)
  {
    fValue += g_EARTH[2] * pT[2] + g_EARTH[3] * pT[3] + g_EARTH[4] * pT[4];
  }

  return fValue;
}

public static double EarthMoonBarycentreMeanLongitude(double JD) //Aka T
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return EarthMoonBarycentreMeanLongitude(t, 5);
}

public static double EarthMoonBarycentreMeanLongitudeOfPerihelion(double[] pT, int nTSize) //Aka Omega'
{
  //Validate our parameters
  //assert(pT);
  //assert((nTSize == 5) || (nTSize == 2));
  
  double fValue = g_PERI[0] + g_PERI[1] * pT[1];
  if (nTSize == 5)
  {
    fValue += g_PERI[2] * pT[2] + g_PERI[3] * pT[3];
  }

  return fValue;
}

public static double EarthMoonBarycentreMeanLongitudeOfPerihelion(double JD) //Aka Omega'
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return EarthMoonBarycentreMeanLongitudeOfPerihelion(t, 5);
}

public static double MoonMeanSolarElongation(double[] pT, int nTSize) //Aka D
{
  //Implement D in terms of W1 and T
  return MoonMeanLongitude(pT, nTSize) - EarthMoonBarycentreMeanLongitude(pT, nTSize) + AASCoordinateTransformation.PI();
}

public static double MoonMeanSolarElongation(double JD) //Aka D
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return MoonMeanSolarElongation(t, 5);
}

public static double SunMeanAnomaly(double[] pT, int nTSize) //Aka l'
{
  //Implement l' in terms of T and Omega'
  return EarthMoonBarycentreMeanLongitude(pT, nTSize) - EarthMoonBarycentreMeanLongitudeOfPerihelion(pT, nTSize);
}

public static double SunMeanAnomaly(double JD) //Aka l'
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];

  return SunMeanAnomaly(t, 5);
}

public static double MoonMeanAnomaly(double[] pT, int nTSize) //Aka l
{
  //Implement L in terms of W1 and W2
  return MoonMeanLongitude(pT, nTSize) - MoonMeanLongitudeLunarPerigee(pT, nTSize);
}

public static double MoonMeanAnomaly(double JD) //Aka l
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return MoonMeanAnomaly(t, 5);
}

public static double MoonMeanArgumentOfLatitude(double[] pT, int nTSize) //Aka F
{
  //Implement F in terms of W1 and W3
  return MoonMeanLongitude(pT, nTSize) - MoonMeanLongitudeLunarAscendingNode(pT, nTSize);
}

public static double MoonMeanArgumentOfLatitude(double JD) //Aka F
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return MoonMeanArgumentOfLatitude(t, 5);
}

public static double MercuryMeanLongitude(double T)
{
  return g_P[0][0] + g_P[0][1]*T;
}

public static double VenusMeanLongitude(double T)
{
  return g_P[1][0] + g_P[1][1]*T;
}

public static double MarsMeanLongitude(double T)
{
  return g_P[3][0] + g_P[3][1]*T;
}

public static double JupiterMeanLongitude(double T)
{
  return g_P[4][0] + g_P[4][1]*T;
}

public static double SaturnMeanLongitude(double T)
{
  return g_P[5][0] + g_P[5][1]*T;
}

public static double UranusMeanLongitude(double T)
{
  return g_P[6][0] + g_P[6][1]*T;
}

public static double NeptuneMeanLongitude(double T)
{
  return g_P[7][0] + g_P[7][1]*T;
}

//Handle the main problem calculation (Longitude & Latitude)
public static double Accumulate(ELP2000MainProblemCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF)
{
  //Validate our parameters
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    double tgv = pCoefficients[j].m_B[0] + DTASM * pCoefficients[j].m_B[4];
    double x = pCoefficients[j].m_A + tgv * (g_DELNP - AM * g_DELNU) + pCoefficients[j].m_B[1] * g_DELG + pCoefficients[j].m_B[2] * g_DELE + pCoefficients[j].m_B[3] * g_DELEP;
    double y = fD * pCoefficients[j].m_I[0] +
                     fldash * pCoefficients[j].m_I[1] +
                     fl * pCoefficients[j].m_I[2] +
                     fF * pCoefficients[j].m_I[3];
    fResult += x * Math.Sin(y);
  }

  return fResult;
}

public static double Accumulate_2(ELP2000MainProblemCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF)
{
  //Validate our parameters
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j = 0; j<nCoefficients; j++)
  {
    double tgv = pCoefficients[j].m_B[0] + DTASM * pCoefficients[j].m_B[4];
    double A = pCoefficients[j].m_A;
    A -= A * 2.0 * g_DELNU / 3.0;
    double x = A + tgv * (g_DELNP - AM * g_DELNU) + pCoefficients[j].m_B[1] * g_DELG + pCoefficients[j].m_B[2] * g_DELE + pCoefficients[j].m_B[3] * g_DELEP;
    double y = fD * pCoefficients[j].m_I[0] +
                     fldash * pCoefficients[j].m_I[1] +
                     fl * pCoefficients[j].m_I[2] +
                     fF * pCoefficients[j].m_I[3];
    fResult += x * Math.Cos(y);
  }

  return fResult;
}


//Handle the Earth figure perturbations, Tidal Effects, Moon figure & Relativistic perturbations calculation
      public static double Accumulate(double[] pT, int nTSize, ELP2000EarthTidalMoonRelativisticSolarEccentricityCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF, bool bI1isZero)
{
  //Validate our parameters
  //assert(pT);
  //assert(nTSize == 5);
  ////UNREFERENCED_PARAMETER(nTSize);
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    if (bI1isZero)
    {
      //assert(pCoefficients[j].m_IZ == 0);
    }

    double y = fD * pCoefficients[j].m_I[0] +
               fldash * pCoefficients[j].m_I[1] +
               fl * pCoefficients[j].m_I[2] +
               fF * pCoefficients[j].m_I[3] +
               AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_O);

    if (!bI1isZero)
    {
      y += pCoefficients[j].m_IZ * g_ZETA[0] * pT[0] +
           pCoefficients[j].m_IZ * g_ZETA[1] * pT[1];
    }

    fResult += pCoefficients[j].m_A * Math.Sin(y);
  }

  return fResult;
}

//Handle the Earth figure perturbations & Tidal Effects /t calculation
      public static double Accumulate_2(double[] pT, int nTSize, ELP2000EarthTidalMoonRelativisticSolarEccentricityCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF, bool bI1isZero)
{
  //Validate our parameters
  //assert(pT);
  //assert(nTSize == 5);
  ////UNREFERENCED_PARAMETER(nTSize);
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    if (bI1isZero)
    {
      //assert(pCoefficients[j].m_IZ == 0);
    }

    double y = fD * pCoefficients[j].m_I[0] +
               fldash * pCoefficients[j].m_I[1] +
               fl * pCoefficients[j].m_I[2] +
               fF * pCoefficients[j].m_I[3] +
               AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_O);
    if (!bI1isZero)
    {
      y += pCoefficients[j].m_IZ * g_ZETA[0] * pT[0] +
           pCoefficients[j].m_IZ * g_ZETA[1] * pT[1];
    }

    fResult += pCoefficients[j].m_A * pT[1] * Math.Sin(y);
  }

  return fResult;
}

//Handle the Planetary perturbations Table 1 calculation
      public static double AccumulateTable1( ELP2000PlanetPertCoefficient[] pCoefficients, int nCoefficients, double fD, double fl, double fF, double fMe, double fV, double fT, double fMa, double fJ, double fS, double fU, double fN)
{
  //Validate our parameters
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    double y = fMe * pCoefficients[j].m_ip[0] +
                     fV * pCoefficients[j].m_ip[1] +
                     fT * pCoefficients[j].m_ip[2] +
                     fMa * pCoefficients[j].m_ip[3] +
                     fJ * pCoefficients[j].m_ip[4] +
                     fS * pCoefficients[j].m_ip[5] +
                     fU * pCoefficients[j].m_ip[6] +
                     fN * pCoefficients[j].m_ip[7] +
                     fD * pCoefficients[j].m_ip[8] +
                     fl * pCoefficients[j].m_ip[9] +
                     fF * pCoefficients[j].m_ip[10] +
                     AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_theta);
    fResult += pCoefficients[j].m_O * Math.Sin(y);
  }

  return fResult;
}

//Handle the Planetary perturbations Table 1 /t calculation
public static double AccumulateTable1_2(double[] pT, int nTSize, ELP2000PlanetPertCoefficient[] pCoefficients, int nCoefficients, double fD, double fl, double fF, double fMe, double fV, double fT, double fMa, double fJ, double fS, double fU, double fN)
{
  //Validate our parameters
  //assert(pT);
  //assert(nTSize == 5);
  //UNREFERENCED_PARAMETER(nTSize);
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    double y = fMe * pCoefficients[j].m_ip[0] +
                     fV * pCoefficients[j].m_ip[1] +
                     fT * pCoefficients[j].m_ip[2] +
                     fMa * pCoefficients[j].m_ip[3] +
                     fJ * pCoefficients[j].m_ip[4] +
                     fS * pCoefficients[j].m_ip[5] +
                     fU * pCoefficients[j].m_ip[6] +
                     fN * pCoefficients[j].m_ip[7] +
                     fD * pCoefficients[j].m_ip[8] +
                     fl * pCoefficients[j].m_ip[9] +
                     fF * pCoefficients[j].m_ip[10] +
                     AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_theta);
    fResult += pCoefficients[j].m_O * pT[1] * Math.Sin(y);
  }

  return fResult;
}

//Handle the Planetary perturbations Table 2 calculation
      public static double AccumulateTable2( ELP2000PlanetPertCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF, double fMe, double fV, double fT, double fMa, double fJ, double fS, double fU)
{
  //Validate our parameters
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    double y = fMe * pCoefficients[j].m_ip[0] +
                     fV * pCoefficients[j].m_ip[1] +
                     fT * pCoefficients[j].m_ip[2] +
                     fMa * pCoefficients[j].m_ip[3] +
                     fJ * pCoefficients[j].m_ip[4] +
                     fS * pCoefficients[j].m_ip[5] +
                     fU * pCoefficients[j].m_ip[6] +
                     fD * pCoefficients[j].m_ip[7] +
                     fldash * pCoefficients[j].m_ip[8] +
                     fl * pCoefficients[j].m_ip[9] +
                     fF * pCoefficients[j].m_ip[10] +
                     AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_theta);
    fResult += pCoefficients[j].m_O * Math.Sin(y);
  }

  return fResult;
}

//Handle the Planetary perturbations Table 2 /t calculation
      public static double AccumulateTable2_2(double[] pT, int nTSize, ELP2000PlanetPertCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF, double fMe, double fV, double fT, double fMa, double fJ, double fS, double fU)
{
  //Validate our parameters
  //assert(pT);
  //assert(nTSize == 5);
  //UNREFERENCED_PARAMETER(nTSize);
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  //Accumulate the result
  for (int j=0; j<nCoefficients; j++)
  {
    double y = fMe * pCoefficients[j].m_ip[0] +
                     fV * pCoefficients[j].m_ip[1] +
                     fT * pCoefficients[j].m_ip[2] +
                     fMa * pCoefficients[j].m_ip[3] +
                     fJ * pCoefficients[j].m_ip[4] +
                     fS * pCoefficients[j].m_ip[5] +
                     fU * pCoefficients[j].m_ip[6] +
                     fD * pCoefficients[j].m_ip[7] +
                     fldash * pCoefficients[j].m_ip[8] +
                     fl * pCoefficients[j].m_ip[9] +
                     fF * pCoefficients[j].m_ip[10] +
                     AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_theta);
    fResult += pCoefficients[j].m_O * pT[1] * Math.Sin(y);
  }

  return fResult;
}

//Handle the Planetary perturbations (solar eccentricity) /t squared calculation
      public static double Accumulate_3(double[] pT, int nTSize, ELP2000EarthTidalMoonRelativisticSolarEccentricityCoefficient[] pCoefficients, int nCoefficients, double fD, double fldash, double fl, double fF)
{
  //Validate our parameters
  //assert(pT);
  //assert(nTSize == 5);
  //UNREFERENCED_PARAMETER(nTSize);
  //assert(pCoefficients);
  //assert(nCoefficients);

  //What will be the return value from this function
  double fResult = 0;

  for (int j=0; j<nCoefficients; j++)
  {
    //assert(pCoefficients[j].m_IZ == 0);

    double y = fD * pCoefficients[j].m_I[0] +
                     fldash * pCoefficients[j].m_I[1] + fl * pCoefficients[j].m_I[2] +
                     fF * pCoefficients[j].m_I[3] +
                     AASCoordinateTransformation.DegreesToRadians(pCoefficients[j].m_O);
    fResult += pCoefficients[j].m_A * pT[2] * Math.Sin(y);
  }

  return fResult;
}

public static double EclipticLongitude(double[] pT, int nTSize)
{
  //Validate our parameters
  //assert(pT != nullptr);
  //assert(nTSize >= 2);

  //Compute the delaney arguments for the specified time
  double fD = MoonMeanSolarElongation(pT, nTSize);
  double fldash = SunMeanAnomaly(pT, nTSize);
  double fl = MoonMeanAnomaly(pT, nTSize);
  double fF = MoonMeanArgumentOfLatitude(pT, nTSize);
  double fD2 = MoonMeanSolarElongation(pT, 2);
  double fldash2 = SunMeanAnomaly(pT, 2);
  double fl2 = MoonMeanAnomaly(pT, 2);
  double fF2 = MoonMeanArgumentOfLatitude(pT, 2);

  //Compute the planet mean longitudes for the specified time
  double fMe = MercuryMeanLongitude(pT[1]);
  double fV = VenusMeanLongitude(pT[1]);
  double fT = EarthMoonBarycentreMeanLongitude(pT, 2);
  double fMa = MarsMeanLongitude(pT[1]);
  double fJ = JupiterMeanLongitude(pT[1]);
  double fS = SaturnMeanLongitude(pT[1]);
  double fU = UranusMeanLongitude(pT[1]);
  double fN = NeptuneMeanLongitude(pT[1]);

  //Calculate the Longitude
  double A = Accumulate        (g_ELP1,  g_ELP1.Length, fD, fldash, fl, fF) +
                   Accumulate        (pT, nTSize, g_ELP4,  g_ELP4.Length, fD2, fldash2, fl2, fF2, false) +
                   Accumulate_2      (pT, nTSize, g_ELP7,  g_ELP7.Length, fD2, fldash2, fl2, fF2, false) +
                   AccumulateTable1  (g_ELP10, g_ELP10.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                   AccumulateTable1_2(pT, nTSize, g_ELP13, g_ELP13.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                   AccumulateTable2  (g_ELP16, g_ELP16.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                   AccumulateTable2_2(pT, nTSize, g_ELP19, g_ELP19.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                   Accumulate        (pT, nTSize, g_ELP22, g_ELP22.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate_2      (pT, nTSize, g_ELP25, g_ELP25.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate        (pT, nTSize, g_ELP28, g_ELP28.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate        (pT, nTSize, g_ELP31, g_ELP31.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate_3      (pT, nTSize, g_ELP34, g_ELP34.Length, fD2, fldash2, fl2, fF2);
  return AASCoordinateTransformation.MapTo0To360Range(A/3600.0 + AASCoordinateTransformation.RadiansToDegrees(MoonMeanLongitude(pT, nTSize)));
}

public static double EclipticLongitude(double JD)
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return EclipticLongitude(t, 5);
}

      public static double EclipticLatitude(double[] pT, int nTSize)
{
  //Validate our parameters
  //assert(pT != nullptr);
  //assert(nTSize >= 2);

  //Compute the delaney arguments for the specified time
  double fD = MoonMeanSolarElongation(pT, nTSize);
  double fldash = SunMeanAnomaly(pT, nTSize);
  double fl = MoonMeanAnomaly(pT, nTSize);
  double fF = MoonMeanArgumentOfLatitude(pT, nTSize);
  double fD2 = MoonMeanSolarElongation(pT, 2);
  double fldash2 = SunMeanAnomaly(pT, 2);
  double fl2 = MoonMeanAnomaly(pT, 2);
  double fF2 = MoonMeanArgumentOfLatitude(pT, 2);

  //Compute the planet mean longitudes for the specified time
  double fMe = MercuryMeanLongitude(pT[1]);
  double fV = VenusMeanLongitude(pT[1]);
  double fT = EarthMoonBarycentreMeanLongitude(pT, 2);
  double fMa = MarsMeanLongitude(pT[1]);
  double fJ = JupiterMeanLongitude(pT[1]);
  double fS = SaturnMeanLongitude(pT[1]);
  double fU = UranusMeanLongitude(pT[1]);
  double fN = NeptuneMeanLongitude(pT[1]);

  //Calculate the Longitude
  double B = Accumulate        (g_ELP2,  g_ELP2.Length, fD, fldash, fl, fF) +
                   Accumulate        (pT, nTSize, g_ELP5,  g_ELP5.Length, fD2, fldash2, fl2, fF2, false) +
                   Accumulate_2      (pT, nTSize, g_ELP8,  g_ELP8.Length, fD2, fldash2, fl2, fF2, false) +
                   AccumulateTable1  (g_ELP11, g_ELP11.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                   AccumulateTable1_2(pT, nTSize, g_ELP14, g_ELP14.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                   AccumulateTable2  (g_ELP17, g_ELP17.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                   AccumulateTable2_2(pT, nTSize, g_ELP20, g_ELP20.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                   Accumulate        (pT, nTSize, g_ELP23, g_ELP23.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate_2      (pT, nTSize, g_ELP26, g_ELP26.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate        (pT, nTSize, g_ELP29, g_ELP29.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate        (pT, nTSize, g_ELP32, g_ELP32.Length, fD2, fldash2, fl2, fF2, true) +
                   Accumulate_3      (pT, nTSize, g_ELP35, g_ELP35.Length, fD2, fldash2, fl2, fF2);
  return AASCoordinateTransformation.MapToMinus90To90Range(B/3600.0);
}

public static double EclipticLatitude(double JD)
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return EclipticLatitude(t, 5);
}


      public static double RadiusVector(double[] pT, int nTSize)
{
  //Validate our parameters
  //assert(pT != nullptr);
  //assert(nTSize >= 2);

  //Compute the delaney arguments for the specified time
  double fD = MoonMeanSolarElongation(pT, nTSize);
  double fldash = SunMeanAnomaly(pT, nTSize);
  double fl = MoonMeanAnomaly(pT, nTSize);
  double fF = MoonMeanArgumentOfLatitude(pT, nTSize);
  double fD2 = MoonMeanSolarElongation(pT, 2);
  double fldash2 = SunMeanAnomaly(pT, 2);
  double fl2 = MoonMeanAnomaly(pT, 2);
  double fF2 = MoonMeanArgumentOfLatitude(pT, 2);

  //Compute the planet mean longitudes for the specified time
  double fMe = MercuryMeanLongitude(pT[1]);
  double fV = VenusMeanLongitude(pT[1]);
  double fT = EarthMoonBarycentreMeanLongitude(pT, 2);
  double fMa = MarsMeanLongitude(pT[1]);
  double fJ = JupiterMeanLongitude(pT[1]);
  double fS = SaturnMeanLongitude(pT[1]);
  double fU = UranusMeanLongitude(pT[1]);
  double fN = NeptuneMeanLongitude(pT[1]);

  //Calculate the Longitude
  double fValue = Accumulate_2      (g_ELP3,  g_ELP3.Length, fD, fldash, fl, fF) +
                        Accumulate        (pT, nTSize, g_ELP6,  g_ELP6.Length, fD2, fldash2, fl2, fF2, false) +
                        Accumulate_2      (pT, nTSize, g_ELP9, g_ELP9.Length, fD2, fldash2, fl2, fF2, false) +
                        AccumulateTable1  (g_ELP12, g_ELP12.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                        AccumulateTable1_2(pT, nTSize, g_ELP15, g_ELP15.Length, fD2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU, fN) +
                        AccumulateTable2  (g_ELP18, g_ELP18.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                        AccumulateTable2_2(pT, nTSize, g_ELP21, g_ELP21.Length, fD2, fldash2, fl2, fF2, fMe, fV, fT, fMa, fJ, fS, fU) +
                        Accumulate        (pT, nTSize, g_ELP24, g_ELP24.Length, fD2, fldash2, fl2, fF2, true) +
                        Accumulate_2      (pT, nTSize, g_ELP27, g_ELP27.Length, fD2, fldash2, fl2, fF2, true) +
                        Accumulate        (pT, nTSize, g_ELP30, g_ELP30.Length, fD2, fldash2, fl2, fF2, true) +
                        Accumulate        (pT, nTSize, g_ELP33, g_ELP33.Length, fD2, fldash2, fl2, fF2, true) +
                        Accumulate_3      (pT, nTSize, g_ELP36, g_ELP36.Length, fD2, fldash2, fl2, fF2);
  return fValue * 384747.9806448954 / 384747.9806743165;
}

public static double RadiusVector(double JD)
{
  //Calculate Julian centuries
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];

  return RadiusVector(t, 5);
}

public static AAS3DCoordinate EclipticRectangularCoordinates(double JD)
{
  double fLongitude = EclipticLongitude(JD);
  double fLatitude = EclipticLatitude(JD);
  double fR = RadiusVector(JD);

  AAS3DCoordinate value = new AAS3DCoordinate();
  fLongitude = AASCoordinateTransformation.DegreesToRadians(fLongitude);
  fLatitude = AASCoordinateTransformation.DegreesToRadians(fLatitude);
  double fCosLat = Math.Cos(fLatitude);
  value.X = fR * Math.Cos(fLongitude) * fCosLat;
  value.Y = fR * Math.Sin(fLongitude) * fCosLat;
  value.Z = fR * Math.Sin(fLatitude);

  return value;
}

public static AAS3DCoordinate EclipticRectangularCoordinatesJ2000(double JD)
{
  double[] t = new double[5];
  t[0] = 1;
  t[1] = (JD - 2451545.0) / 36525.0;
  t[2] = t[1] * t[1];
  t[3] = t[2] * t[1];
  t[4] = t[3] * t[1];
  double P = (1.0180391e-5   + 4.7020439e-7*t[1] + -5.417367e-10*t[2] + -2.507948e-12*t[3] + 4.63486e-15*t[4]) * t[1];
  double Q = (-1.13469002e-4 + 1.2372674e-7*t[1] + 1.265417e-9*t[2]   + -1.371808e-12*t[3] + -3.20334e-15*t[4]) * t[1];
  double TwoP = 2*P;
  double P2 = P*P;
  double Q2 = Q*Q;
  double OneMinus2P2 = 1 - 2*P2;
  double TwoPQ = TwoP*Q;
  double Twosqrt1MinusPart = 2*Math.Sqrt(1 - P2 - Q2);

  AAS3DCoordinate Ecliptic = EclipticRectangularCoordinates(JD);

  AAS3DCoordinate J2000 = new AAS3DCoordinate();
  J2000.X = OneMinus2P2*Ecliptic.X          + TwoPQ*Ecliptic.Y               + P*Twosqrt1MinusPart*Ecliptic.Z;
  J2000.Y = TwoPQ*Ecliptic.X                + (1 - 2 * Q2)*Ecliptic.Y        - Q*Twosqrt1MinusPart*Ecliptic.Z;
  J2000.Z = -P*Twosqrt1MinusPart*Ecliptic.X + Q*Twosqrt1MinusPart*Ecliptic.Y + (1-2*P2-2*Q2)*Ecliptic.Z;

  return J2000;
}

    public static AAS3DCoordinate EquatorialRectangularCoordinatesFK5(double JD)
    {
      AAS3DCoordinate J2000 = EclipticRectangularCoordinatesJ2000(JD);

      AAS3DCoordinate FK5 = new AAS3DCoordinate();
      FK5.X = J2000.X + 0.000000437913 * J2000.Y - 0.000000189859 * J2000.Z;
      FK5.Y = -0.000000477299 * J2000.X + 0.917482137607 * J2000.Y - 0.397776981701 * J2000.Z;
      FK5.Z = 0.397776981701 * J2000.Y + 0.917482137607 * J2000.Z;

      return FK5;
    }

    }
}