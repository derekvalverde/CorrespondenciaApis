using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDatos.Request
{
    public class clsPedidoSolicitudUclIdCabeceraRequest
    {
        public int uclId { get; set; }
        public int usuId { get; set; }
        public string aplicacion { get; set; }
    }
}
