namespace GuitarShop.WebApi.Models.ViewModels.OrderViewModels
{
    public class GetAllOrdersModel
    {
        public string Customer { get; set; }
        public int Guitar { get; set; }
        public string BuyDate { get; set; }
        public decimal Amount { get; set; }
        public string PayType { get; set; }
    }
}