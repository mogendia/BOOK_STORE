using BOOK_STORE.Core.Dto;
using BOOK_STORE.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BOOK_STORE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController : ControllerBase
    {
      private readonly UserManager<ApplicationUser>_userManager;
      private readonly IConfiguration _config;
        public RegisterationController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            if (ModelState.IsValid)
            {
                 ApplicationUser user = new();
                 user.UserName = register.UserName;
                 user.Email = register.Email;
                 var result = await _userManager.CreateAsync(user,register.Password);
                 if (result.Succeeded)
                     return Ok("Created Account");
                 foreach (var item in result.Errors)
                 ModelState.AddModelError("Password", item.Description);
            }
           return BadRequest(ModelState);
           
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login) 
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                if (user is not null)
                {
                    var check = await _userManager.CheckPasswordAsync(user, login.Password);
                    if (check)
                    {
                        List<Claim> userClaims = new List<Claim>();
                        userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        

                        var smKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                        var signCred = new SigningCredentials(smKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken myToken = new JwtSecurityToken
                            (
                            issuer: _config["JWT:Issuer"],
                            audience: _config["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            claims: userClaims,
                            signingCredentials: signCred
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiresIn = DateTime.Now.AddHours(1),
                        });

                    }

                }
                ModelState.AddModelError("UserName", "UserName or Passord Not Valid");
            }
            return BadRequest(ModelState);
        }
    }
}
