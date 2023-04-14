using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class CarImageValidator: AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.Date).NotNull().NotEmpty();
            
        }

    }
}
