using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Camioneta : Vehiculos
    {
        //atributos
        private float _capacidadCarga;
        private String _descripcionMotor;

        //constructor
        public Camioneta(int Anio, String Marca, String Modelo, int NroMotor, int Km, Combustible Combustible, float Precio, float Carga, String DescMotor)
            : base(Anio, Marca, Modelo, NroMotor, Km, Combustible, Precio)
        {
            this.CapacidadCarga = Carga;
            this.DescripcionMotor = DescMotor;
        }

        //geters/seters

        public float CapacidadCarga
        {
            get { return _capacidadCarga; }
            set { _capacidadCarga = value; }
        }

        public String DescripcionMotor
        {
            get { return _descripcionMotor; }
            set { _descripcionMotor = value; }
        }
    }
}
