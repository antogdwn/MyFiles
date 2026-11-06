using System;
namespace XUnitTesting
{
    public class OrderService
    {

        public decimal CalculateOrderTotal(decimal itemPrice,int quanity,decimal discountPercent)
        {
            if (itemPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(itemPrice),"Item price cannot be negative");
            }

            if (quanity <= 0) {
                throw new ArgumentOutOfRangeException(nameof(quanity), "Quantity must be greater than zero");
            }
            if (discountPercent < 0 || discountPercent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(discountPercent), "Discountpercent must be between 0 to 100");

            }

            decimal subtotal = itemPrice * quanity;
            decimal discountAmount = subtotal * (discountPercent / 100m);
            decimal discountedTotal = subtotal - discountAmount;
            decimal tax = discountedTotal * 0.08m;

            return discountedTotal +tax;
        }
            
    }
}
