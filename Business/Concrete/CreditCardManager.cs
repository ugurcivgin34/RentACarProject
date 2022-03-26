using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal credirCardDal)
        {
            _creditCardDal = credirCardDal;
        }
        public IResult Add(CreditCard creditCard)
        {
            var result = BusinessRules.Run(CheckIsCreditCardExist(creditCard.CardNumber));
            if (result == null)
            {
                return new ErrorResult();
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult("Credi Kartı Eklendi");
        }

       

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Kredi kartı silindi");
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), "Credi Kartı Listelendi");
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == creditCardId));
        }
        public IDataResult<List<CreditCard>> GetCardsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult("Credi Kartı Güncellendi");
        }
        private IResult CheckIsCreditCardExist(string cardNumber)
        {
            var result = _creditCardDal.GetAll(c => c.CardNumber == cardNumber).Any();
            if (result)
            {
                return new ErrorResult("Bu kart var");
            }
            return new SuccessResult();
        }

       
        
    }
}
