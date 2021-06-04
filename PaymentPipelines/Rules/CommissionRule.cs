using PaymentPipelines.Enum;
using PaymentPipelines.Model.Context;
using RuleEngine;
using RuleEngine.Contracts;
using System;
using System.Threading.Tasks;

namespace PaymentPipelines.Rules
{
    /// <summary>
    /// Rule definition for Commision Addition
    /// </summary>
    public class CommissionRule : Rule<CartItemContext>
    {
        public CommissionRule(RuleHandler<CartItemContext> next) : base(next)
        { }
        public override bool CanExecute(CartItemContext cartItemContext)
        {
            return cartItemContext.Context.ProductType == ProductType.PhysicalProduct
                || cartItemContext.Context.ProductType == ProductType.Book;
        }

        public override Task Execute(CartItemContext cartItemContext)
        {
            throw new NotImplementedException();
        }
    }
}
