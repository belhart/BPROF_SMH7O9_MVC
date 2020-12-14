﻿namespace F1Stats.Logic
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
    }
}