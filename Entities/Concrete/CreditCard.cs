using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int CardNo { get; set; }
        public DateTime? Validity { get; set; }
        public int SecurityNo { get; set; }

    }
}
