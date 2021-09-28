using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Super_Shop.Models;
using Super_Shop.Repositories;

namespace Super_Shop.Controllers
{
    public class HeroesController : Controller
    {
        private Database _database;
        private HeroRepository _heroRepository;

        public HeroesController()
        {
            _database = new Database();
            _heroRepository = new HeroRepository();
        }

        public IActionResult Index()
        {
            var heroes = _heroRepository.FindAll();
            return View(heroes);
        }

        public IActionResult Show(int id)
        {
            Hero hero = _heroRepository.FindByID(id);
            return View(hero);
        }
    }
}
