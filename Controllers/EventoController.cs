using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Repositories
{
    namespace Api_Event.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
        public class EventoController : ControllerBase
        {
            private readonly IEventoRepository _eventoRepository;
            public EventoController(IEventoRepository eventoRepository)
            {
                _eventoRepository = eventoRepository;
            }

            //Metodo Listar 
            [HttpGet("{id}")]
            public IActionResult Get()
            {
                try
                {
                    List<Evento> listarEvento = _eventoRepository.Listar();
                    return Ok(listarEvento);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            //Metodo Cadastrar
            [HttpPost]
            public IActionResult Post(Evento novoEvento)
            {
                try
                {
                    _eventoRepository.Cadastrar(novoEvento);
                    return Created();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            //Metodo Buscar
            [HttpGet("BuscarPorid/{id}")]
            public IActionResult GetByid(Guid id)
            {
                try
                {
                    Evento eventoBuscado = _eventoRepository.BuscarPorid(id);
                    return Ok(eventoBuscado);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            //Metodo Deletar
            [HttpDelete("{id}")]
            public IActionResult Delete(Guid id)
            {
                try
                {
                    _eventoRepository.Deletar(id);
                    return NoContent();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            //MetodoAtualizar
            [HttpPut("{id}")]
            public IActionResult Put(Guid id, Evento evento)
            {
                try
                {
                    _eventoRepository.Atualizar(id, evento);
                    return NoContent();
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }

        }
    }
}
