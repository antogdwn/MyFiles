using System.Security.Cryptography;

namespace Delegate
{
    public delegate void NotifyUser(string message);

    public class DelegateDemo
    {


    }

    public class User
    {
        
       public string Name { get; set; }
       public NotifyUser Notify { get; set; }

        public User(string name, NotifyUser notify)
        {
            this.Name = name;
            this.Notify = notify;
        }

    }   

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class MarketPlace
    {

        public List<Product> Products = new List<Product>();
        List<User> Users = new List<User>();
        Predicate<User> filter = user => user.Name.StartsWith("M");

        public MarketPlace()
        {
            Products = [new Product { Name = "Apple", Price = 100 }, new Product { Name = "MangoBar", Price = 0 }];
            
            User User1 = new User("Anto", new NotificationService().SendEmail);
            User1.Notify += new NotificationService().SendSms;
            User1.Notify += new NotificationService().PushNotification;
            Users.Add(User1);

            User User2 = new User("Mansi", new NotificationService().SendEmail);
            User2.Notify += new NotificationService().SendSms;
            Users.Add(User2);


        }




        public void AddProduct(Product product)
        {

           
            Products.Add(product);
            foreach(User user in Users)
            {
                if (filter(user))
                {
                    user.Notify($"New product added {user.Name}");
                }
            }
            
        }

        public void ChangePrice(Product product, decimal newprice)
        {
            if(newprice < product.Price)
            {
                foreach(User user in Users)
                {
                    if (filter(user))
                    {
                        user.Notify($"Price dropped {user.Name}");
                    }
                }
                
            }
        }
        


    }
    public class NotificationService
    {
        public NotificationService()
        {

        }
        public void SendEmail(string message)
        {
            Console.WriteLine("Email Notification");
            Console.WriteLine(message);
        }
        public void SendSms(string message)
        {
            Console.WriteLine("SMS Notification");

            Console.WriteLine(message);

        }
        public void PushNotification(string message)
        {
            Console.WriteLine("Push Notification");
            Console.WriteLine(message);
        }
    }

}
