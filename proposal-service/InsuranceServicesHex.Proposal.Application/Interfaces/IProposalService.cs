using InsuranceServicesHex.Proposal.Application.DTOs;
using InsuranceServicesHex.Proposal.Domain.Entities;

namespace InsuranceServicesHex.Proposal.Application.Services
{
    public interface IProposalService
    {
        Task<ProposalEntity> CreateProposalAsync(CreateProposalDto dto);
        Task<IEnumerable<ProposalEntity>> GetAllProposalsAsync();
        Task<ProposalEntity?> GetProposalByIdAsync(Guid id);
        Task<bool> UpdateStatusAsync(Guid id, string status);
    }
}
