using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class CustomersOrders
    {
        [Key]
        public int cusord_id {get;set;}
        public int customer_id {get;set;}
        public Customer Customers {get;set;}
        public int order_id {get;set;}
        public Order Orders {get;set;}
    }
}