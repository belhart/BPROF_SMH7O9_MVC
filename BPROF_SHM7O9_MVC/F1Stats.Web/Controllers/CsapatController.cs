using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Logic;
using Microsoft.AspNetCore.Mvc;
using F1Stats.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace F1Stats.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CsapatController : ControllerBase
    {
        ICsapatLogic logic;

        public CsapatController(ICsapatLogic csapatLogic)
        {
            this.logic = csapatLogic;
        }
        [HttpGet("{name}")]
        public Csapat GetOneCsapat(string name)
        {
            return this.logic.GetOneCsapat(name);
        }

        [HttpGet]
        public IEnumerable<Csapat> GetAll()
        {
            return this.logic.GetAllCsapat();
        }

        [HttpDelete("{name}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCsapat(string name)
        {
            if (this.logic.DeleteCsapat(name)) return Ok();
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCsapat([FromBody] Csapat csapat)
        {
            this.logic.CreateCsapat(csapat);
            return Ok();
        }

        [HttpPut("{name}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCsapat(string name, [FromBody] Csapat csapat)
        {
            if (this.logic.UpdateCsapat(name, csapat)) return Ok();
            return BadRequest();
        }
    }
}