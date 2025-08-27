using InsuranceServicesHex.Proposal.Domain.Entities;

namespace InsuranceServicesHex.Proposal.DTOs;

public record ProposalCreateDto(string ClientName, string Document, decimal Premium);
public record ProposalViewDto(Guid Id, string ClientName, string Document, decimal Premium, ProposalStatus Status, DateTime CreatedAtUtc)
{
    public static ProposalViewDto From(ProposalEntity p) =>
        new(p.Id, p.ClientName, p.Document, p.Premium, p.Status, p.CreatedAtUtc);
}
public record ProposalStatusUpdateDto(ProposalStatus Status);
