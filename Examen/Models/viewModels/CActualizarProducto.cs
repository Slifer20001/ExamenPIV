using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen.Models.viewModels
{
    public class CActualizarProducto
    {

        [Required]
        [Display(Name = "DescripcionProducto")]
        public string DescripcionProducto { get; set; }

        [Required]
        [Display(Name = "AnnoFabricacion")]
        public int AnooFabricacion { get; set; }

        [Required]
        [Display(Name = "CasaFabricacion")]
        public string CasaFabricacion { get; set; }

        [Required]
        [Display(Name = "EstadoProducto")]
        public string EstadoProducto { get; set; }

        [Required]
        [Display(Name = "AreaTratamiento")]
        public string AreaTratamiento { get; set; }

    }
}