using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int order_id {get;set;}
        public string shipping_address {get;set;}
        public string shipping_city {get;set;}
        public string shipping_state {get;set;}
        public string shipping_zip {get;set;}
        public double shipping_weight {get;set;}
        public double total {get;set;}
        public double shipping_fees {get;set;}
        public List<Customer> Customers {get;set;}
        public Order()
        {
            Customers = new List<Customer>();
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}