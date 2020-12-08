using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F1Stats.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateVersenyzoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<F1Stats.Data.Versenyzo, F1Stats.Web.Models.Versenyzo>().
                ForMember(dest => dest.Rajtszam, map => map.MapFrom(src => src.rajtszam)).
                ForMember(dest => dest.Nev, map => map.MapFrom(src => src.nev)).
                ForMember(dest => dest.CsapatNev, map => map.MapFrom(src => src.csapat_nev)).
                ForMember(dest => dest.Eletkor, map => map.MapFrom(src => src.eletkor)).
                ForMember(dest => dest.OsszPont, map => map.MapFrom(src => src.ossz_pont)).
                ForMember(dest => dest.IdenybeliPont, map => map.MapFrom(src => src.idenybeli_pont));
            });

            return config.CreateMapper();
        }

        public static IMapper CreateCsapatMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<F1Stats.Data.Csapat, F1Stats.Web.Models.Csapat>().
                ForMember(dest => dest.CsapatNev, map => map.MapFrom(src => src.csapat_nev)).
                ForMember(dest => dest.Motor, map => map.MapFrom(src => src.motor)).
                ForMember(dest => dest.VersenyekSzama, map => map.MapFrom(src => src.versenyek_szama)).
                ForMember(dest => dest.Gyozelmek, map => map.MapFrom(src => src.gyozelmek));
            });

            return config.CreateMapper();
        }

        public static IMapper CreateVersenyhetvegeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<F1Stats.Data.Versenyhetvege, F1Stats.Web.Models.Versenyhetvege>().
                ForMember(dest => dest.Nev, map => map.MapFrom(src => src.nev)).
                ForMember(dest => dest.Versenyhetvege_szama, map => map.MapFrom(src => src.VERSENYHETVEGE_SZAMA)).
                ForMember(dest => dest.Hossz, map => map.MapFrom(src => src.hossz)).
                ForMember(dest => dest.Idopont, map => map.MapFrom(src => src.idopont)).
                ForMember(dest => dest.Helyszin, map => map.MapFrom(src => src.helyszin));
            });

            return config.CreateMapper();
        }
    }
}