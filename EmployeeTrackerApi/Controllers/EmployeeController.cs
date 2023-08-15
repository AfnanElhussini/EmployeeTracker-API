using EmployeeTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using EmployeeTrackerApi.Helpers;
using AutoMapper;
using EmployeeTrackerApi.Services.Interfaces;
using EmployeeTrackerApi.DTOs;
using EmployeeTrackerApi.DTOs;

namespace EmployeeTrackerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAdressReprositry _adressRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IAdressReprositry adressRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _adressRepository = adressRepository;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetEmployeesAsync(int page, int pageSize)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(page, pageSize);
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(employeesDTO);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAllEmployee();
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(employeesDTO);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }
        // POST: api/Employee
        // Id {3fa85f64-5717-4562-b3fc-2c963f66afa6}
        // guid ={d32f0643-28ba-4383-b368-aa6398913706}
        //employee id ={025d4da3-0ab8-4f67-b98f-9137dfbad118}
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(EmployeeDTO employeeDTO)
        { 
            var employee = _mapper.Map<Employee>(employeeDTO);
            var empId = Guid.NewGuid();
            employee.Id = empId;
            await _employeeRepository.CreateEmployeeAsync(employee);

          
           
            _employeeRepository.SaveChanges();
            return Ok("Employee Added!");
        }
        // PUT 

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(Guid id, EmployeeDTO employeeDTO)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("No Employee with This ID.");
            }
            _mapper.Map(employeeDTO, employee);
            _employeeRepository.UpdateEmployeeAsync(employee);
            _employeeRepository.SaveChanges();
            return Ok("Employee Updated!");
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {
            var employee =await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("No Employee with This ID.");
            }
            _employeeRepository.DeleteEmployee(id);
           int Result = _employeeRepository.SaveChanges();
            return Ok("Employee Deleted!");
        }
     

    }
}
