using ShoppingCartSystem;
using Xunit;

namespace ShoppingCartSystem.Tests
{
    public class ShoppingCartTests
    {
        // AddItem Tests

        [Fact]
        public void AddSingleItem_ShouldReturnCorrectTotal()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            cart.AddItem("Apple", 100, 2);

            // Assert
            Assert.Equal(200, cart.GetTotal());
        }

        [Fact]
        public void AddSameItemTwice_ShouldUpdateQuantity()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            cart.AddItem("Apple", 100, 2);
            cart.AddItem("Apple", 100, 3);

            // Assert
            Assert.Equal(500, cart.GetTotal());
        }

        // GetTotal Tests

        [Fact]
        public void GetTotal_WithMultipleItems_ShouldReturnCorrectSum()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Act
            cart.AddItem("Apple", 100, 2);   // 200
            cart.AddItem("Orange", 50, 1);   // 50

            // Assert
            Assert.Equal(250, cart.GetTotal());
        }

        [Fact]
        public void GetTotal_WithEmptyCart_ShouldReturnZero()
        {
            // Arrange
            var cart = new ShoppingCart();

            // Assert
            Assert.Equal(0, cart.GetTotal());
        }

        // ApplyDiscount Tests

        [Fact]
        public void ApplyDiscount_TenPercent_ShouldReturnDiscountedTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 100, 1);

            // Act
            decimal result = cart.ApplyDiscount(10);

            // Assert
            Assert.Equal(90, result);
        }

        [Fact]
        public void ApplyDiscount_ZeroPercent_ShouldReturnOriginalTotal()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 100, 1);

            // Act
            decimal result = cart.ApplyDiscount(0);

            // Assert
            Assert.Equal(100, result);
        }

        // This test will FAIL until you implement validation
        [Fact]
        public void ApplyDiscount_GreaterThan100_ShouldThrowArgumentException()
        {
            // Arrange
            var cart = new ShoppingCart();
            cart.AddItem("Apple", 100, 1);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cart.ApplyDiscount(150));
        }

        // ClearCart Tests

        [Fact]
        public void ClearCart_ShouldRemoveAllItems()
        {
            // Arrange
            var cart = new ShoppingCart();

            cart.AddItem("Apple", 100, 2);
            cart.AddItem("Orange", 50, 1);

            // Act
            cart.ClearCart();

            // Assert
            Assert.Equal(0, cart.GetTotal());
        }
    }
}