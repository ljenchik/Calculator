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
            private static int EnterInformation(string message)
            {
                Console.WriteLine(message);
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out var number))
                    {
                        return number;
                    }

                    Console.WriteLine("Enter an integer");
                }
            }

            public static void PerformNumberCalcultion()
            {
                Console.WriteLine("Please enter the operator +, -, / or *: ");
                char math_sign = char.Parse(Console.ReadLine());

                int quantity = EnterInformation("How many numbers do you want to " + $"{math_sign}" + " ?: ");
                int[] numbers = new int[quantity];

                for (int i = 0; i < quantity; i++)
                    numbers[i] = EnterInformation($"Please enter number {i + 1}: ");
                decimal res = numbers[0];
                for (int i = 1; i < quantity; i++)
                {
                    if (math_sign == '+')
                        res += numbers[i];
                    else if (math_sign == '-')
                        res -= numbers[i];
                    else if (math_sign == '/')
                        res /= numbers[i];
                    else if (math_sign == '*')
                        res *= numbers[i];
                }
                Console.WriteLine("The answer is {0}", res);
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
}
        

        



