namespace CalculatorApp
{
    public class Calculator
    {
        protected virtual string[] ValidOperations { get; } = ["+", "-", "*", "/"];
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
    }
}
