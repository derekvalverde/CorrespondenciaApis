using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CapaDatos.Request;
using CapaDatos.Response;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiLector")]
    [ApiController]
    public class ApiLectorCelularController : ControllerBase
    {

        private IApiLectorCelularService _apiLectorCelularService;

        public ApiLectorCelularController(IApiLectorCelularService ApiLectorCelularService)
        {
            _apiLectorCelularService = ApiLectorCelularService;
        }
        [HttpPost]
        [Route("LectorCelular")]
        public IActionResult Post([FromBody] clsLectorCelularRequest model)

        {
            try
            {
                var lectorCelular = _apiLectorCelularService.obtenerLectorCelular(model.LectorTipo, model.UsuCodigo, model.Codigo, model.Archivero);

                if (lectorCelular == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(lectorCelular);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsLectorCelularResponse lectorCelular = new clsLectorCelularResponse();
                lectorCelular.escaneado = false;
                return Ok(lectorCelular);
            }

        }
    }
}
