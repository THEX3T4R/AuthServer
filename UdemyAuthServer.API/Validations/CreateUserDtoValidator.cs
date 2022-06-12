using FluentValidation;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.API.Validations
{
    public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email zorunlu").EmailAddress().WithMessage("Email formatı doğru değil");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunlu");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("username zorunlu");
        }
    }
}
