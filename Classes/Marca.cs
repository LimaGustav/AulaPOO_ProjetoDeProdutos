using System;
using System.Collections.Generic;
using ProjetoProduto.Interfaces;

namespace ProjetoProduto.Classes
{
    public class Marca : IMarca
    {
        // Atributos
        private int Codigo { get; set; }
        public string NomeMarca { get; set; }
        private DateTime DataCadastro { get; set; }

        // Construtores
        public Marca() {

        }

        public Marca(int _codigo, string _nomeMarca) {
            this.Codigo = _codigo;
            this.NomeMarca = _nomeMarca;
            this.DataCadastro = DateTime.Now;
        }
        
        // Lista de Marcas
        private List<Marca> listaMarcas = new List<Marca>();

        // Métodos
        public string Cadastrar(Marca marca)
        {
            listaMarcas.Add(marca);
            return ($"Marca {marca.NomeMarca} cadastrada");
        }

        public string Deletar(Marca marca)
        {
            listaMarcas.Remove(marca);
            return ($"Marca {marca.NomeMarca} deletada");
        }

        public int RetornarCodigo() {
            return Codigo;
        }

        public Marca MarcaPeloNome(string _nomeMarca) {
            return listaMarcas.Find(x => x.NomeMarca == _nomeMarca);
        }
        public List<Marca> Listar()
        {
            return listaMarcas;
        }
    }
}