namespace InsuranceServicesHex.Proposal.Application.DTOs
{
    public class CreateProposalDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public decimal Premium { get; set; }
    }
}
