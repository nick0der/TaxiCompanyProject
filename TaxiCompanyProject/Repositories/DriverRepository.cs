using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiCompanyProject.Data;
using TaxiCompanyProject.Models;

namespace TaxiCompanyProject.Repositories
{
    public class DriverRepository
    {
        private readonly ApplicationDbContext _context;

        public DriverRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> Create(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return driver;
        }

        public async Task Delete(int id)
        {
            var employeeToDelete = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Driver>> Get()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver> Get(int id)
        {
            return await _context.Drivers.FindAsync(id);
        }

        public async Task Update(Driver driver)
        {
            _context.Entry(driver).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public DriverRepository()
        {
        }
    }
}



