﻿using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IComentarioEventoRepository
    {

        void Cadastrar(ComentarioEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentarioEvento> Listar(Guid id);
        ComentarioEvento BuscarPoridUsuario(Guid Usuarioid, Guid Eventoid);



    }
}
