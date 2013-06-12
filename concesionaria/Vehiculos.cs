using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    public class errorPrecioNegativo : Exception
    {
        public override string Message
        {
            get
            {
                return "ERROR los precios no pueden ser negativos!";
            }
        }
    }

    public enum Combustible { Nafta = 1, Gasoil = 2 }

    class Vehiculos: IComparable
    {
        //atributos
        private int _anio;
        private String _marca;
        private String _modelo;
        private int _nroMotor;
        private int _kilometraje;
        private Combustible _combustible;
        private float _precioVenta;

        //constructor
        public Vehiculos(int Anio, String Marca, String Modelo, int NroMotor, int Km, Combustible Combustible, float Precio)
        {
            this.Anio = Anio;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.NroMotor = NroMotor;
            this.Kilometraje = Km;
            this.Combustible = Combustible;
            this.PrecioVenta = Precio;
        }

        //prop tab tab 
        //public int MyProperty { get; set; }
        //private string myVar;

        //prop full
        /*public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }*/
        
        //geters/seters       
        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        public String Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public String Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        public int NroMotor
        {
            get { return _nroMotor; }
            set { _nroMotor = value; }
        }

        public int Kilometraje
        {
            get { return _kilometraje; }
            set { _kilometraje = value; }
        }

        public Combustible Combustible
        {
            get { return _combustible; }
            set { _combustible = value; }
        }

        public float PrecioVenta
        {
            get { return _precioVenta; }
            
            set {
                if (value <= 0)
                    throw new errorPrecioNegativo();
                _precioVenta = value;
            }
        }

        //[METODOS DE ICOMPARABLE]
        //[GENERICO] creo delegado
        private delegate int comp(Vehiculos a, Vehiculos b);
        //[GENERICO] instancio var delegado y la asocio a la func de comparacion que va a usar
        //la funcion que le asocio al delegado la puedo cambiar, eso es para poder 
        //usar con un delegado varias funciones de comparacion distintas
        private static comp cmp = new comp(Vehiculos.compararPorMarca);
        
        
        //[TODO Comparar por marca]
        //implemento la funcion de comparacion que vamos a usar para ordenar
        private static int compararPorMarca(Vehiculos a, Vehiculos b)
        {
            return a.Marca.CompareTo(b.Marca);
        }
        //[TODO Comparar por marca] creo los seter para poder setearle al delegado varias funciones de comparacion
        public static void setCompararPorMarca()
        {
            Vehiculos.cmp = Vehiculos.compararPorMarca;
        }

        //[TODO Comparar por anio]
        //implemento la funcion de comparacion que vamos a usar para ordenar
        private static int compararPorAnio(Vehiculos a, Vehiculos b)
        {
            return a.Anio.CompareTo(b.Anio);
        }
        //[TODO Comparar por anio] creo los seter para poder setearle al delegado varias funciones de comparacion
        public static void setCompararPorAnio()
        {
            Vehiculos.cmp = Vehiculos.compararPorAnio;
        }


        //[TODO Comparar por modelo]
        //implemento la funcion de comparacion que vamos a usar para ordenar
        private static int compararPorModelo(Vehiculos a, Vehiculos b)
        {
            return a.Modelo.CompareTo(b.Modelo);
        }
        //[TODO Comparar por anio] creo los seter para poder setearle al delegado varias funciones de comparacion
        public static void setCompararPorModelo()
        {
            Vehiculos.cmp = Vehiculos.compararPorModelo;
        }


        //[GENERICO] refdefino el compareTo haciendo uso del delegado
        public int CompareTo(object obj)
        {
            return Vehiculos.cmp((Vehiculos)this, (Vehiculos)obj);
        }
        
        
    }

}
