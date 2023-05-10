using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> customResponse)
        {
            if(customResponse.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = customResponse.StatusCode
                };

                return new ObjectResult(customResponse)
                {
                    StatusCode = customResponse.StatusCode
                };
            
        }

    }
}
