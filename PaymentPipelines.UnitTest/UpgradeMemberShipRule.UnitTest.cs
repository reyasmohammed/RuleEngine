﻿using Moq;
using PaymentPipelines.Model.Context;
using PaymentPipelines.Rules;
using RuleEngine.Contracts;
using Xunit;
using FluentAssertions;

namespace PaymentPipelines.UnitTest
{
    public class UpgradeMemberShipRuleUnitTest
    {
        [Fact(DisplayName = "Returns True - Product Type is Membership Upgrade")]
        public void UpgradeMemberShipRule_ShouldRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new UpgradeMemberShipRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102211,
                    ProductName = "Product 1",
                    ProductType = Enum.ProductType.Membership,
                    MemberShipType = Enum.MemberShipType.Upgrade,
                    ProductPrice = 999
                }
            };

            // Act 
            var canExecute = rule.CanExecute(context);

            // Assert
            canExecute.Should().Be(true);
        }

        [Fact(DisplayName = "Returns False - Product Type is Membership but Upgrade")]
        public void UpgradeMemberShipRule_ShouldNotRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new UpgradeMemberShipRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102212,
                    ProductName = "Product 2",
                    ProductType = Enum.ProductType.Membership,
                    MemberShipType = Enum.MemberShipType.New,
                    ProductPrice = 999
                }
            };

            // Act 
            var canExecute = rule.CanExecute(context);

            // Assert
            canExecute.Should().Be(false);
        }

        [Fact(DisplayName = "Returns False - Product Type is not Membership")]
        public void UpgradeMemberShipRule_DifferenProduct_ShouldNotRun()
        {
            // Arrange
            var mockRule = new Mock<IRule<CartItemContext>>();
            mockRule.Setup(_ => _.CanExecute(It.IsAny<CartItemContext>())).Returns(false);

            var rule = new UpgradeMemberShipRule(mockRule.Object.Invoke);
            var context = new CartItemContext
            {
                Context = new Model.CartItem
                {
                    Id = 102212,
                    ProductName = "Product 2",
                    ProductType = Enum.ProductType.Book,
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

