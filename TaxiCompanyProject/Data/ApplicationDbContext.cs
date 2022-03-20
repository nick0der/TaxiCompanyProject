using System;
using Microsoft.EntityFrameworkCore;

namespace TaxiCompanyProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Chief> Chiefs { get; set; }
        public DbSet<Models.Dispatcher> Dispatchers { get; set; }
        public DbSet<Models.Driver> Drivers { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.Garage> Garages { get; set; }
        public DbSet<Models.Taxi> Taxis { get; set; }
    }

}
