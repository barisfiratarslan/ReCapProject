using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int ColorID { get; set; }
        public string Name { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int minFindeksPoint { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + ", Name: " + Name + ", Brand ID: " + BrandID + ", Color ID: " + ColorID + ", Model Year: " + ModelYear + ", Daily Price: " + DailyPrice;
        }
    }
}
