using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolaColection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Figura> lista = new List<Figura>();
            
            lista.Add(new Cuadrado {  Base = 0, Lados = 4 , Perimetro = 40});
            lista.Add(new Triangulo { Perimetro = 35 } );

            foreach (Figura figura in lista)
            {
                System.Console.WriteLine(figura);
            }


            System.Console.ReadKey();
        }
    }
}
