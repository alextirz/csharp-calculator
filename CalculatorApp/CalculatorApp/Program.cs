using System;

namespace CalculatorApp
{
    class Program
    {
        static bool exit = false;
        static void Main()
        {

            Console.WriteLine("=== Simple Calculator ===");

            while (!exit)
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

        private static bool CheckQuit(string? input)
        {  // Quit
            if (input?.ToLower() == "q")
            {
                exit = true;
            }
            return exit;
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

        private static void PerformOperation(double a, double b)
        {
            while (true)
            {
                var input = Console.ReadLine()?.Trim();

                // Quit
                if (CheckQuit(input))
                    break;

                try
                {
                    Console.WriteLine($"Result: {input switch
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
                    Console.WriteLine("Error: Invalid input. Please enter a valid operation (+, -, *, /) or 'q' to quit.");
                }
            }
        }

    }
}
