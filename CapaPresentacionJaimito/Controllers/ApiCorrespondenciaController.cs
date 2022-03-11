using System;
using CapaDatos.Request;
using CapaDatos.Response;
using CapaNegocio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CapaPresentacionJaimito.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("ApiCorrespondencia")]
    [ApiController]
    public class ApiCorrespondenciaController : ControllerBase
    {
        private IApiCorrespondenciaListarService _apiCorrespondenciaListarService;
        private IApiCorrespondenciaListarPaginadoService _apiCorrespondenciaListarPaginadoService;
        private IApiCorrespondenciaCantidadRegistrosService _apiCorrespondenciaCantidadRegistrosService;
        private IApiCorrespondenciaDetalleCantidadRegistrosService _apiCorrespondenciaDetalleCantidadRegistrosService;
        private IApiCorrespondenciaDetalleListarPaginadoService _apiCorrespondenciaDetalleListarPaginadoService;
        private IApiCorrespondenciaDetalleListarService _apiDivisionListarService;
        private IApiCorrespondenciaDetalleBusquedaService _apiDivisionBusquedaService;
        private IApiCorrespondenciaDetalleInformaciónService _apiDivisionInformacionService;
        private IApiCorrespondenciaDetalleListarCelularService _apiDivisionListarCelularService;

        private IApiCorrespondenciaDetalleInformacionCelularService _apiCorrespondenciaDetalleInformacionCelularService;
        private IApiCorrespondenciaRegistrarService _apiCorrespondenciaRegistrarService;
        private IApiCorrespondenciaDetalleRegistrarService _apiDivisionRegistrarService;
        private IApiCorrespondenciaDetalleDividirService _apiCorrespondenciaDetalleDividirService;
        private IApiCorrespondenciaEliminarService _apiCorrespondenciaEliminarService;
        private IApiCorrespondenciaBusquedaService _apiCorrespondenciaBusquedaService;

        public ApiCorrespondenciaController(
            IApiCorrespondenciaListarService ApiCorrespondenciaListarService,
            IApiCorrespondenciaListarPaginadoService ApiCorrespondenciaListarPaginadoService,
            IApiCorrespondenciaCantidadRegistrosService ApiCorrespondenciaCantidadRegistrosService,
             IApiCorrespondenciaDetalleListarPaginadoService ApiCorrespondenciaDetalleListarPaginadoService,
            IApiCorrespondenciaDetalleCantidadRegistrosService ApiCorrespondenciaDetalleCantidadRegistrosService,
            IApiCorrespondenciaDetalleListarService ApiDivisionListarService,
            IApiCorrespondenciaDetalleBusquedaService ApiDivisionBusquedaService,
            IApiCorrespondenciaDetalleInformaciónService ApiDivisionInformacionService,
            IApiCorrespondenciaDetalleListarCelularService ApiDivisionListarCelularService,
            IApiCorrespondenciaRegistrarService ApiCorrespondenciaRegistrarService,
            IApiCorrespondenciaDetalleRegistrarService ApiDivisionRegistrarService,
            IApiCorrespondenciaDetalleDividirService ApiCorrespondenciaDetalleDividirService,
            IApiCorrespondenciaDetalleInformacionCelularService ApiCorrespondenciaDetalleInformacionCelularService,
            IApiCorrespondenciaEliminarService ApiCorrespondenciaEliminarService,
            IApiCorrespondenciaBusquedaService ApiCorrespondenciaBusquedaService
            )
        {
            _apiCorrespondenciaListarService = ApiCorrespondenciaListarService;
            _apiCorrespondenciaListarPaginadoService = ApiCorrespondenciaListarPaginadoService;
            _apiCorrespondenciaCantidadRegistrosService = ApiCorrespondenciaCantidadRegistrosService;
            _apiCorrespondenciaDetalleListarPaginadoService = ApiCorrespondenciaDetalleListarPaginadoService;
            _apiCorrespondenciaDetalleCantidadRegistrosService = ApiCorrespondenciaDetalleCantidadRegistrosService;
            _apiDivisionListarService = ApiDivisionListarService;
            _apiDivisionBusquedaService = ApiDivisionBusquedaService;
            _apiDivisionInformacionService = ApiDivisionInformacionService;
            _apiDivisionListarCelularService = ApiDivisionListarCelularService;
            _apiCorrespondenciaRegistrarService = ApiCorrespondenciaRegistrarService;
            _apiDivisionRegistrarService = ApiDivisionRegistrarService;
            _apiCorrespondenciaDetalleDividirService = ApiCorrespondenciaDetalleDividirService;
            _apiCorrespondenciaEliminarService = ApiCorrespondenciaEliminarService;
            _apiCorrespondenciaDetalleInformacionCelularService = ApiCorrespondenciaDetalleInformacionCelularService;
            _apiCorrespondenciaBusquedaService = ApiCorrespondenciaBusquedaService;
        }

        [HttpPost]
        [Route("CorrespondenciaListar")]
        public IActionResult Post([FromBody] clsCorrespondenciaListarRequest model)
        {
            try
            {
                var correspondencia = _apiCorrespondenciaListarService.obteneCorrespondenciaListar(model.UsuCodigo);
                if (correspondencia == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondencia);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }

        [HttpPost]
        [Route("CorrespondenciaListarPaginado")]
        public IActionResult Post([FromBody] clsCorrespondenciaListarPaginadoRequest model)
        {
            try
            {
                var correspondencia = _apiCorrespondenciaListarPaginadoService.obteneCorrespondenciaListarPaginado(model.UsuCodigo, model.corNumPag, model.corCantReg);
                if (correspondencia == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondencia);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }
        [HttpPost]
        [Route("CorrespondenciaCantidadRegistros")]
        public IActionResult Post([FromBody] clsCorrespondenciaCantidadRegistrosRequest model)
        {
            try
            { 
                var correspondencia = _apiCorrespondenciaCantidadRegistrosService.obteneCorrespondenciaCantidadRegistros(model.UsuCodigo);
                if (correspondencia == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondencia);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }

        [HttpPost]
        [Route("CorrespondenciaDetalleListarPaginado")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleListarPaginadoRequest model)
        {
            try
            {
                var correspondenciaDetalle = _apiCorrespondenciaDetalleListarPaginadoService.obteneCorrespondenciaDetalleListarPaginado(model.UsuCodigo, model.cdeNumPag, model.cdeCantReg);
                if (correspondenciaDetalle == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondenciaDetalle);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }

        [HttpPost]
        [Route("CorrespondenciaDetalleCantidadRegistros")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleCantidadRegistrosRequest model)
        {
            try
            {
                var correspondenciaDetalle = _apiCorrespondenciaDetalleCantidadRegistrosService.obtenerCorrespondenciaDetalleCantidadRegistros(model.UsuCodigo);
                if (correspondenciaDetalle == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondenciaDetalle);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }

        }
        [HttpPost]
        [Route("CorrespondenciaDetalleListar")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleListarRequest model)
        {
            try
            {
                var correspondencia = _apiDivisionListarService.obtenerCorrespondenciaDetalleListar(model.usuCodigo);
                if (correspondencia == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(correspondencia);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }
        [HttpPost]
        [Route("CorrespondenciaDetalleBusqueda")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleBusquedaRequest model)
        {
            try
            {
                var busqueda = _apiDivisionBusquedaService.obtenerCorrespondenciaDetalleBusqueda(model.UsuCodigo, model.codigo, model.detalle, model.remitente, model.fechaIni, model.fechaFin);
                if (busqueda == null)
                {
                    return BadRequest(new { message = "No existe busqueda" });
                }
                return Ok(busqueda);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }
        [HttpPost]
        [Route("CorrespondenciaDetalleInformacion")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleInformaciónRequest model)
        {
            try
            {
                var informacion = _apiDivisionInformacionService.obteneCorrespondenciaDetalleInformacion(model.cdeId);
                if (informacion == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(informacion);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }
        [HttpPost]
        [Route("CorrespondenciaDetalleInformacionCelular")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleInformacionCelularRequest model)
        {
            try
            {
                var informacion = _apiCorrespondenciaDetalleInformacionCelularService.obtenerCorrespondenciaDetalleInformacionCelular(model.CdeId);
                if (informacion == null)
                {
                    return BadRequest(new { message = "No existe informacion" });
                }
                return Ok(informacion);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }
        [HttpPost]
        [Route("CorrespondenciaRegistrar")]
        public IActionResult Post([FromBody] clsCorrespondenciaRegistrarRequest model)

        {
            try
            {
                var correspondencia = _apiCorrespondenciaRegistrarService.registrarCorrespondencia(model.UsuCodigo, model.CorCodigo, model.CorNumGuia, model.CodId, model.AreId, model.CorRemitente, model.CorUrgente);

                if (correspondencia == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(correspondencia);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsCorrespondenciaRegistrarResponse corespondencia = new clsCorrespondenciaRegistrarResponse();
                corespondencia.registrado = false;
                return Ok(corespondencia);
            }
        }
        [HttpPost]
        [Route("CorrespondenciaDetalleRegistrar")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleRegistrarRequest model)
        {
            try
            {
                var correspondencia = _apiDivisionRegistrarService.registrarCorrespondenciaDetalle(model.usuCodigo, model.corId, model.cdeCodigo, model.usuFinalId, model.cdeDetalle, model.cdeUrgente);

                if (correspondencia == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(correspondencia);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsCorrespondenciaDetalleRegistrarResponse corespondencia = new clsCorrespondenciaDetalleRegistrarResponse();
                corespondencia.divisionRegistrada = false;
                return Ok(corespondencia);
            }
        }

        [HttpPost]
        [Route("CorrespondenciaDetalleDividir")]
        public IActionResult Post([FromBody] clsCorrespondenciaDetalleDividirRequest model)

        {
            try
            {
                var correspondencia = _apiCorrespondenciaDetalleDividirService.obtenerCorrespondenciaDetalleDividir(model.usuCodigo, model.corId, model.cdeCodigo, model.usuFinalId, model.cdeDetalle, model.cdeUrgente);

                if (correspondencia == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(correspondencia);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsCorrespondenciaDetalleDividirResponse corespondencia = new clsCorrespondenciaDetalleDividirResponse();
                corespondencia.divisionRegistrada = false;
                return Ok(corespondencia);
            }
        }

        [HttpPost]
        [Route("CorrespondenciaEliminar")]
        public IActionResult Post([FromBody] clsCorrespondenciaEliminarRequest model)

        {
            try
            {
                var correspondencia = _apiCorrespondenciaEliminarService.eliminarCorrespondencia(model.usuCodigo, model.idCorrespondencia, model.opcion);

                if (correspondencia == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(correspondencia);

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                clsCorrespondenciaEliminarResponse corespondencia = new clsCorrespondenciaEliminarResponse();
                corespondencia.correspondenciaElimimnada = false;
                return Ok(corespondencia);
            }

        }

        [HttpPost]
        [Route("CorrespondenciaBusqueda")]
        public IActionResult Post([FromBody] clsCorrespondenciaBusquedaRequest model)

        {
            try
            {
                var correspondencia = _apiCorrespondenciaBusquedaService.obtenerCorrespondenciaBusqueda(model.UsuCodigo, model.corCodigo, model.corRemitente, model.arecodigo, model.fechaIni, model.fechaFin);

                if (correspondencia == null)
                {
                    return BadRequest(new { message = "Error" });
                }
                return Ok(correspondencia);

            }
            catch (Exception e)
            {
              
                Console.WriteLine("{0} Exception caught.", e);
                return BadRequest(new { message = "Error al ejecutar Procedimiento Almacenado" });
            }
        }

        

    }
}
