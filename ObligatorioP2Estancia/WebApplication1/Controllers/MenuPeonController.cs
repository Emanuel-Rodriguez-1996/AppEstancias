using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace WebApplication1.Controllers
{
    public class MenuPeonController : Controller
    {
        Sistema unS = Sistema.Instancia;

        public IActionResult MiPerfil()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }
            List<Empleado> listpeones = unS.ObtenerPeones();
            string unE = HttpContext.Session.GetString("Usuario");
            string unEEmail = HttpContext.Session.GetString("Email");
            string unERol = HttpContext.Session.GetString("Rol");
           

            if (unE != null)
            {
            Empleado empleadoPeon = unS.BuscarEmpleadoNombre(unE);
            Peon unP = empleadoPeon as Peon;
                foreach(Peon unPeon in listpeones)
                {
                    if (unPeon.Nombre == unE && unPeon.Email == unEEmail)
                    {
                        ViewBag.rol = unERol;
                        ViewBag.nombre = unPeon.Nombre;
                        ViewBag.email = unPeon.Email;
                        ViewBag.contraseña = unPeon.Contraseña;
                        ViewBag.residente = unPeon.Residente ? "Si" : "No";
                        ViewBag.fechIng = unPeon.FechaIngreso.ToString("yyyy-MM-dd");
                    }

                }
            }
            return View();
        }
        public IActionResult VacunarAnimal()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }

            try
            {
                List<Animal> listAnimales = unS.ObtenerAnimales();
                List<Vacuna> listVacunas = unS.ObtenerVacunas();

                if (listAnimales.Count == 0)
                {
                    ViewBag.error = "Lista Vacia.";
                }

                ViewBag.animales = listAnimales;
                ViewBag.vacunas = listVacunas;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = $"Error al cargar los datos: {ex.Message}";
                return View();
            }
        }
        [HttpPost]
        public IActionResult VacunarAnimal(string codAnimal, string nombreVacuna)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }

            try
            {
                List<Animal> listAnimales = unS.ObtenerAnimales();
                List<Vacuna> listVacunas = unS.ObtenerVacunas();

                ViewBag.animales = listAnimales;
                ViewBag.vacunas = listVacunas;

                foreach (Animal unA in listAnimales)
                {
                    foreach (Vacuna unaV in listVacunas)
                    {
                        if (nombreVacuna == unaV.Nombre)
                        {
                            unS.AgregarVacunaEnAnimal(codAnimal, unaV);
                            return RedirectToAction("MostrarVacunasAnimal", new { codigoAnimal = codAnimal });
                        }
                    }
                }

                ViewBag.error = "No se encontró la vacuna especificada o hubo un problema al agregarla al animal.";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = $"Error al procesar la solicitud: {ex.Message}";
                return View();
            }
        }
        public IActionResult MostrarVacunasAnimal(string codigoAnimal)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }
            ViewBag.mensaje = "Vacuna agregada.";
            Animal unA = unS.BuscarAnimal(codigoAnimal);
            ViewBag.codigoAnimal = codigoAnimal;
            ViewBag.cantidadVacunasDelAnimal = unA.Vacunas; 

            return View();
        }
        public IActionResult Tareas()
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }
            string unE = HttpContext.Session.GetString("Usuario");
            List<Tarea> aux = new List<Tarea>();
            if (unE != null)
            {
                Empleado empleado = unS.BuscarEmpleadoNombre(unE);
                if (empleado is Peon)
                {
                    Peon unP = empleado as Peon;
                    if (unP.Tareas.Count > 1)
                    {
                        foreach (Tarea unaT in unP.Tareas)
                        {
                            if(unaT.Completa == false)
                            {
                                aux.Add(unaT);
                            }
                        }  
                        ViewBag.listTareas = aux;
                        return View();
                    }
                    else
                    {
                        ViewBag.error = "Lista Vacia.";
                        return View();
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Tareas(int tareaId)
        {
            
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }

            try
            {
                Tarea unaT = unS.DevolverTarea(tareaId); 

                if (unaT != null)
                {
                    ViewBag.tareaId = tareaId; 
                    ViewBag.descripcion = unaT.Descripcion; 

                    return RedirectToAction("ComentarioTarea", new { tareaId = tareaId });
                }
                else
                {
                    throw new Exception("La tarea especificada no se encontró.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Error al procesar la tarea: " + ex.Message;
                return View();
            }
        }
        
        public IActionResult ComentarioTarea(int tareaId, string comentario)
        {
            ViewBag.rol = HttpContext.Session.GetString("Rol");
            if (ViewBag.rol != "Peon")
            {
                return RedirectToAction("AccesoNoAutorizado", "MenuCapataz");
            }

            try
            {
                Tarea unaT = unS.DevolverTarea(tareaId);
                string unE = HttpContext.Session.GetString("Usuario");
                Empleado empleado = unS.BuscarEmpleadoNombre(unE);
                Peon unP = empleado as Peon;

                if (comentario != null)
                {
                    unaT.Comentario = comentario;
                    unaT.FechaFin = DateTime.Now;
                    unP.Tareas.Remove(unaT);

                    

                    return RedirectToAction("Tareas");
                }

                List<Tarea> aux = new List<Tarea>();
                if (unP.Tareas.Count > 0)
                {
                    foreach (Tarea unaTarea in unP.Tareas)
                    {
                        if (!unaTarea.Completa)
                        {
                            aux.Add(unaTarea);
                        }
                    }
                    ViewBag.listTareas = aux;
                }
                else
                {
                    ViewBag.error = "Lista Vacia.";
                }

                ViewBag.tarea = tareaId;
                ViewBag.descripcion = unaT.Descripcion;
                ViewBag.fechaIni = unaT.FechaInicio.ToString("yyyy-MM-dd");
                ViewBag.completa = unaT.Completa ? "Si" : "No";
                ViewBag.comentario = unaT.Comentario;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = $"Error al procesar la solicitud: {ex.Message}";
                return View();
            }
        }
    }
}

