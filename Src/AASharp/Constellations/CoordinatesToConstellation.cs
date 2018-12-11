using System;

namespace AASharp.Constellations
{
    /// <summary>
    ///precess() and get_name() are adapted from program.c, from
    ///ftp://cdsarc.u-strasbg.fr/pub/cats/VI/42/program.c
    ///which is from
    ///CDS (Centre de donnees astronomiques de Strasbourg) catalog VI/42; also see
    ///
    ///Identification of a constellation from a position,
    ///Nancy G. Roman,
    ///PUBLICATIONS OF THE ASTRONOMICAL SOCIETY OF THE PACIFIC,
    ///99 (July 1987), pp. 695-699.
    ///
    ///Program.c says:
    ///This program is a translation with a few adaptations of the 
    ///Fortran program.f, made by FO @ CDS  (francois@simbad.u-strasbg.fr)  
    ///in November 1996.
    /// </summary>
    public class CoordinatesToConstellation
    {
        private static (double ra, double dec) precess(double ra1, double dec1, double epoch1, double epoch2)
        {
            double cdr, csr;
            double[] x1 = {0.0, 0.0, 0.0};
            double[] x2 = {0.0, 0.0, 0.0};
            double [][] r = {new[]{0.0, 0.0, 0.0}, new[]{0.0, 0.0, 0.0}, new[]{0.0, 0.0, 0.0}}; 
            double t, st, a, b, c, sina, sinb, sinc, cosa, cosb, cosc, ra2, dec2;

            cdr = Math.PI / 180.0;
            csr = cdr / 3600.0;
            a = Math.Cos(dec1);
            x1[0] = a * Math.Cos(ra1);
            x1[1] = a * Math.Sin(ra1);
            x1[2] = Math.Sin(dec1);
            
            t = 0.001 * (epoch2 - epoch1);
            st = 0.001 * (epoch1 - 1900.0);
            a = csr * t * (23042.53 + st * (139.75 + 0.06 * st) + t * (30.23 - 0.27 * st + 18.0 * t));
            b = csr * t * t * (79.27 + 0.66 * st + 0.32 * t) + a;
            c = csr * t * (20046.85 - st * (85.33 + 0.37 * st) + t * (-42.67 - 0.37 * st - 41.8 * t));
            sina = Math.Sin(a);
            sinb = Math.Sin(b);
            sinc = Math.Sin(c);
            cosa = Math.Cos(a);
            cosb = Math.Cos(b);
            cosc = Math.Cos(c);
            r[0][0] = cosa* cosb*cosc - sina* sinb;
            r[0][1] = -cosa* sinb - sina* cosb*cosc;
            r[0][2] = -cosb* sinc;
            r[1][0] = sina* cosb + cosa* sinb*cosc;
            r[1][1] = cosa* cosb - sina* sinb*cosc;
            r[1][2] = -sinb* sinc;
            r[2][0] = cosa* sinc;
            r[2][1] = -sina* sinc;
            r[2][2] = cosc;
            for (var i = 0; i < 3; i++)
            {
                x2[i] = r[i][0] * x1[0] + r[i][1] * x1[1] + r[i][2] * x1[2];
            }

            ra2 = Math.Atan2(x2[1], x2[0]);
            if (ra2 < 0.0)
            {
                ra2 += 2.0 * Math.PI;
            }

            dec2 = Math.Asin(x2[2]);
            return (ra2, dec2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ra">RA in hours</param>
        /// <param name="dec">declination in degrees</param>
        /// <param name="epoch">epoch in years AD</param>
        /// <returns>constellation abbreviation (3 letters), or '' on error</returns>
        public static string get_name(double ra, double dec, double epoch)
        {
            double convh = Math.PI / 12.0;
            double convd = Math.PI / 180.0;
            ra *= convh;
            dec *= convd;
            (ra, dec) = precess(ra, dec, epoch, 1875.0);
            ra /= convh;
            dec /= convd;
            for (var i = 0; i < ConstellationsBoundaries.table.Length; i++)
            {
                if (dec < (double)ConstellationsBoundaries.table[i][2] || ra < (double)ConstellationsBoundaries.table[i][0] || ra >= (double)ConstellationsBoundaries.table[i][1])
                    continue;
                return (string)ConstellationsBoundaries.table[i][3];
            }

            return "";    // Error!
        }
    }
}