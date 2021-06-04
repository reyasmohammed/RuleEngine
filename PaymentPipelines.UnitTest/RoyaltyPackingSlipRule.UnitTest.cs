using Moq;
using PaymentPipelines.Model.Context;
using PaymentPipelines.Rules;
using RuleEngine.Contracts;
using Xunit;
using FluentAssertions;

namespace PaymentPipelines.UnitTest
{
    public class RoyaltyPackingSlipRuleUnitTest
    {
        [Fact(DisplayName = "Returns True - As the Product Type is Book")]        
        public void ShouldRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new RoyaltyPackingSlipRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102211,
                    ProductName = "Product 1",
                    ProductType = Enum.ProductType.Book,
                    ProductPrice = 999
                }
            };

            // Act 
            var canExecute = rule.CanExecute(context);

            // Assert
            canExecute.Should().Be(true);
        }

        [Fact(DisplayName = "Returns False - As the Product Type is not Book")]
        public void ShouldNotRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new RoyaltyPackingSlipRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102212,
                    ProductName = "Product 2",
                    ProductType = Enum.ProductType.PhysicalProduct,
                    ProductPrice = 999
                }
            };

            // Act 
            var canExecute = rule.CanExecute(context);

            // Assert
            canExecute.Should().Be(false);
        }
    }
}
