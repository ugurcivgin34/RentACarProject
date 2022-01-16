using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car { Id = 2, BrandId = 10, DailyPrice = 2560, ModelYear = 2005, Description = "Ferrari" };
            CarManager carManager = new CarManager(new InMemoryCarDal());
            //carManager.Add(car);
            carManager.Delete(1); 
            //Console.WriteLine(carManager.GetById(1).Description);
            //carManager.Update(car);


            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }
        }
    }
}
