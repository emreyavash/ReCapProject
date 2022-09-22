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
            Car cars = new Car();
            cars.Id = 4;
            cars.BrandId = 1;
            cars.ColorId = 2;
            cars.ModelName = "Transit";
            cars.DailyPrice = 1500;
            cars.Description = "Yük Taşıma Arabası";
            cars.ModelYear = DateTime.Parse("2018-02-10");
            carManager.Add(cars);

        }
    }
}