namespace GuitarShop.WebApi.Models.ViewModels.CustomerViewModels
{
    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ContactId { get; set; }
    }
}