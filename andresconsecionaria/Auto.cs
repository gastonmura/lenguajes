using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Auto: Vehiculo
    {
        private int cantPuertas;
        private Boolean baul;

        public int CantPuertas
        {
            get
            {
                return this.cantPuertas;
            }
            set
            {
                if (value > 0)
                {
                    this.cantPuertas = value;
                }
            }

        }

        public Boolean Baul
        {
            get
            {
                return this.baul;
            }
            set
            {
                this.baul = value;
            }

        }

        public Auto(int anio, String marca, String modelo, int nro, int km, float precio, Combustibles comb, int cantP, Boolean baul): base(anio,marca,modelo,nro,km, precio,comb)
        {
            this.CantPuertas = cantP;
            this.Baul = baul;
        }

        public Auto(float precio, int anio, String marca, String modelo) : base(precio, anio, marca, modelo) { }
    }
}
