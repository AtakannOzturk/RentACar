using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation
{
    public class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotNull().NotEmpty();
            RuleFor(c => c.CustomerId).NotNull().NotEmpty();
            RuleFor(r => r.RentDate < r.ReturnDate);
        }

    }
}
