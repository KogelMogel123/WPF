using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Siec3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"D:\tekst.txt";
            Console.WriteLine("Wpisz nazwę pliku z danymi (np: tekst.txt)");
            string fileName = Console.ReadLine();
            string filePath = $@"D:\{fileName}";

            Console.WriteLine("Wpisz znak, którym oddzielasz dane w pliku (np: ';')");
            string fileSeparator = Console.ReadLine();

            List<string> lines = File.ReadAllLines(filePath).ToList();
            
            Random rnd = new Random();
            
            int dlugoscNauki = 200;
            int liczbaProbek = 0;
            int liczbaCech = 3;
            int liczbaKlas = 2;
            double wspolczynnikNauki = 0.2;

            foreach (var line in lines)
            {
                liczbaProbek++;
            }
            Probka[] probki = new Probka[liczbaProbek];

            

            
            Console.WriteLine("Podaj liczbę cech (domyślnie: 3)");
            liczbaCech = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj liczbę klas (domyślnie: 2)");
            liczbaKlas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj długość nauki wyrażaną w liczbach przejść po całej kolekcji próbek (domyślnie: 200)");
            dlugoscNauki = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj współczynnik nauki (domyślnie: 0,2)");
            wspolczynnikNauki = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            double[] cechyMax = new double[liczbaCech];
            double[] cechyMin = new double[liczbaCech];

            double[,] tablicaOdleglosci = new double[liczbaCech,liczbaKlas];

            int q = 0;
            foreach (var line in lines)
            {
                probki[q] = new Probka(liczbaCech);
                string[] entries = line.Split(Convert.ToChar($"{fileSeparator}"));
                for(int i=0;i<entries.Length;i++)
                {
                    probki[q].pozycja[i] = Convert.ToDouble(entries[i]);
                }
                q++;
            }
            //MAX
            for(int i=0;i<liczbaProbek;i++)
            {
                for(int j=0;j<liczbaCech;j++)
                {
                    if(probki[i].pozycja[j] > cechyMax[j])
                        cechyMax[j] = probki[i].pozycja[j];
                    cechyMin[j] = cechyMax[j];
                }
            }

            //MIN
            for (int i = 0; i < liczbaProbek; i++)
            {
                for (int j = 0; j < liczbaCech; j++)
                {
                    if (probki[i].pozycja[j] < cechyMin[j])
                        cechyMin[j] = probki[i].pozycja[j];
                }
            }

            Console.WriteLine("Wartości maksymalne i minimalne dla wszystkich próbek:");
            for (int i=0;i<liczbaCech;i++)
            {
                Console.WriteLine($"Max: {cechyMax[i]}");
                Console.WriteLine($"Min: {cechyMin[i]}");
                Console.WriteLine();
            }

            Neuron[] neurony = new Neuron[liczbaKlas];

            for(int i=0;i<liczbaKlas;i++)
            {
                neurony[i] = new Neuron(liczbaCech, wspolczynnikNauki);
                for(int j=0;j<liczbaCech;j++)
                {
                    neurony[i].Pozycja[j] = rnd.NextDouble() * (cechyMax[j] - cechyMin[j]) + cechyMin[j];
                }
                
            }

            //NAUKA
            int ktoryNeuron = 0;
            double najmniejszaOdleglosc = double.MaxValue;
            
            for (int i = 0; i < dlugoscNauki; i++)
            {
                najmniejszaOdleglosc = double.MaxValue;
                for(int z = 0; z < liczbaCech; z++)
                {
                    for (int j = 0; j < liczbaKlas; j++)
                    {
                        if (neurony[j].ZmierzOdleglosc(probki[z]) < najmniejszaOdleglosc)
                        {
                            najmniejszaOdleglosc = neurony[j].ZmierzOdleglosc(probki[z]);
                            ktoryNeuron = j;
                        }
                    }
                    neurony[ktoryNeuron].Przesun(probki[z]);
                } 
            }

            //WYPISANIE WYJŚĆ
            Console.WriteLine("Neurony:");
            for(int i = 0; i<liczbaKlas;i++)
            {
                for(int j=0;j<liczbaCech;j++)
                {
                    Console.WriteLine($"Wartość {j+1}: {neurony[i].Pozycja[j]}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
