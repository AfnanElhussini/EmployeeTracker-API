using AutoMapper;
using EmployeeTrackerApi.DTOs;

using EmployeeTrackerApi.Models;


namespace EmployeeTrackerApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

        }
    }
}
