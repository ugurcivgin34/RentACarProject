using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext contex = new RentACarContext())
            {
                var result = from c in contex.Cars
                             join b in contex.Brands
                             on c.BrandId equals b.Id
                             join cl in contex.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {

                                 Id = c.Id,
                                 CarName = c.Description,
                                 Brandname = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = (from a in contex.CarImages where a.CarId == c.Id select a.ImagePath).ToList(),


                                 //CarImages = ((from ci in contex.CarImages
                                 //              where c.Id == ci.CarId
                                 //              select new CarImage
                                 //              {
                                 //                  Id = ci.Id,
                                 //                  CarId = ci.CarId,
                                 //                  Date = ci.Date,
                                 //                  ImagePath = ci.ImagePath
                                 //              }).ToList())
                             };
                             
                             
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
