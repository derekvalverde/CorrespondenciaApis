using CapaDatos.Models;
using CapaDatos.Request;
using CapaDatos.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WebIntiApi.Models;

namespace CapaNegocio.Servicios
{
    public interface IApiMaterialVentaPromocionMesesService
    {
        List<clsMaterialVentaPromocionMesesAgenciaResponse> obtenerVentaPromocionGrupoMeses(string matCodigo);
    }
}
