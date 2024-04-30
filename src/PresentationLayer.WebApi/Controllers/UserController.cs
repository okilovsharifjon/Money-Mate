using BusinessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _userService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            int id = await _userService.CreateAsync(user);
            return Ok(id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<UserDtoUpdate> patchDocument)
        {
            if (patchDocument is null)
            {
                return BadRequest();
            }

            var userDto = await _userService.GetByIdAsyncForUpdate(id);
            patchDocument.ApplyTo(userDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userService.UpdateAsync(id, userDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            return Ok(await _userService.GetByNameAsync(name));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
/*
 * [
  { "op": "replace", "path": "/Name", "value": "Новое имя" }
]

{
  "operations" : 
                 { 
                 "op": "replace", 
                 "path": "/fullname",  
                 "value": "Новое имя" 
                 }
}
*/