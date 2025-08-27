namespace InsuranceServicesHex.Proposal.Domain.Entities
{
    public enum ProposalStatus { UnderReview = 0, Approved = 1, Rejected = 2 }

    public class ProposalEntity
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public ProposalStatus Status { get; set; } = ProposalStatus.UnderReview;
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
