using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Usuario : IUsuario
    {   
        // Atributos
        private int Codigo { get; set; }
        private string Nome { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        private DateTime DataCadastro { get; set; }

        // Lista de Usuarios
        List<Usuario> usuariosCadastrados = new List<Usuario>();

        // Construtores
        public Usuario() {

        }
        
        public Usuario(int _codigo, string _nome, string _email, string _senha) {
            this.Codigo = _codigo;
            this.Nome = _nome;
            this.Email = _email;
            this.Senha = _senha;
            this.DataCadastro = DateTime.Now;
        }

        // Metodos
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