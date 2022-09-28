using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

    {
        List<Car> _cars;

        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car>()
        //   {
        //       new Car
        //       {
        //           Id = 1,
        //           BrandId = 1,
        //           ColorId = 1,
        //           ModelYear = "2020",
        //           DailyPrice = 2000,
        //           Description = "Hızlı Araba"

        //       },
        //       new Car
        //       {
        //           Id = 2,
        //           BrandId = 3,
        //           ColorId = 3,
        //           ModelYear = "2010",
        //           DailyPrice = 200,
        //           Description = "Eski Araba"

        //       },
        //        new Car
        //       {
        //           Id = 3,
        //           BrandId = 2,
        //           ColorId = 4,
        //           ModelYear = "2015",
        //           DailyPrice = 1000,
        //           Description = "Rahat Araba"

        //       },
        //        new Car
        //       {
        //           Id = 4,
        //           BrandId = 1,
        //           ColorId = 2,
        //           ModelYear = "2022",
        //           DailyPrice = 2500,
        //           Description = "Yeni Araba"

        //       },
        //   };
        //}

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carDelete = _cars.SingleOrDefault(p => p.Id == entity.Id);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carUpdate = _cars.SingleOrDefault(p=> p.Id == entity.Id);
            carUpdate.BrandId = entity.BrandId;
            carUpdate.ColorId = entity.ColorId;
            carUpdate.DailyPrice = entity.DailyPrice;
            carUpdate.ModelYear = entity.ModelYear;
            carUpdate.Description = entity.Description;

            
        }
    }
}
