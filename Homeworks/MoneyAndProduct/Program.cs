namespace MoneyAndProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Create a new product ===");

            string name = ReadString("Enter product name: ");
            Money price = CreateMoney();
            string? description = ReadString("Enter description (optional, press Enter to skip): ", false);

            Product product = new Product(name, price, description);

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("1. Show product");
                Console.WriteLine("2. Increase price");
                Console.WriteLine("3. Decrease price");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(product);
                        break;

                    case "2":
                        decimal increase = ReadDecimal("Enter amount to increase price: ");
                        product.IncreasePrice(increase);
                        Console.WriteLine("Price updated: " + product);
                        break;

                    case "3":
                        decimal decrease = ReadDecimal("Enter amount to decrease price: ");
                        product.DecreasePrice(decrease);
                        Console.WriteLine("Price updated: " + product);
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static string? ReadString(string prompt, bool required = true)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (required)
                {
                    if (!string.IsNullOrWhiteSpace(input))
                        return input;
                    Console.WriteLine("Input cannot be empty. Try again.");
                }
                else
                {
                    return string.IsNullOrWhiteSpace(input) ? null : input;
                }
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                try
                {
                    if (int.TryParse(input, out int value))
                        return value;

                    throw new FormatException("Invalid number format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                try
                {
                    if (decimal.TryParse(input, out decimal value))
                        return value;

                    throw new FormatException("Invalid number format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} Try again.");
                }
            }
        }

        static Money CreateMoney()
        {
            while (true)
            {
                try
                {
                    decimal whole = ReadDecimal("Enter whole part of price: ");
                    int cents = ReadInt("Enter cents: ");
                    return new Money((int)whole, cents);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid money value: {ex.Message}. Please try again.");
                }
            }
        }
    }
}
