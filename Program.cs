using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Empleados
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Empresa empresa = new Empresa();
            
            List<Empleado> empleados = new List<Empleado>();
            empresa.AgregarEmpleado(
                new EmpleadoPermanente(20, DateTime.Today, "Juan", "1"));
            try
            {
                empresa.AgregarEmpleado(
                new EmpleadoPermanente
                {
                    FechaIngreso = System.DateTime.Today,
                    HorasTrabajadas = 21,
                    Nombre = "Juan Alberto",
                    Dni = "1"
                });
            }
            catch ( ExceptionDNI ex)
            {
                System.Console.WriteLine("ERROR: " + ex.Message);
            }
            

            empresa.AgregarEmpleado(new EmpleadoTemporario(20, System.DateTime.Today, "Jose", "2"));
            empresa.AgregarEmpleado(new EmpleadoPermanente(20, System.DateTime.Today, "Ana", "3"));

            
            foreach (Empleado e in empresa)
                 empleados.Add(e);

            List<Empleado> listado_Result = empleados.FindAll(e => e.Dni.Equals("1"));

            Empleado empleado_Result = empleados.Find(e => e.Dni == "1" && e.Nombre == "Juan Alberto");

            Console.WriteLine("Variaciones: ");
            foreach (Empleado e in empresa)
                foreach (Empleado j in empresa)
                {
                    if (j == e)
                        continue;
                    Console.WriteLine("{0,9} {1,10}", e.Nombre, j.Nombre);
                }


            Console.WriteLine("Ordenados por dni: ");
            Empleado.setCompareDni();
            empleados.Sort();            
            foreach (Empleado e in empleados)
                Console.WriteLine(e.Nombre);            
            
            
            Console.WriteLine("Ordenados por Nombre: ");
            Empleado.setCompareNombre();
            empleados.Sort();

            foreach (Empleado e in empleados)
                Console.WriteLine(e.Nombre);
            System.Console.ReadKey();
        }
    }
}
