using FluentValidation;
using AgendaApiNova.DTOs;

namespace AgendaApiNova.Validators;

public class ContatoValidator : AbstractValidator<ContatoDTO>
{
    public ContatoValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
        RuleFor(c => c.Telefone).NotEmpty().Matches(@"^\d+$").WithMessage("Telefone deve ter apenas números");
    }
}