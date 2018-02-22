using System;

namespace AASharp
{
    public class CVSOP87
    {
        internal static double Calculate(double JD, VSOP87Coefficient2[] pTable, int nTableSize, bool bAngle)
        {
            double T = (JD - 2451545) / 365250;
            double TTerm = T;
            double Result = 0;
            for (int i = 0; i < nTableSize; i++)
            {
                double TempResult = 0;
                for (int j = 0; j < pTable[i].nCoefficientsSize; j++)
                    TempResult += pTable[i].pCoefficients[j].A * Math.Cos(pTable[i].pCoefficients[j].B + pTable[i].pCoefficients[j].C * T);

                if (i > 0)
                {
                    TempResult *= TTerm;
                    TTerm *= T;
                }

                Result += TempResult;
            }

            if (bAngle)
                Result = AASCoordinateTransformation.MapTo0To2PIRange(Result);

            return Result;
        }

        internal static double Calculate_Dash(double JD, VSOP87Coefficient2[] pTable, int nTableSize)
        {
            double T = (JD - 2451545) / 365250;
            double TTerm1 = 1;
            double TTerm2 = T;
            double Result = 0;
            for (int i = 0; i < nTableSize; i++)
            {
                double tempPart1 = 0;
                double tempPart2 = 0;
                for (int j = 0; j < pTable[i].nCoefficientsSize; j++)
                {
                    double B_CT = pTable[i].pCoefficients[j].B + pTable[i].pCoefficients[j].C * T;
                    tempPart1 += i * pTable[i].pCoefficients[j].A * Math.Cos(B_CT);
                    tempPart2 += pTable[i].pCoefficients[j].A * pTable[i].pCoefficients[j].C * Math.Sin(B_CT);
                }

                if (i > 0)
                {
                    tempPart1 *= TTerm1;
                    tempPart2 *= TTerm2;
                    TTerm1 *= T;
                    TTerm2 *= T;
                }

                Result += (tempPart1 - tempPart2);
            }

            //The value returned is in per days
            return Result / 365250;
        }
    }
}