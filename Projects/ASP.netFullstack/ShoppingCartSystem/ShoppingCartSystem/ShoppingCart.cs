namespace ShoppingCartSystem
{
    public class Items
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
    public class ShoppingCart
    {
        List<Items> items = new List<Items>();
        //decimal Total;


        public void AddItem(string name, decimal price, int quantity)
        {          
            var item = items.FirstOrDefault(x => x.Name == name);

            if (item == null)
            {
                items.Add(new Items { Name = name, Price = price, Quantity = quantity });
            }
            else {
                item.Quantity += quantity;
            }                       
        }

        public decimal GetTotal()
        {           
            return items.Select(x => x.Price * x.Quantity)
                            .Sum();
             
        }

        public decimal ApplyDiscount(decimal percentage)
        {
            //decimal Total = items.Select(x => x.Price)
            //                .Sum();
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException("Percentage cannot be less than 0 and greater than 100");
            }
                var Total =GetTotal();
            decimal discount = Total * (percentage / 100);

            return Total - discount;

        }

        public void ClearCart() 
        {

            items.Clear();
        }

    }
}
