using BusinessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService service, ILogger<AccountController> logger)
        {
            _accountService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountDto accountDto)
        {
            int id = await _accountService.CreateAsync(accountDto);
            return Ok(id);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] JsonPatchDocument<AccountDtoUpdate> patchDocument)
        {
            if(patchDocument is  null)
            {
                return BadRequest();
            }

            var accountDto = await _accountService.GetByIdAsyncForUpdate(id);
            patchDocument.ApplyTo(accountDto, ModelState);
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _accountService.UpdateAsync(id, accountDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
            => Ok(await _accountService.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name) 
            => Ok(await _accountService.GetByNameAsync(name));
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _accountService.DeleteAsync(id);
            return Ok();
        }
    }
}
