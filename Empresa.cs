using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Empleados
{

    class EmpresaEnumerator : IEnumerator
    {
        private int actual;
        private Empresa e;

        public EmpresaEnumerator(Empresa e)
        {
            actual = -1;
            this.e = e;
        }
        public Object Current
        {
            get { return this.e[this.actual]; }
        }

        public bool MoveNext()
        {
            if (this.actual >= this.e.CantidadEmpleados() - 1)
                return false;
            this.actual++;
            return true;
        }

        public void Reset()
        {
            this.actual = -1;
        }
    }

    class Empresa: IEnumerable
    {
        private System.Collections.Generic.List<Empleado> empleados;
             
        public Empresa()
        { 
            this.empleados = new List<Empleado>();
        }

        public IEnumerator GetEnumerator()
        {
            return new EmpresaEnumerator(this);
        }

        public int CantidadEmpleados()
        {
            return this.empleados.Count;
        }

        public Empleado this[int index]
        {
            get { return this.empleados[index]; }
        }

        public void AgregarEmpleado(Empleado e) 
        {
            this.empleados.Add(e);
        }
    }
}
