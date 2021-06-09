using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Produto : IProduto
    {
        // Atributos
        private int Codigo { get; set; }
        private string NomeProduto { get; set; }
        private float Preco { get; set; }
        private DateTime DataCadastro { get; set; }
        private Marca Marca { get; set; }
        private Usuario CadastradoPor { get; set; }
        private List<Produto> ListaDeProdutos { get; set; }
        
        // Construtores
        public Produto() {

        }

        public Produto(int _codigo, string _nomeProduto, float _preco, Marca _marca, Usuario _cadastradoPor ) {
            this.Codigo = _codigo;
            this.NomeProduto = _nomeProduto;
            this.Preco = _preco;
            this.DataCadastro = DateTime.Now;
            this.Marca = _marca;
            this.CadastradoPor = _cadastradoPor;
        }

        // Métodos
        public string Cadastrar(Produto produto)
        {
            ListaDeProdutos.Add(produto);
            return ($"O produto {produto.NomeProduto} foi cadastrado");
        }

        public string Deletar(Produto produto)
        {
            ListaDeProdutos.Remove(produto);
            return ($"O produto {produto.NomeProduto} foi removido");
        }

        public string RetornaNome () {
            return NomeProduto;
        }

        public string RetornaNomeMarca() {
            return Marca.NomeMarca;
        }

        public float RetornaPreco() {
            return Preco;
        }
        public List<Produto> Listar()
        {
            return ListaDeProdutos;
        }
    }
}