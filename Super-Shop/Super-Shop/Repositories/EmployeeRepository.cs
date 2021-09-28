using System;
using System.Collections.Generic;
using System.Linq;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> FindAll()
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Employees.ToList();
            }
        }
    }
}