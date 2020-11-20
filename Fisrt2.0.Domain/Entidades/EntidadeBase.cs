using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fisrt2._0.Domain
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(IValidator validator)
        {
            Validator = validator;
        }

        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }
        [NotMapped]
        private IValidator Validator { get; set; }
        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public bool Valid
        {
            get
            {
                Validate(this);
                return ValidationResult.IsValid;
            }
        }

        private void Validate(EntidadeBase model)
        {
            ValidationResult = Validator.Validate(model);
        }

        public void Desabilitar()
        {
            Ativo = false;
        }
    }
}
