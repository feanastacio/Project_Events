using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeUsuarioRepository
    {
        void Cadastrar(TipoDeUsuario tipoDeUsuario);
        void Atualizar(Guid id, TipoDeUsuario tipoDeUsuario);
        void Deletar(Guid id);
        List<TipoDeEvento> Listar();
        TipoDeUsuario BuscarPorid(Guid id);
        void Cadastrar(Usuario novoUsuario);
    }
}
