using PaymentPipelines.Enum;
using PaymentPipelines.Model.Context;
using RuleEngine;
using RuleEngine.Contracts;
using System;
using System.Threading.Tasks;

namespace PaymentPipelines.Rules
{
    public class FirstAidVideoRule : Rule<CartItemContext>
    {
        public FirstAidVideoRule(RuleHandler<CartItemContext> next) : base(next)
        { }
        public override bool CanExecute(CartItemContext cartItemContext)
        {
            return cartItemContext.Context?.ProductType == ProductType.Video
                && cartItemContext.Context?.ProductName == "Learning to Ski";
        }

        public override Task Execute(CartItemContext cartItemContext)
        {
            throw new NotImplementedException();
        }
    }
}
