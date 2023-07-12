using Capathon.Dtos.Dependent;

namespace Capathon.Services.DependentService
{
    public interface IDependentService
    {
         
        Task<ServiceResponse<List<GetDependentDto>>> GetAllDependents();

        Task<ServiceResponse<GetDependentDto>> GetDependentById(int id);

        Task<ServiceResponse<List<GetDependentDto>>> AddDependent(AddDependentDto newDependent);

        Task<ServiceResponse<GetDependentDto>> UpdateDependent(UpdateDependentDto updatedDependent);

        Task<ServiceResponse<List<GetDependentDto>>> DeleteDependent(int id);

    }
}