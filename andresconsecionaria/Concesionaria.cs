using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Concesionaria
{

    class IteradorVehículo : IEnumerator
    {
        private Concesionaria empresa;
        private int actual;

        public IteradorVehículo(Concesionaria e)
        {
            this.actual = -1;
            this.empresa = e;
        }

        public Object Current
        {
            get { return this.empresa[this.actual]; }
        }

        public bool MoveNext()
        {
            if (this.actual >= this.empresa.CantidadVehiculos() - 1)
                return false;
            this.actual++;
            return true;
        }

        public void Reset()
        {
            this.actual = -1;
        }

    }
    class Concesionaria : IEnumerable
    {
        private List<Vehiculo> vehiculos;

        public Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        public void AgregarVehiculo(Vehiculo v)
        {
            this.vehiculos.Add(v);
        }

        public void VehiculosXPrecio(float precio)
        {
            foreach (Vehiculo v in this.vehiculos)
            {
                if (v.PrecioV <= precio)
                {
                    if (v is Auto)
                    {
                        Console.WriteLine("Auto: {0}", v);
                    }
                    else
                    {
                        Console.WriteLine("Camioneta: {0}", v);
                    }
                }
            }
        }

        public void VehiculosXAnio(int anio)
        {
            foreach (Vehiculo v in this.vehiculos)
            {
                if (v.Anio == anio)
                {
                    if (v is Auto)
                    {
                        Console.WriteLine("Auto: {0}", v);
                    }
                    else
                    {
                        Console.WriteLine("Camioneta: {0}", v);
                    }
                }
            }
        }

        public int CantAutos()
        {
            int cant = 0;
            foreach (Vehiculo v in this.vehiculos)
            {
                if (v is Auto)
                {
                    cant++;
                }
            }
            return cant;
        }

        public int CantCamionetas()
        {
            int cant = 0;
            foreach (Vehiculo v in this.vehiculos)
            {
                if (v is Camioneta)
                {
                    cant++;
                }
            }
            return cant;
        }

        public void ListarVehiculos()
        {
            foreach (Vehiculo v in this.vehiculos)
            {
                Console.WriteLine(v);
            }
        }

        public int CantidadVehiculos()
        {
            return this.vehiculos.Count;
        }

        public IEnumerator GetEnumerator()
        {
            return new IteradorVehículo(this);
        }

        public Vehiculo this[int index]
        {
            get { return this.vehiculos[index]; }
        }

        public void OrdenarXAnio()
        {
            vehiculos.Sort();
        }
        public static void Main()
        {
            float precio;
            int anio;
            Boolean resultado;
            Concesionaria con = new Concesionaria();
            con.AgregarVehiculo(new Auto(25000f, 2000, "Renault", "3cv"));
            con.AgregarVehiculo(new Auto(35000f, 2010, "Citroen", "3cv"));
            con.AgregarVehiculo(new Auto(55000f, 2013, "wolwagen", "3cv"));
            con.AgregarVehiculo(new Camioneta(18000f, 1990, "Renault", "3cv"));
            con.AgregarVehiculo(new Camioneta(50000f, 2013, "Mercedes", "3cv"));
            con.AgregarVehiculo(new Camioneta(25000f, 1998, "Lada", "3cv"));
            Console.WriteLine("Cantidad de Autos: {0}", con.CantAutos());
            Console.WriteLine("Cantidad de Camionetas: {0}", con.CantCamionetas());
            con.ListarVehiculos();
            do
            {
                Console.WriteLine("Ingrese precio a consultar");
                resultado = float.TryParse(Console.ReadLine(), out precio);
                if (resultado == false)
                {
                    Console.WriteLine("Error, debe introducir un valor númerico");
                }
            } while (resultado == false);
            Console.WriteLine(precio);
            con.VehiculosXPrecio(precio);
            Console.Read();

            do
            {
                Console.WriteLine("Ingrese anio del vehiculo");
                resultado = int.TryParse(Console.ReadLine(), out anio);
                if (resultado == false)
                {
                    Console.WriteLine("Error, debe introducir un valor númerico");
                }
            } while (resultado == false);
            con.VehiculosXAnio(anio);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Parte Correspondiente al punto 5");
            foreach (Vehiculo v in con) // Esta parte corresponde al punto 5
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Parte Correspondiente al punto 6");
            con.OrdenarXAnio();
            foreach (Vehiculo v in con)
            {
                Console.WriteLine(v);
            }
            Console.Read();








           



        }

    }
}
