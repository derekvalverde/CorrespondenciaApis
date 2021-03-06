using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDatos.Response
{
    public class clsPedidoSolicitudEstadoResponse
    {
        
        public int pedId { get; set; }
        public string cliCodigo { get; set; }
        public decimal pedPrecio { get; set; }
        public decimal pedCheque { get; set; }
        public string pedObservacion { get; set; }
        public DateTime pedFechaEntrega { get; set; }
        public string pedPeriodo { get; set; }
        public List<clsPedidoDetalleSolicitudResponse> detalleSolicitudEstado { get; set; }
    }
}