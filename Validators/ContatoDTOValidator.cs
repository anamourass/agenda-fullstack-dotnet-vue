using FluentValidation;
using AgendaApiNova.DTOs;

namespace AgendaApiNova.Validators;

public class ContatoDTOValidator : AbstractValidator<ContatoDTO>
{
    public ContatoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório!")
            .Length(3, 50).WithMessage("O nome deve ter entre 3 e 50 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório!")
            .EmailAddress().WithMessage("Formato de e-mail inválido.");

        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("O telefone é obrigatório!")
            .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 números (com DDD).");
    }
}