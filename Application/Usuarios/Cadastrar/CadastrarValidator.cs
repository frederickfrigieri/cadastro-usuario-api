using FluentValidation;

namespace Application.Usuarios.Cadastrar
{
    public class CadastrarValidator : AbstractValidator<CadastrarCommand>
    {
        public CadastrarValidator()
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

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Senha é obrigatória")
                .MinimumLength(6)
                .WithMessage("Senha deve ter no mínimo 6 caracteres")
                .MaximumLength(100)
                .WithMessage("Senha deve ter no máximo 100 caracteres");

            RuleFor(x => x.ConfirmarSenha)
                .Equal(x => x.Senha)
                .WithMessage("As senhas não conferem");
        }
    }
}
