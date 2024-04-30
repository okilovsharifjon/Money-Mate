using BusinessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("transaction_category")]
    public class TransactionCategoryController : ControllerBase
    {
        private readonly ITransactionCategoryService _transactionCategoryService;
        private readonly ILogger<TransactionCategoryController> _logger;

        public TransactionCategoryController(ITransactionCategoryService service, ILogger<TransactionCategoryController> logger)
        {
            _transactionCategoryService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCategoryDto transactionCategory)
        {
            int id = await _transactionCategoryService.CreateAsync(transactionCategory);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TransactionCategoryDto transactionCategoryDto)
        {
            await _transactionCategoryService.UpdateAsync(id, transactionCategoryDto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            await _transactionCategoryService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _transactionCategoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
