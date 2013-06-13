using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolaColection
{
    public abstract class Figura
    {
        public virtual int Lados { get; set; }
        public abstract float Perimetro { get; set; }
        public virtual float Base { get; set; }
    }
}
