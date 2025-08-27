using FluentAssertions;
using InsuranceServicesHex.Contract.Application.Services;
using InsuranceServicesHex.Contract.Domain.Entities;
using Moq;

namespace InsuranceServicesHex.Contract.Tests;

public class ContractServiceTests
{
    [Fact]
    public async Task CreateContract_ShouldReturnContract_WhenProposalNotExists()
    {
        var mockRepo = new Mock<Application.Interfaces.IContractRepository>();
        mockRepo.Setup(r => r.GetByProposalIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ContractEntity?)null);
        mockRepo.Setup(r => r.AddAsync(It.IsAny<ContractEntity>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ContractEntity c, CancellationToken _) => c);

        var service = new ContractRepository(mockRepo.Object);

        var result = await service.CreateContractAsync(Guid.NewGuid(), CancellationToken.None);
        result.Should().NotBeNull();
    }
}
