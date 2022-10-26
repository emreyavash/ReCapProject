using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetById(int id);
        IDataResult<List<RentalsDetailDto>> GetRentalByCarId(int carId);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalsDetailDto>> GetRentalDetail();
    }
}
