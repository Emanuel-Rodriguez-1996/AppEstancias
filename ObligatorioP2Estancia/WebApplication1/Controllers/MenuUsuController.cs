using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace WebApplication1.Controllers
{
    public class MenuUsuController : Controller
    {
        Sistema unS = Sistema.Instancia;
        public IActionResult Inicio(string nombre)
        {
            return View();
        }
        public IActionResult Registrarse(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult Registrarse(Peon unP)
        {
            try
            {
                if (unP != null)
                {
                    unS.VerificarEmpleadoNoExiste(unP);
                    unS.AgregarEmpleado(unP);

                    // Establecer sesiones y variables para mostrar en la vista
                    HttpContext.Session.SetString("Usuario", unP.Nombre);
                    HttpContext.Session.SetString("Rol", unP.GetType().ToString().Split(".")[1]);
                    HttpContext.Session.SetString("Email", unP.Email);

                    
                    ViewBag.nombre = unP.Nombre;
                    ViewBag.email = unP.Email;
                    ViewBag.rol = HttpContext.Session.GetString("Rol");
                    ViewBag.residente = unP.Residente;
                    ViewBag.fechaIng = unP.FechaIngreso = DateTime.Now; 
                    ViewBag.tareas = unP.Tareas;

                    
                    return RedirectToAction("PeonVista", "Login", new { nombre = unP.Nombre });
                }
                else
                {
                    ViewBag.error = "Credenciales Incorrectas.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error al agregar Peon: " + ex.Message;
                return View();
            }
        }
    }
}
