using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 2,
                Description = "kşş",
                DailyPrice = 0,
                ModelYear = 1994
            };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car1);
                
         

            //foreach (var item in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            //}



        }
    }
}
