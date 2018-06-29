using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRegistroCasillas.Models;

namespace WebRegistroCasillas.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var uBLL = new UsuarioBLL();
            var users = uBLL.RetrieveAll();

            return View(users);
        }

        public ActionResult Create()
        {
            Usuario usuario = new Usuario();

            SelectListItem item = new SelectListItem()
            {
                Value = "A",
                Text = "Administrador"
            };

            SelectListItem item2 = new SelectListItem()
            {
                Value = "C",
                Text = "Capturista"
            };

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(item);
            selectListItems.Add(item2);

            ViewBag.tipo = new SelectList(selectListItems, "Value", "Text");

            return PartialView("_Create", usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _Create(Usuario usuario)
        {
            ResponseModel result = new ResponseModel();
            {
                result.respuesta = false;
                result.redirect = "";
                result.mensaje = "";
            }
            try
            {
                Guid g = Guid.NewGuid();
                usuario.idUsuario = g.ToString();
                usuario.fechaCreacion = DateTime.Now;
                if (ModelState.IsValid)
                {
                    var oBLL = new UsuarioBLL();
                    oBLL.Create(usuario);
                    result.respuesta = true;
                    result.mensaje = "El usuario se creó correctamente";
                }
                else
                {
                    result.mensaje = "Favor de revisar los datos";
                }
            }
            catch (Exception ex)
            {
                result.mensaje = "Error al agregar al usuario: " + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(string id)
        {
            var uBLL = new UsuarioBLL();
            Usuario usuario = uBLL.RetrieveByIdUsuario(id);

            SelectListItem item = new SelectListItem()
            {
                Value = "A",
                Text = "Administrador"
            };

            SelectListItem item2 = new SelectListItem()
            {
                Value = "C",
                Text = "Capturista"
            };

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(item);
            selectListItems.Add(item2);

            ViewBag.tipo = new SelectList(selectListItems, "Value", "Text", usuario.tipo);

            return PartialView("_Edit", usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _Edit(Usuario usuario)
        {
            ResponseModel result = new ResponseModel();
            {
                result.respuesta = false;
                result.redirect = "";
                result.mensaje = "";
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var oBLL = new UsuarioBLL();
                    oBLL.Update(usuario);
                    result.respuesta = true;
                    result.mensaje = "El usuario se actualizó correctamente";
                }
                else
                {
                    result.mensaje = "Favor de teclear todos los campos";
                }
            }
            catch (Exception ex)
            {
                result.mensaje = "Error al actualizar al usuario: " + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(string id)
        {
            ResponseModel result = new ResponseModel();
            {
                result.respuesta = false;
                result.redirect = "";
                result.mensaje = "";
            }
            try
            {
                var oBLL = new UsuarioBLL();
                bool bEliminar = oBLL.Delete(id);
                if (bEliminar)
                {
                    result.respuesta = true;
                    result.mensaje = "El Usuario se eliminó correctamente";
                }
                else
                {
                    result.mensaje = "Error a eliminar al usuario";
                }
            }
            catch (Exception ex)
            {
                result.mensaje = "Error al eliminar al usuario: " + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerUsuario(string id)
        {
            var oBLL = new UsuarioBLL();
            var usuario = oBLL.RetrieveByIdUsuario(id);

            if (usuario == null)
            {
                return new HttpNotFoundResult();
            }

            return PartialView("_UsuarioDelete.ModalPreview", usuario);
        }

        public ActionResult ObtenerUsuarios()
        {
            var oBLL = new UsuarioBLL();
            List<Usuario> usuarios = oBLL.RetrieveAll();
            return PartialView("_Usuarios", usuarios);
        }
    }
}