namespace F1Stats.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using F1Stats.Data;
    using F1Stats.Data.Models;
    using F1Stats.Repository;

    public class OsszetettLogic
    {
        public static string GetTeamWithMostPoints()
        {
            F1StatsDbContext db = new F1StatsDbContext();
            VersenyzoLogic verLogic = new VersenyzoLogic(new VersenyzoRepository(db));
            var query = from x in verLogic.GetAllVersenyzo()
                        orderby x.ossz_pont descending
                        group x by x.Csapat.csapat_nev into g
                        select new
                        {
                            CsapatNev = g.Key,
                        };
            return query.First().CsapatNev.ToString();
        }

        public static string TestGetTeamWithMostPoints(IVersenyzoRepository vRepo, ICsapatRepository csRepo)
        {
            VersenyzoLogic verLogic = new VersenyzoLogic(vRepo);
            CsapatLogic csLogic = new CsapatLogic(csRepo);
            var query = from x in verLogic.GetAllVersenyzo()
                        orderby x.ossz_pont descending
                        join y in csLogic.GetAllCsapat() on x.csapat_nev equals y.csapat_nev
                        group x by y.csapat_nev into g
                        select new
                        {
                            CsapatNev = g.Key,
                        };
            return query.First().CsapatNev.ToString();
        }

        public static IList<ElertPont> GetDriversPoints()
        {
            F1StatsDbContext db = new F1StatsDbContext();
            EredmenyLogic eredmenyRepo = new EredmenyLogic(new EredmenyRepository(db));
            VersenyzoLogic verRepo = new VersenyzoLogic(new VersenyzoRepository(db));
            var query = from x in eredmenyRepo.GetAllEredmeny()
                        group x by x.rajtszam into g
                        join y in verRepo.GetAllVersenyzo() on g.Key equals y.rajtszam
                        select new ElertPont
                        {
                            DriverName = y.nev,
                            Points = g.Sum(z => z.pont),
                        };
            return query.ToList();
        }

        public static IList<ElertPont> TestGetDriversPoints(IEredmenyRepository eRepo, IVersenyzoRepository vRepo)
        {
            EredmenyLogic eredmenyRepo = new EredmenyLogic(eRepo);
            VersenyzoLogic verRepo = new VersenyzoLogic(vRepo);
            var query = from x in eredmenyRepo.GetAllEredmeny()
                        group x by x.rajtszam into g
                        join y in verRepo.GetAllVersenyzo() on g.Key equals y.rajtszam
                        select new ElertPont
                        {
                            DriverName = y.nev,
                            Points = g.Sum(z => z.pont),
                        };
            var res = query.ToList();
            res.Sort(SortByPoints);
            return res;
        }

        public static IList<string> GetResultWithEngineNames(int raceNumber)
        {
            F1StatsDbContext db = new F1StatsDbContext();
            EredmenyLogic eredmenyRepo = new EredmenyLogic(new EredmenyRepository(db));
            var query = from x in eredmenyRepo.GetAllEredmeny()
                        where x.versenyhetvege_szam == raceNumber
                        orderby x.helyezes
                        select x.Versenyzo.Csapat.motor;

            return query.ToList();
        }

        public static IList<string> TestGetResultWithEngineNames(int raceNumber, IEredmenyRepository eRepo, ICsapatRepository csRepo, IVersenyzoRepository vRepo)
        {
            EredmenyLogic eredmenyRepo = new EredmenyLogic(eRepo);
            CsapatLogic csapatLogic = new CsapatLogic(csRepo);
            VersenyzoLogic vLogic = new VersenyzoLogic(vRepo);
            var query = from x in eredmenyRepo.GetAllEredmeny()
                        where x.versenyhetvege_szam == raceNumber
                        join y in vLogic.GetAllVersenyzo() on x.rajtszam equals y.rajtszam
                        join z in csapatLogic.GetAllCsapat() on y.csapat_nev equals z.csapat_nev
                        orderby x.helyezes
                        select z.motor;

            return query.ToList();
        }

        public static int SortByPoints(ElertPont x, ElertPont y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (y == null)
                {
                    return -1;
                }
                else
                {
                    int retval = x.Points.CompareTo(y.Points);

                    if (retval != 0)
                    {
                        return -1*retval;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}