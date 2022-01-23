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
                Id=1,
                BrandId = 1,
                ColorId = 2,
                Description = "leoo",
                DailyPrice = 150,
                ModelYear = 1994
            };

            Brand brand1 = new Brand
            {
                Id = 1,
                BrandName = "Tofaş"
            };

            Color color1 = new Color
            {
                Id = 1,
                ColorName = "Lacivert"
            };

            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarName + " " + item.Brandname + " " + item.ColorName + " " + item .DailyPrice);
            }

            //Console.WriteLine(carManager.GetById(2).Description);
          
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            //}



        }
    }
}
