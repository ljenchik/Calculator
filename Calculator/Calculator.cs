namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.WriteLine("===================");
            
            Console.WriteLine("Please enter the operator +, -, / or *: ");
            char math_sign = char.Parse(Console.ReadLine());
            
            Console.Write("Enter the first number: ");
            string firstNumber = Console.ReadLine();
            decimal first = decimal.Parse(firstNumber);
            
            Console.Write("Enter the second number: ");
            string secondNumber = Console.ReadLine();
            decimal second = decimal.Parse(secondNumber);

            if (math_sign == '+')
            {
                Console.Write("{0} + {1} = {2}",  first, second, first + second);
            }
            else if (math_sign == '-')
            {
                Console.Write("{0} - {1} = {2}",  first, second, first - second);
            }
            else if (math_sign == '/')
            {
                Console.Write("{0} / {1} = {2}",  first, second, first / second);
            }
            else if (math_sign == '*')
            {
                Console.Write("{0} * {1} = {2}",  first, second, first * second);
            }
            Console.ReadLine();
        }
    }
}

