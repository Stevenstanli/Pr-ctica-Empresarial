using System.Web;
using System.Web.Mvc;
using Practica_Empresarial.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Practica_Empresarial.Controllers
{
    [Authorize]
    public class CuentaController : Controller
    {
        CuentaVistaModelo Datos = new CuentaVistaModelo();
        Encrypt Pass = new Encrypt();
        public ActionResult EtiquetaRegistroUsuario()
        {
            ViewBag.Titulo = "Registro Nuevo Usuario";
            ViewBag.Perfil = "Perfil";
            ViewBag.Nombre = "Nombre";
            ViewBag.Apellido1 = "Primer Apellido";
            ViewBag.Apellido2 = "Segundo Apellido";
            ViewBag.Correo = "Correo";
            ViewBag.Contrasena = "Contraseña";
            ViewBag.ContrasenaVerfificar = "Contraseña";
            return View();
        }
        public ActionResult EtiquetaSesion()
        {
            ViewBag.Titulo = "Inicio Sesión";
            ViewBag.Correo = "Correo";
            ViewBag.Contrasena = "Contraseña";
            return View();
        }
        [AllowAnonymous]
        public ActionResult CrearUsuario()
        {
            EtiquetaRegistroUsuario();
            ViewBag.ListaPerfil = new SelectList(Datos.SeleccionarPerfil(), "ID_Perfil", "NombrePerfil");
            ViewBag.ListaEstado = new SelectList(Datos.SeleccionarEstadoList(), "ID_Estado", "NombreEstado");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(AsignarRegistroUsuario m)
        {
            if (m.Contrasena.Equals(m.ContrasenaVerificar))
            {
                string Contrasena = Pass.GetSHA256(m.Contrasena);
                decimal contexto = Datos.RegistroInicioSesion(m.Perfil, m.Nombre, m.Apellido1, m.Apellido2, 1, m.Correo, Contrasena);
                if (contexto.Equals(null))
                {
                    return RedirectToAction("CrearUsuario");
                }
                else
                {
                    return RedirectToAction("InicioSesion");
                }
            }
            else
            {
                ViewBag.Incorrecto = "Contraseña no es igual";
                return View();
            }
        }

        // GET: Inicio de Sesion
        [AllowAnonymous]
        public ActionResult InicioSesion()
        {
            EtiquetaSesion();
            return View();
        }
        // POST: Inicio de Sesion
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult InicioSesion(IniciosesionVistaModelo m)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(m);
            //}
            string Contrasena = Pass.GetSHA256(m.Contrasena);
            try
            {
                var contexto = Datos.SeleccionarInicioSesion(m.Correo, Contrasena);
                if(contexto.ID_Estado == 1)
                {
                    IdentitySignin(contexto.ID_Usuario.ToString(), contexto.NombreUsuario, contexto.ID_Perfil.ToString());
                    return RedirectToAction("Principal", "Administrador");
                }
                else
                {
                    ViewBag.Aviso = 2;
                    return View(m);
                }
                  
            }
            catch (Exception)
            {
                EtiquetaSesion();
                ViewBag.Aviso = 1;
                return View(m);
            }
        }

        public void IdentitySignin(string id,string Nombre,string Perfil, string providerKey = null, bool isPersistent = false)
        {
            var claims = new List<Claim>();

            // create *required* claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
            claims.Add(new Claim(ClaimTypes.Name, Nombre));
            claims.Add(new Claim(ClaimTypes.Role, Perfil));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var sim = HttpContext;
            var Aut = sim.GetOwinContext();
            var AuthenticationManager = Aut.Authentication;
            // add to user here!
            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            }, identity);
        }

        public void IdentitySignout()
        {
            var Aut = Request.GetOwinContext();
            var AuthenticationManager = Aut.Authentication;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                          DefaultAuthenticationTypes.ExternalCookie);
        }

        // Generador de errores
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Redireccionamiento a página Principal
        private ActionResult RedireccionarPaginaPrincipal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Principal");
        }

        // POST: /Cuenta/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Principal");
        }

        // Maneja  la Administración de la cookie de seguimiento de Usuarios que asocia a un Usuario con la Cuenta.
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}
