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
            ViewBag.listaCasaFabricacion = ListaCasaFabricacion();
            ViewBag.listaEstadoProducto = ListaEstadoProducto();
            ViewBag.listaAreaTratamiento = ListaAreaTratamiento();

            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto([Bind(Include = "ID_PRODUCTO,DESC_PRODUCTO,ANIO_FABRICACION,CASA_FABRICACION,ESTADO_PRODUCTO,AREA_TRATAMIENTO")] CAgregarProducto t_PRODUCTOS)
        {
            ViewBag.listaCasaFabricacion = ListaCasaFabricacion();
            ViewBag.listaEstadoProducto = ListaEstadoProducto();
            ViewBag.listaAreaTratamiento = ListaAreaTratamiento();

            if (ModelState.IsValid)
            {
                using (INFO_PRODUCTOSEntities db = new INFO_PRODUCTOSEntities())
                {
                    T_PRODUCTOS producto = new T_PRODUCTOS();

                    producto.DESC_PRODUCTO = t_PRODUCTOS .DESC_PRODUCTO;
                    producto.AÑO_FABRICACION = t_PRODUCTOS.ANIO_FABRICACION.Year;
                    producto.ESTADO_PRODUCTO = t_PRODUCTOS.ESTADO_PRODUCTO; 
                    producto.CASA_FABRICACION = t_PRODUCTOS.CASA_FABRICACION;
                    producto.AREA_TRATAMIENTO = t_PRODUCTOS.AREA_TRATAMIENTO;

                    db.T_PRODUCTOS.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("ConsultaProducto");
                }
            }

            return View(t_PRODUCTOS);
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
                var pro = db.T_PRODUCTOS.Find(id);

                producto.IdProducto = pro.ID_PRODUCTO;
                producto.DescripcionProducto = pro.DESC_PRODUCTO;
                producto.AnooFabricacion = pro.AÑO_FABRICACION;
                producto.CasaFabricacion = pro.CASA_FABRICACION;
                producto.EstadoProducto = pro.ESTADO_PRODUCTO;
                producto.AreaTratamiento = pro.AREA_TRATAMIENTO;
            }
            return View(producto);

        }


        [HttpPost]
        public ActionResult ActualizarProducto(CActualizarProducto produc)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(produc);
                }

                using (INFO_PRODUCTOSEntities db = new INFO_PRODUCTOSEntities())
                {

                    var producto = db.T_PRODUCTOS.Find(produc.IdProducto);

                    
                    producto.DESC_PRODUCTO = produc.DescripcionProducto;
                    producto.AÑO_FABRICACION = produc.AnooFabricacion;
                    producto.CASA_FABRICACION = produc.CasaFabricacion;
                    producto.ESTADO_PRODUCTO = produc.EstadoProducto;
                    producto.AREA_TRATAMIENTO = produc.AreaTratamiento;

                    db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    ViewBag.ValorMensaje = 1;
                    ViewBag.MensajeProducto = "Producto exitosamente actualizado";

                }
                return View(produc);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProducto = "Fallo la actualizacion" + ex ;
                return View(produc);
            }

        }


        [HttpGet]
        public ActionResult ConsultarProducto(int id )
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
        public ActionResult ConsultaProducto()
        {
            List<CListaProductos> listPro = null;

            using (Models.INFO_PRODUCTOSEntities db = new Models.INFO_PRODUCTOSEntities())
            {
                listPro = (from pro in db.T_PRODUCTOS
                           select new CListaProductos
                           {
                               IdProducto = pro.ID_PRODUCTO,
                               DescripcionProducto = pro.DESC_PRODUCTO,
                               AnooFabricacion = pro.AÑO_FABRICACION,
                               CasaFabricacion = pro.CASA_FABRICACION,
                               EstadoProducto = pro.ESTADO_PRODUCTO,
                               AreaTratamiento = pro.AREA_TRATAMIENTO
                           }).ToList();
            }

            return View(listPro);



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

        private List<SelectListItem> ListaCasaFabricacion()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{ Text="Médicos en Casa", Value="Médicos en Casa" },
                new SelectListItem{ Text="Medicina a su Alcance", Value="Medicina a su Alcance" },
                new SelectListItem{ Text="Médico Feliz", Value="Médico Feliz" }
            };

        }

        private List<SelectListItem> ListaEstadoProducto()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{ Text="Activo", Value="Activo" },
                new SelectListItem{ Text="Inactivo", Value="Inactivo" },
                new SelectListItem{ Text="Descontinuado", Value="Descontinuado" }
            };

        }

        private List<SelectListItem> ListaAreaTratamiento()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{ Text="Salud General", Value="Salud General" },
                new SelectListItem{ Text="Salud Mental", Value="Salud Mental" },
                new SelectListItem{ Text="Estética", Value="Estética" }
            };

        }

    }

}