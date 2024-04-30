using BusinessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("user_settings")]
    public class UserSettingsController : ControllerBase
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly ILogger<UserSettingsController> _logger;

        public UserSettingsController(IUserSettingsService service, ILogger<UserSettingsController> logger)
        {
            _userSettingsService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserSettingsDto userSettings)
        {
            int id = await _userSettingsService.CreateAsync(userSettings);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserSettingsDto userSettings)
        {
            await _userSettingsService.UpdateAsync(id, userSettings);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            await _userSettingsService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userSettingsService.DeleteAsync(id);
            return Ok();
        }
    }
}
