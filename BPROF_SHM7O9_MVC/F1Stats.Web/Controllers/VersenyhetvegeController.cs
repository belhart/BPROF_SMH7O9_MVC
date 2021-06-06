using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1Stats.Data.Models;
using F1Stats.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F1Stats.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyhetvegeController : ControllerBase
    {
        IVersenyhetvegeLogic logic;

        public VersenyhetvegeController(IVersenyhetvegeLogic versenyhetvegeLogic)
        {
            logic = versenyhetvegeLogic;
        }

        [HttpGet("{id:int}")]
        public Versenyhetvege GetOneVersenyhetvege(int id)
        {
            return this.logic.GetOneVersenyhetvege(id);
        }

        public IEnumerable<Versenyhetvege> GetAll()
        {
            return this.logic.GetAllVersenyhetvege();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteVersenyhetvege(int id)
        {
            if(this.logic.DeleteVersenyhetvege(id)) return Ok();
            return BadRequest();
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
            if(this.logic.UpdateVersenyhetvege(oldId, versenyhetvege)) return Ok();
            return BadRequest();
        }
    }
}