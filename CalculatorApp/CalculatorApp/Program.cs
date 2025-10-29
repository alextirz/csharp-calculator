using CalculatorLib;

namespace CalculatorApp
{
    class Program
    {
        static Calculator calculator;
        static void Main()
        {

            Console.WriteLine("Super Calculator.");
            calculator = SelectCalculator();
            if (calculator == null) return; // user choice is to quit

            while (true)
            {
                Console.WriteLine($"Choose operation. {calculator.ShowValidOperations()}");
                var operation = SelectOperation();

                Console.WriteLine("Please enter first number:");
                double a = ReadNumberInput();

                Console.WriteLine("Please enter second number:");
                double b = ReadNumberInput();

                calculator.PerformOperation(a, b, operation);
                Console.WriteLine($"(LastResult stored: {calculator.LastResult})");
            }
        }

        static Calculator? SelectCalculator()
        {
            while (true)
            {
                Console.WriteLine("Select calculator type:");
                Console.WriteLine("1 - Basic Calculator");
                Console.WriteLine("2 - Scientific Calculator");
                Console.WriteLine("3 - Programmer Calculator");
                Console.WriteLine("q - Quit");

                var choice = Console.ReadLine()?.Trim().ToLower();

                if (choice == "q")
                {
                    Console.WriteLine("Quitting.");
                    return null;
                }
                if (choice == "1")
                {
                    Console.WriteLine("Selected Basic Calculator");
                    return new Calculator();
                }

                if (choice == "2")
                {
                    Console.WriteLine("Selected Scientific Calculator");
                    return new ScientificCalculator();
                }

                if (choice == "3")
                {
                    Console.WriteLine("Selected Programmer Calculator");
                    return new ProgrammerCalculator();
                }

                Console.WriteLine("Invalid choice. Please follow the rules below.");
            }
        }

        private static string SelectOperation()
        {
            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();

                if (calculator.ValidOperations.Contains(input))
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


    }
}
