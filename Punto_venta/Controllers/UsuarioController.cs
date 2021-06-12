using Newtonsoft.Json;
using Punto_venta.Helpers;
using Punto_venta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punto_venta.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult ValidarUsuario(string usuario, string psw) {            
            try
            {
                string json="";
                FuntionsAuthentication authentication = new FuntionsAuthentication();
                Usuario user = authentication.ObtenerUsuario(usuario, psw);
                if(user.id_usuario != 0)
                {
                    Session["Usuario"] = user;
                    json = JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented);
                    return Content(json, "application/json");
                }                                
                return Json(new { Estatus_Respuesta = "ERROR", Mensaje_Respuesta = "El usuario o la contraseña no es correcta"});
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return Json(new { Estatus_Respuesta = "ERROR", Mensaje_Respuesta = ex.Message });
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Models.Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Session["Usuario"] = usuario;
                    return RedirectToAction("Index", "Home");
                }                    
                return View(usuario);
            }
            catch
            {
                return View();
            }
        }
              
    }
}
