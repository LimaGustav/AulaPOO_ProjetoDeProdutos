using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Marca : IMarca
    {
        private int Codigo { get; set; }
        private string NomeMarca { get; set; }
        private DateTime DataCadastro { get; set; }

        List<Marca> listaMarcas = new List<Marca>();
        public string Cadastrar(Marca marca)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Marca marca)
        {
            throw new NotImplementedException();
        }

        public List<Marca> Listar()
        {
            throw new NotImplementedException();
        }
    }
}