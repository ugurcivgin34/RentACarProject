using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,DailyPrice=1500,ModelYear=2001,Description="Mercedes"},
                new Car{Id=2,BrandId=1,DailyPrice=5000,ModelYear=1994,Description="Audi"},
                new Car{Id=3,BrandId=2,DailyPrice=6504,ModelYear=2010,Description="Tesla"},
                new Car{Id=4,BrandId=2,DailyPrice=8500,ModelYear=2018,Description="Bwm"},
                new Car{Id=5,BrandId=2,DailyPrice=9000,ModelYear=2005,Description="Tofaş"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int carId)
        {

            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.Id ==carId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car car = _cars.SingleOrDefault(c => c.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
