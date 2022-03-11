using System;
using CapaDatos.Request;
using CapaDatos.Response;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Route("ApiUsuario")]
    [ApiController]
    public class ApiUsuarioLoginGeneralController : ControllerBase
    {
        private IApiUsuarioLoginGeneralService _authenticateService;
        private IApiUsuarioMensajeRegistrarTokenService _apiUsuarioMensajeRegistrarTokenService;

        public ApiUsuarioLoginGeneralController(
            IApiUsuarioLoginGeneralService authenticateService,
            IApiUsuarioMensajeRegistrarTokenService ApiUsuarioMensajeRegistrarTokenService
            )
        {
            _authenticateService = authenticateService;
            _apiUsuarioMensajeRegistrarTokenService = ApiUsuarioMensajeRegistrarTokenService;

        }

        [HttpPost]
        [Route("UsuarioLoginGeneral")]
        public IActionResult Post([FromBody] clsUsuarioLoginGeneralRequest model)
        {
            try
            {
                var user = _authenticateService.Authenticate2(model.usuLogin, model.usuPassword, model.grpId);
                if (user == null)
                {
                    return BadRequest(new { message = "Usuario o password es incorrecto" });
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }


        [HttpPost]
        [Route("UsuarioMensajeRegistrarToken")]
        public IActionResult Post([FromBody] clsUsuarioMensajeRegistrarTokenRequest model)

        {
            try
            {
                var token = _apiUsuarioMensajeRegistrarTokenService.registrarToken(model.UsuCodigo, model.UsuToken);

                if (token == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(token);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsUsuarioMensajeRegistrarTokenResponse token = new clsUsuarioMensajeRegistrarTokenResponse();
                token.tokenRegistrado = false;
                return Ok(token);
            }

        }

    }
}
