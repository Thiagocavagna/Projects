using Microsoft.AspNetCore.Mvc;
using Projects.Foods.API.Models.Foods;
using Projects.Foods.API.Services;
using Projects.Base.Controllers;

namespace Projects.Foods.API.Controllers
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
            return CreateResponse(await _service.GetAllAsync());
        }

        [HttpPost("food")]
        public async Task<IActionResult> CreateAsync(FoodRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreateResponse(await _service.CreateAsync(request));
        }
    }
}
