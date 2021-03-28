using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string LastUsingMonth { get; set; }
        public string LastUsingYear { get; set; }
        public string CVV { get; set; }
        public decimal Balance { get; set; }
    }
}
