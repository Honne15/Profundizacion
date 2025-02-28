using System;
using System.Collections;
using System.Collections.Generic;

namespace SegundaClase
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            
            int[] numeros = { 1, 2, 3, 4, 5, 6 };
            List<string> lista = new List<string> { "A", "B", "C" };
            Dictionary<int, string> dic = new Dictionary<int, string>
            {
                { 1, "Uno" },
                { 2, "Dos" }
            };
            
            Console.WriteLine("Array: " + string.Join(", ", numeros));
            Console.WriteLine("Lista: " + string.Join(", ", lista));
            Console.WriteLine("Diccionario: " + dic[1]);

        }
    }
}

