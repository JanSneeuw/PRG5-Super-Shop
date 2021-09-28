using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Super_Shop.Repositories;

namespace Super_Shop.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) :base(options){}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Start Employee Seed Data
            var employee1 = new Employee() 
                {ID = -1, Name = "Eric Kuijpers", Role = "CEO", ImageUri = "~/img/employees/eric.jfif" };
            var employee2 = new Employee()
                {ID = -2, Name = "Carron Schilders", Role = "CTO", ImageUri = "~/img/employees/carron.jfif"};
            var employee3 = new Employee()
                {ID = -3, Name = "Stijn Smulders", Role = "Service desk", ImageUri = "~/img/employees/stijn.jfif"};
            modelBuilder.Entity<Employee>().HasData(employee1);
            modelBuilder.Entity<Employee>().HasData(employee2);
            modelBuilder.Entity<Employee>().HasData(employee3);
            //End Employee Seed Data
            
            //Start Hero Seed Data
            var hero1 = new Hero() {Id = 1, Name = "Iron Man", PowerLevel = 9001, ImageUri = "~/img/iron_man.png"};
            var hero2 = new Hero() {Id = 2, Name = "Kermit the frog", PowerLevel = 5, ImageUri = "~/img/kermit.png"};
            var hero3 = new Hero() {Id = 3, Name = "Batman", PowerLevel = 1, ImageUri = "~/img/batman.png"};
            var hero4 = new Hero() {Id = 4, Name = "Deadpool", PowerLevel = 200, ImageUri = "~/img/deadpool.png"};
            var hero5 = new Hero() {Id = 5, Name = "Wolverine", PowerLevel = 150, ImageUri = "~/img/wolverine.png"};
            modelBuilder.Entity<Hero>().HasData(hero1);
            modelBuilder.Entity<Hero>().HasData(hero2);
            modelBuilder.Entity<Hero>().HasData(hero3);
            modelBuilder.Entity<Hero>().HasData(hero4);
            modelBuilder.Entity<Hero>().HasData(hero5);
            //End Hero Seed Data
            
            //Start Team Seed Data
            //End Team Seed Data
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                context.Database.EnsureCreated();
                var team1 = new Team()
                {
                    Id = 1, Name = "The dream team", Members = new[]{
                        new Hero(){Id = hero3.Id, Name = hero3.Name, ImageUri = hero3.ImageUri, PowerLevel = hero3.PowerLevel},
                        new Hero(){Id = hero5.Id, Name = hero5.Name, ImageUri = hero5.ImageUri, PowerLevel = hero5.PowerLevel},
                    }.ToList(), ImageUri = "" 
                };
                var team3 = new Team()
                {
                    Id = 3, Name = "Dharma Initiative", Members = new[]
                    {
                        new Hero(){Id = hero1.Id, Name = hero1.Name, ImageUri = hero1.ImageUri, PowerLevel = hero1.PowerLevel},
                        new Hero(){Id = hero2.Id, Name = hero1.Name, ImageUri = hero1.ImageUri, PowerLevel = hero1.PowerLevel}
                    }.ToList(), ImageUri = ""
                };
                context.Add(team1);
                context.Add(team3);
                context.SaveChanges();
            }
        }
    }
    
    
    
}