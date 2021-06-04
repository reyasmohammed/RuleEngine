using Moq;
using PaymentPipelines.Model.Context;
using PaymentPipelines.Rules;
using RuleEngine.Contracts;
using Xunit;
using FluentAssertions;

namespace PaymentPipelines.UnitTest
{
    public class FirstAidVideoRuleUnitTest
    {
        [Fact(DisplayName = "Returns True - As the Product Type is Video and Name is 'Learning to Enjoy'")]        
        public void ShouldRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new FirstAidVideoRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102211,
                    ProductName = "Learning to Ski",
                    ProductType = Enum.ProductType.Video,
                    ProductPrice = 999
                }
            };

            // Act 
            var canExecute = rule.CanExecute(context);

            // Assert
            canExecute.Should().Be(true);
        }

        [Fact(DisplayName = "Returns False - As the Product Type is Video but Name is not 'Learning to Enjoy'")]
        public void ShouldNotRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new FirstAidVideoRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102212,
                    ProductName = "Learning to Enjoy",
                    ProductType = Enum.ProductType.Video,
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
