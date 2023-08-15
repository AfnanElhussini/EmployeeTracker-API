using EmployeeTrackerApi.Models;
using EmployeeTrackerApi.Services.Classes;


namespace EmployeeTrackerApi.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
         void DeleteEmployee(Guid Id);

        int SaveChanges();


    }
}
