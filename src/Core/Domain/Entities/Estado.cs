using System;
using Shared.Abstractions;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Estado : BaseEntity
    {
        public Estado(Guid regiaoId, string nome, string uf)
        {
            RegiaoId = regiaoId;
            Nome = nome;
            Uf = uf;
        }

        public Estado() // ORM
        {
        }

        public Guid RegiaoId { get; private init; }
        public string Nome { get; private init; }
        public string Uf { get; private init; }

        public Regiao Regiao { get; private init; }
        public IReadOnlyList<Cidade> Cidades { get; private init; }
    }
}
