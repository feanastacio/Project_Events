using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        Usuario BuscarPorid (Guid id);
        Usuario BuscarPorEmailESenha (string Email, string Senha);
        List<Usuario> ListaPorEmailESenha(string email, string senha);
    }
}
