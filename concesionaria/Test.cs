using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Test
    {

        public static void Main() { 
        
            //creo consecionaria
            Concesionaria conse = new Concesionaria("Autosur S.A");

            //creo autos
            try
            {
                Auto a = new Auto(1997, "Volswagen", "Gol", 12365478, 4587754, Combustible.Nafta, 20000, 3, false);
                Auto b = new Auto(1994, "Fiat", "uno", 12365478, 4587754, Combustible.Nafta, 4500, 3, false);
                Auto c = new Auto(1987, "Renault", "11", 12365478, 4587754, Combustible.Nafta, 4000, 3, false);
                Auto d = new Auto(2006, "Volswagen", "Gol", 12365478, 4587754, Combustible.Nafta, 40000, 3, false);
                Auto e = new Auto(2000, "Chevrolet", "Corsa", 12365478, 4587754, Combustible.Nafta, 16000, 3, false);

                //add auto
                conse.addVehiculo(a);
                conse.addVehiculo(b);
                conse.addVehiculo(c);
                conse.addVehiculo(d);
                conse.addVehiculo(e);

                Camioneta f = new Camioneta(1980, "Ford", "F-100", 1245987, 520698, Combustible.Gasoil, 15000, 2000, "Echa un poco de humo.");
                Camioneta g = new Camioneta(2006, "Chevrolet", "S-10", 1245987, 520698, Combustible.Gasoil, 75000, 1000, "Echa un poco de humo.");
                Camioneta h = new Camioneta(1983, "Chevrolet", "Silverado", 1245987, 520698, Combustible.Nafta, 45000, 700, "Echa un poco de humo.");
                Camioneta i = new Camioneta(2009, "Toyota", "Hylux", 1245987, 520698, Combustible.Gasoil, 115000, 1000, "Echa un poco de humo.");

                conse.addVehiculo(f);
                conse.addVehiculo(g);
                conse.addVehiculo(h);
                conse.addVehiculo(i);
            }
            catch (errorPrecioNegativo e)
            {
                Console.WriteLine("\n" + e.Message);
            }

            conse.buscarVehiculoPorAnio(2006);
            conse.buscarVehiculoPorPrecio(15000);

            conse.listarVehiculos();


            Console.WriteLine("\nOrden Marca ------------------------------------------------------------------------\n");
            //Uso de las listas ordenadas por X criterio
            List<Vehiculos> tmp=new List<Vehiculos>(); //creo lista temporal
            foreach(Vehiculos v in conse)              //recorro la lista original y la copio a tmp 
                tmp.Add(v);
                 
            
            Vehiculos.setCompararPorMarca(); // seteo en el delegado la forma d ecomparar
            tmp.Sort();                      //ordeno la lista
            foreach (Vehiculos v in tmp)     //la muestro
                Console.WriteLine("\nMarca: {0} Modelo:{1} Anio:{2}", v.Marca, v.Modelo, v.Anio);

            Console.WriteLine("\nOrden Anio ------------------------------------------------------------------------\n");

            Vehiculos.setCompararPorAnio(); // seteo en el delegado la forma d ecomparar
            tmp.Sort();                      //ordeno la lista
            foreach (Vehiculos v in tmp)     //la muestro
                Console.WriteLine("\nMarca: {0} Modelo:{1} Anio:{2}",v.Marca,v.Modelo,v.Anio);

            Console.WriteLine("\nOrden Modelo------------------------------------------------------------------------\n");

            Vehiculos.setCompararPorModelo(); // seteo en el delegado la forma d ecomparar
            tmp.Sort();                      //ordeno la lista
            foreach (Vehiculos v in tmp)     //la muestro
                Console.WriteLine("\nMarca: {0} Modelo:{1} Anio:{2}", v.Marca, v.Modelo, v.Anio);

            Console.ReadKey();
        
        }

    }
}
