using BusinessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApi
{
    [ApiController]
    [Route("goal")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly ILogger<GoalController> _logger;

        public GoalController(IGoalService service, ILogger<GoalController> logger)
        {
            _goalService = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GoalDto goal)
        {
            int id = await _goalService.CreateAsync(goal);
            return Ok(id);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] JsonPatchDocument<GoalDtoUpdate> patchDocument)
        {
            if (patchDocument is null)
            {
                return BadRequest();
            }

            var goalDto = await _goalService.GetByIdAsyncForUpdate(id);
            patchDocument.ApplyTo(goalDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _goalService.UpdateAsync(id, goalDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
            => Ok(await _goalService.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
            => Ok(await _goalService.GetByNameAsync(name));
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _goalService.DeleteAsync(id);
            return Ok();
        }
    }
}
