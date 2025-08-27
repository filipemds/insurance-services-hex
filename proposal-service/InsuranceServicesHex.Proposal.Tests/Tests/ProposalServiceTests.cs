using FluentAssertions;
using InsuranceServicesHex.Proposal.Application.Services;
using InsuranceServicesHex.Proposal.Domain.Entities;
using Moq;

namespace InsuranceServicesHex.Proposal.Tests;

public class ProposalServiceTests
{
    [Fact]
    public async Task CreateProposal_ShouldReturnProposal_WhenValid()
    {
        var mockRepo = new Mock<InsuranceServicesHex.Proposal.Application.Interfaces.IProposalRepository>();
        mockRepo.Setup(r => r.AddAsync(It.IsAny<ProposalEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ProposalEntity p, CancellationToken _) => p);

        var service = new ProposalService(mockRepo.Object);

        var result = await service.CreateProposalAsync("Ana", "11122233344", 200, CancellationToken.None);
        result.Should().NotBeNull();
        result.ClientName.Should().Be("Ana");
    }
}
