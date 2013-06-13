using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Vehiculo : IComparable
    {
        private int anio;
        private String marca;
        private String modelo;
        private int nro_motor;
        private int kilometros;
        private float precioV;
        public enum Combustibles
        {
            nafta,
            gasoil,
        }
        private Combustibles combustible;

        public int Anio
        {
            get
            {
                return this.anio;
            }
            set
            {
                if (value > 0)
                {
                    this.anio = value;
                }
            }

        }

        public String Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }

        public String Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }

        public int NroMotor
        {
            get
            {
                return this.nro_motor;
            }
            set
            {
                this.nro_motor = value;
            }
        }

        public int Kilometros
        {
            get
            {
                return this.kilometros;
            }
            set
            {
                if (value > 0)
                {
                    this.kilometros = value;
                }
            }

        }

        public float PrecioV
        {
            get
            {
                return this.precioV;
            }
            set
            {
                if (value > 0)
                {
                    this.precioV = value;
                }
            }

        }

        public Combustibles Combustible
        {
            get
            {
                return this.combustible;
            }
            set
            {
                this.combustible = value;
            }
        }

        private delegate int eCompXAnio (Vehiculo x, Vehiculo y);
        private static eCompXAnio _comp = new eCompXAnio(Vehiculo.CompareAnio);
        private static int CompareAnio(Vehiculo x, Vehiculo y)
        {
            return x.anio.CompareTo(y.anio);
        }

        public int CompareTo(object obj)
        {
            return Vehiculo._comp((Vehiculo)this, (Vehiculo)obj);
        }

        public Vehiculo(int anio, String marca, String modelo, int nro, int km, float precio, Combustibles comb)
        {
            this.Anio = anio;
            this.Marca = marca;
            this.Modelo = modelo;
            this.NroMotor = nro;
            this.Kilometros = km;
            this.PrecioV = precio;
            this.Combustible = comb;
        }

        public Vehiculo(float precio, int anio, String marca, String modelo)
        {
            this.PrecioV = precio;
            this.Anio = anio;
            this.Marca = marca;
            this.Modelo = modelo;
        }

        public override string ToString()
        {
            return "Marca: " + this.Marca+ " Modelo "+ this.Modelo + " Anio "+ this.Anio;
        }

    }
}
