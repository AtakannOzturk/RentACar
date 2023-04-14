using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(u => u.LastName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(30);
            RuleFor(u => u.Email).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100).EmailAddress();
            //RuleFor(u => u.password).NotNull().NotEmpty().MinimumLength(8).Must(PasswordValidator);

        }

        public bool PasswordValidator(string password)
        {
            var passwordToUpper = password.ToUpper();
            var numberArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (password[0] == passwordToUpper[0])//StartsWith Upper!
            {
                foreach (var number in numberArray)
                {
                    if (password.Contains(number.ToString()))//Must Contain 1 Number
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
