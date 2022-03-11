using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CapaDatos.Request;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiArchivero")]
    
    [ApiController]
    public class ApiArchiveroController : ControllerBase
    {

        private IApiArchiveroListarService _apiArchiveroListarService;
        private IApiArchiveroAgregarService _apiArchiveroAgregarService;
        private IApiArchiveroCantidadRegistrosService _apiArchiveroCantidadRegistrosService;
        private IApiArchiveroListarPaginadoService _apiArchiveroListarPaginadoService;

        public ApiArchiveroController(
            IApiArchiveroListarService ApiArchiveroListarService,
            IApiArchiveroAgregarService ApiArchiveroAgregarService,
            IApiArchiveroCantidadRegistrosService ApiArchiveroCantidadRegistrosService,
            IApiArchiveroListarPaginadoService ApiArchiveroListarPaginadoService
            )
        {
            _apiArchiveroListarService = ApiArchiveroListarService;
            _apiArchiveroAgregarService = ApiArchiveroAgregarService;
            _apiArchiveroCantidadRegistrosService = ApiArchiveroCantidadRegistrosService;
            _apiArchiveroListarPaginadoService = ApiArchiveroListarPaginadoService;
        }

        [HttpPost]
        [Route("ArchiveroListar")]
        public IActionResult Post([FromBody] clsArchiveroListarRequest model)
        {
            try
            {
                var usuarios = _apiArchiveroListarService.obteneArchiveroListar(model.UsuCodigo);
                if (usuarios == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }

        [HttpPost]
        [Route("ArchiveroAgregar")]
        public IActionResult Post([FromBody] clsArchiveroAgregarRequest model)
        {
            try
            {
                var archiveroAgregar = _apiArchiveroAgregarService.obteneArchiveroAgregar(model.UsuCodigo, model.Codigo, model.Nombre, model.Descripcion, model.AreId);
                if (archiveroAgregar == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(archiveroAgregar);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }

        [HttpPost]
        [Route("ArchiveroCantidadRegistros")]
        public IActionResult Post([FromBody] clsArchiveroCantidadRegistrosRequest model)
        {
            try
            {
                var usuarios = _apiArchiveroCantidadRegistrosService.obtenerArchiveroCantidadRegistros(model.UsuCodigo);
                if (usuarios == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }

        [HttpPost]
        [Route("ArchiveroListarPaginado")]
        public IActionResult Post([FromBody] clsArchiveroListarPaginadoRequest model)
        {
            try
            {
                var archivero = _apiArchiveroListarPaginadoService.obtenerArchiveroListarPaginado(model.UsuCodigo, model.arcNumPag, model.arcCantReg);
                if (archivero == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(archivero);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }
    }
}
