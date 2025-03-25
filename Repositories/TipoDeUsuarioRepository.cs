using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        private readonly Event_Context _context;
        public void Atualizar(Guid id, TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                TipoDeUsuario tipoDeUsuarioBuscado = _context.TipoDeUsuario.Find(id)!;
                if (tipoDeUsuario != null)
                {
                    tipoDeUsuarioBuscado.TituloTipoUsuario = tipoDeUsuario.TituloTipoUsuario;
                    tipoDeUsuarioBuscado.TipoDeUsuarioid = tipoDeUsuario.TipoDeUsuarioid;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoDeUsuario BuscarPorid(Guid id)
        {
            try
            {
                TipoDeUsuario tipoDeUsuarioBuscado = _context.TipoDeUsuario.Find(id)!;
                return tipoDeUsuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoDeUsuario novoTipoDeUsuario)
        {
            try
            {
                _context.TipoDeUsuario.Add(novoTipoDeUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoDeUsuario tipoDeUsuarioBuscado = _context.TipoDeUsuario.Find(id)!;
                if (tipoDeUsuarioBuscado != null)
                {
                    _context.TipoDeUsuario.Remove(tipoDeUsuarioBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoDeEvento> Listar()
        {
            try
            {
                List<TipoDeEvento> listaTipoDeEvento = _context.TipoDeEventos.ToList();
                return listaTipoDeEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
