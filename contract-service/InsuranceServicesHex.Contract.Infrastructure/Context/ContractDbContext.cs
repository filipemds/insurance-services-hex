using InsuranceServicesHex.Contract.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceServicesHex.Contract.Infrastructure.Context
{
    public class ContractDbContext : DbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext> options) : base(options) { }

        public DbSet<ContractEntity> Contracts => Set<ContractEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<ContractEntity>();
            e.ToTable("contracts");
            e.HasKey(x => x.Id);
            e.Property(x => x.ProposalId).IsRequired();
            e.Property(x => x.ContractDate).IsRequired();
            e.HasIndex(x => x.ProposalId).IsUnique();
        }
    }
}
