using System.Globalization;

namespace Calculator
{
    class Program
    {
        private const int NumberOneCalculator = 1;
        private const int DateOneCalculator = 2;

        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            while (true)
            {
                int calculationMode = AskForCalculationMode();
                if (calculationMode == NumberOneCalculator)
                {
                    NumberCalculator.PerformNumberCalcultion();
                }
                else if (calculationMode == DateOneCalculator)
                {
                    DateCalculator.PerformeDateCalculation();
                }
            }
        }

        private static int AskForCalculationMode()
        {
            Console.WriteLine("Which calculator do you want?");
            Console.WriteLine("For Numbers enter 1");
            Console.WriteLine("For Dates enter 2");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.WriteLine("=========================");
        }

        class NumberCalculator
        {
            public static void PerformNumberCalcultion()
            {
                Console.WriteLine("Please enter the operator +, -, / or *: ");
                char math_sign = char.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the number to " + $"{math_sign}");

                List<int> numbers = new List<int>();
                while (true)
                {
                    Console.WriteLine("Please enter the next number: ");
                    if (int.TryParse(Console.ReadLine(), out var number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        break;
                    }
                }

                decimal result = numbers[0];
                var remainder = numbers.Skip(1);
                foreach (int number in remainder)
                {
                    if (math_sign == '+')
                    {
                        result = numbers.Sum();
                    }
                    else if (math_sign == '-')
                    {
                        result = numbers.Aggregate((a, b) => a - b);
                    }
                    else if (math_sign == '*')
                    {
                        result = numbers.Aggregate((a, b) => a * b);
                    }
                    else if (math_sign == '/')
                    {
                        result = numbers.Aggregate((a, b) => a / b);
                    }
                }

                Console.WriteLine("The answer is {0}", result);
            }
        }
    }

    class DateCalculator
    {
        public static void PerformeDateCalculation()
        {
            Console.WriteLine("Please enter a date in format mm/dd/yyyy: ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add: ");
            int daysToAdd = int.Parse(Console.ReadLine());

            Console.WriteLine(date.AddDays(daysToAdd).ToShortDateString());
        }
    }
}