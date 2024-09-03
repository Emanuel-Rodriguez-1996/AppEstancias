using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dominio.Animal;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema? instancia;
        List<Tarea> listTareas = new List<Tarea>();
        List<Empleado> listEmpleados = new List<Empleado>();
        List<Animal> listAnimales = new List<Animal>();
        List<Vacuna> listVacunas = new List<Vacuna>();
        List<AdministracionVacuna> listVacunaciones = new List<AdministracionVacuna>();
        List<Potrero> listPotrero = new List<Potrero>();


        #region Singleton 
        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }

        private Sistema()
        {

            AgregarEmpleado(new Capataz(5, "fau@gml.com", "123", "Faustina", new DateTime(2024, 07, 4)));
            AgregarEmpleado(new Capataz(3, "flo@gml.com", "12345678", "Florencia", new DateTime(2023, 02, 07)));
            AgregarEmpleado(new Peon(true, "cat@gml.com", "12345678", "Isabella", new DateTime(2012, 07, 28)));
            AgregarEmpleado(new Peon(false, "rodr@gml.com", "12345678", "Rodrigo", new DateTime(2022, 03, 13)));
            AgregarEmpleado(new Peon(false, "agu@gml.com", "12345678", "Agustin", new DateTime(2012, 08, 23)));
            AgregarEmpleado(new Peon(true, "facu@gml.com", "123", "Facundo", new DateTime(2024, 05, 10)));
            AgregarEmpleado(new Peon(true, "alb@gml.com", "12345678", "Alberto", new DateTime(2016, 03, 01)));
            AgregarEmpleado(new Peon(false, "tan@gml.com", "12345678", "Leandro", new DateTime(2018, 11, 05)));
            AgregarEmpleado(new Peon(true, "dog@gml.com", "12345678", "Taña", new DateTime(2020, 06, 24)));
            AgregarEmpleado(new Peon(false, "anit@gml.com", "12345678", "Ana", new DateTime(2013, 12, 18)));
            AgregarEmpleado(new Peon(true, "car@gml.com", "12345678", "Carlos", new DateTime(2022, 04, 15)));
            AgregarEmpleado(new Peon(false, "dan@gml.com", "12345678", "Daniel", new DateTime(2015, 01, 13)));


            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2022, 5, 4), false, new DateTime(2023, 4, 14), ""));
            AgregarTarea(new Tarea("Limpieza", new DateTime(2019, 4, 14), true, new DateTime(2020, 5, 10), "Buena tarea"));
            AgregarTarea(new Tarea("Cosecha", new DateTime(2023, 2, 10), false, new DateTime(2024, 1, 12), ""));
            AgregarTarea(new Tarea("Riego", new DateTime(2021, 3, 16), true, new DateTime(2022, 6, 11), "Riego diario"));
            AgregarTarea(new Tarea("Siembra", new DateTime(2019, 4, 7), false, new DateTime(2021, 5, 13), ""));
            AgregarTarea(new Tarea("Podar", new DateTime(2022, 7, 18), true, new DateTime(2023, 8, 14), "Podar árboles"));
            AgregarTarea(new Tarea("Fertilizar", new DateTime(2023, 4, 28), false, new DateTime(2024, 10, 15), ""));
            AgregarTarea(new Tarea("Cavar", new DateTime(2022, 2, 20), true, new DateTime(2023, 3, 16), "Cavar zanjas"));
            AgregarTarea(new Tarea("Plantar", new DateTime(2019, 4, 11), false, new DateTime(2020, 12, 17), ""));
            AgregarTarea(new Tarea("Poda fina", new DateTime(2014, 12, 23), false, new DateTime(2015, 1, 19), ""));
            AgregarTarea(new Tarea("Recolectar", new DateTime(2017, 3, 25), false, new DateTime(2018, 6, 21), ""));
            AgregarTarea(new Tarea("Desmalezar", new DateTime(2016, 8, 6), true, new DateTime(2017, 7, 22), "Eliminar malezas"));
            AgregarTarea(new Tarea("Aplicar pesticida", new DateTime(2013, 4, 27), false, new DateTime(2014, 2, 23), ""));
            AgregarTarea(new Tarea("Preparar suelo", new DateTime(2018, 2, 16), true, new DateTime(2019, 3, 24), "Airear y nivelar suelo"));
            AgregarTarea(new Tarea("Poda fina", new DateTime(2014, 4, 23), false, new DateTime(2015, 1, 19), ""));
            AgregarTarea(new Tarea("Limpiar establos", new DateTime(2022, 5, 4), false, new DateTime(2023, 4, 14), ""));
            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2022, 5, 5), true, new DateTime(2023, 4, 15), "Urgente"));
            AgregarTarea(new Tarea("Reparar cercas", new DateTime(2022, 5, 6), false, new DateTime(2023, 4, 16), ""));
            AgregarTarea(new Tarea("Vacunar ovejas", new DateTime(2022, 5, 7), false, new DateTime(2023, 4, 17), ""));
            AgregarTarea(new Tarea("Sembrar pasto", new DateTime(2022, 5, 8), true, new DateTime(2023, 4, 18), "Zona norte del campo"));
            AgregarTarea(new Tarea("Podar árboles", new DateTime(2022, 5, 9), false, new DateTime(2023, 4, 19), ""));
            AgregarTarea(new Tarea("Revisar maquinaria", new DateTime(2022, 5, 10), false, new DateTime(2023, 4, 20), ""));
            AgregarTarea(new Tarea("Cuidar caballos", new DateTime(2022, 5, 11), false, new DateTime(2023, 4, 21), " "));
            AgregarTarea(new Tarea("Recoger cosecha", new DateTime(2022, 5, 12), true, new DateTime(2023, 4, 22), "Almacenar en bodega principal"));
            AgregarTarea(new Tarea("Desmalezar campos", new DateTime(2022, 5, 13), false, new DateTime(2023, 4, 23), ""));
            AgregarTarea(new Tarea("Revisar sistema de riego", new DateTime(2022, 5, 14), false, new DateTime(2023, 4, 24), ""));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 5, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Reparar techos de establos", new DateTime(2022, 5, 16), false, new DateTime(2023, 4, 26), ""));
            AgregarTarea(new Tarea("Control de plagas", new DateTime(2022, 5, 17), false, new DateTime(2023, 4, 27), ""));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automático"));
            AgregarTarea(new Tarea("Clasificar ganado", new DateTime(2022, 4, 20), true, new DateTime(2023, 4, 30), "Separar por edad y peso"));
            AgregarTarea(new Tarea("Esterilizar utensilios de trabajo", new DateTime(2022, 3, 20), false, new DateTime(2024, 5, 01), ""));
            AgregarTarea(new Tarea("Comprar alimentos para ganado", new DateTime(2022, 5, 22), true, new DateTime(2023, 5, 2), "Verificar precios en proveedores"));
            AgregarTarea(new Tarea("Inspeccionar corrales", new DateTime(2022, 2, 23), false, new DateTime(2023, 5, 3), ""));
            AgregarTarea(new Tarea("Entrenar perros guardianes", new DateTime(2022, 1, 24), true, new DateTime(2023, 5, 4), "Enfoque en delimitar perímetro"));
            AgregarTarea(new Tarea("Realizar mantenimiento a vehículos", new DateTime(2022, 5, 25), false, new DateTime(2023, 5, 5), ""));
            AgregarTarea(new Tarea("Sembrar árboles frutales", new DateTime(2022, 4, 26), false, new DateTime(2023, 5, 6), ""));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 3, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Limpiar Establos", new DateTime(2021, 2, 28), false, new DateTime(2023, 5, 8), ""));
            AgregarTarea(new Tarea("Monitorear estado de ganado", new DateTime(2022, 5, 29), true, new DateTime(2023, 5, 9), "Registro de observaciones"));
            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2024, 5, 5), true, new DateTime(2023, 4, 15), "Urgente"));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 1, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automático"));
            AgregarTarea(new Tarea("Vacunar ovejas", new DateTime(2022, 5, 7), false, new DateTime(2023, 4, 17), ""));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2023, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Revisar suministros", new DateTime(2021, 6, 10), false, new DateTime(2023, 5, 15), ""));
            AgregarTarea(new Tarea("Entrenar nuevo personal", new DateTime(2023, 6, 15), false, new DateTime(2023, 6, 1), ""));
            AgregarTarea(new Tarea("Podar árboles frutales", new DateTime(2022, 7, 5), false, new DateTime(2023, 6, 20), ""));
            AgregarTarea(new Tarea("Preparar terreno para siembra", new DateTime(2022, 7, 20), false, new DateTime(2023, 7, 1), ""));
            AgregarTarea(new Tarea("Inspeccionar sistema de riego", new DateTime(2022, 8, 1), false, new DateTime(2023, 7, 15), ""));
            AgregarTarea(new Tarea("Recoger cosecha de maíz", new DateTime(2022, 8, 15), false, new DateTime(2023, 8, 1), ""));
            AgregarTarea(new Tarea("Clasificar y almacenar cosecha", new DateTime(2022, 9, 1), false, new DateTime(2023, 8, 15), ""));
            AgregarTarea(new Tarea("Planificar rotación de cultivos", new DateTime(2022, 9, 15), false, new DateTime(2023, 9, 1), ""));
            AgregarTarea(new Tarea("Mantener registros de producción", new DateTime(2022, 10, 1), false, new DateTime(2023, 9, 15), ""));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 5, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Reparar techos de establos", new DateTime(2022, 5, 16), false, new DateTime(2023, 4, 26), ""));
            AgregarTarea(new Tarea("Control de plagas", new DateTime(2022, 5, 17), false, new DateTime(2023, 4, 27), ""));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automatico"));
            AgregarTarea(new Tarea("Limpiar establos", new DateTime(2022, 5, 4), false, new DateTime(2023, 4, 14), ""));
            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2022, 5, 5), true, new DateTime(2023, 4, 15), "Urgente"));
            AgregarTarea(new Tarea("Reparar cercas", new DateTime(2022, 5, 6), false, new DateTime(2023, 4, 16), ""));
            AgregarTarea(new Tarea("Vacunar ovejas", new DateTime(2022, 5, 7), false, new DateTime(2023, 4, 17), ""));
            AgregarTarea(new Tarea("Sembrar pasto", new DateTime(2022, 5, 8), true, new DateTime(2023, 4, 18), "Zona norte del campo"));
            AgregarTarea(new Tarea("Podar árboles", new DateTime(2022, 5, 9), false, new DateTime(2023, 4, 19), ""));
            AgregarTarea(new Tarea("Revisar maquinaria", new DateTime(2022, 5, 10), false, new DateTime(2023, 4, 20), ""));
            AgregarTarea(new Tarea("Cuidar caballos", new DateTime(2022, 5, 11), false, new DateTime(2023, 4, 21), ""));
            AgregarTarea(new Tarea("Recoger cosecha", new DateTime(2022, 5, 12), true, new DateTime(2023, 4, 22), "Almacenar en bodega principal"));
            AgregarTarea(new Tarea("Desmalezar campos", new DateTime(2022, 5, 13), false, new DateTime(2023, 4, 23), ""));
            AgregarTarea(new Tarea("Revisar sistema de riego", new DateTime(2022, 5, 14), false, new DateTime(2023, 4, 24), ""));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 5, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Reparar techos de establos", new DateTime(2022, 5, 16), false, new DateTime(2023, 4, 26), ""));
            AgregarTarea(new Tarea("Control de plagas", new DateTime(2022, 5, 17), false, new DateTime(2023, 4, 27), ""));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automático"));
            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2022, 3, 14), false, new DateTime(2023, 4, 14), ""));
            AgregarTarea(new Tarea("Limpieza", new DateTime(2019, 4, 11), true, new DateTime(2020, 5, 10), "Buena tarea"));
            AgregarTarea(new Tarea("Cosecha", new DateTime(2023, 4, 30), false, new DateTime(2024, 1, 12), ""));
            AgregarTarea(new Tarea("Riego", new DateTime(2021, 8, 6), true, new DateTime(2022, 6, 11), "Riego diario"));
            AgregarTarea(new Tarea("Siembra", new DateTime(2019, 10, 17), false, new DateTime(2021, 9, 13), ""));
            AgregarTarea(new Tarea("Podar", new DateTime(2022, 1, 13), true, new DateTime(2023, 8, 14), "Podar árboles"));
            AgregarTarea(new Tarea("Fertilizar", new DateTime(2023, 12, 19), false, new DateTime(2024, 5, 15), ""));
            AgregarTarea(new Tarea("Cavar", new DateTime(2022, 9, 20), true, new DateTime(2023, 3, 16), "Cavar zanjas"));
            AgregarTarea(new Tarea("Plantar", new DateTime(2019, 5, 21), false, new DateTime(2020, 1, 17), ""));
            AgregarTarea(new Tarea("Poda fina", new DateTime(2014, 4, 23), false, new DateTime(2015, 1, 19), ""));
            AgregarTarea(new Tarea("Fumigar", new DateTime(2023, 2, 22), true, new DateTime(2024, 3, 20), "Control de plagas"));
            AgregarTarea(new Tarea("Recolectar", new DateTime(2017, 8, 25), false, new DateTime(2018, 6, 21), ""));
            AgregarTarea(new Tarea("Desmalezar", new DateTime(2016, 4, 10), true, new DateTime(2017, 8, 20), "Eliminar malezas"));
            AgregarTarea(new Tarea("Aplicar pesticida", new DateTime(2013, 4, 27), false, new DateTime(2014, 2, 23), ""));
            AgregarTarea(new Tarea("Preparar suelo", new DateTime(2018, 3, 28), true, new DateTime(2019, 10, 29), "Airear y nivelar suelo"));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2023, 5, 7), true, new DateTime(2024, 5, 27), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Limpiar establos", new DateTime(2023, 5, 15), true, new DateTime(2024, 6, 10), "Desinfectar con solución apropiada"));
            AgregarTarea(new Tarea("Revisar equipos", new DateTime(2023, 6, 1), false, new DateTime(2024, 6, 15), ""));
            AgregarTarea(new Tarea("Cuidar animales", new DateTime(2023, 6, 15), true, new DateTime(2024, 6, 30), "Alimentar y dar agua"));
            AgregarTarea(new Tarea("Sembrar nuevos cultivos", new DateTime(2023, 7, 1), false, new DateTime(2024, 7, 15), ""));
            AgregarTarea(new Tarea("Control de plagas", new DateTime(2023, 7, 15), false, new DateTime(2024, 7, 30), ""));
            AgregarTarea(new Tarea("Recoger cosecha", new DateTime(2023, 8, 1), false, new DateTime(2024, 8, 15), ""));
            AgregarTarea(new Tarea("Podar árboles frutales", new DateTime(2023, 8, 15), false, new DateTime(2024, 8, 31), ""));
            AgregarTarea(new Tarea("Planificar rotación de cultivos", new DateTime(2023, 9, 1), true, new DateTime(2024, 9, 15), "Optimizar rendimiento del suelo"));
            AgregarTarea(new Tarea("Mantener registros de producción", new DateTime(2023, 9, 15), true, new DateTime(2024, 9, 30), "Organizar y archivar datos"));
            AgregarTarea(new Tarea("Revisar suministros", new DateTime(2023, 10, 1), false, new DateTime(2024, 10, 15), ""));
            AgregarTarea(new Tarea("Entrenar nuevo personal", new DateTime(2023, 10, 15), true, new DateTime(2024, 10, 31), "Impartir capacitación y orientación"));
            AgregarTarea(new Tarea("Preparar terreno para siembra", new DateTime(2023, 11, 1), false, new DateTime(2024, 11, 15), ""));
            AgregarTarea(new Tarea("Inspeccionar sistema de riego", new DateTime(2023, 11, 15), false, new DateTime(2024, 11, 30), ""));
            AgregarTarea(new Tarea("Clasificar y almacenar cosecha", new DateTime(2023, 12, 1), true, new DateTime(2024, 12, 15), "Separar por calidad y cantidad"));
            AgregarTarea(new Tarea("Revisar estado de cercas", new DateTime(2024, 1, 15), false, new DateTime(2024, 2, 1), ""));
            AgregarTarea(new Tarea("Plantar árboles ornamentales", new DateTime(2024, 2, 5), true, new DateTime(2024, 2, 20), "Seleccionar especies adecuadas"));
            AgregarTarea(new Tarea("Preparar suelo para siembra de hortalizas", new DateTime(2024, 2, 25), true, new DateTime(2024, 3, 10), "Enriquecer con abono orgánico"));
            AgregarTarea(new Tarea("Controlar maleza en campos de cultivo", new DateTime(2024, 3, 15), false, new DateTime(2024, 3, 30), ""));
            AgregarTarea(new Tarea("Recolectar y analizar muestras de suelo", new DateTime(2024, 4, 1), true, new DateTime(2024, 4, 15), "Enviar a laboratorio para análisis"));
            AgregarTarea(new Tarea("Revisar sistema de riego por goteo", new DateTime(2024, 4, 20), false, new DateTime(2024, 5, 5), ""));
            AgregarTarea(new Tarea("Fertilizar cultivos de temporada", new DateTime(2024, 5, 10), true, new DateTime(2024, 5, 25), "Aplicar nutrientes según recomendaciones"));
            AgregarTarea(new Tarea("Monitorear condiciones meteorológicas", new DateTime(2024, 6, 1), false, new DateTime(2024, 6, 15), ""));
            AgregarTarea(new Tarea("Evaluar rendimiento de cultivos", new DateTime(2024, 6, 20), false, new DateTime(2024, 7, 5), ""));
            AgregarTarea(new Tarea("Controlar enfermedades en plantaciones", new DateTime(2024, 7, 10), true, new DateTime(2024, 7, 25), "Aplicar tratamientos fitosanitarios"));
            AgregarTarea(new Tarea("Realizar mantenimiento a maquinaria agrícola", new DateTime(2024, 8, 1), true, new DateTime(2024, 8, 15), "Cambiar aceites y revisar componentes"));
            AgregarTarea(new Tarea("Hacer inventario de herramientas", new DateTime(2024, 8, 20), true, new DateTime(2024, 9, 5), "Reemplazar y reparar según necesidad"));
            AgregarTarea(new Tarea("Revisar sistema de almacenamiento de cosecha", new DateTime(2024, 9, 10), false, new DateTime(2024, 9, 25), ""));
            AgregarTarea(new Tarea("Organizar capacitación sobre técnicas agrícolas", new DateTime(2024, 10, 1), false, new DateTime(2024, 10, 15), ""));
            AgregarTarea(new Tarea("Preparar terreno para nuevas siembras", new DateTime(2024, 10, 20), true, new DateTime(2024, 11, 5), "Limpiar y adecuar suelo"));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2023, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Revisar suministros", new DateTime(2021, 6, 10), false, new DateTime(2023, 5, 15), ""));
            AgregarTarea(new Tarea("Entrenar nuevo personal", new DateTime(2023, 6, 15), false, new DateTime(2023, 6, 1), ""));
            AgregarTarea(new Tarea("Podar árboles frutales", new DateTime(2022, 7, 5), false, new DateTime(2023, 6, 20), ""));
            AgregarTarea(new Tarea("Preparar terreno para siembra", new DateTime(2022, 7, 20), false, new DateTime(2023, 7, 1), ""));
            AgregarTarea(new Tarea("Inspeccionar sistema de riego", new DateTime(2022, 8, 1), false, new DateTime(2023, 7, 15), ""));
            AgregarTarea(new Tarea("Recoger cosecha de maíz", new DateTime(2022, 8, 15), false, new DateTime(2023, 8, 1), ""));
            AgregarTarea(new Tarea("Clasificar y almacenar cosecha", new DateTime(2022, 9, 1), false, new DateTime(2023, 8, 15), ""));
            AgregarTarea(new Tarea("Planificar rotación de cultivos", new DateTime(2022, 9, 15), false, new DateTime(2023, 9, 1), ""));
            AgregarTarea(new Tarea("Mantener registros de producción", new DateTime(2022, 10, 1), false, new DateTime(2023, 9, 15), ""));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 5, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Reparar techos de establos", new DateTime(2022, 5, 16), false, new DateTime(2023, 4, 26), ""));
            AgregarTarea(new Tarea("Control de plagas", new DateTime(2022, 5, 17), false, new DateTime(2023, 4, 27), ""));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automático"));
            AgregarTarea(new Tarea("Clasificar ganado", new DateTime(2022, 4, 20), true, new DateTime(2023, 4, 30), "Separar por edad y peso"));
            AgregarTarea(new Tarea("Esterilizar utensilios de trabajo", new DateTime(2022, 3, 20), false, new DateTime(2024, 5, 01), ""));
            AgregarTarea(new Tarea("Comprar alimentos para ganado", new DateTime(2022, 5, 22), true, new DateTime(2023, 5, 2), "Verificar precios en proveedores"));
            AgregarTarea(new Tarea("Inspeccionar corrales", new DateTime(2022, 2, 23), false, new DateTime(2023, 5, 3), ""));
            AgregarTarea(new Tarea("Entrenar perros guardianes", new DateTime(2022, 1, 24), true, new DateTime(2023, 5, 4), "Enfoque en delimitar perímetro"));
            AgregarTarea(new Tarea("Realizar mantenimiento a vehículos", new DateTime(2022, 5, 25), false, new DateTime(2023, 5, 5), ""));
            AgregarTarea(new Tarea("Sembrar árboles frutales", new DateTime(2022, 4, 26), false, new DateTime(2023, 5, 6), ""));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 3, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));
            AgregarTarea(new Tarea("Limpiar Establos", new DateTime(2021, 2, 28), false, new DateTime(2023, 5, 8), ""));
            AgregarTarea(new Tarea("Monitorear estado de ganado", new DateTime(2022, 5, 29), true, new DateTime(2023, 5, 9), "Registro de observaciones"));
            AgregarTarea(new Tarea("Alimentar ganado", new DateTime(2024, 5, 5), true, new DateTime(2023, 4, 15), "Urgente"));
            AgregarTarea(new Tarea("Preparar área de siembra", new DateTime(2022, 1, 15), true, new DateTime(2023, 4, 25), "Nivelar terreno"));
            AgregarTarea(new Tarea("Regar cultivos", new DateTime(2022, 5, 18), true, new DateTime(2023, 4, 28), "Programar riego automático"));
            AgregarTarea(new Tarea("Vacunar ovejas", new DateTime(2022, 5, 7), false, new DateTime(2023, 4, 17), ""));
            AgregarTarea(new Tarea("Desinfectar áreas comunes", new DateTime(2022, 5, 27), true, new DateTime(2023, 5, 7), "Usar desinfectantes aprobados"));

            AgregarTareaAPeon("cat@gml.com", DevolverTarea(1));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(2));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(3));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(4));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(5));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(6));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(7));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(8));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(9));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(10));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(11));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(12));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(13));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(14));
            AgregarTareaAPeon("cat@gml.com", DevolverTarea(15));

            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(16));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(17));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(18));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(19));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(20));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(21));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(22));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(23));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(24));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(25));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(26));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(27));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(28));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(29));
            AgregarTareaAPeon("rodr@gml.com", DevolverTarea(30));

            AgregarTareaAPeon("agu@gml.com", DevolverTarea(31));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(32));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(33));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(34));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(35));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(36));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(37));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(38));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(39));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(40));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(41));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(42));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(43));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(44));
            AgregarTareaAPeon("agu@gml.com", DevolverTarea(45));

            AgregarTareaAPeon("facu@gml.com", DevolverTarea(46));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(47));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(48));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(49));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(50));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(51));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(52));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(53));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(54));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(55));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(56));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(57));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(58));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(59));
            AgregarTareaAPeon("facu@gml.com", DevolverTarea(60));

            AgregarTareaAPeon("alb@gml.com", DevolverTarea(61));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(62));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(63));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(64));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(65));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(66));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(67));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(68));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(69));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(70));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(71));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(72));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(73));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(74));
            AgregarTareaAPeon("alb@gml.com", DevolverTarea(75));

            AgregarTareaAPeon("tan@gml.com", DevolverTarea(76));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(77));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(78));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(79));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(80));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(81));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(82));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(83));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(84));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(85));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(86));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(87));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(88));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(89));
            AgregarTareaAPeon("tan@gml.com", DevolverTarea(90));

            AgregarTareaAPeon("dog@gml.com", DevolverTarea(91));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(92));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(93));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(94));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(95));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(96));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(97));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(98));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(99));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(100));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(101));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(102));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(103));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(104));
            AgregarTareaAPeon("dog@gml.com", DevolverTarea(105));

            AgregarTareaAPeon("anit@gml.com", DevolverTarea(106));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(107));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(108));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(109));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(110));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(111));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(112));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(113));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(114));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(115));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(116));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(117));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(118));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(119));
            AgregarTareaAPeon("anit@gml.com", DevolverTarea(120));

            AgregarTareaAPeon("car@gml.com", DevolverTarea(121));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(122));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(123));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(124));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(125));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(126));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(127));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(128));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(129));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(130));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(131));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(132));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(133));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(134));
            AgregarTareaAPeon("car@gml.com", DevolverTarea(135));

            AgregarTareaAPeon("dan@gml.com", DevolverTarea(136));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(137));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(138));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(139));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(140));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(141));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(142));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(143));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(144));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(145));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(146));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(147));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(148));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(149));
            AgregarTareaAPeon("dan@gml.com", DevolverTarea(150));

            AgregarAnimal(new Ovino(3448, "OVIN4829", Sexo.Hembra, "Suffolk", new DateTime(2005 - 06 - 12), 32000, 1000, 70500, true, null, new Potrero("Potrero18", 13000, 35)));
            AgregarAnimal(new Ovino(3449, "OVIN4830", Sexo.Macho, "Merino", new DateTime(2003 - 01 - 2), 24000, 1200, 63500, false, null, null));
            AgregarAnimal(new Ovino(3450, "OVIN4831", Sexo.Hembra, "Suffolk", new DateTime(2005, 6, 12), 32000, 1000, 70500, true, null, null));
            AgregarAnimal(new Ovino(3451, "OVIN4832", Sexo.Macho, "Merino", new DateTime(2003, 1, 2), 24000, 1200, 63500, false, null, null));
            AgregarAnimal(new Ovino(3452, "OVIN4833", Sexo.Hembra, "Dorper", new DateTime(2004, 3, 15), 30000, 1100, 69000, true, null, null));
            AgregarAnimal(new Ovino(3453, "OVIN4834", Sexo.Macho, "Rambouillet", new DateTime(2006, 8, 27), 28000, 1050, 65000, false, null, null));
            AgregarAnimal(new Ovino(3454, "OVIN4835", Sexo.Hembra, "Corriedale", new DateTime(2002, 5, 9), 33000, 1000, 71000, true, null, null));
            AgregarAnimal(new Ovino(3455, "OVIN4836", Sexo.Macho, "Lincoln", new DateTime(2007, 10, 31), 26000, 1150, 62000, false, null, null));
            AgregarAnimal(new Ovino(3456, "OVIN4837", Sexo.Hembra, "Romney", new DateTime(2001, 12, 20), 34000, 980, 72000, true, null, null));
            AgregarAnimal(new Ovino(3457, "OVIN4838", Sexo.Macho, "Cotswold", new DateTime(2005, 4, 8), 25000, 1250, 60000, false, null, null));
            AgregarAnimal(new Ovino(3458, "OVIN4839", Sexo.Hembra, "Targhee", new DateTime(2003, 9, 17), 31000, 1020, 68000, true, null, null));
            AgregarAnimal(new Ovino(3459, "OVIN4840", Sexo.Macho, "Cheviot", new DateTime(2002, 7, 23), 27000, 1180, 63000, false, null, null));
            AgregarAnimal(new Ovino(3460, "OVIN4841", Sexo.Hembra, "Columbia", new DateTime(2004, 11, 5), 32500, 1060, 70000, true, null, null));
            AgregarAnimal(new Ovino(3461, "OVIN4842", Sexo.Macho, "Dorset", new DateTime(2006, 2, 14), 29000, 1120, 66000, false, null, null));
            AgregarAnimal(new Ovino(3462, "OVIN4843", Sexo.Hembra, "Hampshire", new DateTime(2003, 3, 28), 33500, 990, 71500, true, null, null));
            AgregarAnimal(new Ovino(3463, "OVIN4844", Sexo.Macho, "Jacob", new DateTime(2001, 8, 7), 25500, 1200, 61000, false, null, null));
            AgregarAnimal(new Ovino(3464, "OVIN4845", Sexo.Hembra, "Merino", new DateTime(2005, 6, 12), 32000, 1000, 70500, true, null, null));
            AgregarAnimal(new Ovino(3465, "OVIN4846", Sexo.Macho, "Suffolk", new DateTime(2003, 1, 2), 24000, 1200, 63500, false, null, null));
            AgregarAnimal(new Ovino(3466, "OVIN4847", Sexo.Hembra, "Dorper", new DateTime(2004, 3, 15), 30000, 1100, 69000, true, null, null));
            AgregarAnimal(new Ovino(3467, "OVIN4848", Sexo.Macho, "Rambouillet", new DateTime(2006, 8, 27), 28000, 1050, 65000, false, null, null));
            AgregarAnimal(new Ovino(3468, "OVIN4849", Sexo.Hembra, "Corriedale", new DateTime(2002, 5, 9), 33000, 1000, 71000, true, null, null));
            AgregarAnimal(new Ovino(3469, "OVIN4850", Sexo.Macho, "Lincoln", new DateTime(2007, 10, 31), 26000, 1150, 62000, false, null, null));
            AgregarAnimal(new Ovino(3470, "OVIN4851", Sexo.Hembra, "Romney", new DateTime(2001, 12, 20), 34000, 980, 72000, true, null, null));
            AgregarAnimal(new Ovino(3471, "OVIN4852", Sexo.Macho, "Cotswold", new DateTime(2005, 4, 8), 25000, 1250, 60000, false, null, null));
            AgregarAnimal(new Ovino(3472, "OVIN4853", Sexo.Hembra, "Targhee", new DateTime(2003, 9, 17), 31000, 1020, 68000, true, null, null));
            AgregarAnimal(new Ovino(3473, "OVIN4854", Sexo.Macho, "Cheviot", new DateTime(2002, 7, 23), 27000, 1180, 63000, false, null, null));
            AgregarAnimal(new Ovino(3474, "OVIN4855", Sexo.Hembra, "Columbia", new DateTime(2004, 11, 5), 32500, 1060, 70000, true, null, null));
            AgregarAnimal(new Ovino(3475, "OVIN4856", Sexo.Macho, "Dorset", new DateTime(2006, 2, 14), 29000, 1120, 66000, false, null, null));
            AgregarAnimal(new Ovino(3476, "OVIN4857", Sexo.Hembra, "Hampshire", new DateTime(2003, 3, 28), 33500, 990, 71500, true, null, null));
            AgregarAnimal(new Ovino(3477, "OVIN4858", Sexo.Macho, "Jacob", new DateTime(2001, 8, 7), 25500, 1200, 61000, false, null, null));
            AgregarAnimal(new Ovino(3478, "OVIN4859", Sexo.Hembra, "Merino", new DateTime(2005, 11, 5), 33500, 1500, 87000, true, null, null));

            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3801", Sexo.Hembra, "Corriedale", new DateTime(2005 - 01 - 12), 24000, 1500, 90350, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3802", Sexo.Hembra, "Merino", new DateTime(2003 - 06 - 22), 21000, 1530, 50500, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3803", Sexo.Hembra, "Merino", new DateTime(2020, 12, 01), 18000, 1100, 80500, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3804", Sexo.Macho, "Angus", new DateTime(2008, 03, 25), 28000, 1600, 42000, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3805", Sexo.Hembra, "Hereford", new DateTime(2010, 12, 07), 26000, 1550, 81000, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3806", Sexo.Macho, "Simmental", new DateTime(2007, 08, 14), 15000, 1700, 73200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3807", Sexo.Macho, "Chiannina", new DateTime(2014, 02, 06), 22000, 3000, 85020, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3808", Sexo.Macho, "Marchigiana", new DateTime(2023, 9, 27), 30000, 1700, 63200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3810", Sexo.Hembra, "Corriedale", new DateTime(2005, 1, 12), 24000, 1500, 90350, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3811", Sexo.Hembra, "Merino", new DateTime(2003, 6, 22), 21000, 1530, 50500, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3812", Sexo.Hembra, "Merino", new DateTime(2020, 12, 1), 18000, 1100, 80500, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3813", Sexo.Macho, "Angus", new DateTime(2008, 3, 25), 28000, 1600, 42000, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3814", Sexo.Hembra, "Hereford", new DateTime(2010, 12, 7), 26000, 1550, 81000, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3815", Sexo.Macho, "Simmental", new DateTime(2007, 8, 14), 15000, 1700, 73200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3816", Sexo.Macho, "Chiannina", new DateTime(2014, 2, 6), 22000, 3000, 85020, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3817", Sexo.Macho, "Marchigiana", new DateTime(2023, 9, 27), 30000, 1700, 63200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3818", Sexo.Hembra, "Corriedale", new DateTime(2005, 1, 12), 24000, 1500, 90350, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3819", Sexo.Hembra, "Merino", new DateTime(2003, 6, 22), 21000, 1530, 50500, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3820", Sexo.Hembra, "Merino", new DateTime(2020, 12, 1), 18000, 1100, 80500, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3821", Sexo.Macho, "Angus", new DateTime(2008, 3, 25), 28000, 1600, 42000, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3822", Sexo.Hembra, "Hereford", new DateTime(2010, 12, 7), 26000, 1550, 81000, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3823", Sexo.Macho, "Simmental", new DateTime(2007, 8, 14), 15000, 1700, 73200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3824", Sexo.Macho, "Chiannina", new DateTime(2014, 2, 6), 22000, 3000, 85020, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3825", Sexo.Macho, "Marchigiana", new DateTime(2023, 9, 27), 30000, 1700, 63200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3826", Sexo.Hembra, "Corriedale", new DateTime(2005, 1, 12), 24000, 1500, 90350, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3827", Sexo.Hembra, "Merino", new DateTime(2003, 6, 22), 21000, 1530, 50500, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3828", Sexo.Hembra, "Merino", new DateTime(2020, 12, 1), 18000, 1100, 80500, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3829", Sexo.Macho, "Angus", new DateTime(2008, 3, 25), 28000, 1600, 42000, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Pastura, "BOVN3830", Sexo.Hembra, "Hereford", new DateTime(2010, 12, 7), 26000, 1550, 81000, false, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3831", Sexo.Macho, "Simmental", new DateTime(2007, 8, 14), 15000, 1700, 73200, true, null, null));
            AgregarAnimal(new Bovino(Bovino.TipoAlim.Grano, "BOVN3832", Sexo.Macho, "Chiannina", new DateTime(2014, 2, 6), 22000, 3000, 85020, false, null, null));

            AgregarVacuna(new Vacuna("Biogenesis", "Bioqueratogen Oleomax", "Campylobacter"));
            AgregarVacuna(new Vacuna("VacunaFelinitis", "Felid alphaherpesvirus 1", "Rinotraqueitis Felina"));
            AgregarVacuna(new Vacuna("VacunaBovina", "Clostridium chauvoei", "Carbunco Bacteridiano"));
            AgregarVacuna(new Vacuna("VacunaAviar", "Influenza aviar", "Gripe Aviar"));
            AgregarVacuna(new Vacuna("VacunaEquina", "Equine Influenza Virus", "Influenza Equina"));
            AgregarVacuna(new Vacuna("VacunaPorcina", "Porcine Reproductive", "Síndrome Reproductivo Porcino"));
            AgregarVacuna(new Vacuna("VacunaOvina", "Chlamydophila abortus", "Aborto Enzoótico de las Ovejas"));
            AgregarVacuna(new Vacuna("VacunaCaprina", "Mycoplasma agalactiae", "Agalactia Contagiosa de las Cabras"));
            AgregarVacuna(new Vacuna("VacunaPiscina", "Iridovirus", "Virus de la Necrosis Pancreática Infecciosa"));
            AgregarVacuna(new Vacuna("VacunaAbejastis", "Nosema apis", "Nosemosis"));

            AgregarVacunaEnAnimal("OVIN4829", DevolverVacuna("Biogenesis"));
            AgregarVacunaEnAnimal("OVIN4830", DevolverVacuna("VacunaFelinitis"));
            AgregarVacunaEnAnimal("OVIN4831", DevolverVacuna("VacunaOvina"));
            AgregarVacunaEnAnimal("OVIN4832", DevolverVacuna("VacunaPiscina"));

            listPotrero.Add((new Potrero("Potrero1", 13000, 35)));
            listPotrero.Add((new Potrero("Potrero2", 10000, 25)));
            listPotrero.Add((new Potrero("Potrero3", 15000, 45)));
            listPotrero.Add((new Potrero("Potrero4", 9000, 15)));
            listPotrero.Add((new Potrero("Potrero5", 13000, 35)));
            listPotrero.Add((new Potrero("Potrero6", 20000, 60)));
            listPotrero.Add((new Potrero("Potrero7", 11000, 30)));
            listPotrero.Add((new Potrero("Potrero8", 10000, 25)));
            listPotrero.Add((new Potrero("Potrero9", 18000, 35)));
            listPotrero.Add((new Potrero("Potrero10", 12000, 3)));
        }
        #endregion
        public Empleado? BuscarEmpleado(string email)
        {
            foreach (Empleado unEmpleado in listEmpleados)
            {
                if (unEmpleado.Email == email) return unEmpleado;
            }
            return null;
        }
        //LOG
        public Empleado? DevolverEmpleado(string email, string contraseña)
        {
            foreach (Empleado unEmpleado in listEmpleados)
            {
                if (unEmpleado.Email == email && unEmpleado.Contraseña == contraseña)
                    return unEmpleado;
            }
            return null;
        }
        public Empleado? BuscarEmpleadoNombre(string nombre)
        {
            foreach (Empleado unEmpleado in listEmpleados)
            {
                if (unEmpleado.Nombre == nombre) return unEmpleado;
            }
            return null;
        }
        public void VerificarEmpleadoNoExiste(Empleado unE)
        {
            foreach (Empleado empleado in listEmpleados)
            {
                if (empleado.Email.Equals(unE.Email))
                {
                    throw new Exception("El email ya está registrado para otro empleado.");
                }
            }
        }
        public void AgregarEmpleado(Empleado unEmpleado)
        {
            try
            {
                if (unEmpleado != null)
                {
                    unEmpleado.Validar();
                    VerificarEmpleadoNoExiste(unEmpleado);
                    listEmpleados.Add(unEmpleado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AgregarTarea(Tarea unaTarea)
        {
            listTareas.Add(unaTarea);
        }
        public Tarea? DevolverTarea(int id)
        {
            foreach (Tarea unaT in listTareas)
            {
                if (unaT.Id == id) return unaT;
            }
            return null;
        }

        public void AgregarTareaAPeon(string emailPeon, Tarea? unaTarea)
        {
            try
            {
                if (unaTarea == null)
                {
                    throw new Exception("La tarea es nula.");
                }
                Peon peon = BuscarEmpleado(emailPeon) as Peon;

                if (peon == null)
                {
                    throw new Exception("No se encontró un peón con ese email.");
                }
                peon.AsignarTarea(unaTarea);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede agregar Tarea: " + ex.Message);
            }
        }
        public Animal? BuscarAnimal(string codigoAnimal)
        {
            foreach (Animal unAnimal in listAnimales)
            {
                if (unAnimal.Codigo == codigoAnimal) return unAnimal;
            }
            return null;
        }
        public void AgregarAnimal(Animal unAnimal)
        {
            try
            {
                unAnimal.Validar();
                VerificarAnimalNoExiste(unAnimal);
                listAnimales.Add(unAnimal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void VerificarAnimalNoExiste(Animal unA)
        {
            foreach (Animal animal in listAnimales)
            {
                if (animal.Codigo.Equals(unA.Codigo))
                {
                    throw new Exception("El Codigo ya está registrado para otro Animal.");
                }
            }
        }
        public Vacuna? DevolverVacuna(string nombre)
        {
            foreach (Vacuna unaV in listVacunas)
            {
                if (unaV.Nombre == nombre) return unaV;
            }
            return null;
        }
        public void AgregarVacuna(Vacuna unaVacuna)
        {
            listVacunas.Add(unaVacuna);
        }
        public void AgregarVacunaEnAnimal(string codigoAnimal, Vacuna unaVacuna)
        {
            Animal animal = BuscarAnimal(codigoAnimal);

            if (animal.ValidarEdad())
            {
                animal.Vacunas.Add(new AdministracionVacuna(unaVacuna, DateTime.Now));
            }
            else
            {
                throw new Exception("El animal no cumple con la edad mínima para recibir vacunas.");
            }
        }
        public Potrero? BuscarPotrero(int idPotrero)
        {
            foreach (Potrero unPotrero in listPotrero)
            {
                if (unPotrero.Id == idPotrero) return unPotrero;
            }
            return null;
        }
        public void AgregarPotreroEnAnimal(string codigoAnimal, Potrero unPotrero)
        {
            try
            {
                Animal animal = BuscarAnimal(codigoAnimal) ?? throw new Exception("No se encontró un animal con ese código");

                if (animal != null)
                {
                    unPotrero.AsignarAnimal(animal, unPotrero);
                }
                else
                {
                    throw new Exception("El animal es nulo.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Animal> ObtenerAnimales()
        {
            return listAnimales;
        }
        public List<Potrero> ObtenerPotreros()
        {
            return listPotrero;
        }
        public List<Tarea> ObtenerTareas()
        {
            return listTareas;
        }
        public List<Vacuna> ObtenerVacunas()
        {
            return listVacunas;
        }
        public List<Empleado> ObtenerEmpleados()
        {
            return listEmpleados;
        }
        public List<Empleado> ObtenerPeones()
        {
            List<Empleado> aux = new List<Empleado>();
            foreach (Empleado unE in listEmpleados)
            {
                if (unE.GetType() == typeof(Peon))
                {
                    aux.Add(unE);
                }
            }
            return aux;
        }
        public List<Empleado> ObtenerCapataz()
        {
            List<Empleado> aux = new List<Empleado>();
            foreach (Empleado unE in listEmpleados)
            {
                if (unE.GetType() == typeof(Capataz))
                {
                    aux.Add(unE);
                }
            }
            return aux;
        }
    }
}
