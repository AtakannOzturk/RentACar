using RentACar.Business.Abstract;
using RentACar.Business.Constans;
using RentACar.Core.Utilities.Results;
using RentACar.DataAccess.Abstract;
using RentACar.Business.Constans;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation;
using RentACar.Core.CrossCuttingConcerns.Validation;
using RentACar.Core.Aspects.Autofac.Validation;
using RentACar.Business.BusinessAspects.Autofac;
using RentACar.Core.Aspects.Autofac.Transaction;
using RentACar.Core.Aspects.Autofac.Caching;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }
        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.ModelYear < 7)
            {
                throw new Exception("");
            }

            Add(car);
            return null;
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carid)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id == carid));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.BrandId == brandId).ToList(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(p => p.ColorId == colorId).ToList(), Messages.CarsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        
    }
}
