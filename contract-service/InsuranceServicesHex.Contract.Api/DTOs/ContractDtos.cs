namespace InsuranceServicesHex.Contract.Api.DTOs
{
    public record ContractCreateDto(Guid ProposalId);
    public record ContractViewDto(Guid Id, Guid ProposalId, DateTime ContractDateUtc)
    {
        public static ContractViewDto From(InsuranceServicesHex.Contract.Domain.Entities.ContractEntity c) =>
            new(c.Id, c.ProposalId, c.ContractDate);
    }
}
