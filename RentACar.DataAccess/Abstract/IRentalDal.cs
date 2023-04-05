using RentACar.Core.DataAccess;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
       public List<RentalDetailDto> GetRentalDetailsDto();
    }
}
