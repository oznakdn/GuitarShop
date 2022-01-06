using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarShop.WebApi.Models.Entities
{
    public class Customer
    {

        public Customer()
        {
            Orders=new HashSet<Order>();
        }

        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }=true;
        public string Username { get; set; }
        public string Password { get; set; }
        public int? ContactId { get; set; }

        public virtual ICollection<Order>Orders{get;set;}

    }
}