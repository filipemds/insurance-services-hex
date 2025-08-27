namespace InsuranceServicesHex.Contract.Domain.Entities
{
    public class ContractEntity
    {
        public Guid Id { get; private set; }
        public Guid ProposalId { get; private set; }
        public DateTime ContractDate { get; private set; }

        protected ContractEntity() { } 

        public ContractEntity(Guid proposalId)
        {
            Id = Guid.NewGuid();
            ProposalId = proposalId;
            ContractDate = DateTime.UtcNow;
        }
    }
}
