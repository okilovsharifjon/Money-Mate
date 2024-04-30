using BusinessLayer;
using BusinessLayer.Services.Transaction;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService service, ILogger<TransactionController> logger)
        {
            _transactionService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto transaction)
        {
            int id = await _transactionService.CreateAsync(transaction);
            return Ok(id);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] JsonPatchDocument<TransactionDtoUpdate> patchDocument)
        {
            if (patchDocument is null)
            {
                return BadRequest();
            }

            TransactionDtoUpdate transactionDto = new TransactionDtoUpdate();
            patchDocument.ApplyTo(transactionDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _transactionService.UpdateAsync(id, transactionDto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            await _transactionService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _transactionService.DeleteAsync(id);
            return Ok();
        }
    }
}
