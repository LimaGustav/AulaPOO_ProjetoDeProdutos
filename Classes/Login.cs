using System;
using System.Threading;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Login : ILogin
    {
        public bool Logado { get; set; }
        
        public string Deslogar(Usuario usuario)
        {
            if (Logado)
            {
                Logado = false;
                return ($"{usuario.Nome} saiu");
            }
            return ($"{usuario.Nome} já está deslogado");
        }

        public string Logar(Usuario usuario)
        {
            if (!Logado) {
                Logado = true;
                return ($"{usuario.Nome} entrou");
            }
            return ($"{usuario.Nome} já está logado");
        }

        public Login()
        {
            Usuario usuarioPai = new Usuario();
            bool isInt;
            int opcInt;
            int codUser = 0;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("O que você deseja fazer? ");
                    Console.WriteLine("Cadastrar usuário [1]\nDeletar usuário [2]");
                    Console.Write("Logar [3]\nDeslogar [4]\n-> ");
                    string opcString = Console.ReadLine();
                    isInt = int.TryParse(opcString, out opcInt);
                } while (!isInt);

                switch (opcInt)
                {
                    case 1: // Cadastrar usuário
                        Console.WriteLine("Qual seu nome? ");
                        string nomeUser = Console.ReadLine().ToUpper();

                        Console.WriteLine("Digite seu Email");
                        string emailUser = Console.ReadLine().ToLower();

                        bool senhaCorreta;

                        do
                        {
                            Console.WriteLine("Cadastre uma senha: ");
                            string senhaUser = Console.ReadLine();

                            Console.WriteLine("Digite novamente a senha: ");
                            string confirmaSenha = Console.ReadLine();
                            if (senhaUser == confirmaSenha) {
                                senhaCorreta = true;
                                codUser += 1;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine();
                                Console.WriteLine(usuarioPai.Cadastrar(new Usuario(codUser,nomeUser,emailUser,senhaUser)));
                                Thread.Sleep(1000);
                                Console.ResetColor();
                                
                            } else {
                                senhaCorreta = false;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Senhas divergentes.");
                                Console.ResetColor();
                            }
                        } while (!senhaCorreta);
                        break;

                        case 2: // Deletar usuario

                            break;


                    default:

                        break;
                }
            } while (opcInt != 0);
            
        }
    }
}