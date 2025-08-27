using Microsoft.AspNetCore.Mvc;
using InsuranceServicesHex.Contract.Application.Services;
using InsuranceServicesHex.Contract.Application.DTOs;

namespace InsuranceServicesHex.Contract.Api.Controllers
{
    [ApiController]
    [Route("contracts")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        /// <summary>
        /// Create a new contract for an approved proposal
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractDto dto)
        {
            var contract = await _contractService.CreateContractAsync(dto.ProposalId);
            if (contract == null)
                return BadRequest("Proposal not approved or does not exist.");

            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contract);
        }

        /// <summary>
        /// Get all contracts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }

        /// <summary>
        /// Get contract by Id
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contract = await _contractService.GetContractByIdAsync(id);
            if (contract == null) return NotFound();
            return Ok(contract);
        }
    }
}
