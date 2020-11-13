using System;

namespace Fisrt2._0.Domain
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
