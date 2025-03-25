using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoDeUsuarioController : ControllerBase
    {
        private readonly ITipoDeUsuarioRepository _tipoDeUsuarioRepository;
        public TipoDeUsuarioController(ITipoDeUsuarioRepository tipoDeUsuarioRepository)
        {
            _tipoDeUsuarioRepository = tipoDeUsuarioRepository;
        }

        //Metodo Cadastrar 
        [HttpPost("{id}")]
        public IActionResult Post(TipoDeUsuario novoTipoUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Cadastrar(novoTipoUsuario);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo BuscarPorid
        [HttpGet("BuscarPorid/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                TipoDeUsuario tipoDeUsuarioBuscado = _tipoDeUsuarioRepository.BuscarPorid(id);
                return Ok(tipoDeUsuarioBuscado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoDeUsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,TipoDeUsuario novoTipoDeUsuario)
        {
            try
            {
                _tipoDeUsuarioRepository.Atualizar(id, novoTipoDeUsuario);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
