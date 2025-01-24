using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculadora;
class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Calculadora Avanzada por consola (.NET 9)");
            Console.WriteLine("=========================================");

            Console.WriteLine("Selecciona una operación:");
            Console.WriteLine("1. Suma.");
            Console.WriteLine("2. Resta.");
            Console.WriteLine("3. Multiplicación.");
            Console.WriteLine("4. División.");
            Console.WriteLine("5. Raíz Cuadrada.");
            Console.WriteLine("6. Elevar un número al cuadrado.");
            Console.WriteLine("7. Elevar a un número.");
            Console.WriteLine("8. Salir.");
            Console.WriteLine("=========================================");
            Console.Write("Tu elección: ");

            string operacion = Console.ReadLine() ?? "";

            Console.WriteLine("=========================================");

            if (operacion == "8")
            {
                Console.WriteLine("Gracias por usar la calculadora.");
                continuar = false;
                break;
            }

            Console.Write("Introduce el primer número: ");
           
            if (!double.TryParse(Console.ReadLine(), out double numero1))
            {
                Console.WriteLine("Entrada inválida. Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            double numero2 = 0;
      
            if (operacion is "1" or "2" or "3" or "4")
            {
                Console.Write("Introduce el segundo número: ");
                string inputNumero2 = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(inputNumero2) && !double.TryParse(inputNumero2, out numero2))
                {
                    Console.WriteLine("Entrada inválida. Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }
            }

            Console.WriteLine("=========================================");

            double resultado;

            switch (operacion)
            {
                case "1": // Sumar.
                    resultado = numero1 + numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "2": // Resta.
                    resultado = numero1 - numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "3": // Multiplicación.
                    resultado = numero1 * numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "4": // División.
                    if (numero2 == 0)
                    {
                        Console.WriteLine("Error: no se puede dividir por cero.");
                    }
                    else
                    {
                        resultado = numero1 / numero2;
                        Console.WriteLine($"Resultado: {resultado}");
                    }
                    break;
                case "5": // Raíz cuadrada.
                    if (numero1 < 0)
                    {
                        resultado = Math.Sqrt(Math.Abs(numero1));
                    }
                    else 
                    {
                        resultado = Math.Sqrt(numero1);
                    }
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "6": // Número al cuadrado.
                    resultado = Math.Pow(numero1, 2);
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "7": // Elevar a un número.
                    Console.Write("Introduce el exponente: ");
                    string inputExponente = Console.ReadLine() ?? "";

                    if (double.TryParse(inputExponente, out double exponente))
                    {
                        double resultadoExpo = Math.Pow(numero1, exponente);
                        Console.WriteLine($"Resultado: {resultadoExpo}");
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce un número válido para el exponente.");
                    }
                    break;
                default:
                    Console.WriteLine("Operación no válida.");
                    break;
            }

            Console.WriteLine("=========================================");

            if (continuar)
            {
                Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }
    }
}
