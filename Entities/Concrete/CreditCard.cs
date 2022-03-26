﻿using Core.Entities;
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
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public int DateMonth { get; set; } 
        public int DateYear { get; set; }
        public string NameOnTheCard { get; set; }
        public string Cvv { get; set; }

    }
}
