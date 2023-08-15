using System.ComponentModel.DataAnnotations;

namespace EmployeeTrackerApi.Models
{
    public class Employee
    {

      public Guid Id { get; set; }

        [RegularExpression(@"^\S*$", ErrorMessage = "Name should not contain spaces.")]
        public string? Name { get; set; }
        [Range(21, int.MaxValue, ErrorMessage = "Age must be greater than 20")]
        public int Age { get; set; }
        [MinLength(1, ErrorMessage = "Addresses list shouldn't be empty")]
        public List<Address>? Addresses { get; set; }
       

    }
}
