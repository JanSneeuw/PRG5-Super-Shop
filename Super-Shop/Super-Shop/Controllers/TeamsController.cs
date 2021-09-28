using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Super_Shop.Models;
using Super_Shop.Repositories;

namespace Super_Shop.Controllers
{
    public class TeamsController : Controller
    {
        private Database _database;
        private TeamRepository _teamRepository;

        public TeamsController()
        {
            _database = new Database();
            _teamRepository = new TeamRepository();
        }

        // GET
        public IActionResult Index()
        {
            //var teams = _database.GetTeams().Select(team => _database.GetTeamWithMembers(team.Id)).ToList();
            var teams = _teamRepository.FindAll();
            return View(teams);
        }
    }
}