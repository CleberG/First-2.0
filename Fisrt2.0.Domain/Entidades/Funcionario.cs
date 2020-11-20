using Fisrt2._0.Domain.Enums;
using Fisrt2._0.Domain.Validation;

namespace Fisrt2._0.Domain.Entidades
{
    public class Funcionario : EntidadeBase
    {
        public Funcionario(string nome, TipoFuncionario tipoFuncionario, string usuario, string senha)
            : base(new FuncionarioValidation())
        {
            Nome = nome;
            TipoFuncionario = tipoFuncionario;
            Usuario = usuario;
            Senha = senha;
            Ativo = true;
        }

        public void Update(string nome, TipoFuncionario tipoFuncionario, string usuario, string senha)
        {
            Nome = nome;
            TipoFuncionario = tipoFuncionario;
            Usuario = usuario;
            Senha = senha;
        }

        public string Nome { get; set; }
        public TipoFuncionario TipoFuncionario{ get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
