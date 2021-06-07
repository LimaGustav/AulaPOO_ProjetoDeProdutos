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