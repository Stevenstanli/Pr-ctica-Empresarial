using System.Linq;
using System.Web.Mvc;
using Practica_Empresarial.Models;

namespace Practica_Empresarial.Controllers
{
    public class PrincipalController : Controller
    {
        DatosVistaModelo Datos = new DatosVistaModelo();
        // GET: Index
        public ActionResult EtiquetaHistoria()
        {
            ViewBag.Titulo = "Página Principal";
            ViewBag.Historia = "Historia";
            ViewBag.Mision = "Misión";
            ViewBag.Vision = "Visión";
            return View();
        }
        public ActionResult EtiquetaEvento()
        {
            ViewBag.Titulo = "Eventos";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción del Evento";
            ViewBag.FechaInicio = "Fecha de Inicio de Periodo de Tiempo";
            ViewBag.FechaFinal = "Fecha de Final de Periodo de Tiempo";
            return View();
        }
        public ActionResult EtiquetaPromocion()
        {
            ViewBag.Titulo = "Promociones";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción de la Promoción";
            ViewBag.FechaInicio = "Fecha de Inicio de Periodo de Tiempo";
            ViewBag.FechaFinal = "Fecha de Final de Periodo de Tiempo";
            return View();
        }
        public ActionResult EtiquetaPromocionyEvento()
        {
            ViewBag.Titulo = "Promociones y Eventos";
            ViewBag.TituloPromocion = "Promociones";
            ViewBag.TituloEvento = "Eventos";
            return View();
        }
        public ActionResult EtiquetaProducto()
        {
            ViewBag.Titulo = "Productos";
            ViewBag.Categoria = "Categoría";
            ViewBag.Imagen = "Imagen";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción del Producto";
            ViewBag.Estado = "Estado";
            return View();
        }
        public ActionResult EtiquetaCotizacion()
        {
            ViewBag.Titulo = "Cotización";
            ViewBag.Nombre = "Nombre";
            ViewBag.Apellidos = "Apellidos";
            ViewBag.Correo = "Correo";
            ViewBag.Telefono = "Teléfono";
            ViewBag.Asunto = "Asunto del Correo";
            ViewBag.Descripcion = "Descripción del Mensaje";
            return View();
        }
        public ActionResult EtiquetaContacto()
        {
            ViewBag.Titulo = "Contacto";
            ViewBag.Red = "Redes Sociales";
            ViewBag.Ubicaciones = "Ubicación";
            ViewBag.Horarios = "Horarios";
            return View();
        }
            public ActionResult Index()
        {
            EtiquetaHistoria();
            var modelo = Datos.SeleccionarHistoria();
            if (modelo != null)
            {
                ViewBag.LaHistoria = modelo.Historia;
                ViewBag.LaMision = modelo.Mision;
                ViewBag.LaVision = modelo.Vision;
                return View();
            }
            else
            {
                ViewBag.LaHistoria = "";
                ViewBag.LaMision = "";
                ViewBag.LaVision = "";
                return View();
            }
        }

        //GET: Productos por Categoria
        public ActionResult ProductosXCategoria(int ID_)
        {
            var Contexto = Datos.SeleccionarProductosXCategoria(ID_);
            ViewBag.Titulo1 = "Productos";
            return View(Contexto);
        }

        //GET: Categoria por Listas
        public ActionResult ProductosXCategoriaListas()
        {
            var Contexto = Datos.SeleccionarProductosXCategoriaListas();
            ViewBag.Titulo1 = "Productos";
            return PartialView(Contexto);
        }

        //GET: Productos
        public ActionResult Productos()
        {
            EtiquetaProducto();
            var Contexto = Datos.SeleccionarProductosListasXEstado();
            if (Contexto.LongCount().Equals(0))
            {
                return View("Error", "Principal");
            }
            else
            {
                return View(Contexto);
            }
        }

        //GET: Promocion
        public ActionResult Promocion()
        {
            EtiquetaPromocion();
            var Contexto = Datos.SeleccionarPromocionListasXEstado();
                return PartialView(Contexto);
        }
        //GET: Evento
        public ActionResult Evento()
        {
            EtiquetaEvento();
            var Contexto = Datos.SeleccionarEventoListasXEstado();
                return PartialView(Contexto);
        }
        //GET: Cotización
        public ActionResult Cotizacion()
        {
            EtiquetaCotizacion();
            return View();
        }
        //POST: Cotizacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cotizacion(AsignarCotizacion m)
        {
            int result = Datos.IngresarCotizacion(m.Nombre, m.Primer_Apellido, m.Segundo_Apellido, m.Correo, m.Telefono, m.Asunto, m.Descripcion);
            if (result.Equals(null))
            {
                ViewBag.Aviso = 1;
                return View(m);
            }
            else
            {
                ViewBag.Aviso = 2;
                return View();
            }
        }
        public ActionResult Contacto()
        {
            EtiquetaContacto();
            ViewBag.Facebook = "https://www.facebook.com/Confitelandia-2396228267277898/";
            ViewBag.Instagram = "";
            ViewBag.ubicacion = "";
            ViewBag.comollegar = "";
            ViewBag.Waze = "";
            ViewBag.Telefono = "+506 8948 3162";
            ViewBag.Direccion = "Alajuela, Grecia,Calle 4";
            ViewBag.Lunes = "Lunes 9:00–18:30 ";
            ViewBag.Martes = "Martes 9:00 – 18:30 "; 
            ViewBag.Miercoles = "Miércoles 9:00–18:30 ";
            ViewBag.Jueves = "Jueves 9:00–18:30 ";
            ViewBag.Viernes = "Viernes 9:00–18:30 ";
            ViewBag.Sabado = "Sábado 9:00–19:00 "; 
            ViewBag.Domingo = "Domingo Cerrado ";
            return View();
        }
        public ActionResult PromocionyEvento()
        {
            EtiquetaPromocionyEvento();
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}