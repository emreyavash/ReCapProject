using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
    
        public List<RentalsDetailDto> GetRentalsDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.Id
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new RentalsDetailDto
                             {
                                 Id = r.Id,
                                 FullName = $"{u.FirstName} {u.LastName}",
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
            
        }
    }
}
