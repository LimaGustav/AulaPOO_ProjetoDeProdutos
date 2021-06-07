using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Usuario : IUsuario
    {
        private int Codigo { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }

        private DateTime DataCadastro { get; set; }
        
        List<Usuario> usuariosCadastrados = new List<Usuario>();
        
        
        public string Cadastrar(Usuario usuario)
        {
            usuariosCadastrados.Add(usuario);
            return ($"Seja Bem Vindo {usuario.Nome}");
        }

        public string Deletar(Usuario usuario)
        {
            usuariosCadastrados.Remove(usuario);
            return ($"O usuario {usuario.Nome} foi deletado");
        }
    }
}