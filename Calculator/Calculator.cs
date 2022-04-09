namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator!");
            Console.WriteLine("=========================");
            
            Console.WriteLine("Please enter the operator +, -, / or *: ");
            char math_sign = char.Parse(Console.ReadLine());
            
            Console.WriteLine("How many numbers do you want to " + $"{math_sign}" + " ?: ");
            int quantity = int.Parse(Console.ReadLine());

            decimal[] numbers = new decimal[quantity];
            
            for (int i = 0; i < quantity; i++)
            {
                Console.Write("Please enter number: ");
                string num_str = Console.ReadLine();
                decimal number = decimal.Parse(num_str);
                numbers[i] = number;
            }

            decimal res = numbers[0];
            for (int i = 1; i < quantity; i++)
            {
                if (math_sign == '+')
                {
                    res += numbers[i];
                }
                else if (math_sign == '-')
                {
                    res -= numbers[i];
                }
                else if (math_sign == '/')
                {
                    res /= numbers[i];
                }
                else if (math_sign == '*')
                {
                    res *= numbers[i];
                }
            }
            Console.WriteLine("The answer is {0}",res);
            Console.ReadLine();
        }
    }
}

