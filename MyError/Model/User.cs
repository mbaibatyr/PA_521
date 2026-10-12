using FluentValidation;

namespace MyError.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    //public sealed class UserValidator : AbstractValidator<User>
    //{
    //    public UserValidator()
    //    {
    //        RuleFor(x => x.Name)
    //            .NotEmpty()
    //            .WithMessage("Имя обязательно")
    //            .MaximumLength(100)
    //            .WithMessage("Имя не должно превышать 100 символов");                

    //        RuleFor(x => x.Email)
    //            .NotEmpty()
    //            .WithMessage("Email обязателен")
    //            .EmailAddress()
    //            .WithMessage("Некорректный формат email");

    //        RuleFor(x => x.Age)
    //            .InclusiveBetween(18, 120)
    //            .WithMessage("Возраст должен быть от 18 до 120 лет");
    //    }
    //}
}
