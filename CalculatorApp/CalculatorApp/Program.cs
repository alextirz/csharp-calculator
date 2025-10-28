using CalculatorLib;

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

                var calculator = new Calculator();

                Console.WriteLine("Please enter first number:");
                double a = ReadNumberInput();

                Console.WriteLine("Please enter second number:");
                double b = ReadNumberInput();

                PerformOperation(calculator, a, b, operation);
                Console.WriteLine($"(LastResult stored: {calculator.LastResult})");
            }
        }

        private static string SelectOperation()
        {
            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();

                if (input == "q" || input == "+" || input == "-" || input == "*" || input == "/")
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

        private static void PerformOperation(Calculator calculator, double a, double b, string operation)
        {
            try
            {
                Console.WriteLine($"Result: {operation switch
                {
                    "+" => calculator.Add(a, b),
                    "-" => calculator.Subtract(a, b),
                    "*" => calculator.Multiply(a, b),
                    "/" => calculator.Divide(a, b),
                    _ => throw new ArgumentOutOfRangeException("Unknown operation.")
                }}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: Division by 0 is not allowed.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Operation you are trying to perform is invalid.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The result of the operation is invalid.");
            }
        }

    }
}
