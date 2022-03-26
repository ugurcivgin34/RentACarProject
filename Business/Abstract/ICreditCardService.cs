using Core.Utilities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IDataResult<CreditCard> GetById(int creditCardId);
        IDataResult<List<CreditCard>> GetCardsByCustomerId(int customerId);
        IDataResult<List<CreditCard>> GetAll();
    }
}
