namespace EmployeeTrackerApi.Models
{
    public class Address
    {
        public Guid Id { get; set; }
      
        public string? Description { get; set; }

        // Foreign Key
        public Guid EmployeeId { get; set; }
        // Navigation property
        public Employee? Employee { get; set; }

        // in this Logic is Must Adding Employee First and Then Adding His Adress 

    }
}

/*
 Each Empoyee Has Many Addresses
and Each Address Belongs to One Employee

is this mean of realtion ???
 
 */