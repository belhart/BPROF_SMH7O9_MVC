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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCsapat(string name)
        {
            this.logic.DeleteCsapat(name);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCsapat([FromBody] Csapat csapat)
        {
            this.logic.CreateCsapat(csapat);
            return Ok();
        }

        [HttpPut("{oldId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCsapat(string name, [FromBody] Csapat csapat)
        {
            this.logic.UpdateCsapat(name, csapat);
            return Ok();
        }
    }
}