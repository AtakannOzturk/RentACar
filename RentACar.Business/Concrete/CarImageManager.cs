using RentACar.Business.Abstract;
using RentACar.Business.Constans;
using RentACar.Business.DependencyResolvers.ValidationRules.FluentValidation;
using RentACar.Core.Aspects.Autofac.Validation;
using RentACar.Core.Utilities.Business;
using RentACar.Core.Utilities.Results;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        
        public CarImageManager(ICarImageDal carImageDal)
        {
           
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageExist(carImage.ImagePath), CheckCarImageNumber(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>
                (_carImageDal.GetAll().Where(c => c.CarId == carId).ToList(),
               "CarListed");
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarUpdated);
        }


        public IResult CheckCarImageNumber(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("Car Images Count Must Be Lower Then 5");
            }

            return new SuccessResult();
        }

        public IResult CheckCarImageExist(string carImagePath)
        {
            var result = _carImageDal.GetAll(c => c.ImagePath == carImagePath).Any();
            if (result)
            {
                return new ErrorResult("There is already exist this image before");
            }

            return new SuccessResult();
        }


    }
}
