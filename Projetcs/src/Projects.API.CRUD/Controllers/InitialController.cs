using Microsoft.AspNetCore.Mvc;
using Projects.API.CRUD.Models.Foods;
using Projects.API.CRUD.Services;
using Projects.Base.Controllers;

namespace Projects.API.CRUD.Controllers
{
    [Route("[controller]")]
    public class InitialController : BaseController
    {
        private readonly IFoodService _service;
        public InitialController(IFoodService service)
        {
            _service = service;
        }

        [HttpGet("status")]
        public Task<IActionResult> Get()
        {
            return Task.FromResult<IActionResult>(Ok("API CRUD"));
        }

        [HttpGet("food")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost("food")]
        public async Task<IActionResult> CreateAsync(FoodRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

             await _service.CreateAsync(request);

            return Ok();
        }
    }
}
