using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context _context;
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null) 
                {
                    eventoBuscado.TipoDeEvento = evento.TipoDeEvento;
                    eventoBuscado.TipoDeEventoid = evento.TipoDeEventoid;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorid(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id);
                return eventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _context.Evento.Add(novoEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null) 
                {
                    _context.Evento.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaDeEventos = _context.Evento.Include(g => g.TipoDeEvento).ToList();
                return listaDeEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarPorId(int id)
        {
            try
            {
                List<Evento> ListarPorId = _context.Evento.ToList();
                return ListarPorId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ProximosEventos()
        {
            try
            {
                List<Evento> listaProximosEventos = _context.Evento.ToList();
                return listaProximosEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
