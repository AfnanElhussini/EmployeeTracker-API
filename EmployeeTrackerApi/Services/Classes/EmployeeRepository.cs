using EmployeeTrackerApi.Data;
using EmployeeTrackerApi.Services.Interfaces;
using 
    EmployeeTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrackerApi.Services.Classes
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
     
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employees.Include(s=>s.Addresses).FirstOrDefaultAsync(e => e.Id == id);
        }

        
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize)
        {
            return await _context.Employees.Include(s=>s.Addresses).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _context.Employees.Include(s=>s.Addresses).ToListAsync();
        }

   
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);

        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        async Task IEmployeeRepository.CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

       
        public void DeleteEmployee(Guid Id)
        {
          var Current=  _context.Employees.Find(Id);
            _context.Employees.Remove(Current);
        }


   }
    }

