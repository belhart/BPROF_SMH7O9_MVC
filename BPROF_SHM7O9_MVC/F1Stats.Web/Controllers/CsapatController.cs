using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Web.Models;
using F1Stats.Logic;
using Microsoft.AspNetCore.Mvc;
using F1Stats.Data.Models;

namespace F1Stats.Web.Controllers
{
    public class CsapatController : ControllerBase
    {
        ICsapatLogic logic;

        public CsapatController(CsapatLogic csapatLogic)
        {
            this.logic = csapatLogic;
        }
        private Csapat GetCsapatModel(string nev)
        {
            return this.logic.GetOneCsapat(nev);
        }

        // GET: Csapat
        public ActionResult Index()
        {
        }

        // GET: Csapat/Details/5
        public ActionResult Details(string name)
        {
        }
        //GET
        public ActionResult Remove(string name)
        {
        }

        public ActionResult Edit(string name)
        {
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Csapat csapat, string editAction)
        {
        }
    }
}