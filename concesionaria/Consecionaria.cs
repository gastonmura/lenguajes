using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Concesionaria
{

    class Concesionaria : IEnumerable
    {
        //atributos
        private String _nombre;
        private List<Vehiculos> _listaVehiculos;
        private int _contadorCamionetas=0;
        private int _contadorAutos = 0;    

        //constructor
        public Concesionaria(String Nombre)
        {
            this.Nombre = Nombre;
            this._listaVehiculos = new List<Vehiculos>();
        }
        
        //geters/seters
        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public List<Vehiculos> ListaVehiculos
        {
            get { return _listaVehiculos; }
        }
        //[TODO] necesario para IEnumerator y IEnumerable
        //tengo que saber la cantidad de elementos
        public int ContadorCamionetas
        {
            get { return _contadorCamionetas; }
            set { _contadorCamionetas = value; }
        }

        public int ContadorAutos
        {
            get { return _contadorAutos; }
            set { _contadorAutos = value; }
        }


        //metodos
        public void addVehiculo(Vehiculos v)
        {
            ListaVehiculos.Add(v);

            //otra forma de hacerlo if(v as Auto)
            if (v.GetType() == typeof(Auto))
            {
                ContadorAutos = ContadorAutos + 1;
            }
            else
            {
                ContadorCamionetas = ContadorCamionetas + 1;
            }
        }

        public void buscarVehiculoPorPrecio(float hastaPrecio)
        {
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("\n[{0}] Listar Vehiculos por Precio, hasta:{1}.\n",this.Nombre,hastaPrecio);

            //forma de recorrer sin crear iterador con las interfaces IEnumerator, IEnumerable
            /*foreach ( Vehiculos v in ListaVehiculos )
            {
                if( v.PrecioVenta <= hastaPrecio ){
                    Console.WriteLine("\nMarca:{0} Modelo:{1} Precio:{2}",v.Marca,v.Modelo,v.PrecioVenta);  
                }
            }*/

            List<Vehiculos> tmp = ListaVehiculos.FindAll( e => e.PrecioVenta <= hastaPrecio);
            
            foreach(Vehiculos v in tmp){
                //if (v.PrecioVenta <= hastaPrecio)
               // {
                    Console.WriteLine("\n - Marca:{0} Modelo:{1} Precio:{2}", v.Marca, v.Modelo, v.PrecioVenta);
                //}
            }
            Console.WriteLine("\n---------------------------------------------------------------");

            
        }

        public void buscarVehiculoPorAnio(int anio)
        {
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("\n[{0}] Listar Vehiculo1s por Anio: {1}.\n", this.Nombre,anio);

            List<Vehiculos> tmp = ListaVehiculos.FindAll(e => e.Anio == anio);

            foreach (Vehiculos v in tmp)
            {
                //if (v.Anio == anio)
                //{
                    Console.WriteLine("\n - Anio:{0} Marca:{1} Modelo:{2} Precio:{3}",v.Anio, v.Marca, v.Modelo, v.PrecioVenta);
                //}
            }
            Console.WriteLine("\n---------------------------------------------------------------");
        }

        public void listarVehiculos()
        {
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine("\n[{0}] Listar Vehiculos.\n", this.Nombre);

            foreach (Vehiculos v in this)
            {
                Console.WriteLine("\n - Anio:{0} Marca:{1} Modelo:{2} Precio:{3}", v.Anio, v.Marca, v.Modelo, v.PrecioVenta);
             }
            Console.WriteLine("\n---------------------------------------------------------------");
        }

        //metodos enumerable
        //constructor de la clase que voy a recorrer
        //haciendo uso del index
        //[TODO] necesario para IEnumerator y IEnumerable
        public Vehiculos this[int index]{
            get { return this._listaVehiculos[index]; }
        }
        //creo instancia de clase Iterador que implementa la interfaz IEnumerator
        //[TODO] necesario para IEnumerator y IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new IteradorVehiculo(this);
        }
    }
}
