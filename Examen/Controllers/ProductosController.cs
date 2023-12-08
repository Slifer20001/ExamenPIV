using Examen.Models;
using Examen.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class ProductosController : Controller
    {

        //public ActionResult mantProductos()
        //{


        //}

        [HttpGet]
        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoProducto(CProducto cProducto)
        {
            return View();
        }
        
   

        //}

        //[HttpPost]
        //public ActionResult agregarProductos()
        //{
        //}
        [HttpGet]
        public ActionResult ActualizarProducto(int id)
        {
            CActualizarProducto producto = new CActualizarProducto();
            using (INFO_PRODUCTOSEntities db = new INFO_PRODUCTOSEntities())
            { 
                 var produc = db.T_PRODUCTOS.Find (id);

                produc.IdProducto = produc.ID_PRODUCTO;
                produc.DescripcionProducto = produc.DESC_PRODUCTO;
                produc.AnooFabricacion = produc.AÑO_FABRICACION;
                produc.CasaFabricacion = produc.CASA_FABRICACION;
                produc.EstadoProducto = produc.ESTADO_PRODUCTO;
                produc.AreaTratamiento = produc.AREA_TRATAMIENTO;
            }
            return View(producto);

        }

        [HttpPost]
        public ActionResult ActualizarProducto(CActualizarProducto produc)
        {
            try
            {
                if(!ModelSatate.IsValid)
                {
                    return View(produc);
                }

                using (INFO_PRODUCTOSEntities db = new INFO_PRODUCTOSEntities())
                {
                    var producto = db.T_PRODUCTOS.  
                    produc.IdProducto = produc.ID_PRODUCTO;
                    produc.DescripcionProducto = produc.DESC_PRODUCTO;
                    produc.AnooFabricacion = produc.AÑO_FABRICACION;
                    produc.CasaFabricacion = produc.CASA_FABRICACION;
                    produc.EstadoProducto = produc.ESTADO_PRODUCTO;
                    produc.AreaTratamiento = produc.AREA_TRATAMIENTO;

                    db.Entry(producto).State = System.Data.EntityState.Modified;
                    db.SaveChanges;

                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProducto = "Producto exitosamente actuañlizado";

                }
            }
            catch 
            {

            
            }

        }

        [HttpGet]
        public ActionResult ConsultarProducto(int id)
        {

             CProducto per = new CProducto();
            using (INFO_PRODUCTOSEntities db = new INFO_PRODUCTOSEntities())
            {
                var pers = db.T_PRODUCTOS.Find(id);

                per.IdProducto = pers.ID_PRODUCTO;
                per.DescripcionProducto = pers.DESC_PRODUCTO;
                per.AnooFabricacion = pers.AÑO_FABRICACION;
                per.CasaFabricacion = pers.CASA_FABRICACION;
                per.EstadoProducto = pers.ESTADO_PRODUCTO;
                per.AreaTratamiento = pers.AREA_TRATAMIENTO;
            }
            return View(per);

        }

        [HttpGet]
        public ActionResult eliminarProducto(int id)
        {

            using (Models.INFO_PRODUCTOSEntities db = new Models.INFO_PRODUCTOSEntities())
            {

                var per = db.T_PRODUCTOS.Find(id);
                db.T_PRODUCTOS.Remove(per);
                db.SaveChanges();

            }

            return RedirectToAction("ConsultaProducto", "Productos");

        }

    }

}