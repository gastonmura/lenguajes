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
