using System.Threading.Tasks;

namespace AdvancedDelegateDemo
{
    public delegate void NotifyUser(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            MarketPlace market = new MarketPlace();

            Console.WriteLine("Hello, World!");

            //NotifyUser notify = SendEmail; 
            User user1 = new User
            {
                Name = "Anto",
                Notify = SendEmail
            };
            user1.Notify += SendSMS;

            User user2 = new User
            {
                Name = "Godwin",
                Notify = SendEmail
            };
            user2.Notify += SendSMS;
            user2.Notify += SendPushNotification;


            users.Add(user1);
            users.Add(user2);

            Product product = new Product { Name = "bag", Price = 100 };
            Product product2 = new Product { Name = "Nike bag", Price = 150 };

            Predicate<User> filter =
               user => user.Name.StartsWith("A");

            MarketPlace.AddProduct(product, users, filter);
            MarketPlace.AddProduct(product2, users, filter);

            MarketPlace.ChangePrice(product2, 80, users);





        }
        public static void SendEmail(string message)
        {
            Console.WriteLine($"Email :{message}");
        }


        public static void SendSMS(string message)
        {
            Console.WriteLine($"SMS :{message}");
        }

        public static void SendPushNotification(string message)
        {
            Console.WriteLine($"PushNotification :{message}");
        }

    }


    public class User
    {

        public required string Name { get; set; }

        public NotifyUser? Notify { get; set; }

    }

    public class Product
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }

    }




    public class MarketPlace
    {
        public static void AddProduct(Product product, List<User> users, Predicate<User> filter)
        {



            foreach (var user in users)
            {
                if (filter(user))
                {
                    user.Notify?.Invoke($"New Product Added Product :{product.Name} Price :{product.Price}");

                }
            }
        }

        public static void ChangePrice(Product product, decimal newprice, List<User> users)
        {
            foreach (var user in users)
            {
                
                if (newprice < product.Price)
                {
                    user.Notify?.Invoke($"Product price changed :{product.Name} Price :{newprice}");

                }
            }

            product.Price = newprice;

        }

    }
}

