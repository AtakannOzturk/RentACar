using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Constans
{
    public static class Messages
    {
        public static string CarNameInvalid= "Car Name is invalid";
        public static object Car;
        public static string CarAdded = "Car Added!";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated!";
        public static string CarsListed = "Cars Listed!";

        public static string BrandAdded = "Brand Added!";
        public static string BrandDeleted = "Brand Deleted!";
        public static string BrandListed = "Brand Listed!";
        public static string BrandModified = "Brand Modified!";

        public static string ColorAdded = "Color Added!";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorListed = "Color Listed!";
        public static string ColorModified = "Color Modified!";

        public static string CustomerAdded = "Customer Added!";
        public static string CustomerDeleted = "Customer Deleted!";
        public static string CustomerModified = "Customer Modified!";
        public static string CustomerListed = "Customer Listed!";

        public static string RentalAdded = "Rental Added!";
        public static string RentalCannotAdded = "Rental Cannot Added Because of Car Is Not Available Now";
        public static string RentalDeleted = "Rental Deleted!";
        public static string RentalModified = "Rental Modified!";
        public static string RentalListed = "Rental Listed!";

        public static string UserModified;
        public static string UserDeleted;
        public static string UserAdded;
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
