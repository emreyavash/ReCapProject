using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto {
                                 Id = c.Id,
                                 BrandId = b.Id,
                                 ColorId = cl.Id,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 ModelName = c.ModelName,
                                 DailyPrice = c.DailyPrice,
                                 CarImage = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).FirstOrDefault()
                             };
                return  filter == null ? result.ToList() : result.Where(filter).ToList() ;

            }
        }

    
    }
}
