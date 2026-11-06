using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogger
{
    public class OrderService
    {
        private readonly ILogger _logger;

        public OrderService(ILogger logger)
        {
            _logger = logger;
        }

        public void PlaceOrder(string orderId)
        {
            //place order
            _logger.Log($"Order {orderId} placed successfully.");
        }



    }
}
