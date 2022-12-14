using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            rental.RentDate.ToShortDateString();
            rental.ReturnDate.ToShortDateString();
            _rentalDal.Add(rental); 

            return new SuccessResult(Messages.Added);
        }

        

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        } 
        public IDataResult<List<RentalsDetailDto>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalsDetailDto>> (_rentalDal.GetRentalsDetails(p => p.CarId == carId));
        }

        public IDataResult<List<RentalsDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalDal.GetRentalsDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}
