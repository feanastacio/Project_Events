using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface ITipoDeEventoRepository
    {
       void Cadastrar(TipoDeEvento tipoDeEvento);
       void Atualizar(Guid id, TipoDeEvento tipoDeEvento);
       void Deletar(Guid id); 

       List<TipoDeEvento> Listar();
       TipoDeEvento BuscarPorid(Guid id);
    }
}
