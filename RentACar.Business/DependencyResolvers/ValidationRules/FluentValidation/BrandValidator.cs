using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class BrandValidator: AbstractValidator<Brand>
    {
                
            public BrandValidator()
            {
                RuleFor(b => b.BrandName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(30);
            }
        

    }
}
