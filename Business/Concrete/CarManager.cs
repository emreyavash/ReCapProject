using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
          
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> Get(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarDetail);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.Id == carId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        
    }
}
