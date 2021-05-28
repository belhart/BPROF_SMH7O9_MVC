using System;
using F1Stats.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace F1Stats.Logic
{
    public interface IAuthLogic
    {
        /// <summary>
        /// DEBUG ONLY
        /// Creates a single user, used only for debugging, as user registration is not part of our project.
        /// </summary>
        /// <param name="login">Login object, containing the login detals of the user to be created</param>
        /// <returns>'Ok', if the method successfully completed</returns>
        Task<string> RegisterUser(Login login);

        /// <summary>
        /// Method used to verify a login. 
        /// </summary>
        /// <param name="login">Login object, containing the login details</param>
        /// <returns>A TokenModel in case of a successful login, containing the JWT token of the logged in user</returns>
        Task<TokenModel> LoginUser(Login login);
    }
}
