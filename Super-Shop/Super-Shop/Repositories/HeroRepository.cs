using System.Collections.Generic;
using System.Linq;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class HeroRepository
    {
        public Hero FindByName(string name)
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Heroes.First(h => h.Name.Equals(name));
            }
        }
        public List<Hero> FindAll()
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Heroes.ToList();
            }
        }

        public Hero FindByID(int id)
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Heroes.First(h => h.Id == id);
            }
        }
    }
}