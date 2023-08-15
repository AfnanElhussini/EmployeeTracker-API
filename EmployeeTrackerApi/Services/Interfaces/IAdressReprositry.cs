using EmployeeTrackerApi.Models;

namespace EmployeeTrackerApi.Services.Interfaces
{
    public interface IAdressReprositry
    {
        Task<Address> GetAddressByIdAsync(Guid id);
        Task AddAdress(Address address);
        void Update(Address address);
        Task Delete(Address address);
        int SaveChanges();

    }
}
