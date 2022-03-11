using System;
using CapaDatos.Request;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiDestinatario")]
    [ApiController]
    public class ApiDestinatarioListarController : ControllerBase
    {

        private IApiDestinatarioListarService _apiDestinatarioListarService;

        public ApiDestinatarioListarController(IApiDestinatarioListarService ApiDestinatarioListarService)
        {
            _apiDestinatarioListarService = ApiDestinatarioListarService;
        }

        [HttpPost]
        [Route("DestinatarioListar")]
        public IActionResult Post([FromBody]clsDestinatarioListarRequest model)
        {
            try
            {
                var destinatario = _apiDestinatarioListarService.obteneDestinatarioListar(model.usuCodigo);
                if (destinatario == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(destinatario);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }

    }
}
