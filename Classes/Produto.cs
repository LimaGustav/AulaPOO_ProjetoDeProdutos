using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Produto : IProduto
    {
        private int Codigo { get; set; }
        private string NomeProduto { get; set; }
        private float Preco { get; set; }
        private DateTime DataCadastro { get; set; }
        private Marca Marca { get; set; }
        private Usuario CadastradoPor { get; set; }
        private List<Produto> ListaDeProdutos { get; set; }
        

        public Produto() {

        }

        public Produto(int _codigo, string _nomeProduto, float _preco, DateTime _dataCadastro, Marca _marca, Usuario _cadastradoPor ) {
            this.Codigo = _codigo;
            this.NomeProduto = _nomeProduto;
            this.Preco = _preco;
            this.DataCadastro = _dataCadastro;
            this.Marca = _marca;
            this.CadastradoPor = _cadastradoPor;
        }
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

        public List<Produto> Listar()
        {
            return ListaDeProdutos;
        }
    }
}