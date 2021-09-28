﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class ContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        
        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public ShopDbContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<ShopDbContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("Supershop"));

            return new ShopDbContext(builder.Options);
        }
    }
}