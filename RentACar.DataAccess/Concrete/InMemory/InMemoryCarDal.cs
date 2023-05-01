using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal(Car car) 
        {
            _cars = new List<Car> {

                new Car { Id = 1,CarName="BMW",BrandId=2,ColorId=2,ModelYear=2023,DailyPrice=3500,Description="Beyaz Araba"},
                new Car { Id = 2,CarName="Jaguar",BrandId=3,ColorId=3,ModelYear=2022,DailyPrice=3750,Description="Siyah Araba"},
                new Car { Id = 3,CarName="Mercedes",BrandId=4,ColorId=4,ModelYear=2022,DailyPrice=4250,Description="Kırmızı Araba"},
                new Car { Id = 4,CarName="Maybach",BrandId=5,ColorId=5,ModelYear=2023,DailyPrice=5520,Description="Yeşil Araba"},
                new Car { Id = 5,CarName="Range Rover",BrandId=6,ColorId=6,ModelYear=2021,DailyPrice=3700,Description="Gri Araba"},

            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
