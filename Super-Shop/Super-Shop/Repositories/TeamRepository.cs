using System.Collections.Generic;
using System.Linq;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class TeamRepository
    {
        public List<Team> FindAll()
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Teams.ToList();
            }
        }
    }
}