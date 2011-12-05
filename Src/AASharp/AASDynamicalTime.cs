using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AASharp
{
    public static class AASDynamicalTime
    {
        public static double DeltaT(double JD)
        {
            //Construct a CAADate from the julian day
            AASDate date = new AASDate(JD, AASDate.AfterPapalReform(JD));
            double y = date.FractionalYear;
            double T = (y - 2000) / 100;
            double Delta;
            if (y < 948)
                Delta = 2177 + (497 * T) + (44.1 * T * T);
            else
                if (y < 1620)
                    Delta = 102 + (102 * T) + (25.3 * T * T);
                else
                    if (y < 1998)
                    {
                        uint Index = (uint)((y - 1620) / 2);

                        y = y / 2 - Index - 810;
                        Delta = (DeltaTTable[Index] + (DeltaTTable[Index + 1] - DeltaTTable[Index]) * y);
                    }
                    else
                        if (y <= 2000)
                        {
                            // This may be completely wrong.
                            // I was trying to port from this:
                            // int nLookupSize = sizeof(DeltaTTable)/sizeof(double);
                            // Delta = DeltaTTable[nLookupSize - 1];

                            Delta = DeltaTTable[DeltaTTable.Length - 1];
                        }
                        else
                            if (y < 2100)
                                Delta = 102 + (102 * T) + (25.3 * T * T) + 0.37 * (y - 2100);
                            else
                                Delta = 102 + (102 * T) + (25.3 * T * T);

            return Delta;
        }

        private static double[] DeltaTTable =
        {
        121, 112, 103, 95, 88 //1620 - 1698
        , 
        82, 77, 72, 68, 63,
        60, 56, 53, 51, 48,
        46, 44, 42, 40, 38,
        35, 33, 31, 29, 26,
        24, 22, 20, 18, 16,
        14, 12, 11, 10, 9,
        8, 7, 7, 7, 7,

        7, 7, 8, 8, 9 //1700 - 1778
        , 
        9, 9, 9, 9, 10,
        10, 10, 10, 10, 10,
        10, 10, 11, 11, 11,
        11, 11, 12, 12, 12,
        12, 13, 13, 13, 14,
        14, 14, 14, 15, 15,
        15, 15, 15, 16, 16,
        16, 16, 16, 16, 16 //1780 - 1858
        , 
        16, 15, 15, 14, 13,
        13.1, 12.5, 12.2, 12.0, 12.0,
        12, 12, 12, 12, 11.9,
        11.6, 11, 10.2, 9.2, 8.2,
        7.1, 6.2, 5.6, 5.4, 5.3,
        5.4, 5.6, 5.9, 6.2, 6.5,
        6.8, 7.1, 7.3, 7.5, 7.6,
        7.7, 7.3, 6.2, 5.2, 2.7 //1860 - 1938
        , 
        1.4, -1.2, -2.8, -3.8, -4.8,
        -5.5, -5.3,  -5.6, -5.7, -5.9,
        -6, -6.3, -6.5, -6.2, -4.7,
        -2.8, -0.1, 2.6, 5.3, 7.7,
        10.4, 13.3, 16, 18.2, 20.2,
        21.2, 22.4, 23.5, 23.8, 24.3,
        24, 23.9, 23.9, 23.7, 24,

        24.3, 25.3, 26.2, 27.3, 28.2 //1940 - 1998
        , 
        29.1, 30, 30.7, 31.4, 32.2,
        33.1, 34.0, 35.0, 36.5, 38.3,
        40.18, 42.2, 44.5, 46.5, 48.5,
        50.54, 52.2, 53.8, 54.9, 55.8,
        56.86, 58.31, 59.99, 61.63, 62.97
        };
    }
}
