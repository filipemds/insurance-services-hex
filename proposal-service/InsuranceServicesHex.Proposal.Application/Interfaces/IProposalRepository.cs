using InsuranceServicesHex.Proposal.Domain;
using InsuranceServicesHex.Proposal.Domain.Entities;

namespace InsuranceServicesHex.Proposal.Application.Interfaces;

public interface IProposalRepository
{
    Task<ProposalEntity> AddAsync(ProposalEntity proposal, CancellationToken ct);
    Task<ProposalEntity?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IReadOnlyList<ProposalEntity>> ListAsync(CancellationToken ct);
    Task UpdateAsync(ProposalEntity proposal, CancellationToken ct);
}
