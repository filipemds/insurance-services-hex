using InsuranceServicesHex.Contract.Application.Interfaces;
using InsuranceServicesHex.Contract.Domain.Entities;

namespace InsuranceServicesHex.Contract.Application.Services
{
    public class ContractRepository
    {
        private readonly IContractRepository _repository;

        public ContractRepository(IContractRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContractEntity> CreateContractAsync(Guid proposalId, CancellationToken ct)
        {
            var existing = await _repository.GetByProposalIdAsync(proposalId, ct);
            if (existing != null) throw new Exception("Contract already exists for this proposal");

            var contract = new ContractEntity
            {
                Id = Guid.NewGuid(),
                ProposalId = proposalId,
                ContractDate = DateTime.UtcNow
            };

            return await _repository.AddAsync(contract, ct);
        }

        public Task<IReadOnlyList<ContractEntity>> ListContractsAsync(CancellationToken ct) =>
            _repository.ListAsync(ct);
    }
}
