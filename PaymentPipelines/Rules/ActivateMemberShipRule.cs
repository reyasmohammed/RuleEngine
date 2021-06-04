using PaymentPipelines.Enum;
using PaymentPipelines.Model.Context;
using RuleEngine;
using RuleEngine.Contracts;
using System;
using System.Threading.Tasks;

namespace PaymentPipelines.Rules
{
    /// <summary>
    /// Rule definition for Membership Activation
    /// </summary>
    public class ActivateMemberShipRule : Rule<CartItemContext>
    {
        public ActivateMemberShipRule(RuleHandler<CartItemContext> next) : base(next)
        { }
        public override bool CanExecute(CartItemContext cartItemContext)
        {
            return cartItemContext.Context?.ProductType == ProductType.Membership && 
                cartItemContext.Context?.MemberShipType == MemberShipType.New;
        }

        public override Task Execute(CartItemContext cartItemContext)
        {
            throw new NotImplementedException();
        }
    }
}

