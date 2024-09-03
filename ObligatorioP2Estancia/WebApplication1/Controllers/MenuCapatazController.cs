using System;
using System.Formats.Tar;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class MenuCapatazController : Controller
    {
        Sistema unS = Sistema.Instancia;
        public IActionResult RegistrarBovino(string mensaje = "", string error = "")
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }

            List<Potrero> listPotreros = unS.ObtenerPotreros();
            ViewBag.potreros = listPotreros;
            ViewBag.mensaje = mensaje;
            ViewBag.error = error;

            return View();
        }

        [HttpPost]
        public IActionResult RegistrarBovino(Bovino unA)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                
                return RedirectToAction("AccesoNoAutorizado");
            }

            List<Potrero> listPotreros = unS.ObtenerPotreros();
            ViewBag.potreros = listPotreros;

            try
            {
                if (unA != null)
                {
                    unS.AgregarAnimal(unA);
                    return RedirectToAction("RegistrarBovino", new { mensaje = "Animal agregado correctamente." });
                }
                else
                {
                    return RedirectToAction("RegistrarBovino", new { error = "Error: El animal es nulo." });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("RegistrarBovino", new { error = "Error al agregar el animal: " + ex.Message });
            }
        }
        public IActionResult AsignarPotrero()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }

            List<Animal> listAnimales = unS.ObtenerAnimales();
            List<Potrero> listPotreros = unS.ObtenerPotreros();
            List<Animal> newAux = new List<Animal>();
            foreach (Animal animal in listAnimales)
            {
                if (animal.Potrero == null)
                {
                    newAux.Add(animal);
                }
            }

            ViewBag.animalLibre = newAux;
            ViewBag.animales = listAnimales;
            ViewBag.listPotreros = listPotreros;

            return View();
        }
        [HttpPost]
        public IActionResult AsignarPotrero(int potrero, string codAnimal)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }

            try
            {
                Potrero unP = unS.BuscarPotrero(potrero);
                Animal unA = unS.BuscarAnimal(codAnimal);

                if (unP != null && unA != null)
                {
                    unS.AgregarPotreroEnAnimal(codAnimal, unP);
                    ViewBag.mensaje = $"Animal {codAnimal} asignado correctamente al potrero {unP.Descripcion}.";
                }
                else
                {
                    ViewBag.error = "No se encontró el potrero o el animal especificado.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }

            List<Animal> listAnimales = unS.ObtenerAnimales();
            List<Potrero> listPotreros = unS.ObtenerPotreros();
            List<Animal> aux = new List<Animal>();

            foreach (Animal animal in listAnimales)
            {
                if (animal.Potrero == null)
                {
                    aux.Add(animal);
                }
            }

            ViewBag.animalLibre = aux;
            ViewBag.listPotreros = listPotreros;

            return View();
        }
        public IActionResult ListPeones()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }

            List<Empleado> listPeones = unS.ObtenerPeones();
            
            if (listPeones.Count == 0)
            {
                ViewBag.error = "Lista Vacia.";
            }
            ViewBag.peones = listPeones;
            return View();
        }
        [HttpPost]
        public IActionResult ListPeones(string email)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            Empleado unE = unS.BuscarEmpleado(email);
            Peon unP = unE as Peon;

            if (unP != null)
            {
                return RedirectToAction("TareasPeon", new { email = email });
            }
            else
            {
                ViewBag.error = "Error";
                return View();
            }
        }
        public IActionResult TareasPeon(string email)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            Empleado unE = unS.BuscarEmpleado(email);
            Peon unP = unE as Peon;
            List<Tarea> tareas = unP.Tareas;

            ViewBag.peon = unP;
            ViewBag.email = unP.Email;
            ViewBag.contraseña = unP.Contraseña;
            ViewBag.tareas = tareas;

            return View();
        }
        [HttpPost]
        public IActionResult TareasPeon(string email, string contraseña)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            Empleado unE = unS.DevolverEmpleado(email, contraseña);
            Peon unP = unE as Peon;
            return RedirectToAction("AsignarTarea", new { peonEmail = unP.Email });
        }
        public IActionResult AsignarTarea(string peonEmail)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            Empleado unE = unS.BuscarEmpleado(peonEmail);
            Peon unP = unE as Peon;
            ViewBag.peon = unP;
            ViewBag.email = unP.Email;
            return View();
        }
        [HttpPost]
        public IActionResult AsignarTarea(Tarea unaT, string email)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            try
            {
                Empleado unE = unS.BuscarEmpleado(email);

                if (unE != null)
                {
                    Peon unP = unE as Peon;

                    if (unP != null)
                    {
                        //Agrego 2ble tarea por que si es 1 no la muestra????
                        unS.AgregarTarea(unaT);
                        unP.Tareas.Add(unaT);
                        unS.AgregarTareaAPeon(email, unaT);
                        ViewBag.mensaje = $"Tarea '{unaT.Descripcion}' asignada correctamente a '{unP.Nombre}'.";
                    }
                    else
                    {
                        throw new Exception("El empleado encontrado no es un peón.");
                    }
                }
                else
                {
                    throw new Exception("No se encontró un empleado con ese email.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error al agregar tarea: " + ex.Message;
            }
            return View();
        }
        public IActionResult ListPotreros(string mensaje)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            List<Potrero> potrerosList = unS.ObtenerPotreros();
            ViewBag.mensaje = mensaje;
            if (potrerosList.Count == 0)
            {
                ViewBag.error = "Lista Vacia.";
            }
            else
            {
                potrerosList.Sort((p1, p2) => p1.CapMax.CompareTo(p2.CapMax));

                potrerosList.Sort((p1, p2) => p2.Animales.Count.CompareTo(p1.Animales.Count));
            }
            ViewBag.potreros = potrerosList; 
            return View();
        }
        public IActionResult ListAnimales()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ListAnimales(string tipo, int peso)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Capataz")
            {
                return RedirectToAction("AccesoNoAutorizado");
            }
            List<Animal> listAnimales = unS.ObtenerAnimales();
            List<Animal> animalesFiltrados = new List<Animal>();

            if (listAnimales.Count == 0)
            {
                ViewBag.error = "Lista Vacia.";
            }
            else
            {
                foreach (Animal animal in listAnimales)
                {
                    if ((tipo == "ovino" && animal.GetType() == typeof(Ovino)) ||
                        (tipo == "bovino" && animal.GetType() == typeof(Bovino)))
                    {
                        if (animal.Peso > peso)
                        {
                            animalesFiltrados.Add(animal);
                        }
                    }
                }
                ViewBag.animales = animalesFiltrados;
            }

            return View();
        }
        public IActionResult AccesoNoAutorizado()
        {
            ViewBag.mensaje = "Acceso no Autorizado";
           return View();
        }
    }
}
