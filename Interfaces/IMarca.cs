using System.Collections.Generic;
using ProjetoProduto.Classes;

namespace ProjetoProduto.Interfaces
{
    public interface IMarca
    {
        string Cadastrar(Marca marca);

        List<Marca> Listar();

        string Deletar(Marca marca);
    }
}