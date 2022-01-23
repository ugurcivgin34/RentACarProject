using Business.Abstract;
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

        public void Add(Car car)
        {
            if (CheckAdCar(car))
                _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
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
