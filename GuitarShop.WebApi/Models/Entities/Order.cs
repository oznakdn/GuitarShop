using System;

namespace GuitarShop.WebApi.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerId { get; set; }
        public int GuitarId { get; set; }
        public DateTime BuyDate { get; set; }
        public decimal Amount { get; set; }
        public int PayType { get; set; }

        public virtual Customer Customer{get;set;}
        public virtual Guitar Guitar { get; set; }
    }
}