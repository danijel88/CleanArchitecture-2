using System.Threading.Tasks;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateRequestModel request)
        {
            IValidationResult validResult = await _service.Validate(request);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            TodoResponseModel result = await _service.Create(request);

            return Ok(result);
        }
    }
}