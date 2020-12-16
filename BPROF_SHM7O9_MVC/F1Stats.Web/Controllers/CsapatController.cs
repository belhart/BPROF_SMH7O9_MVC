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
    public class CsapatController : Controller
    {
        ICsapatLogic logic;
        CsapatViewModel vm;

        public CsapatController(CsapatLogic csapatLogic)
        {
            this.logic = csapatLogic;

            vm = new CsapatViewModel();
            vm.EditedCsapat = new Csapat();
            var csapatok = logic.GetAllCsapat();
            vm.ListOfCsapatok = csapatok.ToList();
        }
        private Csapat GetCsapatModel(string nev)
        {
            return this.logic.GetOneCsapat(nev);
        }

        // GET: Csapat
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("CsapatIndex", vm);
        }

        // GET: Csapat/Details/5
        public ActionResult Details(string name)
        {
            return View("CsapatDetails", GetCsapatModel(name));
        }
        //GET
        public ActionResult Remove(string name)
        {
            TempData["editResult"] = "Delete FAIL";
            if (logic.DeleteCsapat(name)) TempData["editResult"] = "Delete OK";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(string name)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedCsapat = GetCsapatModel(name);
            return View("CsapatIndex", vm);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Csapat csapat, string editAction)
        {
            if (ModelState.IsValid && csapat != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.CreateCsapat(csapat);
                }
                else
                {
                    bool success = logic.UpdateCsapat(csapat.csapat_nev, csapat.motor, csapat.versenyek_szama, csapat.gyozelmek);
                    if (!success) TempData["editResult"] = "Edit FAIL";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedCsapat = csapat;
                return View("CsapatIndex", vm);
            }
        }
    }
}