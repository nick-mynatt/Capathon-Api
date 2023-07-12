using Capathon.Dtos.Appointment;

namespace Capathon.Services.AppointmentService
{
    public interface IAppointmentService
    {
       Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();

        Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int id);

        Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment);

        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment);

        Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(int id);
    }
}