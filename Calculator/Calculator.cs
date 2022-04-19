namespace Calculator;

internal class Program
{
    private static void Main(string[] args)
    {
        PrintWelcomeMessage();
        while (true)
        {
            var calculationMode = AskForCalculationMode();
            if (calculationMode == (int) CalculatorMode.Numbers)
            {
                NumberCalculator.PerformNumberCalcultion();
            }
            else if (calculationMode == (int) CalculatorMode.Dates)
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
        var choice = int.Parse(Console.ReadLine());
        return choice;
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("=========================");
    }

    private class NumberCalculator
    {
        public static void PerformNumberCalcultion()
        {
            Console.WriteLine("Please enter the operator +, -, /, *: ");
            var math_sign = Console.ReadLine();

            if (string.IsNullOrEmpty(math_sign) || !Enum.IsDefined(typeof(Operations), (int)math_sign[0]))
            {
                throw new Exception("Please enter one of these operations: +, -, *, /");
            }

            Console.WriteLine("Please enter the number to " + $"{math_sign}");
            var numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Please enter the next number: ");
                if (int.TryParse(Console.ReadLine(), out var number))
                    numbers.Add(number);
                else
                    break;
            }

            decimal result = Decimal.MaxValue;
            switch ((Operations) math_sign[0])
            {
                case Operations.Add:
                    result = numbers.Sum();
                    break;
                case Operations.Subtract:
                    result = numbers.Aggregate((a, b) => a - b);
                    break;
                case Operations.Multiply:
                    result = numbers.Aggregate((a, b) => a * b);
                    break;
                case Operations.Divide:
                    result = numbers.Aggregate((a, b) => a / b);
                    break;
            }

            Console.WriteLine("The answer is {0}", result);
        }
    }

    private class DateCalculator
    {
        public static void PerformeDateCalculation()
        {
            Console.WriteLine("Please enter a date in format mm/dd/yyyy: ");
            var date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the number of days to add: ");
            var daysToAdd = int.Parse(Console.ReadLine());

            Console.WriteLine(date.AddDays(daysToAdd).ToShortDateString());
        }
    }
}