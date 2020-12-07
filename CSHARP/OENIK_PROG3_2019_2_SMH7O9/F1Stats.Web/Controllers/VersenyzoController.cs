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
    public class VersenyzoController : Controller
    {
        IVersenyzoLogic logic;
        IMapper mapper;
        VersenyzoViewModel vm;

        public VersenyzoController()
        {
            logic = new VersenyzoLogic();
            mapper = MapperFactory.CreateVersenyzoMapper();

            vm = new VersenyzoViewModel();
            vm.EditedVersenyzo = new Versenyzo();
            var versenyzok = logic.GetAllVersenyzo();
            vm.ListOfVersenyzok = mapper.Map<IList<Data.Versenyzo>, List<Models.Versenyzo>>(versenyzok);
        }

        private Versenyzo GetVersenyzoModel(int rajtszam)
        {
            F1Stats.Data.Versenyzo oneVersenyzo = logic.GetOneVersenyzo(rajtszam);
            return mapper.Map<Data.Versenyzo, Models.Versenyzo>(oneVersenyzo);
        }

        // GET: Versenyzo
        public ActionResult Index()
        {
            ViewData["editAction"] = "AddNew";
            return View("VersenyzoIndex", vm);
        }

        // GET: Versenyzo/Details/5
        public ActionResult Details(int id)
        {
            return View("VersenyzoDetails", GetVersenyzoModel(id));
        }
        //GET
        public ActionResult Remove(int id)
        {
            TempData["editResult"] = "Delete FAIL";
            if (logic.DeleteVersenyzo(id)) TempData["editResult"] = "Delete OK";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.EditedVersenyzo = GetVersenyzoModel(id);
            return View("VersenyzoIndex", vm);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Versenyzo versenyzo, string editAction)
        {
            if (ModelState.IsValid && versenyzo != null)
            {
                TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    logic.CreateVersenyzo(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
                }
                else
                {
                    bool success = logic.UpdateVersenyzo(versenyzo.Rajtszam, versenyzo.Nev, versenyzo.CsapatNev, versenyzo.Eletkor, versenyzo.OsszPont, versenyzo.IdenybeliPont);
                    if (!success) TempData["editResult"] = "Edit FAIL";
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.EditedVersenyzo = versenyzo;
                return View("VersenyzoIndex", vm);
            }
        }
    }
}
