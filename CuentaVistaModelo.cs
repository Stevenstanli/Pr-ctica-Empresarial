using Practica_Empresarial.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Practica_Empresarial.Models
{
    public class Encrypt
    {
        public string GetSHA256(string Contrasena)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(Contrasena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
    public class CuentaVistaModelo
    {
        Practica_EmpresarialBDEntities contexto = new Practica_EmpresarialBDEntities();

        //Variables de Iniciar de Sesion
        public PA_SelectInicioSesion_Result SeleccionarInicioSesion(string user, string contrasena)
        {
            return contexto.PA_SelectInicioSesion(user, contrasena).First();
        }

        public List<PA_SelectPerfil_Result> SeleccionarPerfil()
        {
            int ID = -1;
            return contexto.PA_SelectPerfil(ID).ToList();
        }

        public List<PA_SelectEstado_Result> SeleccionarEstadoList()
        {
            int ID_Estado = -1;
            return contexto.PA_SelectEstado(ID_Estado).ToList();
        }

        // Variables de Registrar Usuario y Registrar Inicio Sesion
        public decimal RegistroInicioSesion(int Perfil, string nombre, string apellido1, string apellido2, int estado, string correo, string contrasena)
        {
            decimal variable = contexto.PA_InsertaUsuario(Perfil, nombre, apellido1, apellido2, estado, correo).First().Value;
            return contexto.PA_InsertaInicioSesion(Convert.ToInt32(variable), contrasena).First().Value;
        }
    }
    // Variables de Inicio Sesion
    public class IniciosesionVistaModelo
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }

    //Variables de Registro
    public class AsignarRegistroUsuario
    {
        [Required]
        public byte Perfil { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Apellido1 { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Apellido2 { get; set; }

        [Required]
        public int Estado { get; set; }

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
        public string ContrasenaVerificar { get; set; }
    }

    //Variables de Reseteo de Contraseña
    public class ReseteoContrasenaVistaModelo
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        [StringLength(100, ErrorMessage = "El correo no puede estar vacío.")]
        public string Correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmarContrasena { get; set; }

        public string Codigo { get; set; }
    }

    //Variables de Olvido la contraseña
    public class OlvidoContrasenaVistaModelo
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
    }

    //Variables de Cambio de Contraseña
    public class CambioContrasenaVistaModelo
    {
        [Required]
        [DataType(DataType.Password)]
        public string ContrasenaAnterior { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ContrasenaNueva { get; set; }

        [DataType(DataType.Password)]
        [Compare("ContrasenaNueva", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
        public string ConfirmarContrasena { get; set; }
    }
}