using AutoMapper;

namespace Capathon.Services.DependentService
{
    public class DependentService : IDependentService
    {

        private readonly IMapper _mapper;
        private readonly CapathonBroadwayContext _dataContext;
        

        public DependentService(IMapper mapper, CapathonBroadwayContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }


        public async Task<ServiceResponse<List<GetDependentDto>>> AddDependent(AddDependentDto newDependent)
        {
            var serviceResponse = new ServiceResponse<List<GetDependentDto>>();
            var dependent =_mapper.Map<Dependent>(newDependent);

            _dataContext.Dependents.Add(dependent);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Dependents.Select(d => _mapper.Map<GetDependentDto>(d)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDependentDto>>> DeleteDependent(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDependentDto>>();

            try{
            var dependent = await _dataContext.Dependents.FirstOrDefaultAsync(d => d.DId == id);
            if(dependent == null){
                throw new Exception($"Dependent with ID '{id}' not found.");
            }
            
             _dataContext.Dependents.Remove(dependent); 

            await _dataContext.SaveChangesAsync(); 

            serviceResponse.Data = await _dataContext.Dependents.Select(d => _mapper.Map<GetDependentDto>(d)).ToListAsync();; 

            }
            catch(Exception){
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDependentDto>>> GetAllDependents()
        {
            var serviceResponse = new ServiceResponse<List<GetDependentDto>>();
            var dbDependents = await _dataContext.Dependents.ToListAsync();
            serviceResponse.Data = dbDependents.Select(d => _mapper.Map<GetDependentDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDependentDto>> GetDependentById(int id)
        {

            var serviceResponse = new ServiceResponse<GetDependentDto>();
            var dbDependent = await _dataContext.Dependents.FirstOrDefaultAsync(d => d.DId == id);
            serviceResponse.Data = _mapper.Map<GetDependentDto>(dbDependent);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDependentDto>> UpdateDependent(UpdateDependentDto updatedDependent)
        {
            var serviceResponse = new ServiceResponse<GetDependentDto>();

            try{
            var dependent = await _dataContext.Dependents.FirstOrDefaultAsync(d => d.DId == updatedDependent.DId);
            if(dependent == null)
                throw new Exception($"Dependent with ID '{updatedDependent.DId}' not found.");

            dependent.UId = updatedDependent.DId;
            dependent.FirstName = updatedDependent.FirstName;
            dependent.LastName = updatedDependent.LastName;
            dependent.Age = updatedDependent.Age; 
            dependent.Gender = updatedDependent.Gender; 
            dependent.Accomodations = updatedDependent.Accomodations; 
            dependent.MedicalInfo = updatedDependent.MedicalInfo;


            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDependentDto>(dependent); 

            }
            catch(Exception){
                serviceResponse.Success = false;
            }
            return serviceResponse; 
        }
    }
}