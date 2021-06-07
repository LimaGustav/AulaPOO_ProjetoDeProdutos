using ProjetoProduto.Classes;

namespace ProjetoProduto.Interfaces
{
    public interface IUsuario
    {
        string Cadastrar(Usuario usuario);
        string Deletar(Usuario usuario);
    }
}