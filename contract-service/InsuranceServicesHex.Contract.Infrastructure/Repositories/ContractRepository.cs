using InsuranceServicesHex.Contract.Application.Interfaces;
using InsuranceServicesHex.Contract.Domain.Entities;
using InsuranceServicesHex.Contract.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InsuranceServicesHex.Contract.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractDbContext _db;

        public ContractRepository(ContractDbContext db)
        {
            _db = db;
        }

        public async Task<ContractEntity> AddAsync(ContractEntity contract, CancellationToken ct)
        {
            _db.Contracts.Add(contract);
            await _db.SaveChangesAsync(ct);
            return contract;
        }

        public Task<ContractEntity?> GetByProposalIdAsync(Guid proposalId, CancellationToken ct) =>
            _db.Contracts.AsNoTracking().FirstOrDefaultAsync(c => c.ProposalId == proposalId, ct);

        public Task<IReadOnlyList<ContractEntity>> ListAsync(CancellationToken ct) =>
            _db.Contracts.AsNoTracking().ToListAsync(ct)
                .ContinueWith<IReadOnlyList<ContractEntity>>(t => t.Result, ct);
    }
}
