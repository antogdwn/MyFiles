namespace TemperatureConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Temperature to convert");
            //double Temperature;
            double.TryParse(Console.ReadLine(), out double Temperature);

            Console.WriteLine("Enter Source (C/F/K)");
            Enum.TryParse(Console.ReadLine(), out Scale Source);
            //Scale Source = (Scale)Convert.ToInt32(Console.Read());

            Console.WriteLine(("Enter Source (C/F/K)"));
            Enum.TryParse(Console.ReadLine(), out Scale Target);

            string Converted = (Source,Target) switch
            {
                (Scale.C,Scale.F) => ((Temperature * 1.8) +32).ToString("0.00"),
                (Scale.C, Scale.K) => (Temperature + 273.15).ToString("0.00"),

                (Scale.F, Scale.C) => ((Temperature - 32) / 1.8).ToString("0.00"),
                (Scale.F, Scale.K) => ((Temperature + 459.67) * 0.5555).ToString("0.00"),


                (Scale.K, Scale.C) =>((Temperature - 273.15).ToString("0.00")),
                (Scale.K, Scale.F) => ((1.8 * (Temperature - 273.15) + 32).ToString("0.00")),

                _=>Temperature.ToString("0.00")

            };
            Console.WriteLine(Converted);
            /*
            switch (Source)
            {
                case Scale.C:
                    if (Target == Scale.F)
                    {
                        Console.WriteLine(((Temperature * 1.8) + 32).ToString("0.00"));
                    }
                    else if (Target == Scale.K)
                    {
                        Console.WriteLine((Temperature + 273.15).ToString("0.00"));
                    }
                    break;
                case Scale.F:
                    if (Target == Scale.C)
                    {
                        Console.WriteLine(((Temperature - 32) / 1.8).ToString("0.00"));

                    }
                    else if (Target == Scale.K)
                    {
                        Console.WriteLine(((Temperature + 459.67) * 0.5555).ToString("0.00"));

                    }
                    break;
                case Scale.K:
                    if (Target == Scale.C)
                    {
                        Console.WriteLine((Temperature - 273.15).ToString("0.00"));

                    }
                    else if (Target == Scale.F)
                    {
                        Console.WriteLine((1.8 * (Temperature - 273.15) + 32).ToString("0.00"));

                    }
                    break;
            }
            */
        }


        enum Scale
        {
            C,
            F,
            K
        }
    }
}

