using Fisrt2._0.Domain.Enums;

namespace First2._0.Application.Models.FuncionarioModel
{
    public abstract class FuncionarioDtoBase
    {
        public string Nome { get; set; }
        public TipoFuncionario TipoFuncionario{ get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
