using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capathon.Dtos.CareCenter;

namespace Capathon.Services
{
    public interface ICareCenterService
    {
        Task<ServiceResponse<List<GetCareCenterDto>>> GetAllCareCenters();
        Task<ServiceResponse<GetCareCenterDto>> GetCareCenterById(int id);
        Task<ServiceResponse<List<GetCareCenterDto>>> AddCareCenter(AddCareCenterDto newCareCenter);
        Task<ServiceResponse<GetCareCenterDto>> UpdateCareCenter(UpdateCareCenterDto updatedCareCenter);
        Task<ServiceResponse<List<GetCareCenterDto>>> DeleteCareCenter(int id);
    }
}