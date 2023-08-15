using EmployeeTrackerApi.DTOs;
using EmployeeTrackerApi.Models;

using System.ComponentModel.DataAnnotations;


namespace EmployeeTrackerApi.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        [RegularExpression(@"^\S*$", ErrorMessage = "Name should not contain spaces.")]
        public string? Name { get; set; }
        [Range(21, int.MaxValue, ErrorMessage = "Age must be greater than 20")]
        public int Age { get; set; }
        public List<AddressDTO>? Addresses { get; set; }


    }
}
