using CapaDatos.Response;
using System;
using System.Collections.Generic;
using System.Text;
using WebIntiApi.Models;

namespace CapaNegocio.Servicios
{
    public interface IApiClienteCarteraPendienteService
    {
        List<clsClienteCarteraPendienteResponse> obtenerClientePendiente(int usuId);
    }
}
