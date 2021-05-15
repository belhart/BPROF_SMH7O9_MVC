using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;
using F1Stats.Logic;
using F1Stats.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1Stats.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyhetvegeController : ControllerBase
    {
        IVersenyhetvegeLogic logic;

        public VersenyhetvegeController(VersenyhetvegeLogic versenyhetvegeLogic)
        {
            logic = versenyhetvegeLogic;
        }

        [HttpGet("{id:int}")]
        public Versenyhetvege GetOneVersenyhetvege(int id)
        {
            return this.logic.GetOneVersenyhetvege(id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteVersenyhetvege(int id)
        {
            this.logic.DeleteVersenyhetvege(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateVersenyhetvege([FromBody] Versenyhetvege versenyhetvege)
        {
            this.logic.CreateVersenyhetvege(versenyhetvege);
            return Ok();
        }

        [HttpPut("{oldId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateVersenyhetvege(int oldId, [FromBody] Versenyhetvege versenyhetvege)
        {
            //this.logic.UpdateVersenyzo(oldId, versenyhetvege);
            return Ok();
        }
    }
}