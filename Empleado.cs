using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Empleados
{

    public class ExceptionDNI : Exception
    {
        public override string Message
        {
            get
            {
                return "El DNI no puede ser cero";
            }
        }
        
    }
    public abstract class Empleado: IComparable
    {
        private DateTime fechaIngreso;
        private int horasTrabajadas;
        private string nombre;
        private string dni;

        private delegate int eComp (Empleado x, Empleado y);

        private static eComp _comp = new eComp(Empleado.CompareNombre);

        private static int CompareNombre(Empleado x, Empleado y)
        {
              return x.Nombre.CompareTo(y.Nombre);
        }
                       
        private static int CompareDni(Empleado x, Empleado y) 
        {
               return x.Dni.CompareTo(y.Dni);
        }

        
        
        public int CompareTo(object obj)
        {
            return Empleado._comp((Empleado)this, (Empleado)obj); ;
        }

        public static void setCompareDni()
        {
            Empleado._comp = Empleado.CompareDni;
        }

        public static void setCompareNombre()
        {
            Empleado._comp = Empleado.CompareNombre;
        }


        public string Nombre {
            get {return this.nombre;}
            set { this.nombre = value; }
        }

        public string Dni {
            get {return this.dni;}
            set {
                if (value == "0")
                    throw new ExceptionDNI();
                this.dni = value; }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return this.fechaIngreso;

            }
            set
            {
                this.fechaIngreso = value;
            }
        }

        public int HorasTrabajadas
        {
            get
            {
                return this.horasTrabajadas;
            }
            set
            {
                this.horasTrabajadas = value;
            }
        }

        public abstract double DescuentoObraSocial();

        public abstract double BonoAntigüedad();

        public abstract double SueldoBasico();

        public double AsignacionFamiliar()
        {
            return 30;
        }
        public double Sueldo()
        {
            return this.SueldoBasico() + this.AsignacionFamiliar() + this.BonoAntigüedad() - this.DescuentoObraSocial();
        }

        public Empleado(int horas, DateTime fechaIngreso)
        {
            this.HorasTrabajadas = horas;
            this.FechaIngreso = fechaIngreso;
        }

        public Empleado(string n, string d) {
            this.Nombre = n;
            this.Dni = d;
        }

        public Empleado()
        {

        }
        

    }

}
