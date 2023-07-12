using Capathon.Dtos.Appointment;
using AutoMapper;

namespace Capathon.Services.AppointmentService
{
    public class AppointmentService :IAppointmentService
    {
         private readonly IMapper _mapper;
        private readonly CapathonBroadwayContext _dataContext;

        public AppointmentService(IMapper mapper, CapathonBroadwayContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<ServiceResponse<List<GetAppointmentDto>>> AddAppointment(AddAppointmentDto newAppointment)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var appointment =_mapper.Map<Appointment>(newAppointment);

            _dataContext.Appointments.Add(appointment);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Appointments.Select(a => _mapper.Map<GetAppointmentDto>(a)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> DeleteAppointment(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();

            try{
            var appointment = await _dataContext.Appointments.FirstOrDefaultAsync(a => a.UId == id); //Need ID for appointments (AId?)
            if(appointment == null){
                throw new Exception($"Appointment with ID '{id}' not found.");
            }
            
            _dataContext.Appointments.Remove(appointment); 
            await _dataContext.SaveChangesAsync(); 

            serviceResponse.Data = await _dataContext.Appointments.Select(a => _mapper.Map<GetAppointmentDto>(a)).ToListAsync();; 

            }
            catch(Exception){
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointment = await _dataContext.Appointments.ToListAsync();
            serviceResponse.Data = dbAppointment.Select(a => _mapper.Map<GetAppointmentDto>(a)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(int id)
        {

            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var dbAppointment = await _dataContext.Appointments.FirstOrDefaultAsync(a => a.UId == id);
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(UpdateAppointmentDto updatedAppointment)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();

            try{
            var appointment = await _dataContext.Appointments.FirstOrDefaultAsync(a => a.UId == updatedAppointment.UId);
            if(appointment == null)
                throw new Exception($"Appointment for user with ID '{updatedAppointment.UId}' not found.");

            appointment.PickupTime = updatedAppointment.PickupTime;
            appointment.DropoffTime = updatedAppointment.DropoffTime;
            appointment.CId = updatedAppointment.CId; 
            appointment.DId = updatedAppointment.DId; 
            appointment.UId = updatedAppointment.UId; 

            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment); 

            }
            catch(Exception){
                serviceResponse.Success = false;
            }
            return serviceResponse; 
        }
    }
}