using System.Web.Mvc;
using Practica_Empresarial.Models;
using System.Web.Helpers;
using System.Linq;
using System.Security.Claims;
using System.IO;
using System.Collections.Generic;

namespace Practica_Empresarial.Controllers
{
    [Authorize]
    public class AdministradorController : Controller
    {
        Ingreso DatosIngresados = new Ingreso();
        Selecciona DatosSeleccionados = new Selecciona();
        Modifica DatosModificados = new Modifica();
        Elimina DatosEliminados = new Elimina();
        DatosVistaModelo Datos = new DatosVistaModelo();
        Encrypt Pass = new Encrypt();
        public ActionResult EtiquetaHistoria()
        {
            ViewBag.Titulo = "Historia";
            ViewBag.TituloIngreso = "Ingresar Nueva Historia";
            ViewBag.TituloModificar = "Modificar Historia";
            ViewBag.TituloEliminar = "Eliminar Historia";
            ViewBag.Historia = "Historia";
            ViewBag.Mision = "Misión";
            ViewBag.Vision = "Vision";
            return View();
        }
        public ActionResult EtiquetaPerfil()
        {
            ViewBag.Titulo = "Perfil";
            ViewBag.TituloIngreso = "Ingresar Nuevo Perfil";
            ViewBag.TituloModificar = "Modificar Perfil";
            ViewBag.TituloEliminar = "Eliminar Perfil";
            ViewBag.NombrePerfil = "Nombre";
            return View();
        }
        public ActionResult EtiquetaCategoria()
        {
            ViewBag.Titulo = "Categoría";
            ViewBag.TituloIngreso = "Ingresar Nueva Categoría";
            ViewBag.TituloModificar = "Modificar Categoría";
            ViewBag.TituloEliminar = "Eliminar Categoría";
            ViewBag.NombreCategoria = "Nombre";
            return View();
        }
        public ActionResult EtiquetaProducto()
        {
            ViewBag.Titulo = "Producto";
            ViewBag.TituloIngreso = "Ingresar Nuevo Producto";
            ViewBag.TituloModificar = "Modificar Producto";
            ViewBag.TituloEliminar = "Eliminar Producto";
            ViewBag.Categoria = "Categoría";
            ViewBag.Imagen = "Imagen";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción del Producto";
            ViewBag.Estado = "Estado";
            return View();
        }
        public ActionResult EtiquetaEvento()
        {
            ViewBag.Titulo = "Evento";
            ViewBag.TituloIngreso = "Ingresar Nuevo Evento";
            ViewBag.TituloModificar = "Modificar Evento";
            ViewBag.TituloEliminar = "Eliminar Evento";
            ViewBag.Imagen = "Imagen";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción del Evento";
            ViewBag.Estado = "Estado";
            ViewBag.FechaInicio = "Fecha de Inicio de Periodo de Tiempo";
            ViewBag.FechaFinal = "Fecha de Final de Periodo de Tiempo";
            return View();
        }
        public ActionResult EtiquetaPromocion()
        {
            ViewBag.Titulo = "Promoción";
            ViewBag.TituloIngreso = "Ingresar Nueva Promoción";
            ViewBag.TituloModificar = "Modificar Promoción";
            ViewBag.TituloEliminar = "Eliminar Promoción";
            ViewBag.Imagen = "Imagen";
            ViewBag.Nombre = "Nombre";
            ViewBag.Descripcion = "Descripción de la Promoción";
            ViewBag.Estado = "Estado";
            ViewBag.FechaInicio = "Fecha de Inicio de Periodo de Tiempo";
            ViewBag.FechaFinal = "Fecha de Final de Periodo de Tiempo";
            return View();
        }
        public ActionResult EtiquetaAyuda()
        {
            ViewBag.Titulo = "Ayuda";
            ViewBag.TituloIngreso = "Ingresar Nueva Ayuda";
            ViewBag.TituloModificar = "Modificar Ayuda";
            ViewBag.TituloEliminar = "Eliminar Ayuda";
            ViewBag.Version = "Versión de la Página Web";
            ViewBag.Manual = "Manual de Usuario para usar la página Web";
            return View();
        }
        public ActionResult EtiquetaCotizacion()
        {
            ViewBag.Titulo = "Cotización";
            ViewBag.TituloIngreso = "Enviar Respuesta a la solicitud de Cotización";
            ViewBag.TituloEliminar = "Eliminar Cotización";
            ViewBag.Nombre = "Nombre";
            ViewBag.Apellidos = "Apellidos";
            ViewBag.Correo = "Correo";
            ViewBag.Telefono = "Teléfono";
            ViewBag.Asunto = "Asunto del Correo";
            ViewBag.Descripcion = "Descripción del Mensaje";
            ViewBag.Fecha = "Fecha en que se emitió el correo";
            return View();
        }
        public ActionResult EtiquetaUsuario()
        {
            ViewBag.Titulo = "Usuario";
            ViewBag.TituloModificarUsuario = "Modificar Usuario";
            ViewBag.TituloModificar = "Modificar Estado";
            ViewBag.TituloEliminar = "Eliminar Usuario";
            ViewBag.Perfil = "Perfil Asignado";
            ViewBag.Nombre = "Nombre";
            ViewBag.Estado = "Estado";
            ViewBag.Correo = "Correo";
            return View();
        }
        public ActionResult EtiquetaContrasena()
        {
            ViewBag.Titulo = "Usuario";
            ViewBag.TituloModificar = "Modificar Estado";
            ViewBag.Correo = "Correo";
            ViewBag.Contrasena = "Contraseña";
            ViewBag.ContrasenaVerifica = "Contraseña de Confirmación";
            return View();
        }

        // GET: Páginas Administrativas
        public ActionResult Principal()
        {
            EtiquetaHistoria();
            var Contexto = Datos.SeleccionarHistoria();
            if (Contexto == null)
            {
                return RedirectToAction("CrearPrincipal");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Perfil()
        {
            EtiquetaPerfil();
            var Contexto = DatosSeleccionados.SeleccionarPerfilList();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearPerfil");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Categoria()
        {
            EtiquetaCategoria();
            var Contexto = Datos.SeleccionarCategoriaListas();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearCategoria");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Evento()
        {
            EtiquetaEvento();
            var Contexto = Datos.SeleccionarEventoListas();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearEvento");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Promocion()
        {
            EtiquetaPromocion();
            var Contexto = Datos.SeleccionarPromocionListas();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearPromociones");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Productos()
        {
            EtiquetaProducto();
            var Contexto = Datos.SeleccionarProductosListas();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearProductos");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult Cotizacion()
        {
            EtiquetaCotizacion();
            var Contexto = DatosSeleccionados.SeleccionarCotizacionList();
            return View(Contexto);
        }
        public ActionResult Ayuda()
        {
            EtiquetaAyuda();
            var Contexto = DatosSeleccionados.SeleccionarAyudaList();
            if (Contexto.LongCount().Equals(0))
            {
                return RedirectToAction("CrearAyuda");
            }
            else
            {
                return View(Contexto);
            }
        }
        public ActionResult CotizacionRespuesta(int id)
        {
            EtiquetaCotizacion();
            var Contexto = DatosSeleccionados.SeleccionarCotizacion(id);
            AsignarCotizaciónRespuesta asignado = new AsignarCotizaciónRespuesta();
            asignado.ID_Cotizacion = Contexto.ID_Cotizacion;
            asignado.Nombre = Contexto.Nombre;
            asignado.Apellido1 = Contexto.Apellido1;
            asignado.Apellido2 = Contexto.Apellido2;
            asignado.Correo = Contexto.Correo;
            asignado.Telefono = Contexto.Telefono;
            asignado.Asunto = Contexto.Asunto;
            asignado.Descripcion = Contexto.Descripcion;
            return View(asignado);
        }
        public ActionResult CotizacionRespuestaLista(int id)
        {
            EtiquetaCotizacion();
            var Contexto = DatosSeleccionados.SeleccionarCotizacionRespuestaLista(id);
            return PartialView(Contexto);
        }
        public ActionResult Usuario()
        {
            EtiquetaUsuario();
            var Contexto = DatosSeleccionados.SeleccionarUsuarioListas();
            return View(Contexto);
        }
        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            var Contexto = DatosSeleccionados.SeleccionarAyuda(id);

            return File(Contexto.Manual_, "application/pdf","Manual de Usuario.pdf");
        }
        // POST: Crear Principal ---------------------------------------------------------------------------------------------------------------------
        public ActionResult CrearPrincipal()
        {
            EtiquetaHistoria();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPrincipal(AsignarHistoria m)
        {
            try
            {
                int result = DatosIngresados.IngresarHistoria(m.Historia, m.Mision, m.Vision);
                if (result.Equals(null))
                {
                    EtiquetaHistoria();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Principal");
                }
            }
            catch
            {
                EtiquetaHistoria();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // POST: CrearPerfil
        public ActionResult CrearPerfil()
        {
            EtiquetaPerfil();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPerfil(AsignarPerfil m)
        {
            try
            {
                int result = DatosIngresados.IngresarPerfil(m.Perfil);
                if (result.Equals(null))
                {
                    EtiquetaPerfil();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Perfil");
                }
            }
            catch
            {
                EtiquetaPerfil();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // POST: CrearCategoria
        public ActionResult CrearCategoria()
        {
            EtiquetaCategoria();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCategoria(AsignarCategoria m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    decimal result = DatosIngresados.IngresarCategoria(m.Nombre);
                    if (result.Equals(null))
                    {
                        EtiquetaCategoria();
                        ViewBag.Aviso = 1;
                        return View(m);
                    }
                    else
                    {
                        return RedirectToAction("Categoria");
                    }
                }
                EtiquetaCategoria();
                ViewBag.Aviso = 2;
                return View(m);
            }
            catch
            {
                EtiquetaCategoria();
                ViewBag.Aviso = 1;
                return View(m);
            }

        }

        // GET: Crear Productos
        public ActionResult CrearProductos()
        {
            ViewBag.ListaCategoria = new SelectList(Datos.SeleccionarCategoriaListas(), "ID_Categoria", "NombreCategoria");
            ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
            EtiquetaProducto();
            return View();
        }

        // POST: Crear Productos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProductos(AsignarProducto m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    int result = DatosIngresados.IngresarProducto(image.GetBytes(), m.ID_Categoria, m.NombreProducto, m.Descripcion, m.Estado);
                    if (result.Equals(null))
                    {
                        EtiquetaProducto();
                        ViewBag.Aviso = 1;
                        return View(m);
                    }
                    else
                    {
                        return RedirectToAction("Productos");
                    }
                }
                return RedirectToAction("Productos");
            }
            catch
            {
                EtiquetaProducto();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Crear Eventos
        public ActionResult CrearEvento()
        {
            ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
            ViewBag.Tiempo = System.DateTime.Today.ToString("yyyy-MM-dd");
            EtiquetaEvento();
            return View();
        }

        // POST: Crear Eventos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEvento(AsignarEvento m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    int result = DatosIngresados.IngresarEvento(image.GetBytes(), m.NombreEvento, m.Descripcion, m.Estado, m.FechaInicio, m.FechaFinal);
                    if (result.Equals(null))
                    {
                        EtiquetaEvento();
                        ViewBag.Aviso = 1;
                        return View(m);
                    }
                    else
                    {
                        return RedirectToAction("Evento");
                    }
                }
                return RedirectToAction("Evento");
            }
            catch
            {
                EtiquetaEvento();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Crear Promociones
        public ActionResult CrearPromociones()
        {
            EtiquetaPromocion();
            ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
            ViewBag.Tiempo = System.DateTime.Today.ToString("yyyy-MM-dd");
            return View();
        }

        // POST: Crear Promociones
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPromociones(AsignarPromoción m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    int result = DatosIngresados.IngresarPromocion(image.GetBytes(), m.Nombre, m.Descripcion, m.Estado, m.FechaInicio, m.FechaFinal);
                    if (result.Equals(null))
                    {
                        EtiquetaPromocion();
                        ViewBag.Aviso = 1;
                        return View(m);
                    }
                    else
                    {
                        return RedirectToAction("Promocion");
                    }
                }
                return RedirectToAction("Promocion");
            }
            catch
            {
                EtiquetaPromocion();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // POST: Crear Cotizacion Respuesta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CotizacionRespuesta(AsignarCotizaciónRespuesta m)
        {
            try
            {
                int result = DatosIngresados.IngresarCotizacionRespuesta(m.ID_Cotizacion, m.AsuntoEnviar, m.DescripcionEnviar);
                if (result.Equals(null))
                {
                    EtiquetaCotizacion();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("CotizacionRespuesta");
                }
            }
            catch
            {
                EtiquetaCotizacion();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Crear Ayuda
        public ActionResult CrearAyuda()
        {
            EtiquetaAyuda();
            return View();
        }

        // POST: Crear Ayuda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearAyuda(AsignarAyuda m)
        {
            try
            {
                Stream str = m.Manual.InputStream;
                BinaryReader Br = new BinaryReader(str);
                byte[] FileDet = Br.ReadBytes(System.Convert.ToInt32(str.Length));
                int result = DatosIngresados.IngresarAyuda(m.Version, FileDet);
                if (result.Equals(null))
                {
                    EtiquetaAyuda();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Ayuda");
                }
            }
            catch
            {
                EtiquetaAyuda();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Editar Principal ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult EditarPrincipal(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Principal");
            }
            else
            {
                EtiquetaHistoria();
                var context = Datos.SeleccionarHistoria();
                if (context.Equals(null))
                {
                    return RedirectToAction("Principal");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Editar Principal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPrincipal(ModificarHistoria m)
        {
            try
            {
                int resultado = DatosModificados.ModificarHistoria(m.ID_Historia, m.Historia, m.Mision, m.Vision);
                if (resultado.Equals(null))
                {
                    EtiquetaHistoria();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Principal");
                }
            }
            catch
            {
                EtiquetaHistoria();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Editar Categoría
        public ActionResult EditarCategoria(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Categoria");
            }
            else
            {
                EtiquetaCategoria();
                var context = Datos.SeleccionarCategoria(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Categoria");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Editar Categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCategoria(ModificarCategoria m)
        {
            try
            {
                int resultado = DatosModificados.ModificarCategoria(m.ID_Categoria, m.NombreCategoria);
                if (resultado.Equals(null))
                {
                    EtiquetaCategoria();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Categoria");
                }
            }
            catch
            {
                EtiquetaCategoria();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Perfil
        public ActionResult EditarPerfil(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Perfil");
            }
            else
            {
                EtiquetaPerfil();
                var context = DatosSeleccionados.SeleccionarPerfil(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Perfil");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Editar Perfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPerfil(ModificarPerfil m)
        {
            try
            {
                int resultado = DatosModificados.ModificarPerfil(m.ID_Perfil, m.NombrePerfil);
                if (resultado.Equals(null))
                {
                    EtiquetaPerfil();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Perfil");
                }
            }
            catch
            {
                EtiquetaPerfil();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Producto
        public ActionResult EditarProducto(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Producto");
            }
            else
            {
                EtiquetaProducto();
                ViewBag.ListaCategoria = new SelectList(Datos.SeleccionarCategoriaListas(), "ID_Categoria", "NombreCategoria");
                ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
                var context = Datos.SeleccionarProductosVerficacion(id);
                ModificarProducto asignado = new ModificarProducto();
                asignado.ID_Producto = context.ID_Producto;
                asignado.ID_Categoria = context.ID_Categoria;
                asignado.ID_Imagen_ = context.ID_Imagen_;
                asignado.Imagen_ = context.Imagen_;
                asignado.NombreProducto = context.NombreProducto;
                asignado.Descripcion = context.Descripcion;
                asignado.ID_Estado = context.ID_Estado;
                if (context.Equals(null))
                {
                    return RedirectToAction("Producto");
                }
                else
                {
                    return View(asignado);
                }
            }
        }
        // POST: Editar Producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(ModificarProducto m)
        {
            try
            {
                byte[] ImagenTemp;
                var verificar = Datos.SeleccionarProductosVerficacion(m.ID_Producto);
                if (m.Imagen == null)
                {
                    ImagenTemp = verificar.Imagen_;
                }
                else
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    ImagenTemp = image.GetBytes();
                }
                if (m.ID_Categoria.Equals(null))
                    m.ID_Categoria = verificar.ID_Categoria;
                int resultado = DatosModificados.ModificarProducto(m.ID_Producto, m.ID_Imagen_, ImagenTemp, m.ID_Categoria, m.NombreProducto, m.Descripcion, m.ID_Estado);
                if (resultado.Equals(null))
                {
                    EtiquetaProducto();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Productos");
                }
            }
            catch
            {
                EtiquetaProducto();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Evento
        public ActionResult EditarEvento(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Evento");
            }
            else
            {
                EtiquetaEvento();
                ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
                var context = Datos.SeleccionarEventoVerificacion(id);
                ModificarEvento asignado = new ModificarEvento();
                asignado.ID_Evento = context.ID_Evento;
                asignado.ID_Imagen_ = context.ID_Imagen_;
                asignado.Imagen_ = context.Imagen_;
                asignado.NombreEvento = context.NombreEvento;
                asignado.Descripcion = context.Descripcion;
                asignado.ID_Estado = context.ID_Estado;
                asignado.Fecha_Inicio = context.Fecha_Inicio;
                asignado.Fecha_Final = context.Fecha_Final;
                if (context.Equals(null))
                {
                    return RedirectToAction("Evento");
                }
                else
                {
                    return View(asignado);
                }
            }
        }
        // POST: Editar Evento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEvento(ModificarEvento m)
        {
            try
            {
                byte[] ImagenTemp;
                var verificar = Datos.SeleccionarEventoVerificacion(m.ID_Evento);
                if (m.Imagen == null)
                {
                    ImagenTemp = verificar.Imagen_;
                }
                else
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    ImagenTemp = image.GetBytes();
                }
                int resultado = DatosModificados.ModificarEvento(m.ID_Evento, m.ID_Imagen_, ImagenTemp, m.NombreEvento, m.Descripcion, m.ID_Estado, m.Fecha_Inicio, m.Fecha_Final);
                if (resultado.Equals(null))
                {
                    EtiquetaEvento();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Evento");
                }
            }
            catch
            {
                EtiquetaEvento();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Promoción
        public ActionResult EditarPromocion(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Promocion");
            }
            else
            {
                EtiquetaPromocion();
                ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
                var context = Datos.SeleccionarPromocionVerificacion(id);
                ModificarPromocion asignado = new ModificarPromocion();
                asignado.ID_Promocion = context.ID_Promocion;
                asignado.ID_Imagen_ = context.ID_Imagen_;
                asignado.Imagen_ = context.Imagen_;
                asignado.NombrePromocion = context.NombrePromocion;
                asignado.Descripcion = context.Descripcion;
                asignado.ID_Estado = context.ID_Estado;
                asignado.Fecha_Inicio = context.Fecha_Inicio;
                asignado.Fecha_Final = context.Fecha_Final;
                if (context.Equals(null))
                {
                    ViewBag.Error = "Su solicitud no ha sido Procesada";
                    return View("Promocion");
                }
                else
                {
                    return View(asignado);
                }
            }
        }
        // POST: Editar Promoción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPromocion(ModificarPromocion m)
        {
            try
            {
                byte[] ImagenTemp;
                var verificar = Datos.SeleccionarPromocionVerificacion(m.ID_Promocion);
                if (m.Imagen == null)
                {
                    ImagenTemp = verificar.Imagen_;
                }
                else
                {
                    WebImage image = new WebImage(m.Imagen.InputStream);
                    ImagenTemp = image.GetBytes();
                }
                int resultado = DatosModificados.ModificarPromocion(m.ID_Promocion, m.ID_Imagen_, ImagenTemp, m.NombrePromocion, m.Descripcion, m.ID_Estado, m.Fecha_Inicio, m.Fecha_Final);
                if (resultado.Equals(null))
                {
                    EtiquetaPromocion();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Promocion");
                }
            }
            catch
            {
                EtiquetaPromocion();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        //GET: Editar Usuario
        public ActionResult EditarUsuario(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Usuario");
            }
            else
            {
                EtiquetaUsuario();
                ViewBag.ListaEstado = new SelectList(DatosSeleccionados.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
                var context = DatosSeleccionados.SeleccionarUsuarioVerificar(id);
                if (id.Equals(null))
                {
                    return RedirectToAction("Usuario");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Editar Promoción
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(ModificarUsuario m)
        {
            try
            {
                var verificar = DatosSeleccionados.SeleccionarUsuarioVerificar(m.ID_Usuario);
                int resultado = DatosModificados.ModificarUsuario(verificar.ID_Usuario, System.Convert.ToByte(verificar.ID_Perfil), verificar.NombreUsuario, verificar.Apellido1, verificar.Apellido2, m.ID_Estado, verificar.correo);
                if (resultado.Equals(null))
                {
                    EtiquetaUsuario();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Usuario");
                }
            }
            catch
            {
                EtiquetaUsuario();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Ayuda
        public ActionResult EditarAyuda(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Ayuda");
            }
            else
            {
                EtiquetaAyuda();
                var context = DatosSeleccionados.SeleccionarAyuda(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Ayuda");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Editar Ayuda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAyuda(ModificarAyuda m)
        {
            try
            {
                Stream str = m.Manual.InputStream;
                BinaryReader Br = new BinaryReader(str);
                byte[] FileDet = Br.ReadBytes(System.Convert.ToInt32(str.Length));
                int resultado = DatosModificados.ModificarAyuda(m.ID_Ayuda, m.Version, FileDet);
                if (resultado.Equals(null))
                {
                    EtiquetaAyuda();
                    ViewBag.Aviso = 1;
                    return View(m);
                }
                else
                {
                    return RedirectToAction("Ayuda");
                }
            }
            catch
            {
                EtiquetaAyuda();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }
        // GET: Editar Contraseña
        [AllowAnonymous]
        public ActionResult EditarContrasena()
        {
            EtiquetaContrasena();
            return View();

        }
        // POST: Editar Contrasena
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult EditarContrasena(ModificarContrasena m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var valores = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
                    string id = valores.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var CorreoVer = DatosSeleccionados.SeleccionarCorreoVerificar(m.Correo);
                    if (CorreoVer == null)
                    {
                        EtiquetaContrasena();
                        ViewBag.Aviso = 2;
                        return View(m);
                    }
                    else
                    {
                        string Contrasena = Pass.GetSHA256(m.Contrasena);
                        int resultado = DatosModificados.ModificarContrasena(System.Convert.ToInt32(id), Contrasena);
                        if (resultado.Equals(null))
                        {
                            EtiquetaContrasena();
                            ViewBag.Aviso = 1;
                            return View(m);
                        }
                        else
                        {
                            return RedirectToAction("Principal");
                        }
                    }
                }
                else
                {
                    EtiquetaContrasena();
                    ViewBag.Aviso = 2;
                    return View(m);
                }
            }
            catch
            {
                EtiquetaContrasena();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        // GET: Eliminar Categoría --------------------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult EliminarCategoria(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Categoria");
            }
            else
            {
                EtiquetaCategoria();
                var context = Datos.SeleccionarCategoria(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Categoria");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarCategoria(EliminarCategoria m)
        {
            try
            {
                var revision = Datos.SeleccionarProductosXCategoriaListasXIndice(m.ID_Categoria);
                if (revision.LongCount().Equals(0))
                {
                    int resultado = DatosEliminados.EliminarCategoria(m.ID_Categoria);
                    if (resultado.Equals(null))
                    {
                        EtiquetaCategoria();
                        ViewBag.Aviso = 1;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Categoria");
                    }
                }
                else
                {
                    EtiquetaCategoria();
                    ViewBag.Aviso = 2;
                    return View();
                }
            }
            catch
            {
                EtiquetaCategoria();
                ViewBag.Aviso = 1;
                return View();
            }
        }
        // GET: Eliminar Perfil
        public ActionResult EliminarPerfil(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Perfil");
            }
            else
            {
                EtiquetaPerfil();
                var context = DatosSeleccionados.SeleccionarPerfil(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Perfil");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Perfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarPerfil(EliminarPerfil m)
        {
            try
            {
                var revision = Datos.SeleccionarProductosXCategoriaListasXIndice(m.ID_Perfil);
                if (revision.LongCount().Equals(0))
                {
                    int resultado = DatosEliminados.EliminarCategoria(m.ID_Perfil);
                    if (resultado.Equals(null))
                    {
                        EtiquetaPerfil();
                        ViewBag.Aviso = 1;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Perfil");
                    }
                }
                else
                {
                    EtiquetaPerfil();
                    ViewBag.Aviso = 2;
                    return View();
                }
            }
            catch
            {
                EtiquetaPerfil();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Historia
        public ActionResult EliminarHistoria()
        {
            EtiquetaHistoria();
            var context = Datos.SeleccionarHistoria();
            if (context.Equals(null))
            {
                return RedirectToAction("Principal");
            }
            else
            {
                return View(context);
            }
        }
        // POST: Eliminar Historia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarHistoria(EliminarHistoria m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarHistoria(m.ID_Historia);
                if (resultado.Equals(null))
                {
                    EtiquetaHistoria();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Principal");
                }
            }
            catch
            {
                EtiquetaHistoria();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Producto
        public ActionResult EliminarProducto(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Producto");
            }
            else
            {
                EtiquetaProducto();
                var context = Datos.SeleccionarProductos(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Producto");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarProducto(EliminarProducto m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarProducto(m.ID_Producto, m.ID_Imagen);
                if (resultado.Equals(null))
                {
                    EtiquetaProducto();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Producto");
                }
            }
            catch
            {
                EtiquetaProducto();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Evento
        public ActionResult EliminarEvento(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Evento");
            }
            else
            {
                EtiquetaEvento();
                var context = Datos.SeleccionarEvento(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Evento");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Evento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarEvento(EliminarEvento m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarEvento(m.ID_Evento, m.ID_Imagen);
                if (resultado.Equals(null))
                {
                    EtiquetaEvento();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Evento");
                }
            }
            catch
            {
                EtiquetaEvento();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Promocion
        public ActionResult EliminarPromocion(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Promocion");
            }
            else
            {
                EtiquetaPromocion();
                var context = Datos.SeleccionarPromocion(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Promocion");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Evento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarPromocion(EliminarPromocion m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarPromocion(m.ID_Promocion, m.ID_Imagen);
                if (resultado.Equals(null))
                {
                    EtiquetaPromocion();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Promocion");
                }
            }
            catch
            {
                EtiquetaPromocion();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Cotizacion
        public ActionResult EliminarCotizacion(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Cotizacion");
            }
            else
            {
                EtiquetaCotizacion();
                var context = DatosSeleccionados.SeleccionarCotizacion(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Cotizacion");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Cotización
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarCotizacion(EliminarCotizacion m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarCotizacion(m.ID_Cotizacion);
                if (resultado.Equals(null))
                {
                    EtiquetaCotizacion();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Cotizacion");
                }
            }
            catch
            {
                EtiquetaCotizacion();
                ViewBag.Aviso = 1;
                return View();
            }
        }

        // GET: Eliminar Cotizacion Respuesta
        public ActionResult EliminarCotizacionRespuesta(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Cotizacion");
            }
            else
            {
                EtiquetaCotizacion();
                var context = DatosSeleccionados.SeleccionarCotizacion(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Cotizacion");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Cotizacion Respuesta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarCotizacionRespuesta(EliminarCotizacionRespuesta m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarCotizacionRespuesta(m.ID_CotizacionRespuesta);
                if (resultado.Equals(null))
                {
                    EtiquetaCotizacion();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("CotizacionRespuesta");
                }
            }
            catch
            {
                EtiquetaCotizacion();
                ViewBag.Aviso = 1;
                return View();
            }
        }
        // GET: Eliminar Usuario
        public ActionResult EliminarUsuario(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Usuario");
            }
            else
            {
                EtiquetaUsuario();
                var context = DatosSeleccionados.SeleccionarUsuario(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("EliminarUsuario");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarUsuario(EliminarUsuario m)
        {
            try
            {
                var valores = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
                string id = valores.FindFirst(ClaimTypes.NameIdentifier).Value;
                int Usuario = System.Convert.ToInt32(id);
                if (Usuario == m.ID_Usuario)
                {
                    EtiquetaUsuario();
                    ViewBag.Aviso = 2;
                    return View();
                }
                else
                {
                    int resultado = DatosEliminados.EliminarUsuario(m.ID_Usuario);
                    if (resultado.Equals(null))
                    {
                        EtiquetaUsuario();
                        ViewBag.Aviso = 1;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Usuario");
                    }
                }
            }
            catch
            {
                EtiquetaUsuario();
                ViewBag.Aviso = 1;
                return View();
            }
        }
        // GET: Eliminar Ayuda
        public ActionResult EliminarAyuda(int id)
        {
            if (id.Equals(null))
            {
                return RedirectToAction("Ayuda");
            }
            else
            {
                EtiquetaAyuda();
                var context = DatosSeleccionados.SeleccionarAyuda(id);
                if (context.Equals(null))
                {
                    return RedirectToAction("Ayuda");
                }
                else
                {
                    return View(context);
                }
            }
        }
        // POST: Eliminar Ayuda
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarAyuda(EliminarAyuda m)
        {
            try
            {
                int resultado = DatosEliminados.EliminarAyuda(m.ID_Ayuda);
                if (resultado.Equals(null))
                {
                    EtiquetaAyuda();
                    ViewBag.Aviso = 1;
                    return View();
                }
                else
                {
                    return RedirectToAction("Ayuda");
                }
            }
            catch
            {
                EtiquetaPerfil();
                ViewBag.Aviso = 1;
                return View();
            }
        }
    }
}