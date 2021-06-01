 
using Newtonsoft.Json;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManager.Core.Entities
{
    public class Order : BaseEntity
    {
            
 
        
        public int UserId { get; set; }
      
        public DateTime Date { get; set; }
        
        public List<OrderItem> Items { get; set; }

        public virtual User User { get; set; }


    }
}
