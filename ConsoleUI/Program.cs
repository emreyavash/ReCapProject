using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.ModelYear + " "+car.Description);
            //} 
            //foreach (var car in carManager.Get(3))
            //{
            //    Console.WriteLine(car.ModelYear + " "+car.Description);
            //}
            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.ModelYear + " " + car.Description);
            //}
            Car cars = new Car { 
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