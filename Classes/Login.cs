using System;
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
            return ($"{usuario.Nome} já está deslogado")
        }

        public string Logar(Usuario usuario)
        {
            if (!Logado) {
                Logado = true;
                return ($"{usuario.Nome} entrou");
            }
            return ($"{usuario.Nome} já está logado");
        }

        void ILogin.Login()
        {
            Console.WriteLine("Teste");
        }
    }
}