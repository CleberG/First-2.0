using Fisrt2._0.Domain.Entidades;
using FluentValidation;

namespace Fisrt2._0.Domain.Validation
{
    public class HistoricoValidation  : AbstractValidator<Historico>
    {
        public HistoricoValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Descricao).Length(10, 100);
        }
    }
}
