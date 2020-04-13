using Practica_Empresarial.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Practica_Empresarial.Models
{
    public class Ingreso
    {
        private Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();
        public int IngresarPerfil(string Perfil)
        {
            return contexto.PA_InsertaPerfil(Perfil).GetHashCode();
        }
        public decimal IngresarImagen(byte[] Imagen)
        {
            return contexto.PA_InsertaImagen_(Imagen).First().Value;
        }
        public decimal IngresarCategoria(string Categoria)
        {
            return contexto.PA_InsertaCategoria(Categoria).First().Value;
        }
        public int IngresarHistoria(string Historia, string Mision, string Vision)
        {
            return contexto.PA_InsertaHistoria(Historia, Mision, Vision).GetHashCode();
        }
        public int IngresarProducto(byte[] Imagen, int Categoria, string Nombre, string Descripcion, int Estado)
        {
            decimal variable = IngresarImagen(Imagen);
            return contexto.PA_InsertaProducto(Categoria, Convert.ToInt32(variable), Nombre, Descripcion, Estado).GetHashCode();
        }
        public int IngresarPromocion(byte[] Imagen, string Nombre, string Descripcion, int Estado, DateTime Fecha_Inicio, DateTime Fecha_Final)
        {
            decimal variable = IngresarImagen(Imagen);
            return contexto.PA_InsertaPromocion(Convert.ToInt32(variable), Nombre, Descripcion, Estado, Fecha_Inicio, Fecha_Final).GetHashCode();
        }
        public int IngresarEvento(byte[] Imagen, string Nombre, string Descripcion, int Estado, DateTime Fecha_Inicio, DateTime Fecha_Final)
        {
            decimal variable = IngresarImagen(Imagen);
            return contexto.PA_InsertaEvento(Convert.ToInt32(variable), Nombre, Descripcion, Estado, Fecha_Inicio, Fecha_Final).GetHashCode();
        }
        public int IngresarCotizacionRespuesta(int ID_Cotizacion, string Asunto, string Descripcion)
        {
            return contexto.PA_InsertaCotizacionRespuesta(ID_Cotizacion, Asunto, Descripcion).GetHashCode();
        }
        public int IngresarAyuda(string Version, byte[] Manual_)
        {
            return contexto.PA_InsertaAyuda(Version, Manual_).GetHashCode();
        }
    }
    public class Selecciona
    {
        private Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();
        public PA_SelectPerfil_Result SeleccionarPerfil(int ID_Perfil)
        {
            return contexto.PA_SelectPerfil(ID_Perfil).FirstOrDefault();
        }
        public List<PA_SelectPerfil_Result> SeleccionarPerfilList()
        {
            SByte ID_Perfil = -1;
            return contexto.PA_SelectPerfil(ID_Perfil).ToList();
        }
        public List<PA_SelectEstado_Result> SeleccionarEstadoList()
        {
            int ID_Estado = -1;
            return contexto.PA_SelectEstado(ID_Estado).ToList();
        }
        public PA_SelectImagen__Result SeleccionarImagen(int ID_Imagen)
        {
            return contexto.PA_SelectImagen_(ID_Imagen).First();
        }
        public PA_SelectCotizacion_Result SeleccionarCotizacion(int ID_Cotizacion)
        {
            return contexto.PA_SelectCotizacion(ID_Cotizacion).FirstOrDefault();
        }
        public List<PA_SelectCotizacion_Result> SeleccionarCotizacionList()
        {
            int ID_Cotizacion = -1;
            return contexto.PA_SelectCotizacion(ID_Cotizacion).ToList();
        }
        public PA_SelectCotizacionRespuesta_Result SeleccionarCotizacionRespuesta(int ID_Cotizacion)
        {
            return contexto.PA_SelectCotizacionRespuesta(ID_Cotizacion).FirstOrDefault();
        }
        public List<PA_SelectCotizacionRespuesta_Result> SeleccionarCotizacionRespuestaLista(int ID_Cotizacion)
        {
            return contexto.PA_SelectCotizacionRespuesta(ID_Cotizacion).ToList();
        }
        public PA_SelectAyuda_Result SeleccionarAyuda(int ID_Ayuda)
        {
            return contexto.PA_SelectAyuda(ID_Ayuda).First();
        }
        public List<PA_SelectAyuda_Result> SeleccionarAyudaList()
        {
            int ID_Ayuda = -1;
            return contexto.PA_SelectAyuda(ID_Ayuda).ToList();
        }
        public PA_SelectUsuario_Result SeleccionarUsuario(int ID)
        {
            return contexto.PA_SelectUsuario(ID).First();
        }
        public List<PA_SelectUsuario_Result> SeleccionarUsuarioListas()
        {
            int ID = -1;
            return contexto.PA_SelectUsuario(ID).ToList();
        }
        public PA_SelectUsuarioVerificar_Result SeleccionarUsuarioVerificar(int ID)
        {
            return contexto.PA_SelectUsuarioVerificar(ID).First();
        }
        public PA_SelectCorreoVerificacion_Result SeleccionarCorreoVerificar(string Correo)
        {
            return contexto.PA_SelectCorreoVerificacion(Correo).First();
        }
    }
    public class Modifica
    {
        private Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();
        public int ModificarPerfil(int ID, string Perfil)
        {
            return contexto.PA_ActualizarPerfil(ID,Perfil).GetHashCode();
        }
        public int ModificarImagen(int ID, byte[] Imagen)
        {
            return contexto.PA_ActualizarImagen_(ID,Imagen).GetHashCode();
        }
        public int ModificarCategoria(int ID, string Nombre)
        {
            return contexto.PA_ActualizarCategoria(ID,Nombre).GetHashCode();
        }
        public int ModificarHistoria(byte ID, string Historia, string Mision, string Vision)
        {
            return contexto.PA_ActualizarHistoria(ID,Historia,Mision,Vision).GetHashCode();
        }
        public int ModificarProducto(int ID, int ID_Imagen, byte[] Imagen, int Categoria, string Nombre, string Descripcion, int Estado)
        {
            ModificarImagen(ID,Imagen);

            return contexto.PA_ActualizarProducto(ID,Categoria, ID_Imagen, Nombre,Descripcion,Estado).GetHashCode();
        }
        public int ModificarPromocion(int ID, int ID_Imagen, byte[] Imagen, string Nombre, string Descripcion, int Estado, DateTime Fecha_Inicio, DateTime Fecha_Final)
        {
            ModificarImagen(ID_Imagen,Imagen);

            return contexto.PA_ActualizarPromocion(ID,ID_Imagen,Nombre,Descripcion,Estado,Fecha_Inicio,Fecha_Final).GetHashCode();
        }
        public int ModificarEvento(int ID, int ID_Imagen, byte[] Imagen, string Nombre, string Descripcion, int Estado, DateTime Fecha_Inicio, DateTime Fecha_Final)
        {
            ModificarImagen(ID,Imagen);

            return contexto.PA_ActualizarEvento(ID, ID_Imagen, Nombre,Descripcion,Estado,Fecha_Inicio,Fecha_Final).GetHashCode();
        }
        public int ModificarAyuda(int ID, string Version, byte[] Manual_)
        {
            return contexto.PA_ActualizarAyuda(ID,Version,Manual_).GetHashCode();
        }
        public int ModificarUsuario(int ID_Usuario, byte ID_Perfil, string nombre, string Apellido1, string Apellido2, int estado, string correo)
        {
            return contexto.PA_ActualizarUsuario(ID_Usuario, ID_Perfil, nombre, Apellido1, Apellido2, estado, correo).GetHashCode();
        }
        public int ModificarContrasena(int ID, string Contrasena)
        {
            return contexto.PA_ActualizarContrasena(ID, Contrasena).GetHashCode();
        }
    }
    public class Elimina
    {
        private Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();
        public int EliminarPerfil(int ID)
        {
            return contexto.PA_EliminarPerfil(ID).GetHashCode();
        }
        public int EliminarEstado(int ID)
        {
            return contexto.PA_EliminarEstado(ID).GetHashCode();
        }
        public int EliminarImagen(int ID)
        {
            return contexto.PA_EliminarImagen(ID).GetHashCode();
        }
        public int EliminarCategoria(int ID)
        {
            return contexto.PA_EliminarCategoria(ID).GetHashCode();
        }
        public int EliminarHistoria(int ID)
        {
            return contexto.PA_EliminarHistoria(ID).GetHashCode();
        }
        public int EliminarProducto(int ID, int ID_Imagen)
        {
                return contexto.PA_EliminarProducto(ID,ID_Imagen).GetHashCode();
        }
        public int EliminarPromocion(int ID, int ID_Imagen)
        {
                return contexto.PA_EliminarPromocion(ID, ID_Imagen).GetHashCode();
        }
        public int EliminarEvento(int ID, int ID_Imagen)
        {
            return contexto.PA_EliminarEvento(ID, ID_Imagen).GetHashCode();
        }
        public int EliminarCotizacion(int ID)
        {
            return contexto.PA_EliminarCotizacion(ID).GetHashCode();
        }
        public int EliminarCotizacionRespuesta(int ID)
        {
            return contexto.PA_EliminarCotizacionRespuesta(ID).GetHashCode();
        }
        public int EliminarAyuda(int ID)
        {
            return contexto.PA_EliminarAyuda(ID).GetHashCode();
        }
        public int EliminarUsuario(int ID_Usuario)
        {
            return contexto.PA_EliminarUsuario(ID_Usuario).GetHashCode();
        }
    }

    //Variables de Asignar Historia -----------------------------------------------------------------------------------
    public class AsignarHistoria
    {
        [Required]
        [Display(Name = "Historia")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Historia { get; set; }

        [Required]
        [Display(Name = "Misión")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Mision { get; set; }

        [Required]
        [Display(Name = "Visión")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Vision { get; set; }
    }

    //Variables de Asignar Perfil
    public class AsignarPerfil
    {
        [Required]
        [Display(Name = "Nombre de Perfil")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Perfil { get; set; }
    }

    //Variables de Asignar Categoria
    public class AsignarCategoria
    {
        [Required]
        [Display(Name = "Nombre de Categoría")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Nombre { get; set; }
    }

    //Variables de Asignar Promoción
    public class AsignarPromoción
    {
        [Required]
        [Display(Name = "Imagen")]
        public HttpPostedFileBase Imagen { get; set; }

        [Required]
        [Display(Name = "Nombre de Promoción")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Descripción del Promoción")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime FechaFinal { get; set; }
    }

    //Variables de Asignar Evento
    public class AsignarEvento
    {
        [Required]
        [Display(Name = "Imagen")]
        public HttpPostedFileBase Imagen { get; set; }

        [Required]
        [Display(Name = "Nombre del Evento")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreEvento { get; set; }

        [Required]
        [Display(Name = "Descripción del Evento")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime FechaFinal { get; set; }
    }

    //Variables de Asignar Productos
    public class AsignarProducto
    {
        [Required]
        public int ID_Categoria { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public HttpPostedFileBase Imagen { get; set; }

        [Required]
        [Display(Name = "Nombre del Producto")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreProducto { get; set; }

        [Required]
        [Display(Name = "Descripción del Producto")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }
    }

    //Variable de Asignar Cotización Respuesta
    public class AsignarCotizaciónRespuesta
    {
        public int ID_Cotizacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        [Required]
        [Display(Name = "Asunto del Correo")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string AsuntoEnviar { get; set; }

        [Required]
        [Display(Name = "Descripción del Correo")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string DescripcionEnviar { get; set; }
    }

    //Variables de Asignar Ayuda
    public class AsignarAyuda
    {
        [Required]
        [Display(Name = "Versión de la página")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Version { get; set; }

        [Required]
        public HttpPostedFileBase Manual { get; set; }
    }

    //Variables de Modificar Historia ----------------------------------------------------------------------------------
    public class ModificarHistoria
    {
        [Required]
        public byte ID_Historia { get; set; }

        [Required]
        [Display(Name = "Historia")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Historia { get; set; }

        [Required]
        [Display(Name = "Misión")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Mision { get; set; }

        [Required]
        [Display(Name = "Visión")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Vision { get; set; }
    }

    //Variables de Modificar Perfil
    public class ModificarPerfil
    {
        [Required]
        public byte ID_Perfil { get; set; }

        [Required]
        [Display(Name = "Nombre de Perfil")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombrePerfil { get; set; }
    }

    //Variables de Modificar Categoria
    public class ModificarCategoria
    {
        [Required]
        public int ID_Categoria { get; set; }

        [Required]
        [Display(Name = "Nombre de Categoría")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreCategoria { get; set; }
    }

    //Variables de Promoción
    public class ModificarPromocion
    {
        [Required]
        public int ID_Promocion { get; set; }

        [Required]
        public int ID_Imagen_ { get; set; }

        [Required]
        public byte[] Imagen_ { get; set; }

        [Required]
        [Display(Name = "Nombre de Promoción")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombrePromocion { get; set; }

        [Required]
        [Display(Name = "Descripción del Promoción")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int ID_Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        [Display(Name = "Fecha Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Fecha_Final { get; set; }

        public HttpPostedFileBase Imagen { get; set; }
    }

    //Variables de Evento
    public class ModificarEvento
    {
        [Required]
        public int ID_Evento { get; set; }

        [Required]
        public int ID_Imagen_ { get; set; }

        [Required]
        public byte[] Imagen_ { get; set; }

        [Required]
        [Display(Name = "Nombre del Evento")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreEvento { get; set; }

        [Required]
        [Display(Name = "Descripción del Evento")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required]
        public int ID_Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        [Display(Name = "Fecha Final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Fecha_Final { get; set; }

        
        public HttpPostedFileBase Imagen { get; set; }

    }

    //Variables de Productos
    public class ModificarProducto
    {
        [Required]
        public int ID_Producto { get; set; }
        [Required]
        public int ID_Categoria { get; set; }
        [Required]
        public int ID_Imagen_ { get; set; }
        [Required]
        [Display(Name = "Imagen")]
        public byte[] Imagen_ { get; set; }
        [Required]
        [Display(Name = "Nombre del Producto")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreProducto { get; set; }
        [Required]
        [Display(Name = "Descripción del Producto")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required]
        public int ID_Estado { get; set; }
        public HttpPostedFileBase Imagen { get; set; }

    }

    //Variables de Ayuda
    public class ModificarAyuda
    {
        [Display(Name = "ID de Ayuda")]
        public byte ID_Ayuda { get; set; }

        [Required]
        [Display(Name = "Versión de la página")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Version { get; set; }

        [Required]
        [Display(Name = "Manual")]
        public HttpPostedFileBase Manual { get; set; }
    }
    public class ModificarUsuario
    {
        [Required]
        public int ID_Usuario { get; set; }

        [Required]
        public int ID_Perfil { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string NombreUsuario { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Apellido1 { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Apellido2 { get; set; }

        [Required]
        public int ID_Estado { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        [StringLength(100, ErrorMessage = "El correo no puede estar vacío.")]
        public string correo { get; set; }
    }
    public class ModificarContrasena
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        [StringLength(100, ErrorMessage = "El correo no puede estar vacío.")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Contrasena { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña de confirmación")]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ContrasenaVerifica { get; set; }
    }

    //Variables de Eliminar Historia----------------------------------------------------------------------------------------------------------
    public class EliminarHistoria
    {
        [Required]
        public byte ID_Historia { get; set; }
    }

    //Variables de Eliminar Perfil
    public class EliminarPerfil
    {
        [Required]
        public byte ID_Perfil { get; set; }
    }

    //Variables de Eliminar Categoria
    public class EliminarCategoria
    {
        [Required]
        public int ID_Categoria { get; set; }
    }

    //Variables de Eliminar Producto
    public class EliminarProducto
    {
        [Required]
        public int ID_Producto { get; set; }

        [Required]
        public int ID_Imagen { get; set; }
    }

    //Variables de Eliminar Evento
    public class EliminarEvento
    {
        [Required]
        public int ID_Evento { get; set; }

        [Required]
        public int ID_Imagen { get; set; }
    }

    //Variables de Eliminar Promoción
    public class EliminarPromocion
    {
        [Required]
        public int ID_Promocion { get; set; }

        [Required]
        public int ID_Imagen { get; set; }
    }

    //Variables de Eliminar Cotizacion
    public class EliminarCotizacion
    {
        [Required]
        public int ID_Cotizacion { get; set; }
    }

    //Variables de Eliminar Cotizacion Respuesta
    public class EliminarCotizacionRespuesta
    {
        [Required]
        public int ID_CotizacionRespuesta { get; set; }
    }
    //Variables de Eliminar Usuario
    public class EliminarUsuario
    {
        [Required]
        public int ID_Usuario { get; set; }
    }
    public class EliminarAyuda
    {
        [Required]
        public int ID_Ayuda { get; set; }
    }
}