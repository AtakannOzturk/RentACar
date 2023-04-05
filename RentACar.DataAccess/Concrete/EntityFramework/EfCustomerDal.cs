using RentACar.Core.DataAccess.EntityFramework;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetDetailCustomer()
        {
            using (RentACarContext context = new())
            {
                var result = from customer in context.Customers
                             join user in context.Users on customer.CustomerId equals user.Id
                             select new CustomerDetailDto
                             {
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
