using AutoMapper;
using Capathon.Dtos.Appointment;
using Capathon.Dtos.CareCenter;
using Capathon.Dtos.User;

namespace Capathon
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<Dependent,GetDependentDto>();
            CreateMap<AddDependentDto,Dependent>();
            
            CreateMap<CareCenter,GetCareCenterDto>();
            CreateMap<AddCareCenterDto,CareCenter>();

            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();

            CreateMap<Appointment, GetAppointmentDto>();
            CreateMap<AddAppointmentDto, Appointment>();
        }
    }
}