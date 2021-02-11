using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:ICar
    {
        public int ID { get; set; }
        public int BrandID { get; set; }

    }
}
