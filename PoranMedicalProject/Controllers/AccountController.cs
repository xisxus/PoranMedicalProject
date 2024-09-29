using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PoranMedicalProject.Models.DTO;
using PoranMedicalProject.Models.Entites.EmployeeAndUser;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PoranMedicalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest("Model is empty");

            if (userDTO.Password != userDTO.ConfirmPassword)
                return BadRequest("Passwords do not match");

            var newUser = new ApplicationUser
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                UserName = userDTO.Email
            };

            var existingUser = await _userManager.FindByEmailAsync(newUser.Email)
                               ?? await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == newUser.PhoneNumber);

            if (existingUser != null)
                return Conflict("User already registered");

            var createUser = await _userManager.CreateAsync(newUser, userDTO.Password);
            if (!createUser.Succeeded)
                return StatusCode(500, "An error occurred while creating the account");

            var checkAdmin = await _roleManager.FindByNameAsync("Admin");
            if (checkAdmin == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else
            {
                var checkUser = await _roleManager.FindByNameAsync("User");
                if (checkUser == null)
                    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });

                await _userManager.AddToRoleAsync(newUser, "User");
            }

            //string url = $"{Request.Scheme}://{Request.Host}/api/account/{newUser.Id}";

            string url = "/login/";
            return Ok(new { Message = "Account created", Url = url });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest("Login container is empty");

            var getUser = await _userManager.FindByEmailAsync(loginDTO.EmailOrPhone)
                         ?? await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == loginDTO.EmailOrPhone);

            if (getUser == null)
                return NotFound("User not found");

            bool checkPassword = await _userManager.CheckPasswordAsync(getUser, loginDTO.Password);
            if (!checkPassword)
                return Unauthorized("Invalid username/password");

            var getUserRole = await _userManager.GetRolesAsync(getUser);
            var userSession = new UserSession(getUser.Id, getUser.Name, getUser.Email, getUserRole.First());

            string token = GenerateJWTToken(userSession);

            //string url = $"{Request.Scheme}://{Request.Host}/api/account/{getUser.Id}/token";

            string url = "/dashboard/";
            return Ok(new { Message = "User login successful", Url = url, Token = token });
        }

        private string GenerateJWTToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
