using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F1Stats.Logic;
using F1Stats.Web.Models;
using F1Stats.Data.Models;

namespace F1Stats.Web.Controllers
{
    public class VersenyzoController : Controller
    {
        IVersenyzoLogic logic;
        VersenyzoViewModel vm;

        public VersenyzoController(VersenyzoLogic versenyzoLogic)
        {
            logic = versenyzoLogic;
            vm = new VersenyzoViewModel();
            vm.EditedVersenyzo = new Versenyzo();
            var versenyzok = logic.GetAllVersenyzo();
            vm.ListOfVersenyzok = versenyzok.ToList();
        }

        private Versenyzo GetVersenyzoModel(int rajtszam)
        {
            return this.logic.GetOneVersenyzo(rajtszam);
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
                    logic.CreateVersenyzo(versenyzo);
                }
                else
                {
                    bool success = logic.UpdateVersenyzo(versenyzo.rajtszam, versenyzo.nev, versenyzo.csapat_nev, versenyzo.eletkor, versenyzo.ossz_pont, versenyzo.idenybeli_pont);
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