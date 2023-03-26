using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.InMemory;
using System;

namespace RentACar.ConsoleUI
{
    public class ConsoleUI 
    {
        static void Main(string[] args)
        {
            CarManager carManager= new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);

            }
        }
    
    
    
    }

}