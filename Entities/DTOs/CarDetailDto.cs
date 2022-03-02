using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string Brandname { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public int ModelYear { get; set; }

        public List<string> ImagePath { get; set; }
    }
}
