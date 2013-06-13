using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolaColection
{
    class Triangulo:Figura
    {
        private int _milado = 3;
        private float _mibase = 0;        
        private float _miperimetro = 0;
        public new int Lados
        {
            get
            {
                return _milado;
            }
            set
            {
                _milado = value;
            }
        }
        public new float Perimetro
        {
            get
            {
                return _miperimetro;
            }
            set
            {
                _miperimetro = value;
            }
        }
        public new float Base
        {
            get
            {
                   return _mibase;
            }
            set
            {
                _mibase = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Triangulo perimetro:{0} - base:{1}",this.Perimetro, this.Base);
        }
    }

    class Cuadrado : Figura
    {
        private int _milado = 4;
        private float _miperimetro = 0;
        public override int Lados
        {
            get
            {
                return _milado;
            }
            set
            {
                _milado = value;
            }
        }
        public override float Perimetro
        {
            get
            {
                return _miperimetro;
            }
            set
            {
                _miperimetro = value;
            }
        }
        public override float Base
        {
            get
            {
                return base.Base;
            }
            set
            {
                base.Base = value;
            }
        }
    }
}
