using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capathon.Models;
using Capathon.Services.AppointmentService;
using Capathon.Dtos.Appointment;

namespace Capathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService){
            this._appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> GetAppointments()
        {
          return Ok(await _appointmentService.GetAllAppointments());
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> GetAppointment(int id)
        {
           return Ok(await _appointmentService.GetAppointmentById(id));
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> UpdateAppointment(UpdateAppointmentDto updateAppointment)
         {

                return Ok(await _appointmentService.UpdateAppointment(updateAppointment));
         }

        // POST: api/Dependent
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAppointmentDto>>>> AddAppointment(AddAppointmentDto newAppointment)
         {
            var response = await _appointmentService.AddAppointment(newAppointment);

                if (response.Data == null){
                    return NotFound(response);
                }
                return Ok(response);
         }

        // DELETE: api/Dependent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetAppointmentDto>>> DeleteAppointment(int id)
        {
           var response = await _appointmentService.DeleteAppointment(id);

                if (response.Data == null){
                    return NotFound(response);
                }
                return Ok(response);
        }

      
    }
}