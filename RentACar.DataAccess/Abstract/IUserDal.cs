using RentACar.Core.DataAccess;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
