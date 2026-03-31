using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sessao2
{
    public static class Calculadora
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("Calculadora Simples");
            Console.WriteLine("Digite o primeiro número:");
            double num1 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o segundo número:");
            double num2 = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Escolha a operação (+, -, *, /):");
            string operacao = Console.ReadLine()!;

            double resultado = 0;

            switch (operacao)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        resultado = num1 / num2;
                    else
                        Console.WriteLine("Erro: Divisão por zero!");
                    break;
                default:
                    Console.WriteLine("Operação inválida!");
                    return;
            }

            Console.WriteLine($"Resultado: {resultado}");
        }
    }
}