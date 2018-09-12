using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class ProductsOrders
    {
        [Key]
        public int poord_id {get;set;}
        public int product_id {get;set;}
        public Product Products {get;set;}
        public int order_id {get;set;}
        public Order Orders {get;set;}
    }
}