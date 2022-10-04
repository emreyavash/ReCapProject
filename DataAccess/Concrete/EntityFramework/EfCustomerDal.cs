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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> CustomerDetailById(int id)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             where c.Id == id
                             select new CustomerDetailDto { Id = c.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName }
                             ;

                return result.ToList();

            }
        }

        public List<CustomerDetailDto> CustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto { Id = c.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName };

                return result.ToList();

            }
        }
    }
}
