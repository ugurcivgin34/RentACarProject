using Business.Abstract;
using Business.Constans;
using Core.Utilities;
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

        public IResult Add(Car car)
        {
            if (CheckAdCar(car))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.BrandAdded);
            }
            return new ErrorResult();
                
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private bool CheckAdCar(Car car)
        {
            bool dogruMu = true;
            if (car.Description.Length < 2)
            {
                Console.WriteLine("Araba ismi minimum 2 uzunluğunda olmalı");
                dogruMu = false;
            }

            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0 dan büyük olmalı");
                dogruMu = false;
            }

            else
            {
                Console.WriteLine("Araba eklendi");
                dogruMu = true;
            }
            return dogruMu;

        }
    }
}
