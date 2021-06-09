using System;
using System.Collections.Generic;
using System.Threading;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Login : ILogin
    {
        // Atributos
        public bool Logado { get; set; }
        Usuario usuarioPai = new Usuario();
        Marca marcaPai = new Marca();
        string emailLogin;
        string senhaLogin;
        
        // Métodos
        public string Deslogar(Usuario usuario)
        {
            if (Logado)
            {
                Logado = false;
                return ("");
            }
            return ("");
        }

        public string Logar(Usuario usuario)
        {
            if (!Logado) {
                Logado = true;
                return ("");
            }
            return ("");
        }


        // Construtor
        public Login()
        {
            Console.Clear();
            bool isInt;
            int opcInt;
            int codUser = 0;
            int codMarca = 0;
            string senhaAdm = "lima";

            do
            {
                do
                {
                    Console.WriteLine("O que você deseja fazer? ");
                    Console.WriteLine("Cadastrar usuário [1]\nDeletar usuário [2]");
                    Console.WriteLine("Logar [3]\nDeslogar [4]");
                    Console.WriteLine("Cadastrar marca [5]\nListar marca [6]\nDeletar marca [7]");
                    Console.WriteLine("Cadastrar produto [8]\nListar produto [9]\nDeletar produto [10]");
                    Console.Write("Sair [0]\n ->");
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
                            if (senhaUser == confirmaSenha && senhaUser != "") {
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
                        Console.WriteLine("Digite o Email: ");
                        string emailLogin = Console.ReadLine().Trim();
                        
                        Console.WriteLine("Digite a senha: ");
                        string senhaLogin = Console.ReadLine().Trim();

                        bool avaliou = usuarioPai.AvaliarEmailSenha(emailLogin, senhaLogin);
                        if (avaliou) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Logar(usuarioPai.UserPeloEmail(emailLogin));

                            Console.WriteLine(usuarioPai.UserPeloEmail(emailLogin).LogarUsuario());
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                            
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Senha ou Email invalidos.");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;

                    case 4: // Deslogar
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Digite o email para confirmar: ");
                        Console.ResetColor();

                        string emailDeslog = Console.ReadLine().ToLower();
                        bool emailValido = usuarioPai.AvaliarEmail(emailDeslog);
                        if (emailValido)
                        {
                            Deslogar(usuarioPai.UserPeloEmail(emailDeslog));
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(usuarioPai.UserPeloEmail(emailDeslog).DeslogarUsuario());

                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Email invalido.");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;

                    case 5: // Cadastrar marca
                        Console.WriteLine("Identifique-se com seu email");
                        string emailIdentMarca = Console.ReadLine().ToLower();
                        Console.Clear();

                        bool emailCadastrado = usuarioPai.AvaliarEmail(emailIdentMarca); 
                        if (emailCadastrado)
                        {
                            if (usuarioPai.UserPeloEmail(emailIdentMarca).Logado) {
                                Console.WriteLine("Qual marca você deseja cadastar? ");
                                string marca = Console.ReadLine().ToUpper().Trim();
                                codMarca += 1;
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(marcaPai.Cadastrar(new Marca(codMarca,marca)));

                                Console.ResetColor();
                                Thread.Sleep(2000);
                                Console.Clear();
                            } else {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Você precisa primeiro estar logado");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                                Console.Clear();
                            }
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Email não cadastrado");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;
                    
                    case 6: // Listar marcas
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("MARCAS\n\n");
                        Console.ResetColor();
        
                        foreach (Marca marca in marcaPai.Listar())
                        {
                            Console.WriteLine($"- {marca.NomeMarca}");
                        }
                        Console.Write("\nAperter alguma tecla: ");
                        string segura = Console.ReadLine();
                        Console.Clear();

                        break;

                    case 7: // Deletar marca
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Digite a senha de Administrador: ");
                        Console.ResetColor();
                        senhaAdmConfirm = Console.ReadLine();


                        if (senhaAdm == senhaAdmConfirm) {
                            Console.Clear();
                            foreach (Marca marca in marcaPai.Listar())
                            {
                                Console.WriteLine($"- {marca.NomeMarca} - Codigo: {marca.RetornarCodigo()}");
                            }
                            Console.WriteLine("Qual o codigo da marca que você quer deletar? ");
                            string marcaDeleteStr = Console.ReadLine();

                            int marcaDeleteInt;
                            isInt = int.TryParse(marcaDeleteStr, out marcaDeleteInt);

                            if (isInt)
                            {
                                marcaDeleteInt = int.Parse(marcaDeleteStr);
                                if (marcaDeleteInt == 0)
                                {   
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Nenhuma marca foi deletada");
                                    Console.ResetColor();
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                } else {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(marcaPai.Deletar(marcaPai.Listar().Find(x => x.RetornarCodigo() == marcaDeleteInt)));
                                    Console.ResetColor();
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                
                            }
                        } else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Senha incorreta");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
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