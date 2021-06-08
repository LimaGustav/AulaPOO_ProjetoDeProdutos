using ProjetoProduto.Classes;

namespace ProjetoProduto.Interfaces
{
    public interface ILogin
    {
        string Logar(Usuario usuario);
        string Deslogar(Usuario usuario);
    }
}