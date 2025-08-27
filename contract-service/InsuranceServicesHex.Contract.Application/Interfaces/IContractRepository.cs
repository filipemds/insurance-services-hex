using InsuranceServicesHex.Contract.Domain.Entities;

namespace InsuranceServicesHex.Contract.Application.Interfaces
{
    public interface IContractRepository
    {
        Task<ContractEntity> AddAsync(ContractEntity contract, CancellationToken ct);
        Task<ContractEntity?> GetByProposalIdAsync(Guid proposalId, CancellationToken ct);
        Task<IReadOnlyList<ContractEntity>> ListAsync(CancellationToken ct);
    }
}
