using System;

namespace Domain.Entidades
{
    public class EntityBase
    {
        public Guid Id { get; protected set; }
        public bool Ativo { get; set; }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
