using F1Stats.Data;
using F1Stats.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1Stats.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IAuthLogic authLogic;

        /// <summary>
        /// Creates a new instance of AuthController
        /// </summary>
        /// <param name="authLogic">AuthLogic object (transient)</param>
        public AuthController(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="model">Login model, containing the details of the user to be created.</param>
        /// <returns>Http200 if ok</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] Login model)
        {
            string result = await authLogic.RegisterUser(model);
            return Ok(new { UserName = result });
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>Attempts to log in the user, and gives him a TokenModel if successful. </remarks>
        /// <param name="model">LoginModel, containing the details of the user logging in</param>
        /// <returns>A TokenModel if successful, BadRequest if not</returns>
        [HttpPut]
        public async Task<ActionResult> Login([FromBody] Login model)
        {
            try
            {
                return Ok(await authLogic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
