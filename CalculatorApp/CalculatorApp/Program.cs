using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Simple Calculator.");

            while (true)
            {
                Console.WriteLine("Choose operation (+, -, *, /) or 'q' to quit:");
                var operation = SelectOperation();
                if (operation == "q")
                    return;

                Console.WriteLine("Please enter first number:");
                double a = ReadNumberInput();

                Console.WriteLine("Please enter second number:");
                double b = ReadNumberInput();

                PerformOperation(a, b, operation);
                Console.WriteLine($"(LastResult stored: {Calculator.LastResult})");
            }
        }

        private static string SelectOperation()
        {
            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();

                if (input == "q" || input == "+" || input == "+" || input == "+" || input == "+")
                    return input;

                Console.WriteLine("Error: Invalid input. Please enter a valid operation (+, -, *, /) or 'q' to quit.");
            }
        }

        private static double ReadNumberInput()
        {
            while (true)
            {
                var input = Console.ReadLine()?.Trim();

                if (double.TryParse(input, out double number))
                    return number;

                Console.WriteLine("Invalid number, try again:");
            }
        }

        private static void PerformOperation(double a, double b, string operation)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Result: {operation switch
                    {
                        "+" => Calculator.Add(a, b),
                        "-" => Calculator.Subtract(a, b),
                        "*" => Calculator.Multiply(a, b),
                        "/" => Calculator.Divide(a, b),
                        _ => throw new ArgumentOutOfRangeException("Unknown operation.")
                    }}");

                    break; 
                }
                catch
                {
                    Console.WriteLine("Error: Invalid operation.");
                }
            }
        }

    }
}
