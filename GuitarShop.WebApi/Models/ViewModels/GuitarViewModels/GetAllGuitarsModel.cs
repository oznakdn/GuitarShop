namespace GuitarShop.WebApi.Models.ViewModels.GuitarViewModels
{
    public class GetAllGuitarsModel
    {
        public string GuitarType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Code { get; set; }
        public string Features { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
    }
}