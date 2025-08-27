using InsuranceServicesHex.Proposal.Domain;
using InsuranceServicesHex.Proposal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InsuranceServicesHex.Proposal.Infrastructure;

public class ProposalDbContext : DbContext
{
    public ProposalDbContext(DbContextOptions<ProposalDbContext> options) : base(options) { }

    public DbSet<ProposalEntity> Proposals => Set<ProposalEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var e = modelBuilder.Entity<ProposalEntity>();
        e.ToTable("proposals");
        e.HasKey(p => p.Id);
        e.Property(p => p.ClientName).IsRequired().HasMaxLength(200);
        e.Property(p => p.Document).HasMaxLength(50);
        e.Property(p => p.Premium).HasColumnType("numeric(18,2)");
        e.Property(p => p.Status).IsRequired();
        e.Property(p => p.CreatedAtUtc).IsRequired();
    }
}
