using BLL;
using Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebRegistroCasillas.Models;

namespace WebRegistroCasillas.Controllers
{
    public class HomeController : Controller
    {
        private string idUsuario = "";
        private string Rol = "";

        public HomeController()
        {
            ClaimsPrincipal Principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            if (Principal != null && Principal.Identity.IsAuthenticated)
            {
                var Claims = Principal.Claims.ToList();
                idUsuario = Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                Rol = Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Error = null;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login login)
        {
            ActionResult Result;

            if(login.UsernameLogin != null && login.PasswordLogin != null)
            {
                var uBLL = new UsuarioBLL();
                var User = uBLL.Authentication(login.UsernameLogin, login.PasswordLogin);

                if (User != null)
                {
                    Result = SignInUser(User, login.Type);
                }
                else
                {
                    ViewBag.Error = "Los datos proporcionados no son correctos";
                    Result = View("Index");
                }
            }
            else
            {
                ViewBag.Error = null;
                Result = View("Index");
            }

            return Result;
        }

        [Authorize]
        public ActionResult Register(string id, string message)
        {
            var sBLL = new SeccionBLL();

            RCasilla casilla = new RCasilla();

            Guid g = Guid.NewGuid();

            casilla.idRegistroCasilla = g.ToString();
            casilla.tipoEleccion = id;
            casilla.fecha = DateTime.Now;
            casilla.idUsuario = idUsuario;
            casilla.Editable = false;

            var secciones = sBLL.RetrieveSeccions();
            ViewBag.seccion = new SelectList(secciones);
            ViewBag.casilla = new SelectList(Enumerable.Empty<SelectListItem>());
            string tipo = "";

            ViewBag.Message = message;

            if (id == "A")
                tipo = "PRESIDENTE MUNICIPAL";
            else
                if (id == "D")
                    tipo = "DIPUTADOS LOCALES";
                else
                    if (id == "F")
                        tipo = "DIPUTADOS FEDERALES";
                    else
                        if (id == "S")
                            tipo = "SENADORES";
                        else
                            if (id == "P")
                                tipo = "PRESIDENTES";
                            else
                                return View("Index");

            ViewBag.Tipo = tipo;

            var oRR = new EstadoCasillaRepository();
            List<EstadoCasilla> estados = new List<EstadoCasilla>();

            if (Rol != null)
            {
                if(Rol == "A")
                {
                    estados = oRR.RetrieveAllEstadosCasilla();
                }

                if(Rol == "C")
                {
                    estados = oRR.RetrieveAllEstadosCasillaCapturista();
                }
            }

            ViewBag.status = new SelectList(estados, "idEstado", "descripcion", "A");

            return View(casilla);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RCasilla rCasilla)
        {
            var rcBLL = new RCasillaBLL();

            if(ModelState.IsValid)
            {
                Guid g = Guid.NewGuid();
                rCasilla.idRegistroCasilla = g.ToString();
                rCasilla.fecha = DateTime.Now;
                rcBLL.Create(rCasilla);
                return RedirectToAction("Register", new { id = rCasilla.tipoEleccion, message = "El registro se guardó exitosamente." });
            }
            else
            {
                var sBLL = new SeccionBLL();
                var secciones = sBLL.RetrieveSeccions();
                ViewBag.seccion = new SelectList(secciones);
                ViewBag.casilla = new SelectList(Enumerable.Empty<SelectListItem>());
                string tipo = "";

                if (rCasilla.tipoEleccion == "A")
                    tipo = "PRESIDENTE MUNICIPAL";
                else
                if (rCasilla.tipoEleccion == "D")
                    tipo = "DIPUTADOS LOCALES";
                else
                    if (rCasilla.tipoEleccion == "F")
                    tipo = "DIPUTADOS FEDERALES";
                else
                    if (rCasilla.tipoEleccion == "S")
                    tipo = "SENADORES";
                else
                            if (rCasilla.tipoEleccion == "P")
                    tipo = "PRESIDENTES";
                else
                    return View("Index");

                ViewBag.Tipo = tipo;

                var oRR = new EstadoCasillaRepository();
                List<EstadoCasilla> estados = new List<EstadoCasilla>();

                if (Rol != null)
                {
                    if (Rol == "A")
                    {
                        estados = oRR.RetrieveAllEstadosCasilla();
                    }

                    if (Rol == "C")
                    {
                        estados = oRR.RetrieveAllEstadosCasillaCapturista();
                    }
                }

                ViewBag.status = new SelectList(estados, "idEstado", "descripcion", "A");

                return View();
            }
        }

        [Authorize]
        public ActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Menu(string type)
        {
            return RedirectToAction("Register", "Home", new { id = type, message = "null" });
        }

        [Authorize]
        public ActionResult Update(string idRCasilla)
        {
            var sBLL = new SeccionBLL();
            var rcBLL = new RCasillaBLL();

            RCasilla casilla = rcBLL.RetrieveByIdRCasilla(idRCasilla);
            casilla.Editable = false;

            Guid g = Guid.NewGuid();

            var secciones = sBLL.RetrieveSeccions();
            var casillas = sBLL.RetrieveBySeccion(casilla.Seccione.seccion);
            ViewBag.seccion = new SelectList(secciones, casilla.Seccione.seccion);
            ViewBag.casilla = new SelectList(casillas, "idSeccion", "casilla", casilla.Seccione.casilla);
            string tipo = "", id = casilla.tipoEleccion;
            
            if (id == "A")
                tipo = "PRESIDENTE MUNICIPAL";
            else
                if (id == "D")
                tipo = "DIPUTADOS LOCALES";
            else
                    if (id == "F")
                tipo = "DIPUTADOS FEDERALES";
            else
                if (id == "S")
                tipo = "SENADORES";
            else
                            if (id == "P")
                tipo = "PRESIDENTES";
            else
                return View("Index");

            var oRR = new EstadoCasillaRepository();
            List<EstadoCasilla> estados = new List<EstadoCasilla>();

            if (Rol != null)
            {
                if (Rol == "A")
                {
                    estados = oRR.RetrieveAllEstadosCasilla();
                }

                if (Rol == "C")
                {
                    estados = oRR.RetrieveAllEstadosCasillaCapturista();
                }
            }

            ViewBag.status = new SelectList(estados, "idEstado", "descripcion",casilla.status);

            ViewBag.Tipo = tipo;

            return PartialView("_Update", casilla);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RCasilla casilla)
        {
            var rcBLL = new RCasillaBLL();

            if(ModelState.IsValid)
            {
                try
                {
                    rcBLL.Update(casilla);
                    return RedirectToAction("Register", "Home", new { id = casilla.tipoEleccion, message = "El registro se ha actualizado correctamente." });
                }catch
                {
                    var sBLL = new SeccionBLL();

                    var secciones = sBLL.RetrieveSeccions();
                    var casillas = sBLL.RetrieveBySeccion(casilla.Seccione.seccion);
                    ViewBag.seccion = new SelectList(secciones, casilla.Seccione.seccion);
                    ViewBag.casilla = new SelectList(casillas, "idSeccion", "casilla", casilla.Seccione.casilla);
                    string tipo = "", id = casilla.tipoEleccion;

                    if (id == "A")
                        tipo = "PRESIDENTE MUNICIPAL";
                    else
                        if (id == "D")
                        tipo = "DIPUTADOS LOCALES";
                    else
                            if (id == "F")
                        tipo = "DIPUTADOS FEDERALES";
                    else
                        if (id == "S")
                        tipo = "SENADORES";
                    else
                            if (id == "P")
                        tipo = "PRESIDENTES";
                    else
                        return View("Index");

                    ViewBag.Tipo = tipo;

                    var oRR = new EstadoCasillaRepository();
                    List<EstadoCasilla> estados = new List<EstadoCasilla>();

                    if (Rol != null)
                    {
                        if (Rol == "A")
                        {
                            estados = oRR.RetrieveAllEstadosCasilla();
                        }

                        if (Rol == "C")
                        {
                            estados = oRR.RetrieveAllEstadosCasillaCapturista();
                        }
                    }

                    ViewBag.status = new SelectList(estados, "idEstado", "descripcion", casilla.status);

                    return View();
                }
            }
            else
            {
                var sBLL = new SeccionBLL();

                var secciones = sBLL.RetrieveSeccions();
                var casillas = sBLL.RetrieveBySeccion(casilla.Seccione.seccion);
                ViewBag.seccion = new SelectList(secciones, casilla.Seccione.seccion);
                ViewBag.casilla = new SelectList(casillas, "idSeccion", "casilla", casilla.Seccione.casilla);
                string tipo = "", id = casilla.tipoEleccion;

                if (id == "A")
                    tipo = "PRESIDENTE MUNICIPAL";
                else
                    if (id == "D")
                    tipo = "DIPUTADOS LOCALES";
                else
                        if (id == "F")
                    tipo = "DIPUTADOS FEDERALES";
                else
                    if (id == "S")
                    tipo = "SENADORES";
                else
                            if (id == "P")
                    tipo = "PRESIDENTES";
                else
                    return View("Index");

                ViewBag.Tipo = tipo;

                var oRR = new EstadoCasillaRepository();
                List<EstadoCasilla> estados = new List<EstadoCasilla>();

                if (Rol != null)
                {
                    if (Rol == "A")
                    {
                        estados = oRR.RetrieveAllEstadosCasilla();
                    }

                    if (Rol == "C")
                    {
                        estados = oRR.RetrieveAllEstadosCasillaCapturista();
                    }
                }

                ViewBag.status = new SelectList(estados, "idEstado", "descripcion", casilla.status);

                return View();
            }
        }

        public JsonResult GetCasillasList(int seccion)
        {
            var sBLL = new SeccionBLL();
            var casillas = sBLL.RetrieveBySeccion(seccion);
            return Json(new SelectList(casillas, "idSeccion", "casilla"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CalculatePCIUD(int total, string idSeccion)
        {
            PCIUDModel model = new PCIUDModel();

            double pciud = 0.0;
            var sBLL = new SeccionBLL();
            var seccion = sBLL.RetrieveByIdSeccion(idSeccion);
            double listaN = seccion.listaNominal;

            if (seccion != null)
            {
                pciud = (total / listaN) * 100;
            }

            model.pciud = pciud;
            model.listaNominal = seccion.listaNominal;

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsRegister(string idSeccion, string tipo)
        {
            RCasilla result = null;
            var rBLL = new RCasillaBLL();
            result = rBLL.VerificarExistente(idSeccion, tipo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesbloquearEditable(string idRegistroCasilla)
        {
            bool Result = false;
            var rBLL = new RCasillaBLL();
            var casilla = rBLL.RetrieveByIdRCasilla(idRegistroCasilla);
            casilla.Editable = true;
            try
            {
                rBLL.Update(casilla);
                Result = true;
            }
            catch
            {
                Result = false;
            }
            
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        private ActionResult SignInUser(Usuario User, string type)
        {
            string returnUrl  = Url.Action("Register", "Home", new { id = type, message = "null" }, null);
            ActionResult Result;

            var Claims = new List<Claim>();

            Claims.Add(new Claim(ClaimTypes.NameIdentifier, User.idUsuario));
            Claims.Add(new Claim(ClaimTypes.Email, User.username));
            Claims.Add(new Claim(ClaimTypes.Name, User.nombreCompleto));
            Claims.Add(new Claim("Type", type));
            Claims.Add(new Claim(ClaimTypes.Role, User.tipo));

            var Identity = new ClaimsIdentity(Claims, DefaultAuthenticationTypes.ApplicationCookie);

            IAuthenticationManager AuthenticationManager = HttpContext.GetOwinContext().Authentication;

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                IsPersistent = true
            }, Identity);

            Result = Redirect(returnUrl);
            return Result;
        }

        public ActionResult LogOff()
        {
            IAuthenticationManager AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

    }
}