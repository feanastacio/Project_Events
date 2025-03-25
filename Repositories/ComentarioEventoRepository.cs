using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Event_Context _context;

        public ComentarioEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPoridUsuario(Guid Usuarioid, Guid Eventoid)
        {
            try
            {
                return _context.ComentarioEvento.Select(c => new ComentarioEvento
                {
                    ComentarioEventoid = c.ComentarioEventoid,
                    Comentario = c.Comentario,
                    Exibe = c.Exibe,
                    Usuarioid = Usuarioid,
                    Eventoid = Eventoid,

                    Usuario = new Usuario
                    {
                        NomeUsuario = c.Usuario.NomeUsuario
                    },
                    Evento = new Evento
                    {
                        NomeEvento = c.Evento.NomeEvento,
                    }
                }).FirstOrDefault(c => c.Usuarioid == Usuarioid && c.Eventoid == Eventoid)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                comentarioEvento.ComentarioEventoid = Guid.NewGuid();
                _context.ComentarioEvento.Add(comentarioEvento);
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
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id);
                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEvento.Select(c => new ComentarioEvento
                {
                    ComentarioEventoid = c.ComentarioEventoid,
                    Comentario = c.Comentario,
                    Exibe = c.Exibe,
                    Usuarioid = c.Usuarioid,
                    Eventoid = c.Eventoid,

                    Usuario = new Usuario
                    {
                        NomeUsuario = c.Usuario.NomeUsuario
                    },

                    Evento = new Evento
                    {
                        NomeEvento = c.Evento.NomeEvento,
                    }
                }).Where(c => c.Eventoid == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

       public List<ComentarioEvento> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentarioEvento.Select(c => new ComentarioEvento
                {
                    ComentarioEventoid = c.ComentarioEventoid,
                    Comentario = c.Comentario,
                    Exibe = c.Exibe,
                    Usuarioid = c.Usuarioid,
                    Eventoid = c.Eventoid,

                    Usuario = new Usuario
                    {
                        NomeUsuario = c.Usuario!.NomeUsuario
                    },

                    Evento = new Evento
                    {
                        NomeEvento = c.Evento!.NomeEvento,
                    }
                }).Where(c => c.Exibe == true && c.Eventoid == id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
