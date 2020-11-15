using Fisrt2._0.Domain.Enums;

namespace Fisrt2._0.Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public UF UF { get; set; }
        public bool Ativo { get; set; }
    }
}
