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

            //Customer Denemeleri
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerById(3);
            foreach (var c in result.Data)
            {
                Console.WriteLine(c.Id + " " + c.FirstName + " " + c.LastName + " " + c.CompanyName);
            }
            //CustomerAllDetail(customerManager);

            //User Denemeleri
            //UserManager userManager = new UserManager(new EfUserDal());
            //UserListed(userManager);
            //UserListedByName(userManager);
            //UserAdd(userManager);


            //Brand Denemeleri
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //BrandGetById(brandManager);
            //BrandListed(brandManager);


            // Rental denemeler
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            ////RentalAdd(rentalManager);
            //RentalListed();
            //RentalGetById(rentalManager);



            // Car için denemeler

            //CarManager carManager = new CarManager(new EfCarDal());
            //CarUpdate(carManager);
            //CarDelete(carManager);
            //CarDetails(carManager);
            //GetAllTest(carManager);
            //CarGetTest(carManager);
            //GetCarsByBrandIdTest(carManager);
            //CarAddTest(carManager);

        }

        private static void CustomerAllDetail(CustomerManager customerManager)
        {
            var cd = customerManager.GetAllCustomerDetails().Data;
            foreach (var c in cd)
            {
                Console.WriteLine(c.Id + " " + c.FirstName + " " + c.LastName + " " + c.CompanyName);
            }
        }

        private static void UserAdd(UserManager userManager)
        {
            userManager.Add(new User { FirstName = "Yeliz", LastName = "Yavaş", Email = "yelizyavas@gmail.com", Password = "yeliz.1234" });
        }

        private static void UserListedByName(UserManager userManager)
        {
            var result = userManager.GetUserByName("Emre");
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.LastName);

            }
        }

        private static void UserListed(UserManager userManager)
        {
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
            }
        }

        private static void BrandGetById(BrandManager brandManager)
        {
            var result = brandManager.GetById(3);
            Console.WriteLine(result.Data.BrandName);
        }

        private static void RentalGetById(RentalManager rentalManager)
        {
            var result = rentalManager.GetById(1);
            Console.WriteLine(result.Data.CarId);
        }

        private static void BrandListed(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id : " + brand.Id + " Marka : " + brand.BrandName);
            }
        }

        private static void RentalListed(RentalManager rentalManager)
        {
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.CarId + " " + rental.CustomerId);
            }
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            Rental rental = new Rental
            {
                CarId = 1003,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now,
            };
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

        private static void CarUpdate(CarManager carManager)
        {
            // Verilen değeler haricinde diğer değerleri null yapıyor
            Car car = new Car
            {
                Id = 1,
                ColorId = 3,
            };
            carManager.Update(car);
        }

        private static void CarDelete(CarManager carManager)
        {
            // EfEntityRepository de delete yerine modified yapıp isactive kısmını false yaptığında bütün değerleri null yapıyor.
            // o yüzden efentityrepository de delete kullandım. Bu sefer de bütün verileri siliyor bu tarz da birşey istemiyorum.
            Car car = new Car();
            car.Id = 2;
            var result = carManager.Delete(car);
            Console.WriteLine(result.Message);
        }

        private static void CarDetails(CarManager carManager)
        {
            foreach (var cd in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(cd.Id + " " + cd.BrandName + " " + cd.ModelName + " " + cd.ColorName + " " + cd.DailyPrice + "");

            }
            Console.WriteLine(carManager.GetCarDetails().Message);
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
                ModelName = "A180d",
                DailyPrice = 3500,
                Description = "Lüks Araba",
                ModelYear = DateTime.Parse("2022-01-10"),
            };
            carManager.Add(cars);
        }
    }
}