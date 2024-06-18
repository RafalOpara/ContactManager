using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetPc;
using NetPcProject.Models;
using NetPcProjectDataBase.Enitites;

namespace NetPcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactManager mContactManager;
        private readonly ViewModelMapper mViewModelMapper;
        

        public HomeController(IContactManager contactManager, ViewModelMapper viewModelMapper)
        {
            mContactManager = contactManager;
            mViewModelMapper = viewModelMapper;
           
        }

        public IActionResult Index()
        {
            var contactDtos = mContactManager.GetAllContacts();
            var contactViewModels = mViewModelMapper.Map(contactDtos);
            return View(contactViewModels);
        }

        
        public IActionResult Add()
        {
            ViewBag.CategoryOptions = GetCategoryOptions();
            return View();
        }

        [HttpPost]
   
        public IActionResult Add(ContactViewModel contactVm)
        {
            if (ModelState.IsValid)
            {
                var dto = mViewModelMapper.Map(contactVm);
                mContactManager.AddNewContact(dto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryOptions = GetCategoryOptions();
            return View(contactVm);
        }

        public IActionResult Delete(int contactId)
        {
            mContactManager.DeleteContact(new ContactDto { Id = contactId });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int contactId)
        {
            var contactDto = mContactManager.GetAllContacts().FirstOrDefault(x => x.Id == contactId);
            if (contactDto == null)
            {
                return NotFound();
            }
            var contactViewModel = mViewModelMapper.Map(contactDto);
            return View(contactViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int contactId)
        {
            var contactDto = mContactManager.GetAllContacts().FirstOrDefault(x => x.Id == contactId);
            if (contactDto == null)
            {
                return NotFound();
            }

            var contactViewModel = mViewModelMapper.Map(contactDto);
            ViewBag.CategoryOptions = GetCategoryOptions(); // Pobierz opcje kategorii

            return View(contactViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContactViewModel updatedContactVm)
        {
            updatedContactVm.Id = (int)TempData["ContactId"];

            if (ModelState.IsValid)
            {
                var updatedContactDto = mViewModelMapper.Map(updatedContactVm);
                mContactManager.UpdateContact(updatedContactDto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryOptions = GetCategoryOptions(); // Pobierz opcje kategorii
            return View(updatedContactVm);
        }

        private SelectList GetCategoryOptions()
        {
            var categories = mContactManager.GetAllContactsCategory(); // Pobierz wszystkie kategorie z bazy danych
            return new SelectList(categories, nameof(ContactCategory.Id), nameof(ContactCategory.Name));
        }



        public IActionResult Register()
        {
            return RedirectToAction("Register", "User");
        }
        public IActionResult Login()
        {
            return RedirectToAction("Login", "User");
        }
    }
}
