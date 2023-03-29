using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using System;

namespace RentACar.ConsoleUI
{
    public class ConsoleUI 
    {
        static void Main(string[] args)
        {
            CarManager carManager= new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.ColorName + "/" + car.BrandName);

            }
        }
    
    
    
    }

}