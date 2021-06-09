using System.Collections.Generic;
using ProjetoProduto.Classes;

namespace ProjetoProduto.Interfaces
{
    public interface IProduto
    {
        string Cadastrar (Produto produto);
        List<Produto> Listar();
        string Deletar(Produto produto);
    }
}