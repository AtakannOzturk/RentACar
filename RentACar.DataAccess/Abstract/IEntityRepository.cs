﻿using RentACar.Entities.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class,IEntity,new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null);
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetBlyd(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
