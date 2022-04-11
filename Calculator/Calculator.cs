namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            PerformOneCalcultion();
            Console.ReadLine();
        }
        
        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.WriteLine("=========================");
        }
        
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
        
        private static void PerformOneCalcultion()
        {
            Console.WriteLine("Please enter the operator +, -, / or *: ");
            char math_sign = char.Parse(Console.ReadLine());
            
            int quantity = EnterInformation("How many numbers do you want to " + $"{math_sign}" + " ?: ");
            int[] numbers = new int[quantity];
            
            for (int i = 0; i < quantity; i++)
                numbers[i] = EnterInformation("Please enter number: ");
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
            PerformOneCalcultion();
        }
    }
}


