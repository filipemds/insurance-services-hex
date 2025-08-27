using Microsoft.AspNetCore.Mvc;
using InsuranceServicesHex.Proposal.Application.Services;
using InsuranceServicesHex.Proposal.Application.DTOs;

namespace InsuranceServicesHex.Proposal.Api.Controllers
{
    [ApiController]
    [Route("proposals")]
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalService _proposalService;

        public ProposalsController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        /// <summary>
        /// Create a new proposal
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProposalDto dto)
        {
            var proposal = await _proposalService.CreateProposalAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = proposal.Id }, proposal);
        }

        /// <summary>
        /// Get all proposals
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proposals = await _proposalService.GetAllProposalsAsync();
            return Ok(proposals);
        }

        /// <summary>
        /// Get proposal by Id
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var proposal = await _proposalService.GetProposalByIdAsync(id);
            if (proposal == null) return NotFound();
            return Ok(proposal);
        }

        /// <summary>
        /// Update proposal status
        /// </summary>
        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateProposalStatusDto dto)
        {
            var updated = await _proposalService.UpdateStatusAsync(id, dto.Status);
            if (!updated) return BadRequest("Proposal not found or invalid status.");
            return NoContent();
        }
    }
}
