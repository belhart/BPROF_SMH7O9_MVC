using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;
using F1Stats.Logic;
using F1Stats.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace F1Stats.Web.Controllers
{
    public class EredmenyController : ControllerBase
    {
        IEredmenyLogic logic;

        public EredmenyController(EredmenyLogic eredmenyLogic)
        {
            this.logic = eredmenyLogic;
        }
        private Eredmeny GetEredmenyModel(int id)
        {
            return this.logic.GetOneEredmeny(id);
        }

        // GET: Eredmeny
        public ActionResult Index()
        {
        }

        // GET: Eredmeny/Details/5
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
        public ActionResult Edit(Eredmeny eredmeny, string editAction)
        {
        }
    }
}