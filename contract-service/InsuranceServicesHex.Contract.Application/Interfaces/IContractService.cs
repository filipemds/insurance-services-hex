using InsuranceServicesHex.Contract.Domain.Entities;

namespace InsuranceServicesHex.Contract.Application.Services
{
    public interface IContractService
    {
        Task<ContractEntity?> CreateContractAsync(Guid proposalId);
        Task<IEnumerable<ContractEntity>> GetAllContractsAsync();
        Task<ContractEntity?> GetContractByIdAsync(Guid id);
    }
}
