using InsuranceServicesHex.Proposal.Application.Interfaces;
using InsuranceServicesHex.Proposal.Domain;
using InsuranceServicesHex.Proposal.Domain.Entities;

namespace InsuranceServicesHex.Proposal.Application.Services;

public class ProposalService
{
    private readonly IProposalRepository _repository;

    public ProposalService(IProposalRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProposalEntity> CreateProposalAsync(string clientName, string document, decimal premium, CancellationToken ct)
    {
        if (premium <= 0) throw new ArgumentException("Premium must be greater than 0");

        var proposal = new ProposalEntity
        {
            Id = Guid.NewGuid(),
            ClientName = clientName,
            Document = document,
            Premium = premium
        };

        return await _repository.AddAsync(proposal, ct);
    }

    public Task<IReadOnlyList<ProposalEntity>> ListProposalsAsync(CancellationToken ct) =>
        _repository.ListAsync(ct);

    public async Task<ProposalEntity?> GetProposalByIdAsync(Guid id, CancellationToken ct) =>
        await _repository.GetByIdAsync(id, ct);

    public async Task UpdateProposalStatusAsync(Guid id, ProposalStatus status, CancellationToken ct)
    {
        var proposal = await _repository.GetByIdAsync(id, ct) ?? throw new Exception("Proposal not found");
        proposal.Status = status;
        await _repository.UpdateAsync(proposal, ct);
    }
}
