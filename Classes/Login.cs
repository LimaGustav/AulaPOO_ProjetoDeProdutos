using System;
using System.Collections.Generic;
using System.Threading;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Login : ILogin
    {
        // Atributos
        // public bool Logado { get; set; }
        Usuario usuarioPai = new Usuario();
        string emailLogin;
        string senhaLogin;
        
        // Métodos
        public string Deslogar(Usuario usuario)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o email para confirmar: ");
            Console.ResetColor();

            string emailDeslog = Console.ReadLine().ToLower();
            if (usuarioPai.UserPeloEmail(emailDeslog).Logado)
            {
                usuarioPai.UserPeloEmail(emailDeslog).Logado = false;
                return ($"{usuario.Nome} saiu");
            }
            return ($"{usuario.Nome} já está deslogado");
        }

        public string Logar(Usuario usuario)
        {
            Console.Clear();
            Console.WriteLine("Digite o Email: ");
            emailLogin = Console.ReadLine().Trim();
            
            Console.WriteLine("Digite a senha: ");
            senhaLogin = Console.ReadLine().Trim();

            bool avaliou = usuarioPai.AvaliarEmailSenha(emailLogin, senhaLogin);
            if (avaliou) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Logar(usuarioPai.UserPeloEmail(emailLogin)));
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
                if (usuarioPai.UserPeloEmail(emailLogin).Logado == false) {
                    usuarioPai.UserPeloEmail(emailLogin).Logado = true;
                    return ($"{usuario.Nome} entrou");
                }
                return ($"{usuario.Nome} já está logado");
                
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Senha ou Email invalidos.");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();
            }
            return "";
        }

        // Construtor
        public Login()
        {
            Console.Clear();
            bool isInt;
            int opcInt;
            int codUser = 0;
            string senhaAdm = "lima";

            do
            {
                do
                {
                    Console.WriteLine("O que você deseja fazer? ");
                    Console.WriteLine("Cadastrar usuário [1]\nDeletar usuário [2]");
                    Console.Write("Logar [3]\nDeslogar [4]\n-> ");
                    string opcString = Console.ReadLine().Trim();
                    isInt = int.TryParse(opcString, out opcInt);
                    if (!isInt) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção invalida");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                } while (!isInt);

                switch (opcInt)
                {
                    case 1: // Cadastrar usuário
                        Console.Clear();
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
                                Console.Clear();
                                
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
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Digite a senha de Administrador: ");
                            Console.ResetColor();
                            string senhaAdmConfirm = Console.ReadLine();
                            if (senhaAdm == senhaAdmConfirm) {
                                int userCodInt;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("USUARIOS\n\n");
                                Console.ResetColor();
                                if (usuarioPai.usuariosCadastrados.Count != 0) {
                                    do
                                    {
                                        foreach (Usuario user in usuarioPai.usuariosCadastrados)
                                        {
                                            Console.WriteLine($"{user.Nome} - Codigo: {user.Codigo}");
                                        }
                                        Console.Write("\nQual o codigo do usuário que você quer deletar? ");
                                        string userCodStr = Console.ReadLine().Trim();
                                        isInt = int.TryParse(userCodStr, out userCodInt);
                                        if (isInt) {
                                            userCodInt = int.Parse(userCodStr);
                                        }
                                    } while (!isInt);
                                    if (userCodInt == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Nenhum usuario foi deletado");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(usuarioPai.Deletar(usuarioPai.usuariosCadastrados.Find(x => x.Codigo == userCodInt))); // Deleta o objeto que tem o codigo userCodInt
                                        Thread.Sleep(1000);
                                        Console.ResetColor();
                                        Console.Clear();
                                    }
                                } else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nenhum usuário cadastrado");
                                    Thread.Sleep(2000);
                                    Console.ResetColor();
                                    Console.Clear();
                                }

                            } else {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Senha incorreta");
                                Console.ResetColor();
                                Thread.Sleep(1000);
                                Console.Clear();
                            }

                            break;

                    case 3: // Logar
                        Console.Clear();
                        Console.WriteLine(Logar(usuarioPai.UserPeloEmail(emailLogin)));
                        // Console.WriteLine("Digite o Email: ");
                        // string emailLogin = Console.ReadLine().Trim();
                        
                        // Console.WriteLine("Digite a senha: ");
                        // string senhaLogin = Console.ReadLine().Trim();

                        // bool avaliou = usuarioPai.AvaliarEmailSenha(emailLogin, senhaLogin);
                        // if (avaliou) {
                        //     Console.ForegroundColor = ConsoleColor.Green;
                        //     Console.WriteLine(Logar(usuarioPai.UserPeloEmail(emailLogin)));
                        //     Console.ResetColor();
                        //     Thread.Sleep(1000);
                        //     Console.Clear();
                            
                        // } else {
                        //     Console.ForegroundColor = ConsoleColor.Red;
                        //     Console.WriteLine("Senha ou Email invalidos.");
                        //     Console.ResetColor();
                        //     Thread.Sleep(1000);
                        //     Console.Clear();
                        // }
                        break;

                    case 4: // Deslogar
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Digite o email para confirmar: ");
                        Console.ResetColor();

                        string emailDeslog = Console.ReadLine().ToLower();
                        Console.WriteLine(Deslogar(usuarioPai.UserPeloEmail(emailDeslog)));
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção invalida");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            } while (opcInt != 0);
            
        }
    }
}