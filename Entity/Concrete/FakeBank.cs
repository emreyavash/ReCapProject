using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FakeBank:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string CardNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Cvv { get; set; }
        public decimal Price { get; set; }
    }
}
