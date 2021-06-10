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
            Usuario usuarioPai = new Usuario();
            Marca marcaPai = new Marca();
            Produto produtoPai = new Produto();

            string emailLogin;
            string senhaLogin;

            Console.Clear();
            bool isInt;
            int opcInt;
            int codUser = 0;
            int codMarca = 0;
            int codProduto = 0;
            string senhaAdm = "lima";

            do
            {
                do
                {
                    Console.WriteLine("O que você deseja fazer? ");
                    Console.WriteLine("1 - Cadastrar usuário\n2 - Deletar usuário");
                    Console.WriteLine("3 - Logar\n4 - Deslogar");
                    Console.WriteLine("5 - Cadastrar marca\n6 - Listar marca\n7 - Deletar marca");
                    Console.WriteLine("8 - Cadastrar produto\n9 - Listar produto\n10 - Deletar produto");
                    Console.Write("0 - Sair\n-> ");
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
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\tCadastro de Usuário\n");
                        Console.ResetColor();
                        string nomeUser;
                        do
                        {
                            Console.WriteLine("Qual seu nome? ");
                            nomeUser = Console.ReadLine().ToUpper();
                            if (nomeUser == "")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Digite um nome de usuário");
                                Console.ResetColor();
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                        } while (nomeUser == "");
                        

                        string emailUser;
                        do
                        {
                            Console.WriteLine("\nDigite seu Email");
                            emailUser = Console.ReadLine().ToLower();
                            if (emailUser == "")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Digite um email valido");
                                Console.ResetColor();
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                        } while (emailUser == "");
                        

                        bool senhaCorreta;

                        do
                        {
                            Console.WriteLine("\nCadastre uma senha: ");
                            string senhaUser = Console.ReadLine();

                            Console.WriteLine("\nDigite novamente a senha: ");
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
                                Console.WriteLine("Senhas divergentes ou vazias.");
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
                                Console.WriteLine("\tUSUARIOS\n\n");
                                Console.ResetColor();
                                if (usuarioPai.usuariosCadastrados.Count != 0) {
                                    do
                                    {
                                        foreach (Usuario user in usuarioPai.usuariosCadastrados)
                                        {
                                            Console.WriteLine($"{user.RetornarEmail()} - [{user.Nome}] - Codigo: {user.Codigo}");
                                        }
                                        Console.Write("\nQual o codigo do usuário que você quer deletar? ");
                                        string userCodStr = Console.ReadLine().Trim();
                                        isInt = int.TryParse(userCodStr, out userCodInt);
                                        if (isInt) {
                                            userCodInt = int.Parse(userCodStr);
                                        }
                                        Console.Clear();
                                    } while (!isInt);
                                    if (userCodInt == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Nenhum usuario foi deletado");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } else {
                                        if (userCodInt > codUser || userCodInt < 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nCodigo Invalido");
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

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tLOGIN\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Email: ");
                        emailLogin = Console.ReadLine().Trim().ToLower();
                        
                        Console.WriteLine("\nDigite a senha: ");
                        senhaLogin = Console.ReadLine().Trim();

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

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\tDESLOGAR");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nDigite o email para confirmar: ");
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
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("\tCADASTRO DE MARCA\n");
                        Console.ResetColor();

                        Console.WriteLine("Identifique-se com seu Email");
                        string emailIdentMarca = Console.ReadLine().ToLower();

                        Console.WriteLine("\nDigite sua senha: ");
                        string senhaIdentMarca = Console.ReadLine();
                        Console.Clear();

                        bool valido = usuarioPai.AvaliarEmailSenha(emailIdentMarca,senhaIdentMarca); 
                        if (valido)
                        {
                            if (usuarioPai.UserPeloEmail(emailIdentMarca).Logado) {

                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("\tCADASTRO DE MARCA\n");
                                Console.ResetColor();

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
                            Console.WriteLine("Senha ou Email invalidos");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;
                    
                    case 6: // Listar marcas
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tMARCAS\n\n");
                        Console.ResetColor();
        
                        foreach (Marca marca in marcaPai.Listar())
                        {
                            Console.WriteLine($"{marca.NomeMarca}");
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
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tMARCAS\n\n");
                        Console.ResetColor();

                        if (senhaAdm == senhaAdmConfirm) {
                            if (marcaPai.Listar().Count != 0)
                            {
                                foreach (Marca marca in marcaPai.Listar())
                                {
                                    Console.WriteLine($"- {marca.NomeMarca} - Codigo: {marca.RetornarCodigo()}");
                                }
                                Console.WriteLine("\nQual o codigo da marca que você quer deletar? ");
                                string marcaDeleteStr = Console.ReadLine();

                                int marcaDeleteInt;
                                isInt = int.TryParse(marcaDeleteStr, out marcaDeleteInt);

                                if (isInt)
                                {
                                    marcaDeleteInt = int.Parse(marcaDeleteStr);
                                    if (marcaDeleteInt == 0)
                                    {   
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Nenhuma marca foi deletada");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } else {
                                        if (marcaDeleteInt > codMarca || marcaDeleteInt < 0)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nCodigo Invalido");
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
                                }
                            } else {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhuma marca cadastrada");
                                Thread.Sleep(2000);
                                Console.ResetColor();
                                Console.Clear();
                            } 
                        } else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nSenha incorreta");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;

                    case 8: // Cadastrar produto
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tCADASTRO DE PRODUTOS\n");
                        Console.ResetColor();

                        Console.WriteLine("Identifique-se com seu email");
                        string emailIdentProd = Console.ReadLine().ToLower();

                        Console.WriteLine("\nDigite sua senha: ");
                        string senhaIdentProd = Console.ReadLine();
                        Console.Clear();

                        valido = usuarioPai.AvaliarEmailSenha(emailIdentProd,senhaIdentProd);
                        if (valido)
                        {
                            if (usuarioPai.UserPeloEmail(emailIdentProd).Logado) {
                                int c = 0;
                                bool isFloat;
                                string continuar = "s";
                                float precoFloat;

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\tCADASTRO DE PRODUTOS\n");
                                Console.ResetColor();

                                Console.WriteLine("Qual o nome do produto?");
                                string nomeProd = Console.ReadLine().ToUpper().Trim();

                                do
                                {
                                    Console.WriteLine("\nQual o preço do produto? ");
                                    string precoStr = Console.ReadLine().Trim();
                                    isFloat = float.TryParse(precoStr, out precoFloat);
                                    if (isFloat) {
                                        precoFloat = float.Parse(precoStr);
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Digite apenas números");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                    } 
                                } while (!isFloat);
                                
                                bool check = false;
                                do
                                {
                                    Console.WriteLine("\nQual a marca do produto? ");
                                    string marcaProduto = Console.ReadLine().ToUpper().Trim();

                                    foreach (Marca marca in marcaPai.Listar())
                                    {
                                        if (marca.NomeMarca == marcaProduto)
                                        {
                                            codProduto += 1;

                                            Marca marcaProd = marcaPai.MarcaPeloNome(marcaProduto);
                                            Usuario usuarioProd = usuarioPai.UserPeloEmail(emailIdentProd);
                                            
                                            Produto novoProduto = new Produto(codProduto,nomeProd,precoFloat,marcaProd,usuarioProd);

                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine(produtoPai.Cadastrar(novoProduto));
                                            Thread.Sleep(1000);
                                            Console.ResetColor();
                                            Console.Clear();
                                            c += 1;
                                        }
                                    } if (c == 0) {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Não existe nenhuma marca {marcaProduto}");
                                        Console.ResetColor();

                                        bool opcInvalida = false;
                                        do
                                        {
                                            Console.Write("Ainda quer cadastrar o produto? (S/N) ");
                                            continuar = Console.ReadLine().ToLower().Trim().Substring(0,1);
                                            Console.Clear();

                                            switch (continuar)
                                            {
                                                case "s":
                                                    check = true;
                                                    break;
                                                case "n":
                                                    check = false;
                                                    break;
                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Opção invalida");
                                                    Console.ResetColor();
                                                    opcInvalida = true;
                                                    check = false;
                                                    break;
                                            }
                                        } while (opcInvalida);  
                                    }
                                } while (check);

                            } else {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Você precisa primeiro estar logado");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                                Console.Clear();
                            }
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Senha ou Email invalidos");
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;

                    case 9: // Listar produto
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\tPRODUTOS\n\n");
                        Console.ResetColor();
        
                        foreach (Produto produto in produtoPai.Listar())
                        {
                            Console.WriteLine($"{produto.RetornaNome()} - {produto.RetornaNomeMarca()} - {produto.RetornaPreco():C2}");
                        }
                        Console.Write("\nAperter alguma tecla: ");
                        segura = Console.ReadLine();
                        Console.Clear();
                        break;

                        case 10: // Deletar produto
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Digite a senha de Administrador: ");
                            Console.ResetColor();
                            senhaAdmConfirm = Console.ReadLine();


                            if (senhaAdm == senhaAdmConfirm) {
                                if (produtoPai.Listar().Count != 0)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    foreach (Produto prod in produtoPai.Listar())
                                    {
                                        Console.WriteLine($"{prod.RetornaData()} - {prod.RetornaNome()} - {prod.RetornaNomeMarca()} - {prod.RetornaPreco():C2} - {prod.RetornaUserCadastrou().RetornarEmail()} - Codigo [{prod.RetornarCodigo()}]");
                                    }
                                    Console.ResetColor();

                                    Console.Write("\nDigite o código do produto que deseja deletar: ");
                                    string prodDelStr = Console.ReadLine();
                                    int prodDelInt;
                                    isInt = int.TryParse(prodDelStr, out prodDelInt);

                                    if (isInt) {
                                        prodDelInt = int.Parse(prodDelStr);
                                    } else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Digite apenas números. ");
                                        Console.ResetColor();
                                    }
                                    
                                    if (prodDelInt == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Nenhum produto foi deletado");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } else {
                                        if (prodDelInt > codProduto || prodDelInt < 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nCodigo Invalido");
                                            Console.ResetColor();
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        } else {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine(produtoPai.Deletar(produtoPai.ProdutoPeloCodigo(prodDelInt)));
                                            Console.ResetColor();
                                            Thread.Sleep(1000);
                                            Console.Clear();

                                        }
                                    }
                                } else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Nenhum produto cadastrado");
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

                        case 0:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Obrigado por usar o sistema.");
                            Console.ResetColor();
                            Thread.Sleep(1000);
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