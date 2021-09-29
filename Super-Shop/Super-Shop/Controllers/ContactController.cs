using Microsoft.AspNetCore.Mvc;
using Super_Shop.Models;
using Super_Shop.Repositories;

namespace Super_Shop.Controllers
{
    public class ContactController : Controller
    {
        private ContactRepository _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }
        
        public IActionResult Index()
        {
            var contacts = _contactRepository.FindAll();
            return View(contacts);
        }

        public IActionResult Show(int ID)
        {
            Contact contact = _contactRepository.FindById(ID);
            return View(contact);
        }
    }
}