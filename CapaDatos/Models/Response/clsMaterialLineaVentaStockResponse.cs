using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDatos.Response
{
    public class clsMaterialLineaVentaStockResponse
    {
        public string matCodigo { get; set; }
        public string matNombre { get; set; }
        public string secCodigo { get; set; }
        public decimal mavPrecio { get; set; }
        public string mavLinea { get; set; }
        public string mavFamilia { get; set; }
        public string mavOrigen { get; set; }
        public int mavExistencia { get; set; }
        public decimal madDescuento { get; set; }
        public string matImagen { get; set; }
        public int mprCantidad { get; set; }
    }
}
