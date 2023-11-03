using FluentValidation;
using SagitarioRhApi.Domain.DTOs;
using SagitarioRHDesktop.Models;

namespace SagitarioRhApi.Services
{
    public class CreateFuncionarioValidator : AbstractValidator<FuncionarioModel>
    {

        public CreateFuncionarioValidator() {

            RuleFor(c => c.nome)
                .NotEmpty()
                .Length(3, 100).WithMessage("O nome deve ter pelo menos 3 caracteres e máximo 100");

            RuleFor(c => c.rg)
                .NotEmpty()
                .Length(12).WithMessage("O rg deve conter 12 caracteres");

            RuleFor(c => c.idempresa)
                .NotEmpty();

            RuleFor(c => c.usuario)
                .NotEmpty()
                .Length(3, 10).WithMessage("O usuario deve ter pelo menos 3 caracteres e máximo 100");

            RuleFor(c => c.cpf)
                .NotEmpty()
                .Length(11).WithMessage("O cpf deve conter 11 caracteres");
            RuleFor(c => c.email)
                .NotEmpty()
                .Length(3, 30).WithMessage("Até 30 caracteres,se for maior por favor informe o seu gerente ou administrador")
                .EmailAddress().WithMessage("O 'Email' fornecido não é válido.");
            RuleFor(c => c.salario)
                .NotEmpty().WithMessage("O campo salário não pode estar vazio.")
                 .Must(salario => salario > 0).WithMessage("O salário deve ser um valor positivo.");
            RuleFor(c => c.pis)
                .NotEmpty()
                .Length(11).WithMessage("O pis deve conter até 11 caracteres");
            RuleFor(c => c.funcao)
                .NotEmpty()
                .Length(3, 30).WithMessage("O nome deve ter pelo menos 3 caracteres e máximo 100");
            RuleFor(c => c.jornada)
                .NotEmpty();
            RuleFor(c => c.cep)
                .NotEmpty()
                .Length(8).WithMessage("O cep deve conter até 11 caracteres");
            RuleFor(c => c.senha)
                .NotEmpty()
                .Length(3, 30).WithMessage("A senha deve ter pelo menos 3 caracteres e máximo 100");

            RuleFor(c => c.setor)
                .NotEmpty()
                .Length(1, 30).WithMessage("A senha deve ter pelo menos 2 caracteres e máximo 30");
            


        }

    }

   

}
