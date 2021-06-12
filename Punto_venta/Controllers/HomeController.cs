using Punto_venta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punto_venta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Usuario");
            Usuario user = (Usuario)Session["Usuario"];
            ViewBag.Usuario = user.des_usuario;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}