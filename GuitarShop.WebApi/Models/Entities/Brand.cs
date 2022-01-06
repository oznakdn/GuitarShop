using System.Collections.Generic;

namespace GuitarShop.WebApi.Models.Entities
{
    public class Brand
    {

        public Brand()
        {
            Guitars=new HashSet<Guitar>();
        }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Guitar>Guitars{get;set;}
    }
}