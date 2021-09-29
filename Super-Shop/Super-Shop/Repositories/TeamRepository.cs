using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class TeamRepository
    {
        public List<Team> FindAll()
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Teams.Include(e => e.Members).ToList();
                
            }
        }
    }
}