using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Core.Entities
{
    public class OrderItem  : BaseEntity
    {   
 
        public string Description { get; private set; }
   
        public decimal Price { get; private set; }

        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem()
        {}

    }
}
