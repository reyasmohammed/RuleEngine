using RuleEngine.Contracts;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PaymentPipelines.Model.Context
{
    /// <summary>
    /// Cart Item Context
    /// </summary>
    public class CartItemContext : IRuleContext<CartItem>
    {
        public CartItemContext()
        {
        }

        public CartItemContext(CartItem cartItem)
        {
            Properties = new ConcurrentDictionary<string, object>();
            Context = cartItem;
        }

        public IDictionary<string, object> Properties { get; }

        public CartItem Context { get; set; }

        public string AppliedRule { get; set; }

    }
}