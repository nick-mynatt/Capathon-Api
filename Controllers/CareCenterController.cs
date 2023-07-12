using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capathon.Models;
using Capathon.Services;
using Capathon.Dtos.CareCenter;

namespace Capathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareCenterController : ControllerBase
    {
        private readonly ICareCenterService _careCenterService;

        public CareCenterController(ICareCenterService careCenterService)
        {
            _careCenterService = careCenterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCareCenterDto>>>> GetCareCenters()
        {
            return Ok(await _careCenterService.GetAllCareCenters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCareCenterDto>>> GetCareCenter(int id)
        {
            return Ok(await _careCenterService.GetCareCenterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCareCenterDto>>>> AddCareCenter(AddCareCenterDto newCareCenter)
        {
            var response = await _careCenterService.AddCareCenter(newCareCenter);
            if (response.Data is null) {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCareCenterDto>>> UpdateCareCenter(UpdateCareCenterDto updatedCareCenter)
        {
            var response = await _careCenterService.UpdateCareCenter(updatedCareCenter);
            if (response.Data is null) {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCareCenterDto>>>> DeleteCareCenter(int id)
        {
            var response = await _careCenterService.DeleteCareCenter(id);
            if (response.Data is null) {
                return NotFound(response);
            }
            return Ok(response);
        }
    }

}