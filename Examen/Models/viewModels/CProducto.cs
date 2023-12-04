using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models.viewModels
{
    public class CProducto
    {

        public int IdProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public int AnooFabricacion { get; set; }

        public string CasaFabricacion { get; set; }

        public string EstadoProducto { get; set; }

        public string AreaTratamiento { get; set; }

    }
}