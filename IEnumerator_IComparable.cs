########################
#        Tipos Enumerados            #
########################
public enum Combustible { Nafta = 1, Gasoil = 2 }
########################
#        Interfaz Enumerator          #
########################
#iterador
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Concesionaria
{
    class IteradorVehiculo:IEnumerator
    {
        private Concesionaria c;
        private int actual;

        public IteradorVehiculo(Concesionaria c)
        {
            this.c = c;
            this.actual = -1;
        }

        public object Current
        {
            get { return this.c[this.actual]; }
        }

        public bool MoveNext()
        {
            if (this.actual >= (this.c.ContadorAutos + this.c.ContadorCamionetas ) - 1)
                return false;
            this.actual++;
            return true;   
        }

        public void Reset()
        {
            this.actual = -1;
        }
    }
}


#clase que va a ser iterada
namespace Concesionaria
{
    class Concesionaria : IEnumerable
    {
    .....
    public int cantidadElementosEnLista(){.....} //necesario para poder iterar
    .....
    public Vehiculos this[int index]  //al tipo que se va a iterar le creo un index para poder recorrerlo
    {
            get { return this._listaVehiculos[index]; }
    }
    .....
    public IEnumerator GetEnumerator() //devuelvo una instancia del enumerator
    {
            return new IteradorVehiculo(this);
    }
   }
}
########################
#        Interfaz Comparable         #
########################
class Vehiculo: IComparable
{
        private delegate int comp(Vehiculos a, Vehiculos b); //creo delegado con el modelo del puntero a funcion, solo una ves

        private static comp cmp = new comp(Vehiculos.compararPorMarca); //creo instancia del delegado ya asociado con una funcion de busqueda, solo una ves
              
        private static int compararPorMarca(Vehiculos a, Vehiculos b) //funcion de comparacion que respeta la forma impuesta por el delegado, uno por criterio de busqueda que se crea
        {
            return a.Marca.CompareTo(b.Marca);
        }
        
        public static void setCompararPorMarca() //serter para asociarle la funcion al delegado
        {
            Vehiculos.cmp = Vehiculos.compararPorMarca;
        }

        public int CompareTo(object obj)
        {
            return Vehiculos.cmp((Vehiculos)this, (Vehiculos)obj);
        }
}
#modo de uso en el test

            List<Vehiculos> tmp=new List<Vehiculos>(); //creo lista temporal

            foreach(Vehiculos v in conse)                    //recorro la lista original y la copio a tmp 
                tmp.Add(v);
            
            Vehiculos.setCompararPorMarca();             // seteo en el delegado la forma d ecomparar
            
            tmp.Sort();                                            //ordeno la lista
            
            foreach (Vehiculos v in tmp)                     //la muestro
                Console.WriteLine("\nMarca: {0} Modelo:{1} Anio:{2}", v.Marca, v.Modelo, v.Anio);
########################
#         Expresiones lambda         #
########################
public void buscarPorAnio(int anio){
  Console.WriteLine("\n------------------------------------------------------------------------------");
  Console.WriteLine("Listar Por Anio:{0}", anio);
            List<Vehiculo> tmp = listaVehiculos.FindAll(e => e.Anio == anio);
            foreach (Vehiculo v in tmp)
                Console.WriteLine(v);
 Console.WriteLine("\n------------------------------------------------------------------------------");
}
########################
#             excepciones               #
########################
#definicion
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
#uso, lanzar excepcion
 public float PrecioVenta
        {
            get { return _precioVenta; }
            
            set {
                if (value <= 0)
                    throw new errorPrecioNegativo();
                _precioVenta = value;
            }
       
#atajarla entre try, catch
try
{
   Auto a = new Auto(1997, "Volswagen", "Gol", 12365478, 4587754, Combustible.Nafta, 20000, 3, false);
}
catch (errorPrecioNegativo e)
{
   Console.WriteLine("\n" + e.Message);
}
########################
#             verificar un tipo          #
########################             
if (v.GetType() == typeof(Auto)){...}else{...}
o
if (v is Auto){...}else{...}
################################
#   tipos anonimos,inicializacion, var dinamic    #
################################
#clases anonimas
var persona = new { Apellido=args[0],Nombre=args[1],Edad=args[2],Localidad=args[3]};

#var dinamics
 // dynamic es nuevo en framework 4.0, permite mas de una asignacion de diferentes tipos.
dynamic variable = new { Apellido = args[0], Nombre = args[1], Edad = args[2], Localidad = args[3] };
 variable = 100;
########################
#     entrada y verificacion          #
########################
#verificando tipo de dato que se ingresa
float precio;
Boolean resultado;

Console.WriteLine("Ingrese precio a consultar");
resultado = float.TryParse(Console.ReadLine(), out precio);
 if (resultado == false){......

#sin verificar tipo
String buff;
Console.WriteLine("\nHola loco:");
buff = Console.ReadLine();
Console.WriteLine(buff);