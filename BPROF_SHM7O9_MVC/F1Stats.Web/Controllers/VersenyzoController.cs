﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F1Stats.Logic;
using F1Stats.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace F1Stats.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VersenyzoController : ControllerBase
    {
        IVersenyzoLogic logic;

        public VersenyzoController(IVersenyzoLogic versenyzoLogic)
        {
            logic = versenyzoLogic;
        }

        [HttpGet("{id:int}")]
        public Versenyzo GetOneVersenyzo(int id)
        {
            return this.logic.GetOneVersenyzo(id);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteVersenyzo(int id)
        {
            this.logic.DeleteVersenyzo(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateVersenyzo([FromBody] Versenyzo versenyzo)
        {
            this.logic.CreateVersenyzo(versenyzo);
            return Ok();
        }

        [HttpPut("{oldId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateVersenyzo(int oldId, [FromBody] Versenyzo versenyzo)
        {
            this.logic.UpdateVersenyzo(oldId, versenyzo);
            return Ok();
        }

    }
}