using InsuranceServicesHex.Proposal.Application.Interfaces;
using InsuranceServicesHex.Proposal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceServicesHex.Proposal.Infrastructure;

public class ProposalRepository : IProposalRepository
{
    private readonly ProposalDbContext _db;

    public ProposalRepository(ProposalDbContext db)
    {
        _db = db;
    }

    public async Task<ProposalEntity> AddAsync(ProposalEntity proposal, CancellationToken ct)
    {
        _db.Proposals.Add(proposal);
        await _db.SaveChangesAsync(ct);
        return proposal;
    }

    public Task<ProposalEntity?> GetByIdAsync(Guid id, CancellationToken ct) =>
        _db.Proposals.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

    public Task<IReadOnlyList<ProposalEntity>> ListAsync(CancellationToken ct) =>
        _db.Proposals.AsNoTracking().OrderByDescending(p => p.CreatedAtUtc).ToListAsync(ct)
            .ContinueWith<IReadOnlyList<ProposalEntity>>(t => t.Result, ct);

    public async Task UpdateAsync(ProposalEntity proposal, CancellationToken ct)
    {
        _db.Proposals.Update(proposal);
        await _db.SaveChangesAsync(ct);
    }
}
