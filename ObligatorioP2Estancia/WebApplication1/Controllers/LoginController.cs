using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        Sistema unS = Sistema.Instancia;

        public IActionResult Logaut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Empleado unE = unS.DevolverEmpleado(email, password);
            if (unE != null)
            {
                // Limpiar la sesión antes de establecer nueva información
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("Usuario", unE.Nombre);
                HttpContext.Session.SetString("Email", unE.Email);
                HttpContext.Session.SetString("Rol", unE.GetType().ToString().Split(".")[1]);
                ViewBag.nombre = unE.Nombre;
                ViewBag.rol = HttpContext.Session.GetString("Rol");
                if (ViewBag.rol == "Peon")
                {
                    return RedirectToAction("PeonVista", new { nombre = unE.Nombre });
                }
                else
                {
                    return RedirectToAction("CapatazVista", new { nombre = unE.Nombre });
                }
                
            }
            else
            {
                ViewBag.Mensaje = "Credenciales Incorrectas.";
                return View();
            }
        }
        public IActionResult PeonVista(string nombre)
        {
            if (nombre != null)
            {
                ViewBag.nombre = nombre;
                ViewBag.rol = HttpContext.Session.GetString("Rol");
                List<Empleado> peones = unS.ObtenerPeones();
                if (peones.Count == 0)
                {
                    ViewBag.error = "Lista Vacía.";
                }

                ViewBag.peones = peones;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult CapatazVista(string nombre)
        {
            if (nombre != null)
            {
                ViewBag.nombre = nombre;
                ViewBag.rol = HttpContext.Session.GetString("Rol");
                List<Empleado> capataz = unS.ObtenerCapataz();
                if (capataz.Count == 0)
                {
                    ViewBag.error = "Lista Vacía.";
                }

                ViewBag.capataz = capataz;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
