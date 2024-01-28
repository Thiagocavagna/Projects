using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Projects.Base.Models.Result;

namespace Projects.Base.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        //TODO: implementar melhorias futuras para o tratamento de erros, no momento está só uma forma básica.
        protected IActionResult CreateResponse(Result result)
        {
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        protected IActionResult CreateResponse((Result Result, object Data) response)
        {
            if (response.Result.Success)
                return Ok(new CustomResponse(response.Result, response.Data));

            return BadRequest(new CustomResponse(response.Result, response.Data));
        }

        protected IActionResult CreateResponse(ModelStateDictionary modelState)
        {
            var result = new Result();

            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
                result.AddError(erro.ErrorMessage);

            return CreateResponse(result);
        }
    }
}
