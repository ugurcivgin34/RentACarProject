using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult< List<Car>> GetAll();
        IDataResult< List<Car>> GetCarsByBrandId(int brandId);
        IDataResult <List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);

        
    }
}
