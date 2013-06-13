using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concesionaria
{
    class Camioneta: Vehiculo
    {
        private float capacidad;
        private String descr;

        public String Descripcion
        {
            get
            {
                return this.descr;
            }
            set
            {
                this.descr = value;
            }
        }

        public float Capacidad
        {
            get
            {
                return this.capacidad;
            }
            set
            {
                if (value > 0)
                {
                    this.capacidad = value;
                }
            }

        }

        public Camioneta(int anio, String marca, String modelo, int nro, int km, float precio, Combustibles comb, float capacidad, String desc)
            : base(anio, marca, modelo, nro, km, precio, comb)
        {
            this.Capacidad = capacidad;
            this.Descripcion = desc;
        }

        public Camioneta(float precio, int anio, String marca, String modelo) : base(precio, anio, marca, modelo) { }
    }
}
