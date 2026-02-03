using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrderManagementSystem.DTO;
using OrderManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Account> userManager;
        private readonly IConfiguration config;
        public AccountController(UserManager<Account> UserManager, IConfiguration config)
        {
            userManager = UserManager;
            this.config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO UserFromRequest)
        {
            if (ModelState.IsValid)
            {
                Account user = new Account();
                {
                    user.UserName = UserFromRequest.UserName;
                    user.Frist = UserFromRequest.Frist;
                    user.Last = UserFromRequest.Last;
                    user.Age = UserFromRequest.Age;
                    user.Phone = UserFromRequest.Phone;
                    user.Age = UserFromRequest.Age;
                    user.Email = UserFromRequest.Email;

                }
                ;

                IdentityResult result = await userManager.CreateAsync(user, UserFromRequest.Password);
                if (result.Succeeded)
                {
                    return Ok("created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);

                }


            }
            return BadRequest(ModelState);
            

        }
        [HttpPost("Login")]
        public async  Task<ActionResult> Login(LoginDTO UserFromRequest)
        {
            if (ModelState.IsValid)
            {
                Account userFromDb = await userManager.FindByEmailAsync(UserFromRequest.Email);
                if (userFromDb != null)
                {
                    bool Found = await userManager.CheckPasswordAsync(userFromDb , UserFromRequest.Password);
                    if (Found = true ) {

                        List<Claim> UserClaims = new List<Claim>();
                        UserClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        UserClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDb.Id));
                        UserClaims.Add(new Claim(ClaimTypes.Name, userFromDb.UserName));
                        var UserRoles = await userManager.GetRolesAsync(userFromDb);
                         foreach(var RoleName in UserRoles)
                        {
                            UserClaims.Add(new Claim(ClaimTypes.Role, RoleName));
                        }
                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecritKey"]));
                        SigningCredentials signingCred = new SigningCredentials(signInKey,SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken Mytoken = new JwtSecurityToken(
                            issuer:config["JWT:IssuerIP"],
                            audience:config["JWT:audienceIP"],
                            expires: DateTime.Now.AddHours(1),
                            claims: UserClaims,
                            signingCredentials: signingCred

                            );
                        return Ok(new
                        {

                            token = new JwtSecurityTokenHandler().WriteToken(Mytoken),
                            expiration = Mytoken.ValidTo

                        }


                            );

                    }

                    ModelState.AddModelError("Username", "Username OR Password Invalid");
                }

            }
            return BadRequest(ModelState);

        }



       }
            
 }


