using Common.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Common.Controllers
{
    public class MyColabApiProjectControllerBase : ControllerBase
    {
        public IActionResult GetActionResult<T>(Result<T> result)
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(result.Value);
                case HttpStatusCode.BadRequest:
                    return BadRequest(result.ErrorMessage);
                case HttpStatusCode.Unauthorized:
                    return Unauthorized();
                case HttpStatusCode.NotFound:
                    return NotFound(result.ErrorMessage);
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
        }
    }
}
