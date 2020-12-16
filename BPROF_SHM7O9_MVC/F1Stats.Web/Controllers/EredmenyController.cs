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
    public class EredmenyController : Controller
    {
        IEredmenyLogic logic;
        EredmenyViewModel vm;

        public EredmenyController(EredmenyLogic eredmenyLogic)
        {
            this.logic = eredmenyLogic;

            vm = new EredmenyViewModel();
            vm.EditedEredmeny = new Eredmeny();
            var eredmenyek = logic.GetAllEredmeny();
            vm.ListOfEredmenyek = eredmenyek.ToList();
        }
        private Eredmeny GetEredmenyModel(int id)
        {
            return this.logic.GetOneEredmeny(id);
        }

        // GET: Eredmeny
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("EredmenyIndex", vm);
        }

        // GET: Eredmeny/Details/5
        public ActionResult Details(int id)
        {
            return View("EredmenyDetails", GetEredmenyModel(id));
        }
        //GET
        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete FAIL";
            if (logic.DeleteEredmeny(id)) TempData["editResult"] = "Delete OK";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedEredmeny = GetEredmenyModel(id);
            return View("EredmenyIndex", vm);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Eredmeny eredmeny, string editAction)
        {
            if (ModelState.IsValid && eredmeny != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.CreateEredmeny(eredmeny);
                }
                else
                {
                    bool success = logic.UpdateEredmeny(eredmeny.eredmenyId, eredmeny.versenyhetvege_szam, eredmeny.rajtszam, eredmeny.helyezes, eredmeny.pont);
                    if (!success) TempData["editResult"] = "Edit FAIL";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedEredmeny = eredmeny;
                return View("EredmenyIndex", vm);
            }
        }
    }
}