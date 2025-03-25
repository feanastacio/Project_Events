using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        List<Evento> ProximosEventos();
        List<Evento> ListarPorId(Guid id);
        List<Evento> Listar();
        Evento BuscarPorid(Guid id);
        void Atualizar(Guid id, Evento evento);
        void Deletar(Guid id);
    }
}
