using System.Collections.Generic;

namespace PaymentPipelines.Model
{
    /// <summary>
    /// Cart
    /// </summary>
    public class Cart
    {
        public int Id { get; set; }
        
        public List<CartItem> CartItems { get; set; }
    }
}
