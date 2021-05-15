using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;
using F1Stats.Logic;
using F1Stats.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace F1Stats.Web.Controllers
{
    public class VersenyhetvegeController : ControllerBase
    {
        IVersenyhetvegeLogic logic;

        public VersenyhetvegeController(VersenyhetvegeLogic versenyhetvegeLogic)
        {
            logic = versenyhetvegeLogic;
        }

        private Versenyhetvege GetVersenyhetvegeModel(int versenySzam)
        {
            return this.logic.GetOneVersenyhetvege(versenySzam);
        }

        // GET: Versenyhetvege
        public ActionResult Index()
        {
        }

        // GET: Versenyhetvege/Details/5
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
        public ActionResult Edit(Versenyhetvege versenyhetvege, string editAction)
        {
        }
    }
}