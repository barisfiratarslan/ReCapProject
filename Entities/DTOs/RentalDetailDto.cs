using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Musteri { get; set; }
        public DateTime RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
