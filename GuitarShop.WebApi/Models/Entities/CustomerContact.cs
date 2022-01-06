using System.ComponentModel.DataAnnotations;

namespace GuitarShop.WebApi.Models.Entities
{
    public class CustomerContact
    {

        [Key]
        public int ContactID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer Customer{get;set;}
        
    }
}