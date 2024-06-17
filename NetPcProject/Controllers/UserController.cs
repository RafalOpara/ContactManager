using Microsoft.AspNetCore.Mvc;
using NetPc;
using NetPcProject.Core.Interfacess;
using NetPcProject.Models;

namespace NetPcProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager mUserManager;
        private readonly ViewModelMapper mViewModelMapper;


        public UserController(IUserManager userManager, ViewModelMapper viewModelMapper)
        {
            mUserManager = userManager;
            mViewModelMapper = viewModelMapper;
            
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
    }
}
