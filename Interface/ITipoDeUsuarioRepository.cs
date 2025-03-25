using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeUsuarioRepository
    {
        void Cadastrar(TipoDeUsuario tipoDeUsuario);
        void Atualizar(Guid id, TipoDeUsuario tipoDeUsuario);
        void Deletar(Guid id);
        List<TipoDeUsuario> Listar();
        TipoDeUsuario BuscarPorid(Guid id);
    }
}
