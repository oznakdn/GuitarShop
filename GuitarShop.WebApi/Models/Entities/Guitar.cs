namespace GuitarShop.WebApi.Models.Entities
{
    public class Guitar
    {
        public int GuitarID { get; set; }
        public int GuitarType { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }=true;
        public bool IsStock { get; set; }=true;

        public virtual Brand Brand{get;set;}

    }
}