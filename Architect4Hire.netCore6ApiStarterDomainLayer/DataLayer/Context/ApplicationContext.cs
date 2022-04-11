using System;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}

