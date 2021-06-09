using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Usuario : IUsuario
    {   
        // Atributos
        public int Codigo { get; set; }
        public string Nome { get; set; }
        private string Email { get; set; }
        private string Senha { get; set; }
        public bool Logado { get; set; }
        
        
        private DateTime DataCadastro { get; set; }

        // Lista de Usuarios
        public List<Usuario> usuariosCadastrados = new List<Usuario>();

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
            return ($"{usuario.Nome} cadastrado com sucesso. ");
        }

        public string Deletar(Usuario usuario)
        {
            usuariosCadastrados.Remove(usuario);
            return ($"O usuario {usuario.Nome} foi deletado");
        }

        public List<Usuario> ListarUsuarios() {
            return usuariosCadastrados;
        }

        public bool AvaliarEmailSenha(string emailLogin, string senhaLogin) {
            foreach (Usuario user in usuariosCadastrados)
            {
                if (user.Email == emailLogin) {
                    if (user.Senha == senhaLogin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AvaliarEmail(string _email) {
            foreach (Usuario user in usuariosCadastrados)
            {
                if (user.Email == _email)
                {
                    return true;
                }
            }
            return false;
        }
        
        public Usuario UserPeloEmail(string email) {
            return usuariosCadastrados.Find(x => x.Email == email);
        }

        public string LogarUsuario() {
            if (!Logado) {
                Logado = true;
                return ($"{Nome} entrou");
            }
            return ($"{Nome} já esta logado");
        }

        public string DeslogarUsuario() {
            if (Logado) {
                Logado = false;
                return ($"{Nome} saiu");
            }
            return ($"{Nome} não está logado");
        }
        
        public string RetornarEmail() {
            return Email;
        }
    }
}