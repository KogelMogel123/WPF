using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siec3
{
    public class Neuron
    {
        public double[] Pozycja { get; set; }
        public double Przesuniecie { get; set; }
        public double Odleglosc { get; set; }

        public Neuron(int lCech, double przesuniecie)
        {
            Pozycja = new double[lCech];
            Przesuniecie = przesuniecie;
        }

        public double ZmierzOdleglosc(Probka p)
        {
            double x = 0;

            for (int i = 0; i < p.pozycja.Length; i++)
            {
                x += Math.Pow((p.pozycja[i] - Pozycja[i]), 2);
            }
            Odleglosc = Math.Sqrt(x);

            return Odleglosc;
        }

        public void Przesun(Probka p)
        {
            for (int i = 0; i < p.pozycja.Length; i++)
            {
                if ((Pozycja[i] - p.pozycja[i] > 0))
                    Pozycja[i] -= Przesuniecie;
                else if ((Pozycja[i] - p.pozycja[i] < 0))
                    Pozycja[i] += Przesuniecie;
            }
        }
    }
}
