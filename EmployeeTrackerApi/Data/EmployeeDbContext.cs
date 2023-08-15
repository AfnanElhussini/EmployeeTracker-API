using EmployeeTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackerApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        { }
            
          public DbSet<Employee> Employees { get; set; }
          public DbSet<Address> Addresses { get; set; }
        }
    }
