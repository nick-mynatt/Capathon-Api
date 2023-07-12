using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capathon.Models;

namespace Capathon
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController : ControllerBase
    {

        private readonly IDependentService _dependentService;

        public DependentController(IDependentService dependentService){
            this._dependentService = dependentService;
        }

        // GET: api/Dependent
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetDependentDto>>> GetDependents()
        {
          return Ok(await _dependentService.GetAllDependents());
        }

        // GET: api/Dependent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDependentDto>>> GetDependent(int id)
        {
           return Ok(await _dependentService.GetDependentById(id));
        }

        // PUT: api/Dependent/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetDependentDto>>>> UpdateDependent(UpdateDependentDto updateDependent)
         {

                return Ok(await _dependentService.UpdateDependent(updateDependent));
         }

        // POST: api/Dependent
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetDependentDto>>>> AddDependent(AddDependentDto newDependent)
         {
            var response = await _dependentService.AddDependent(newDependent);

                if (response.Data == null){
                    return NotFound(response);
                }
                return Ok(response);
         }

        // DELETE: api/Dependent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDependentDto>>> DeleteDependent(int id)
        {
           var response = await _dependentService.DeleteDependent(id);

                if (response.Data == null){
                    return NotFound(response);
                }
                return Ok(response);
        }

      
    }
}
