using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;
using F1Stats.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace F1Stats.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EredmenyController : ControllerBase
    {
        IEredmenyLogic logic;

        public EredmenyController(IEredmenyLogic eredmenyLogic)
        {
            this.logic = eredmenyLogic;
        }
        [HttpGet]
        public IEnumerable<Eredmeny> GetAllEredmeny()
        {
            return this.logic.GetAllEredmeny();
        }

        [HttpGet("{id:int}")]
        public Eredmeny GetOneEredmeny(int id)
        {
            return this.logic.GetOneEredmeny(id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteEredmeny(int id)
        {
            this.logic.DeleteEredmeny(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateEredmeny([FromBody] Eredmeny eredmeny)
        {
            this.logic.CreateEredmeny(eredmeny);
            return Ok();
        }

        [HttpPut("{oldId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateEredmeny(int oldId, [FromBody] Eredmeny eredmeny)
        {
            //this.logic.UpdateVersenyzo(oldId, eredmeny);
            return Ok();
        }
    }
}