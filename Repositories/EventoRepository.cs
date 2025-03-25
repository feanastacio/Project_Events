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
                    eventoBuscado.DescricaoEvento = evento.DescricaoEvento;
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }
                _context.Evento.Update(eventoBuscado);
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
                return _context.Evento.Select(e => new Evento
                {
                    Eventoid = e.Eventoid,
                    NomeEvento = e.NomeEvento,
                    DescricaoEvento = e.DescricaoEvento,
                    DataEvento = e.DataEvento,
                    TipoDeEvento = new TipoDeEvento
                    {
                        TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                    },
                    instituicao = new Instituicoes
                    {
                        NomeFantasia = e.instituicao!.NomeFantasia
                    }
                }).FirstOrDefault(e => e.Eventoid == id)!;
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
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.Eventoid = Guid.NewGuid();

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
                return _context.Evento
                    .Select(e => new Evento
                    {
                        Eventoid = e.Eventoid,
                        NomeEvento = e.NomeEvento,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoDeEventoid = e.TipoDeEventoid,
                        TipoDeEvento = new TipoDeEvento
                        {
                            TipoDeEventoid = e.TipoDeEventoid,
                            TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                        },
                        Instituicaoid = e.Instituicaoid,
                        instituicao = new Instituicoes
                        {
                            Instituicaoid = e.Instituicaoid,
                            NomeFantasia = e.instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                return _context.Evento.Include(e => e.Presenca).Select(e => new Evento
                {
                    Eventoid = e.Eventoid,
                    NomeEvento = e.NomeEvento,
                    DescricaoEvento = e.DescricaoEvento,
                    DataEvento = e.DataEvento,
                    TipoDeEventoid = e.TipoDeEventoid,
                    TipoDeEvento = new TipoDeEvento
                    {
                        TipoDeEventoid = e.TipoDeEventoid,
                        TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                    },
                    Instituicaoid = e.Instituicaoid,
                    instituicao = new Instituicoes
                    {
                        Instituicaoid = e.Instituicaoid,
                        NomeFantasia = e.instituicao!.NomeFantasia
                    },
                    Presenca = new Presenca
                    {
                        Usuarioid = e.Presenca!.Usuarioid,
                        Situacao = e.Presenca!.Situacao
                    }
                }).Where(e => e.Presenca!.Situacao == true && e.Presenca.Usuarioid == id).ToList();
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
                return _context.Evento
                    .Select(e => new Evento
                    {
                        Eventoid = e.Eventoid,
                        NomeEvento = e.NomeEvento,
                        DescricaoEvento = e.DescricaoEvento,
                        DataEvento = e.DataEvento,
                        TipoDeEventoid = e.TipoDeEventoid,
                        TipoDeEvento = new TipoDeEvento
                        {
                            TipoDeEventoid = e.TipoDeEventoid,
                            TituloTipoEvento = e.TipoDeEvento!.TituloTipoEvento
                        },
                        Instituicaoid = e.Instituicaoid,
                        instituicao = new Instituicoes
                        {
                            Instituicaoid = e.Instituicaoid,
                            NomeFantasia = e.instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
