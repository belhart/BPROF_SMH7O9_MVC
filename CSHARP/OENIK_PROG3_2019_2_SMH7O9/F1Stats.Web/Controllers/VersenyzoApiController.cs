using AutoMapper;
using F1Stats.Logic;
using F1Stats.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace F1Stats.Web.Controllers
{
    public class VersenyzoApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        IVersenyzoLogic logic;
        IMapper mapper;

        public VersenyzoApiController()
        {
            logic = new VersenyzoLogic();
            mapper = MapperFactory.CreateVersenyzoMapper();
        }

        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Versenyzo> GetAll()
        {
            var versenyzok = logic.GetAllVersenyzo();
            return mapper.Map<IList<Data.Versenyzo>, List<Models.Versenyzo>>(versenyzok);
        }

        [ActionName("del")]
        [HttpGet]
        public ApiResult DelOneVersenyzo(int id)
        {
            bool success = logic.DeleteVersenyzo(id);
            return new ApiResult() { OperationResult = success };
        }

        [ActionName("add")]
        [HttpPost]
        public ApiResult AddOneVersenyzo(Models.Versenyzo versenyzo)
        {
            logic.CreateVersenyzo(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
            return new ApiResult() { OperationResult = true };
        }

        [ActionName("mod")]
        [HttpPost]
        public ApiResult ModOneVersenyzo(Models.Versenyzo versenyzo)
        {
            bool success = logic.UpdateVersenyzo(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
            return new ApiResult() { OperationResult = success };
        }
    }
}
