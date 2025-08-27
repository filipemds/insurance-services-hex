using InsuranceServicesHex.Contract.Domain.Entities;

namespace InsuranceServicesHex.Contract.Application.Services
{
    public class ContractService : IContractService
    {
        private static readonly List<ContractEntity> _contracts = new();

        public async Task<ContractEntity?> CreateContractAsync(Guid proposalId)
        {
            bool approved = true;

            if (!approved) return null;

            var contract = new ContractEntity(proposalId);
            _contracts.Add(contract);

            return await Task.FromResult(contract);
        }

        public async Task<IEnumerable<ContractEntity>> GetAllContractsAsync()
        {
            return await Task.FromResult(_contracts);
        }

        public async Task<ContractEntity?> GetContractByIdAsync(Guid id)
        {
            return await Task.FromResult(_contracts.FirstOrDefault(c => c.Id == id));
        }
    }
}
