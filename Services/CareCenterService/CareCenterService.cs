using AutoMapper;
using Capathon.Dtos.CareCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capathon.Services
{
    public class CareCenterService : ICareCenterService
    {
        private static List<CareCenter> careCenters = new List<CareCenter>{
            new CareCenter { CId = 1, IsCorp = true, Address = "789 Blvd",
                            PhoneNumber = "987564321", Type = "n/a"
             }
        };

        private readonly IMapper _mapper;
        private readonly CapathonBroadwayContext _dataContext;
        
        public CareCenterService(IMapper mapper, CapathonBroadwayContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        
        public async Task<ServiceResponse<List<GetCareCenterDto>>> GetAllCareCenters()
        {
            var serviceResponse = new ServiceResponse<List<GetCareCenterDto>>();
            var dbCareCenters = await _dataContext.CareCenters.ToListAsync();
            serviceResponse.Data = dbCareCenters.Select(d => _mapper.Map<GetCareCenterDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCareCenterDto>> GetCareCenterById(int id)
        {

            var serviceResponse = new ServiceResponse<GetCareCenterDto>();
            var careCenter = _dataContext.CareCenters.FirstOrDefaultAsync(i => i.CId == id);
            serviceResponse.Data = _mapper.Map<GetCareCenterDto>(careCenter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCareCenterDto>>> AddCareCenter(AddCareCenterDto newCareCenter)
        {
            var serviceResponse = new ServiceResponse<List<GetCareCenterDto>>();
            var careCenter = _mapper.Map<CareCenter>(newCareCenter);

            _dataContext.CareCenters.Add(careCenter);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = 
                await _dataContext.CareCenters.Select(c => _mapper.Map<GetCareCenterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCareCenterDto>> UpdateCareCenter(UpdateCareCenterDto updatedCareCenter)
        {
            var serviceResponse = new ServiceResponse<GetCareCenterDto>();

            try
            {
                var careCenter = 
                    await _dataContext.CareCenters.FirstOrDefaultAsync(c => c.CId == updatedCareCenter.CId);
                if (careCenter == null)
                    throw new Exception($"Care Center with Id {updatedCareCenter.CId} not found.");
                
                careCenter.Address = updatedCareCenter.Address;
                careCenter.PhoneNumber = updatedCareCenter.PhoneNumber;
                careCenter.IsCorp = updatedCareCenter.IsCorp;
                careCenter.Type = updatedCareCenter.Type;

                serviceResponse.Data = _mapper.Map<GetCareCenterDto>(careCenter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCareCenterDto>>> DeleteCareCenter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCareCenterDto>>();

            try
            {
                var careCenter = await _dataContext.CareCenters.FirstOrDefaultAsync(c => c.CId == id);
                if (careCenter == null)
                    throw new Exception($"CareCenter with Id {id} not found.");

                _dataContext.CareCenters.Remove(careCenter);

                serviceResponse.Data = await _dataContext.CareCenters.Select(c => _mapper.Map<GetCareCenterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}