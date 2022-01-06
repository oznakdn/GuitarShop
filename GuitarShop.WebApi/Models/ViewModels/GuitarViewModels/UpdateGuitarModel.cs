namespace GuitarShop.WebApi.Models.ViewModels.GuitarViewModels
{
    public class UpdateGuitarModel
    {
        public int GuitarType { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public bool IsActive { get; set; }
        public bool IsStock { get; set; }
    }
}