using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetPc;
using NetPcProject.Core.Interfacess;
using NetPcProject.Models;
using NetPcProjectDataBase.Enitites;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetPcProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager mUserManager;
        private readonly ViewModelMapper mViewModelMapper;
        private readonly AuthenticationSettings mAuthenticationSettings;

        public UserController(IUserManager userManager, ViewModelMapper viewModelMapper, AuthenticationSettings authenticationSettings)
        {
            mUserManager = userManager;
            mViewModelMapper = viewModelMapper;
            mAuthenticationSettings = authenticationSettings;
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(UserViewModel userVm)
        {
            bool emailExists = mUserManager.GetAllUsers().Any(u => u.Email == userVm.Email);

            if (emailExists == false)
            {
                var dto = mViewModelMapper.Map(userVm);
                mUserManager.AddNewUser(dto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(userVm); 
            }

        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(UserViewModel userVm)
        {
            bool userExists = mUserManager.GetAllUsers().Any(u => u.Email == userVm.Email);

            if (userExists == false)
            {
                ModelState.AddModelError("Email", "Email do not exists.");
                return View(userVm);
            }
            else
            {

                var dto = mViewModelMapper.Map(userVm);

                 var checkedPassword= mUserManager.CheckPassword(dto);

                if (checkedPassword == false)
                {
                    ModelState.AddModelError("Password", "Wrong Password.");
                }
                else
                {
                    GenerateJwtToken(userVm);
                    return RedirectToAction("Index", "Home");
                }

               return RedirectToAction("Login", "User");
            }

        }

        private string GenerateJwtToken(UserViewModel userVm)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mAuthenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(mAuthenticationSettings.JwtExpireDays);

            var claims = new List<Claim>()
                    {
                    new Claim(ClaimTypes.NameIdentifier, userVm.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{userVm.FirstName} {userVm.LastName}"),
                    new Claim(ClaimTypes.Role, $"{userVm.RoleId}"),

                    };

            var token = new JwtSecurityToken(mAuthenticationSettings.JwtIssuer,
                claims: claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
