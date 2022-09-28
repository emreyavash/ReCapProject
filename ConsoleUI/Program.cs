using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cd in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(cd.Id + " " + cd.BrandName + " " + cd.ModelName + " " + cd.ColorName + " " + cd.DailyPrice+"" );

            }
            Console.WriteLine(carManager.GetCarDetails().Message); 
            //GetAllTest(carManager);
            //CarGetTest(carManager);
            //GetCarsByBrandIdTest(carManager);
            //CarAddTest(carManager);

        }

        private static void GetAllTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.BrandId + " " + car.ModelName + " " + car.ColorId);
            }
        }

        private static void CarGetTest(CarManager carManager)
        {
            foreach (var car in carManager.Get(3).Data)
            {
                Console.WriteLine(car.ModelYear + " " + car.Description);
            }
        }

        private static void GetCarsByBrandIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.ModelYear + " " + car.Description);
            }
        }

        private static void CarAddTest(CarManager carManager)
        {
            Car cars = new Car
            {
                BrandId = 7,
                ColorId = 2,
                ModelName = "Cla 200",
                DailyPrice = 3500,
                Description = "Lüks Araba",
                ModelYear = DateTime.Parse("2022-01-10"),
            };
            carManager.Add(cars);
        }
    }
}