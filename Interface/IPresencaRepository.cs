using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IPresencaRepository
    {
        void Deletar(Guid id);
        void Increver(Presenca inscricao);
        void Atualizar(Guid id,Presenca presenca);
        List<Presenca> Listar();
        Presenca BuscarPorid(Guid id);
        List<Presenca>ListarPresencas(Guid id);
    }
}
