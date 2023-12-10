using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Examen.Models.viewModels
{
    public class CAgregarProducto
    {


        [Required]
        [Display(Name = "Id")]
        public int ID_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string DESC_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Fabricado")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime ANIO_FABRICACION { get; set; }

        [Required]
        [Display(Name = "Casa")]
        public string CASA_FABRICACION { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string ESTADO_PRODUCTO { get; set; }

        [Required]
        [Display(Name = "Area")]
        public string AREA_TRATAMIENTO { get; set; }

    }
}