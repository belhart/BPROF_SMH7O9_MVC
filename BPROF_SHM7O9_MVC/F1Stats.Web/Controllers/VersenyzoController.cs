using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F1Stats.Logic;
using F1Stats.Web.Models;
using F1Stats.Data.Models;

namespace F1Stats.Web.Controllers
{
    public class VersenyzoController : ControllerBase
    {
        IVersenyzoLogic logic;

        public VersenyzoController(VersenyzoLogic versenyzoLogic)
        {
            logic = versenyzoLogic;
        }

        private Versenyzo GetVersenyzoModel(int rajtszam)
        {
            return this.logic.GetOneVersenyzo(rajtszam);
        }

        // GET: Versenyzo
        public ActionResult Index()
        {
        }

        // GET: Versenyzo/Details/5
        public ActionResult Details(int id)
        {
        }
        //GET
        public ActionResult Remove(int id)
        {
        }

        public ActionResult Edit(int id)
        {
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Versenyzo versenyzo, string editAction)
        {
        }
    }
}