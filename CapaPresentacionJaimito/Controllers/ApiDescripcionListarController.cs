using System;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiDescripcion")]
    [ApiController]
    public class ApiDescripcionListarController : ControllerBase
    {

        private IApiDescripcionListarService _apiDescripcionListarService;

        public ApiDescripcionListarController(IApiDescripcionListarService ApiDescripcionListarService)
        {
            _apiDescripcionListarService = ApiDescripcionListarService;
        }
        [HttpPost]
        [Route("DescripcionListar")]
        public IActionResult Post()
        {
            try
            {
                var descripcionC = _apiDescripcionListarService.obtenerDescripcionListar();
                if (descripcionC == null)
                {
                    return BadRequest(new { message = "No existe correspondencias" });
                }
                return Ok(descripcionC);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }

    }
}
