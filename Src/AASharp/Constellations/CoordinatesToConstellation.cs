using System;
using System.Linq;

namespace AASharp.Constellations
{
    /// <summary>
    ///Precess() and GetConstellation() are adapted from program.c, from
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
    [Obsolete("This class has been moved into a new project : AASharp.Extension")]
    public class CoordinatesToConstellation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ra">RA in hours</param>
        /// <param name="dec">declination in degrees</param>
        /// <param name="epoch">epoch in years AD</param>
        /// <returns>constellation abbreviation (3 letters), or '' on error</returns>
        public static Constellation GetConstellation(double ra, double dec, int epoch)
        {
            AASDate j1875 = new AASDate(1875, 1, 1, 12, 0, 0, true);
            AASDate jEpoch = new AASDate(epoch, 1, 1, 12, 0, 0, true);
 
            var coordinates = AASPrecession.PrecessEquatorial(ra, dec, jEpoch.Julian, j1875.Julian);
            ra = coordinates.X;
            dec = coordinates.Y;


            var foundConstellationBoundary = Constellations.Boundaries.FirstOrDefault(boundary =>
                !(dec < boundary.LowerDeclination ||
                  ra < boundary.LowerRightAscension ||
                  ra >= boundary.UpperRightAscension));

            if (foundConstellationBoundary != null)
            {
                return Constellations.ConstellationsData.Single(c => c.Abbreviation == foundConstellationBoundary.ConstellationAbbreviation);
            }

            throw new NotFoundException($"Constellation not found for coordinates RA : {ra}, Dec : {dec}");
        }
    }
}