using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using F1Stats.Data;
using System.Linq;
using System.Security.Claims;

namespace F1Stats.Logic
{
    public class AuthLogic : IAuthLogic
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public AuthLogic(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<string> RegisterUser(Login model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
            }
            return user.UserName;
        }

        public async Task<TokenModel> LoginUser(Login model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {


                var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(ClaimTypes.NameIdentifier, user.Id)
                };


                var roles = await userManager.GetRolesAsync(user);
                ;
                claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("a vilag valaha volt legnehezebb es legtitkosabb szovege"));

                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo
                };
            }
            throw new ArgumentException("Login failed");
        }

    }
}
