using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Leave, LeaveResponse>().ReverseMap();
            CreateMap<LeaveRequest, Leave>();
            CreateMap<string, Guid>().ConstructUsing(s => Guid.Parse(s));
            CreateMap<Guid, string>().ConstructUsing(g => g.ToString());
        }
    }
}
