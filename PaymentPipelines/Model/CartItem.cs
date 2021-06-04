using PaymentPipelines.Enum;

namespace PaymentPipelines.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }

        //Todo: be moved to Product specific model
        public MemberShipType? MemberShipType { get; set; }
        public ProductType ProductType { get; set; }

    }
}