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
            Rental rental = new Rental
            {
                //Id=1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2021,1,26)
           

            };


            Car car1 = new Car
            {
                Id = 1,
                BrandId = 1,
                ColorId = 2,
                Description = "leoo",
                DailyPrice = 150,
                ModelYear = 1994
            };

            Brand brand1 = new Brand
            {
           
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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental);
            //colorManager.Update(new Color()
            //{
            //    Id = 1,
            //    ColorName = "adasdas"
            //}); 
         


            //foreach (var item in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(item.CarName + " " + item.Brandname + " " + item.ColorName + " " + item.DailyPrice);
            //}

            //Console.WriteLine(carManager.GetById(2).Description);

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.ModelYear + " " + item.DailyPrice + " " + item.Description);
            //}



        }
    }
}
