namespace CalculatorApp
{
    public class Calculator
    {
        public virtual string[] ValidOperations { get; } = ["+", "-", "*", "/"];
        public double LastResult { get; protected set; }
        public double Add(double a, double b) => LastResult = a + b;
        public double Subtract(double a, double b) => LastResult = a - b;
        public double Multiply(double a, double b) => LastResult = a * b;

        public virtual double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return LastResult = a / b;
        }

        public string ShowValidOperations()
        {
            return $"Available operations: {string.Join(", ", ValidOperations)}";
        }

        public virtual void PerformOperation(double a, double b, string operation)
        {
            try
            {
                if (operation == "+")
                    Add(a, b);
                else if (operation == "-")
                    Subtract(a, b);
                else if (operation == "*")
                    Multiply(a, b);
                else if (operation == "/")
                    Divide(a, b);

                else throw new ArgumentOutOfRangeException("Unknown operation.");
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
