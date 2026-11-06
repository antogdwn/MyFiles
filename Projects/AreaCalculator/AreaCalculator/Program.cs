using AreaCalculator.Interfaces;
using AreaCalculator.Services;
using System.Security.Cryptography.X509Certificates;

namespace AreaCalculator
{
    internal class Program
    {
        //public List<Ishape> shapes = new List<Ishape>();

        static void Main(string[] args)
        {
            List<Ishape> shapes = new List<Ishape>();

            while (true)
            {
                Console.WriteLine("Enter Input \n1 -> Circle \n2 -> Rectangle");
                int input1 = Convert.ToInt32(Console.ReadLine());

                if (input1 == 1)
                {
                    Console.WriteLine("Enter radius");
                    double Radius = Convert.ToDouble(Console.ReadLine());
                    Ishape shape = new Circle(Radius);
                    shapes.Add(shape);
                }
                else if (input1 == 2)
                {

                    Console.WriteLine("Enter Width");
                    double Width = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter Height");
                    double Height = Convert.ToDouble(Console.ReadLine());
                    Ishape shape = new Rectangle(Width, Height);
                    shapes.Add(shape);

                }
                Console.WriteLine("Do you want to add another shape ? yes/no");
                string Addanother = Convert.ToString(Console.ReadLine());

                if (Addanother.ToLower().Trim()=="yes")
                {
                    continue;
                }
                else {
                    break;
                }

            }
                //Ishape shape2 = new Rectangle(5, 5);

            //Console.WriteLine(shape.GetArea());
            //Console.WriteLine(shape2.GetArea());

            //shapes.Add(shape);
            //shapes.Add(shape2);

            var TotalArea= shapes.Sum(shape => shape.GetArea());
            Console.WriteLine(TotalArea);


        }

            
    }
}

    

