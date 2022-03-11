using System;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiArea")]
    [ApiController]
    public class ApiAreaDestinoListarController : ControllerBase
    {
        private IApiAreaDestinoListarService _apiAreaDestinoListarService;

        public ApiAreaDestinoListarController(IApiAreaDestinoListarService ApiAreaDestinoListarService)
        {
            _apiAreaDestinoListarService = ApiAreaDestinoListarService;
        }
        [HttpPost]
        [Route("AreaDestinoListar")]
        public IActionResult Post()
        {
            try
            {
                var destinoC = _apiAreaDestinoListarService.obtenerAreaDestinoListar();
                if (destinoC == null)
                {
                    return BadRequest(new { message = "No existe correspondencias" });
                }
                return Ok(destinoC);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }



    }
}
