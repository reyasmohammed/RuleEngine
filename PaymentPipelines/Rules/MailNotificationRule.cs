using PaymentPipelines.Enum;
using PaymentPipelines.Model.Context;
using RuleEngine;
using RuleEngine.Contracts;
using System;
using System.Threading.Tasks;

namespace PaymentPipelines.Rules
{
    public class MailNotificationRule : Rule<CartItemContext>
    {
        public MailNotificationRule(RuleHandler<CartItemContext> next) : base(next)
        { }
        public override bool CanExecute(CartItemContext cartItemContext)
        {
            return cartItemContext.Context?.ProductType == ProductType.Membership;
        }

        public override Task Execute(CartItemContext cartItemContext)
        {
            throw new NotImplementedException();
        }
    }
}
