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
    public class VersenyhetvegeController : Controller
    {
        IVersenyhetvegeLogic logic;
        VersenyhetvegeViewModel vm;

        public VersenyhetvegeController(VersenyhetvegeLogic versenyhetvegeLogic)
        {
            logic = versenyhetvegeLogic;
            vm = new VersenyhetvegeViewModel();
            vm.EditedVersenyhetvege = new Versenyhetvege();
            var versenyhetvegek = logic.GetAllVersenyhetvege();
            vm.ListOfVersenyhetvegek = versenyhetvegek.ToList();
        }

        private Versenyhetvege GetVersenyhetvegeModel(int versenySzam)
        {
            return this.logic.GetOneVersenyhetvege(versenySzam);
        }

        // GET: Versenyhetvege
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("VersenyhetvegeIndex", vm);
        }

        // GET: Versenyhetvege/Details/5
        public ActionResult Details(int id)
        {
            return View("VersenyhetvegeDetails", GetVersenyhetvegeModel(id));
        }
        //GET
        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete FAIL";
            if (logic.DeleteVersenyhetvege(id)) TempData["editResult"] = "Delete OK";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedVersenyhetvege = GetVersenyhetvegeModel(id);
            return View("VersenyhetvegeIndex", vm);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Versenyhetvege versenyhetvege, string editAction)
        {
            if (ModelState.IsValid && versenyhetvege != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.CreateVersenyhetvege(versenyhetvege);
                }
                else
                {
                    bool success = logic.UpdateVersenyhetvege(versenyhetvege.nev, versenyhetvege.VERSENYHETVEGE_SZAMA, versenyhetvege.hossz, versenyhetvege.kor, versenyhetvege.idopont, versenyhetvege.helyszin);
                    if (!success) TempData["editResult"] = "Edit FAIL";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedVersenyhetvege = versenyhetvege;
                return View("VersenyhetvegeIndex", vm);
            }
        }
    }
}