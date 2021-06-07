namespace ProjetoProduto.Interfaces
{
    public interface ILogin
    {
         void Login();
        string Logar(Usuario usuario);
        string Deslogar(Usuario usuario);
    }
}