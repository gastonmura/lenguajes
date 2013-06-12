using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Auto : Vehiculos
    {
        //atributos
        private int _cantidadPuertas;
        private bool _baul;

        //constructor
        public Auto(int Anio, String Marca, String Modelo, int NroMotor, int Km, Combustible Combustible, float Precio, int CantidadPuertas, bool Baul)
            : base(Anio, Marca, Modelo, NroMotor, Km, Combustible, Precio)
        {
            this.CantidadPuertas = CantidadPuertas;
            this.Baul = Baul;
        }
        //geters/seters
        public int CantidadPuertas
        {
            get { return _cantidadPuertas; }
            set { _cantidadPuertas = value; }
        }

        public bool Baul
        {
            get { return _baul; }
            set { _baul = value; }
        }
    }

}
