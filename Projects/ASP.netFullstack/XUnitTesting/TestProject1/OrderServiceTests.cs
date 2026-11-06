using Xunit;
using XUnitTesting;

namespace OrderServiceTests
{
    public class OrderServiceTests
    {
        private readonly OrderService _service = new OrderService();

        [Theory]
        [InlineData(10, 2, 0, 21.6)] //20+8 % tax =21.6
        [InlineData(50, 1, 10, 48.6)] //50-10% +8% tax
        [InlineData(100, 3, 20, 259.2)] //300 -20% +tax

        public void CalculateOrderTotal_ReturnsCorrectValues(decimal price, int qty, decimal discount, decimal expected)
        {
            decimal result = _service.CalculateOrderTotal(price, qty, discount);
            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void CalculateOrderTotal_Throws_WhenPriceIsnegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.CalculateOrderTotal(-1, 1, 0));
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void CalculateOrderTotal_Throws_WhenQuantityInvalid(int qty)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _service.CalculateOrderTotal(10, qty, 0));
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(150)]
        public void CalculateOrderTotal_Throws_WhenDiscountInvalid(decimal discount)
        {

            Assert.Throws<ArgumentOutOfRangeException>(() => _service.CalculateOrderTotal(10, 1, discount));
        }
    }
}