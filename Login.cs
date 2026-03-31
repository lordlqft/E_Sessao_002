using System;
using System.Collections.Generic;

namespace Sessao2
{
    class Usuario
    {
        public string Nome;
        public string Senha;
        public DateTime DataCadastro;
    }

    public static class Login
    {
        static List<Usuario> usuarios = new List<Usuario>();

        public static void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema!");
                Console.WriteLine("1. Cadastrar\n2. Login\n3. Sair");
                Console.Write("-> ");

                int escolha;
                while (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.Write("Opção inválida! -> ");
                }

                switch (escolha)
                {
                    case 1:
                        Cadastrar();
                        break;

                    case 2:
                        LoginUsuario();
                        break;

                    case 3:
                        Console.WriteLine("Encerrando programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Cadastrar()
        {
            Console.Clear();

            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine()!;

            Usuario novo = new Usuario
            {
                Nome = nome,
                Senha = senha,
                DataCadastro = DateTime.Now
            };

            usuarios.Add(novo);

            Console.WriteLine("\nCadastro realizado com sucesso!\n(aperte enter para continuar)");
            Console.ReadKey();
        }

        static void LoginUsuario()
        {
            Console.Clear();

            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine()!;

            Usuario usuario = usuarios.Find(u => u.Nome == nome && u.Senha == senha)!;

            if (usuario == null)
            {
                Console.WriteLine("Login inválido!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nBem-vindo, {usuario.Nome}!\n(aperte enter para continuar)");
            Console.ReadKey();

            MenuUsuario(usuario);
        }

        static void MenuUsuario(Usuario usuario)
        {
            bool logado = true;

            while (logado)
            {
                Console.Clear();
                Console.WriteLine($"Usuário: {usuario.Nome}");
                Console.WriteLine("\n1. Ver perfil\n2. Alterar senha\n3. Excluir conta\n4. Logout");
                Console.Write("-> ");

                int escolha;
                while (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.Write("Opção inválida! -> ");
                }

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Nome: {usuario.Nome}");
                        Console.WriteLine($"Senha: {usuario.Senha}");
                        Console.WriteLine($"Criado em: {usuario.DataCadastro:dd/MM/yyyy HH:mm}\n(aperte enter para continuar)");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Confirme sua senha atual: ");
                        string senhaAtual = Console.ReadLine()!;

                        if (senhaAtual != usuario.Senha)
                        {
                            Console.WriteLine("Senha incorreta!\n(aperte enter para continuar)");
                            Console.ReadKey();
                            break;
                        }

                        else
                        {
                            Console.Write("Digite a nova senha: ");
                            usuario.Senha = Console.ReadLine()!;
                            Console.WriteLine("Senha alterada!\n(aperte enter para continuar)");
                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        usuarios.Remove(usuario);

                        Console.Write("Confirme sua senha atual: ");
                        senhaAtual = Console.ReadLine()!;

                        if (senhaAtual != usuario.Senha)
                        {
                            Console.WriteLine("Senha incorreta!\n(aperte enter para continuar)");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            usuarios.Remove(usuario);
                        }
                        Console.WriteLine("Conta excluída!\n(aperte enter para continuar");
                        Console.ReadKey();
                        logado = false;
                        break;

                    case 4:
                        Console.WriteLine("Logout realizado!\n(aperte enter para continuar");
                        Console.ReadKey();
                        logado = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n(aperte enter para continuar");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}