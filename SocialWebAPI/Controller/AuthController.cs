using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialWebModel;
using SocialWebModel.OtherO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }
        [HttpPost("SeedRole")]
        public async Task<IActionResult> SeedRole()
        {
            await _roleManager.CreateAsync(new IdentityRole(StaticRole.OWNER));
            await _roleManager.CreateAsync(new IdentityRole(StaticRole.ADMIN));
            await _roleManager.CreateAsync(new IdentityRole(StaticRole.USER));

            return Ok("hehe");
        }
        [HttpPost("Resign")]
        public async Task<IActionResult> CreateUser([FromBody] ResignDTO user) {

            var isUserExits = await _userManager.FindByNameAsync(user.UserName);
            if (isUserExits != null)
            {
                return BadRequest();
            }
            IdentityUser newUser = new IdentityUser() 
            { 
                UserName = user.UserName,
                Email = user.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var createNewUser = await _userManager.CreateAsync(newUser,user.Password);
            if (!createNewUser.Succeeded)
            {
                throw new Exception();
            }
            await _userManager.AddToRoleAsync(newUser,StaticRole.USER);
            return Ok("dang ki thanh cong");
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            var userLogin = await _userManager.FindByNameAsync(user.UserName);
            if (userLogin is null) return Unauthorized("cant find user");

            var isPassword = await _userManager.CheckPasswordAsync(userLogin,user.Password);
            if (!isPassword)
            {
                return Unauthorized("sai mat khau");
            }
            var userRole = await _userManager.GetRolesAsync(userLogin);
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userLogin.UserName),
                new Claim(ClaimTypes.NameIdentifier, userLogin.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
            };
            foreach (var role in userRole)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = NewToken(claim);

            return Ok(token);
        }

        private string NewToken(List<Claim> userClaim) {

            var token = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var tokenObj = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: userClaim,
                signingCredentials: new SigningCredentials(token, SecurityAlgorithms.HmacSha256)
                );
            string tokenUser = new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return tokenUser;
           
        }
       
    }
}
