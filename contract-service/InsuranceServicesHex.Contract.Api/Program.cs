using InsuranceServicesHex.Contract.Api.DTOs;
using InsuranceServicesHex.Contract.Application.Interfaces;
using InsuranceServicesHex.Contract.Application.Services;
using InsuranceServicesHex.Contract.Domain;
using InsuranceServicesHex.Contract.Infrastructure;
using InsuranceServicesHex.Contract.Infrastructure.Context;
using InsuranceServicesHex.Contract.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContractDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContractRepository, InsuranceServicesHex.Contract.Infrastructure.Repositories.ContractRepository>();
builder.Services.AddScoped<InsuranceServicesHex.Contract.Application.Services.ContractRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Ensure DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContractDbContext>();
    db.Database.EnsureCreated();
}

// Endpoints
app.MapPost("/contracts", async (ContractCreateDto dto, InsuranceServicesHex.Contract.Application.Services.ContractRepository service, CancellationToken ct) =>
{
    try
    {
        var contract = await service.CreateContractAsync(dto.ProposalId, ct);
        return Results.Created($"/contracts/{contract.Id}", ContractViewDto.From(contract));
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/contracts", async (InsuranceServicesHex.Contract.Application.Services.ContractRepository service, CancellationToken ct) =>
{
    var contracts = await service.ListContractsAsync(ct);
    return Results.Ok(contracts.Select(ContractViewDto.From));
});

app.Run();
