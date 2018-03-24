namespace AASharp
{
    public static class AASMoslemCalendar
    {
        public static AASCalendarDate MoslemToJulian(long Year, long Month, long Day)
        {
            //What will be the return value
            AASCalendarDate julianDate = new AASCalendarDate();
      
            long N = Day + AASDate.INT(29.5001 * (Month - 1) + 0.99);
            long Q = AASDate.INT(Year / 30.0);
            long R = Year % 30;
            long A = AASDate.INT((11 * R + 3) / 30.0);
            long W = 404 * Q + 354 * R + 208 + A;
            long Q1 = AASDate.INT(W / 1461.0);
            long Q2 = W % 1461;
            long G = 621 + 4 * AASDate.INT(7 * Q + Q1);
            long K = AASDate.INT(Q2 / 365.2422);
            long E = AASDate.INT(365.2422 * K);
            long J = Q2 - E + N - 1;
            long X = G + K;
      
            long XMod4 = X % 4;
            if ((J > 366) && (XMod4 == 0))
            {
                J -= 366;
                X++;
            }
            
            if ((J > 365) && (XMod4 > 0))
            {
                J -= 365;
                X++;
            }
      
            julianDate.Year = X;
            var julienDateDay = julianDate.Day;
            var julienDateMonth = julianDate.Month;
            AASDate.DayOfYearToDayAndMonth(J, AASDate.IsLeap(X, false), ref julienDateDay, ref julienDateMonth);
            julianDate.Day = julienDateDay;
            julianDate.Month = julienDateMonth;

            return julianDate;
        }
    
        public static AASCalendarDate JulianToMoslem(long Year, long Month, long Day)
        {
            //What will be the return value
            AASCalendarDate MoslemDate = new AASCalendarDate();
      
            long W = Year % 4 != 0 ? 2 : 1;
            long N = AASDate.INT((275 * Month) / 9.0) - (W * AASDate.INT((Month + 9) / 12.0)) + Day - 30;
            long A = Year - 623;
            long B = AASDate.INT(A / 4.0);
            long C = A % 4;
            double C1 = 365.2501 * C;
            long C2 = AASDate.INT(C1);
            if ((C1 - C2) > 0.5)
                C2++;
      
            long Ddash = 1461 * B + 170 + C2;
            long Q = AASDate.INT(Ddash / 10631.0);
            long R = Ddash % 10631;
            long J = AASDate.INT(R / 354.0);
            long K = R % 354;
            long O = AASDate.INT((11 * J + 14) / 30.0);
            long H = 30 * Q + J + 1;
            long JJ = K - O + N - 1;
      
            if (JJ > 354)
            {
                long CL = H % 30;
                long DL = (11 * CL + 3) % 30;
                if (DL < 19)
                {
                    JJ -= 354;
                    H++;
                }
                else
                {
                    JJ -= 355;
                    H++;
                }
                
                if (JJ == 0)
                {
                    JJ = 355;
                    H--;
                }
            }
      
            long S = AASDate.INT((JJ - 1) / 29.5);
            MoslemDate.Month = 1 + S;
            MoslemDate.Day = AASDate.INT(JJ - 29.5 * S);
            MoslemDate.Year = H;
      
            if (JJ == 355)
            {
                MoslemDate.Month = 12;
                MoslemDate.Day = 30;
            }
      
            return MoslemDate;
        }

        public static bool IsLeap(long Year)
        {
          long R = Year % 30;
          return (11 * R + 3) % 30 > 18;
        }
    }
}