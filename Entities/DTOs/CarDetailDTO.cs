using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime ModelYear { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return "Car name: " + CarName + ", Brand: " + BrandName + ", Color:" + ColorName + ", Daily Price: " + DailyPrice;
        }
    }
}
