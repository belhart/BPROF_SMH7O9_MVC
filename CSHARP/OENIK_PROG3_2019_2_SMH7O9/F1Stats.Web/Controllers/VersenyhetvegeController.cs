using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using F1Stats.Logic;
using F1Stats.Web.Models;

namespace F1Stats.Web.Controllers
{
    public class VersenyhetvegeController : Controller
    {
        IVersenyhetvegeLogic logic;
        IMapper mapper;
        VersenyhetvegeViewModel vm;

        public VersenyhetvegeController()
        {
            logic = new VersenyhetvegeLogic();
            mapper = MapperFactory.CreateVersenyhetvegeMapper();

            vm = new VersenyhetvegeViewModel();
            vm.EditedVersenyhetvege = new Versenyhetvege();
            var versenyhetvegek = logic.GetAllVersenyhetvege();
            vm.ListOfVersenyhetvegek = mapper.Map<IList<Data.Versenyhetvege>, List<Models.Versenyhetvege>>(versenyhetvegek);
        }

        private Versenyhetvege GetVersenyhetvegeModel(int versenySzam)
        {
            F1Stats.Data.Versenyhetvege oneVersenyhetvege = logic.GetOneVersenyhetvege(versenySzam);
            return mapper.Map<Data.Versenyhetvege, Models.Versenyhetvege>(oneVersenyhetvege);
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
                    logic.CreateVersenyhetvege(versenyhetvege.Nev, versenyhetvege.Versenyhetvege_szama, versenyhetvege.Hossz, versenyhetvege.Kor, versenyhetvege.Idopont, versenyhetvege.Helyszin);
                }
                else
                {
                    bool success = logic.UpdateVersenyhetvege(versenyhetvege.Nev, versenyhetvege.Versenyhetvege_szama, versenyhetvege.Hossz, versenyhetvege.Kor, versenyhetvege.Idopont, versenyhetvege.Helyszin);
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