using PaymentPipelines.Model;
using PaymentPipelines.Model.Context;
using PaymentPipelines.Rules;
using RuleEngine.Contracts;

namespace PaymentPipelines
{
    public class PaymentPipeline
    {
        private readonly IRulePipeline<CartItemContext> _rulePipeline;
        public PaymentPipeline(IRulePipeline<CartItemContext> rulePipeline)
        {
            _rulePipeline = rulePipeline;
        }

        public CartItem ApplyRuleOnPayment(CartItem cartItem)
        {
            var paymentPipeline = _rulePipeline
                .Add<PackingSlipRule>()
                .Add<RoyaltyPackingSlipRule>()
                .Add<ActivateMemberShipRule>()
                .Add<UpgradeMemberShipRule>()
                .Add<MailNotificationRule>()
                .Add<FirstAidVideoRule>()
                .Add<CommissionRule>()
                .Build();

            var cartItemContext = new CartItemContext(cartItem);
            //TODO : Product information assignment

            paymentPipeline(cartItemContext);

            return cartItem;
        }
    }
}
