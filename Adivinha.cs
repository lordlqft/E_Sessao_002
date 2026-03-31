using System;

namespace Sessao2
{
    public static class Adivinha
    {
        public static void Executar()
        {
            Random random = new Random();
            int numero = random.Next(100, 1000); // número entre 100 e 999

            int tentativa;
            int maxTentativas = 10;
            Console.Clear();
            Console.WriteLine("Tente adivinhar o número entre 100 e 999!");

            while (true)
            {
                Console.Write("Digite sua tentativa: ");
                string input = Console.ReadLine()!;

                if (!int.TryParse(input, out tentativa))
                {
                    Console.WriteLine("Por favor, digite um número válido!\n");
                    continue;
                }

                if (tentativa < numero)
                {
                    Console.Clear();
                    Console.WriteLine($"O número é maior que {tentativa}.\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"O número é menor que {tentativa}.\n");
                }

                maxTentativas--;
                Console.WriteLine($"Tentativas restantes: {maxTentativas}");

                if (maxTentativas == 0)
                {
                    Console.WriteLine($"Você perdeu! O número era {numero}.");
                    break;
                }
                else if (tentativa == numero)
                {
                    Console.WriteLine($"Parabéns! Você acertou o número! ({numero})");
                    break;
                }
            }
        }
    }
}