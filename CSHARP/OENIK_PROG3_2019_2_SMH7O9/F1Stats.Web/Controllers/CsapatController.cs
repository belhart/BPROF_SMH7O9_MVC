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
    public class CsapatController : Controller
    {
        ICsapatLogic logic;
        IMapper mapper;
        CsapatViewModel vm;

        // GET: Csapat
        public CsapatController()
        {
            logic = new CsapatLogic();
            mapper = MapperFactory.CreateCsapatMapper();

            vm = new CsapatViewModel();
            vm.EditedCsapat = new Csapat();
            var csapatok = logic.GetAllCsapat();
            vm.ListOfCsapatok = mapper.Map<IList<Data.Csapat>, List<Models.Csapat>>(csapatok);
        }
        
        private Csapat GetCsapatModel(string nev)
        {
            F1Stats.Data.Csapat oneCsapat = logic.GetOneCsapat(nev);
            return mapper.Map<Data.Csapat, Models.Csapat>(oneCsapat);
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
            //ezt megcsinálni
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
                    //ezt megcsinálni
                    logic.CreateCsapat(csapat.CsapatNev, csapat.Motor, csapat.VersenyekSzama, csapat.Gyozelmek);
                }
                else
                {
                    //ezt megcsinálni
                    bool success = logic.UpdateCsapat(csapat.CsapatNev, csapat.Motor, csapat.VersenyekSzama, csapat.Gyozelmek);
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