using System.ComponentModel.DataAnnotations;
using System.Linq;
using Practica_Empresarial.Datos;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Practica_Empresarial.Models
{
    public class DatosVistaModelo
    {
        private Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();
        public PA_SelectHistoria_Result SeleccionarHistoria()
        {
            return contexto.PA_SelectHistoria().First();
        }
        public PA_SelectCategoria_Result SeleccionarCategoria(int id)
        {
            return contexto.PA_SelectCategoria(id).First();
        }
        public List<PA_SelectCategoria_Result> SeleccionarCategoriaListas()
        {
            int id = -1;
            return contexto.PA_SelectCategoria(id).ToList();
        }
        public PA_SelectProductos_Result SeleccionarProductos(int id)
        {
            return contexto.PA_SelectProductos(id).First();
        }
        public List<PA_SelectProductos_Result> SeleccionarProductosListas()
        {
            int id = -1;
            return contexto.PA_SelectProductos(id).ToList();
        }
        public PA_SelectProductoVerificacion_Result SeleccionarProductosVerficacion(int id)
        {
            return contexto.PA_SelectProductoVerificacion(id).First();
        }
        public List<PA_SelectProductosXEstado_Result> SeleccionarProductosListasXEstado()
        {
            int id = -1;
            return contexto.PA_SelectProductosXEstado(id).ToList();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        public PA_SelectProductosXCategoria_Result SeleccionarProductosXCategoria(int id)
        {
            return contexto.PA_SelectProductosXCategoria(id).First();
        }
        public List<PA_SelectProductosXCategoria_Result> SeleccionarProductosXCategoriaListas()
        {
            int id = -1;
            return contexto.PA_SelectProductosXCategoria(id).ToList();
        }
        public List<PA_SelectProductosXCategoria_Result> SeleccionarProductosXCategoriaListasXIndice(int id)
        {
            return contexto.PA_SelectProductosXCategoria(id).ToList();
        }
        public List<PA_SelectProductosXCategoriaXEstado_Result> SeleccionarProductosXCategoriaListasXEstado(int id)
        {
            return contexto.PA_SelectProductosXCategoriaXEstado(id).ToList();
        }
        public List<PA_SelectProductosXCategoriaXEstado_Result> SeleccionarProductosListasXCategoriaXEstado()
        {
            int id = -1;
            return contexto.PA_SelectProductosXCategoriaXEstado(id).ToList();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        public PA_SelectPromocion_Result SeleccionarPromocion(int id)
        {
            return contexto.PA_SelectPromocion(id).First();
        }
        public List<PA_SelectPromocion_Result> SeleccionarPromocionListas()
        {
            int id = -1;
            return contexto.PA_SelectPromocion(id).ToList();
        }
        public List<PA_SelectPromocionXEstado_Result> SeleccionarPromocionListasXEstado()
        {
            int id = -1;
            return contexto.PA_SelectPromocionXEstado(id).ToList();
        }
        public PA_SelectPromocionVerificacion_Result SeleccionarPromocionVerificacion(int id)
        {
            return contexto.PA_SelectPromocionVerificacion(id).First();
        }
        public PA_SelectEvento_Result SeleccionarEvento(int id)
        {
            return contexto.PA_SelectEvento(id).First();
        }
        public List<PA_SelectEvento_Result> SeleccionarEventoListas()
        {
            int id = -1;
            return contexto.PA_SelectEvento(id).ToList();
        }
        public List<PA_SelectEventoXEstado_Result> SeleccionarEventoListasXEstado()
        {
            int id = -1;
            return contexto.PA_SelectEventoXEstado(id).ToList();
        }
        public PA_SelectEventoVerificacion_Result SeleccionarEventoVerificacion(int id)
        {
            return contexto.PA_SelectEventoVerificacion(id).First();
        }
        public int IngresarCotizacion(string Nombre, string Apellido1, string Apellido2, string Correo, int Telefono, string Asunto, string Descripcion)
        {
            return contexto.PA_InsertaCotizacion(Nombre, Apellido1, Apellido2, Correo, Telefono, Asunto, Descripcion).GetHashCode();
        }
        public PA_SelectImagen__Result SeleccionarImagen(int id)
        {
            return contexto.PA_SelectImagen_(id).First();
        }
    }
    //Variables de Asignar Cotización
    public class AsignarCotizacion
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Primer_Apellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Segundo_Apellido { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        [StringLength(100, ErrorMessage = "El correo no puede estar vacío.")]
        public string Correo { get; set; }

        [Required]
        [Phone]
        [StringLength(8, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 8)]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Asunto del Correo")]
        [StringLength(50, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Asunto { get; set; }

        [Required]
        [Display(Name = "Descripción del Correo")]
        [StringLength(500, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Descripcion { get; set; }
    }

}