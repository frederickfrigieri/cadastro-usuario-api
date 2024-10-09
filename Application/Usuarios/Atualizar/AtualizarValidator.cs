using FluentValidation;

namespace Application.Usuarios.Atualizar
{
    public class AtualizarValidator : AbstractValidator<AtualizarCommand>
    {
        public AtualizarValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório")
                .MaximumLength(100)
                .WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage("Sobrenome é obrigatório")
                .MaximumLength(100)
                .WithMessage("Sobrenome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório")
                .MaximumLength(100)
                .WithMessage("Email deve ter no máximo 100 caracteres")
                .EmailAddress()
                .WithMessage("Email inválido");
        }
    }
}
