using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Super_Shop.Models;
using Super_Shop.Repositories;

namespace Super_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HeroRepository _heroRepository;
        private EmployeeRepository _employeeRepository;
        private ContactRepository _contactRepository;
        private Database _database;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _database = new Database();
            _heroRepository = new HeroRepository();
            _employeeRepository = new EmployeeRepository();
            _contactRepository = new ContactRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Contact()
        {
            /*ViewBag.Employees = new List<Employee>()
            {
                new Employee() { Name = "Eric Kuijpers", Role = "CEO", ImageUri = "~/img/employees/eric.jfif" },
                new Employee() { Name = "Carron Schilders", Role = "CTO", ImageUri = "~/img/employees/carron.jfif"  },
                new Employee() { Name = "Stijn Smulders", Role = "Service desk", ImageUri = "~/img/employees/stijn.jfif"  },
            };*/
            ViewBag.Employees = _employeeRepository.FindAll();
            ViewBag.Name = "Super Store inc.";
            ViewBag.Adres = "200 Park Ave";  
            ViewBag.City = "New York";
            ViewBag.Postalcode = "NY 10166";
            ViewBag.Country = "Verenigde Staten";
            ViewBag.Phonenumber = "0615879703";
            ViewBag.Email = "info@supershop.net";
            
            ViewBag.Interns = new List<Employee>()
            {
                new Employee() {Name = "Sven van der Zwet", Role = "Intern"},
            };

            ViewBag.Heroes = _heroRepository.FindAll().Select(h => h.Name);
            
            return View(new Contact());
        }

        [HttpPost]
        public IActionResult ContactFormPost(Contact contact)
        {
            Contact contactDup = new Contact
            {
                Title = contact.Title, Email = contact.Email, Message = contact.Message,
                Hero = _heroRepository.FindByName(contact.HeroName)
            };
            
            return View(_contactRepository.Save(contactDup));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
