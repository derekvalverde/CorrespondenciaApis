using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDatos.Request
{
    public class clsCorrespondenciaEliminarRequest
    {

        public string usuCodigo { get; set; }
        public int idCorrespondencia { get; set; }
        public int opcion { get; set; }
    }
}
