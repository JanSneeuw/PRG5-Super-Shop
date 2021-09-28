using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Shop.Models
{
    /** Not so real database **/
    public class Database
    {
        private List<Hero> _heroes;
        private List<Team> _teams;

        public Database()
        {
            #region fake data

            /*_heroes = new List<Hero>() {
                new Hero() { Id = 1, Name = "Iron Man", PowerLevel = 9001, ImageUri = "~/img/iron_man.png" },
                new Hero() { Id = 2, Name = "Kermit the frog", PowerLevel = 5, ImageUri = "~/img/kermit.png" },
                new Hero() { Id = 3, Name = "Batman", PowerLevel = 1, ImageUri = "~/img/batman.png" },
                new Hero() { Id = 4, Name = "Deadpool", PowerLevel = 200, ImageUri = "~/img/deadpool.png" },
                new Hero() { Id = 5, Name = "Wolverine", PowerLevel = 150, ImageUri = "~/img/wolverine.png" },
            };*/

            /*_teams = new List<Team>() {
                new Team() { Id = 1, Name = "The dream team", MemberIds = new []{1, 2, 3 }, ImageUri = "", Members = new List<Hero>()},
                new Team() { Id = 2, Name = "The unbrella accademy", MemberIds = new []{2, 3, 4 }, ImageUri = "", Members = new List<Hero>() },
                new Team() { Id = 3, Name = "Dharma Initiative", MemberIds = new []{3, 4, 5 }, ImageUri = "", Members = new List<Hero>() },
            };*/

            #endregion
        }

        public List<Hero> GetHeroes()
        {
            return _heroes;
        }

        public Hero GetHero(int heroId)
        {
            return _heroes.First(hero => hero.Id == heroId);
        }

        public List<Team> GetTeams()
        {
            return _teams;
        }

        public Team GetTeamWithMembers(int teamId)
        {
            var team = _teams.First(team => team.Id == teamId);
            team.Members.AddRange(_heroes.Where(hero => team.MemberIds.Contains(hero.Id)));
            return team;
        }




        public object Name { get; }
        public object PowerLevel { get; private set; }
    }
}
