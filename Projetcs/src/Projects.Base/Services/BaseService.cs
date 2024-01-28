using Microsoft.IdentityModel.Tokens;
using Projects.Base.Models.Result;
using System.ComponentModel.DataAnnotations;

namespace Projects.Base.Services
{
    public class BaseService
    {
        protected (Result result, T data) Ok<T>(T data) => (new Result(), data);
        protected Result Ok() => new Result();

        protected (Result result, T data) Failed<T>(Result result) => (result, default(T));
        protected (Result result, T data) Failed<T>(string message)
        {
            var result = new Result();
            result.AddError(message);

            return (result, default(T));
        }

        protected Result Failed(Result result) => result;
        protected Result Failed(string message)
        {
            var result = new Result();
            result.AddError(message);

            return result;
        }
    }
}
