﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results
{
    public interface IDataResult<TEntity>
    {
        TEntity Data { get; }
    }
}
