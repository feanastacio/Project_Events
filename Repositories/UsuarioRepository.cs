using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Event_Context _context;
        public void Atualizar(Guid id, Usuario usuario) 
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;
                if (usuarioBuscado != null)
                {
                    usuarioBuscado.TipoDeUsuario = usuario.TipoDeUsuario;
                    usuarioBuscado.TipoDeUsuarioid = usuario.TipoDeUsuarioid;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorid(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find()!;
                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
            _context.Usuario.Add(novoUsuario);
            _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Usuario> ListaPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

    
    }
}
