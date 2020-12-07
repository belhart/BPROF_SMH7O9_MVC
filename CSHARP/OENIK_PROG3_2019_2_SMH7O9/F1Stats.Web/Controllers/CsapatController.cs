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
            mapper = MapperFactory.CreateMapper();

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
        public ActionResult Details(int id)
        {
            return View("CsapatDetails", GetCsapatModel(id));
        }
        //GET
        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete FAIL";
            //ezt megcsinálni
            if (logic.DeleteCsapat(id)) TempData["editResult"] = "Delete OK";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedCsapat = GetCsapatModel(id);
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
                    logic.CreateCsapat(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
                }
                else
                {
                    //ezt megcsinálni
                    bool success = logic.UpdateCsapat(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
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