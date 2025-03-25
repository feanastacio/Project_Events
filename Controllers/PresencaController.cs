using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaRepository _presencaRepository;
        public PresencaController (IPresencaRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }

        [HttpPut]
        public IActionResult Put(Guid Id, Presenca presencaEvento)
        {
            try
            {
                _presencaRepository.Atualizar(Id, presencaEvento);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _presencaRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> ListaPresencaEventos = _presencaRepository.Listar();
                return Ok(ListaPresencaEventos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<Presenca> ListarMinhas = _presencaRepository.ListarMinhas(Id);
                return Ok(ListarMinhas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("BuscarPorId{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Presenca presencaBuscada = _presencaRepository.BuscarPorid(Id);
                return Ok(presencaBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
               
            }
        }

    }
}
