using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;

namespace Api_Event.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly Event_Context? _context;
        public PresencaRepository(Event_Context? context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Presenca presencaEvento)
        {
            try
            {
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                if (presencasBuscada != null)
                {
                    if (presencaBuscada.Situacao)
                    {
                        presencaBuscada.Situacao = false;
                    } else
                    {
                        presencaBuscada.Situacao = true;
                    }
                }
                _context.Presenca.Update(presencaBuscada!);
                _context.SaveChanges(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Presenca BuscarPorid(Guid id)
        {
            try
            {
               return _context.Presenca.Select(p => new Presenca
               {
                   PresencaId = p.PresencaId,
                   Situacao = p.Situacao,
                   Evento = new Evento
                   {
                       Eventoid = p.Eventoid,
                       DataEvento = p.Evento.DataEvento,
                       NomeEvento = p.Evento.NomeEvento,
                       DescricaoEvento = p.Evento.DescricaoEvento,

                       instituicao = new Instituicoes
                       {
                           Instituicaoid = p.Evento.instituicao.Instituicaoid,
                           NomeFantasia = p.Evento.instituicao.NomeFantasia
                       }
                   }
               }).FirstOrDefault(p => p.PresencaId == id)!;
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
                Presenca presenca = _context?.Presenca.Find(id)!;
                if (presenca != null)
                {
                    _context?.Presenca.Remove(presenca);
                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Increver(Presenca inscricao)
        {
            try
            {
                inscricao.PresencaId = Guid.NewGuid();
                _context.Presenca.Add(inscricao);
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        PresencaId = p.PresencaId,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            Eventoid = p.Eventoid,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            DescricaoEvento = p.Evento.DescricaoEvento,

                            instituicao = new Instituicoes
                            {
                                Instituicaoid = p.Evento.instituicao!.Instituicaoid,
                                NomeFantasia = p.Evento.instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> ListarMinhas(Guid id)
        {
            return _context.Presenca.Select(p => new Presenca
            {
                PresencaId = p.PresencaId,
                Situacao = p.Situacao,
                Usuarioid = p.Usuarioid,
                Eventoid = p.Eventoid,

                Evento = new Evento
                {
                    Eventoid = p.Eventoid,
                    DataEvento = p.Evento.DataEvento,
                    NomeEvento = p.Evento.NomeEvento,
                    DescricaoEvento = p.Evento.DescricaoEvento,

                    instituicao = new Instituicoes
                    {
                        Instituicaoid = p.Evento.Instituicaoid,
                    }
                }
            }).Where(p => p.Usuarioid == id).ToList();
        }
    }
}
