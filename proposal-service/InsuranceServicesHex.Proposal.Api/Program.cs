using InsuranceServicesHex.Proposal.Application.Interfaces;
using InsuranceServicesHex.Proposal.Application.Services;
using InsuranceServicesHex.Proposal.DTOs;
using InsuranceServicesHex.Proposal.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProposalDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
builder.Services.AddScoped<ProposalService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Ensure DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProposalDbContext>();
    db.Database.EnsureCreated();
}

// Endpoints
app.MapPost("/proposals", async (ProposalCreateDto dto, ProposalService service, CancellationToken ct) =>
{
    var proposal = await service.CreateProposalAsync(dto.ClientName, dto.Document, dto.Premium, ct);
    return Results.Created($"/proposals/{proposal.Id}", ProposalViewDto.From(proposal));
});

app.MapGet("/proposals", async (ProposalService service, CancellationToken ct) =>
{
    var list = await service.ListProposalsAsync(ct);
    return Results.Ok(list.Select(ProposalViewDto.From));
});

app.MapGet("/proposals/{id:guid}", async (Guid id, ProposalService service, CancellationToken ct) =>
{
    var p = await service.GetProposalByIdAsync(id, ct);
    return p is null ? Results.NotFound() : Results.Ok(ProposalViewDto.From(p));
});

app.MapPatch("/proposals/{id:guid}/status", async (Guid id, ProposalStatusUpdateDto dto, ProposalService service, CancellationToken ct) =>
{
    try
    {
        await service.UpdateProposalStatusAsync(id, dto.Status, ct);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();
