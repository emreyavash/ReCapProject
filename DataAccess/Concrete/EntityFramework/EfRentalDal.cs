using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
    
        public List<RentalsDetailDto> GetRentalsDetails(Expression<Func<RentalsDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join f in context.UserFindexPoints on u.Id equals f.UserId
                             select new RentalsDetailDto
                             {
                                 Id = r.Id,
                                 FullName = $"{u.FirstName} {u.LastName}",
                                 BrandName = b.BrandName,
                                 CarId=r.CarId,
                                 UserId = u.Id,
                                 FindexPoint = c.FindexPoint,
                                 UserFindexPoint = f.FindexPoint,
                                 RentDate =Convert.ToDateTime(r.RentDate.ToString("dd/MM/yyyy")),
                                 ReturnDate = Convert.ToDateTime(r.ReturnDate.ToString("dd/MM/yyyy"))
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
            
        }
    }
}
