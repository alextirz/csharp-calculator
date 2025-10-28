using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Simple Calculator ===");

            while (true)
            {
                Console.WriteLine("Please enter first number:");
                double a = ReadNumberInput();

                Console.WriteLine("Please enter second number:");
                double b = ReadNumberInput();

                Console.WriteLine("Choose operation (+, -, *, /) or 'q' to quit:");
                PerformOperation(a, b);
                Console.WriteLine($"(LastResult stored: {Calculator.LastResult})");
            }
        }

        private static double ReadNumberInput()
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                    return number;

                Console.WriteLine("Invalid number, try again:");
            }
        }

        private static void PerformOperation(double a, double b)
        {
            while (true)
            {
                var op = Console.ReadLine()?.Trim();

                // Quit
                if (op?.ToLower() == "q")
                    break;

                try
                {
                    Console.WriteLine($"Result: {op switch
                    {
                        "+" => Calculator.Add(a, b),
                        "-" => Calculator.Subtract(a, b),
                        "*" => Calculator.Multiply(a, b),
                        "/" => Calculator.Divide(a, b),
                        _ => throw new InvalidOperationException("Unknown operation.")
                    }}");

                    break; 
                }
                catch
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid operation (+, -, *, /) or 'q' to quit.");
                }
            }
        }

    }
}
