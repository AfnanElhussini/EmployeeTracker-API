using EmployeeTrackerApi.Data;
using EmployeeTrackerApi.Models;
using EmployeeTrackerApi.Services.Interfaces;

namespace EmployeeTrackerApi.Services.Classes
{
    public class AdressReprositry : IAdressReprositry
    {
        private readonly EmployeeDbContext _context;
        public AdressReprositry(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task AddAdress(Address address)
        {
           await _context.AddAsync(address);
        }

        public Task Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetAddressByIdAsync(Guid id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public int SaveChanges()
        {
          return  _context.SaveChanges();
        }

        public  void Update(Address address)
        {
             _context.Addresses.Update(address);
        }
    }
}
