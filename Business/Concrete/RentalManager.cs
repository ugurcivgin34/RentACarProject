using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (!CheckRentalCar(rental).Success)
            {

                Console.WriteLine("Araç kiralanamadı");
                return new ErrorResult("Araç kiralanamadı");
            }
            else
            {
                _rentalDal.Add(rental);
                Console.WriteLine("Kiralanadı");
                return new SuccessResult("Araç kiralandı");
            }
           
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalId);
            if (rental != null)
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
            }
            else
            {
                return new ErrorDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
            }

        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
           
        }


        private IResult CheckRentalCar(Rental rental)
        {
            var checkRentalCar = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (checkRentalCar.Count>0)
            {
                return new ErrorResult();
            }
            else
            {
                return new SuccessResult();
            }
        }
    }
}
