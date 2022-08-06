using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Data.DTOs;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AccountController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpPost, Route("login")]
        public async Task<ActionResult<AdminUserDto>> login([FromBody] LoginDto user)
        {
            string currAdminEmail = configuration.GetSection("AdminUsername").Value;
            string currAdminPassword = configuration.GetSection("AdminPassword").Value;

            AdminUserDto adminUser = new AdminUserDto();
            if (user == null)
            {

                return BadRequest(adminUser);
            }
            if (user.Password == currAdminPassword && user.Username == currAdminEmail)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(currAdminPassword));
                var signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                      issuer: "https://localhost:44391",
                      audience: "https://localhost:44391",
                      claims: new List<Claim>(),
                      expires: System.DateTime.Now.AddMinutes(5),
                      signingCredentials: signingCredential
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                adminUser = new AdminUserDto()
                {
                    Email = user.Username,
                    Token = tokenString,
                };
                return Ok(adminUser);

            }


            return Unauthorized(adminUser);

        }
    }
}
