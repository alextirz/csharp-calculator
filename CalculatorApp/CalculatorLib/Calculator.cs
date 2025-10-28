namespace CalculatorApp
{
    public class Calculator
    {
        public double LastResult { get; private set; }
        public double Add(double a, double b) => LastResult = a + b;
        public double Subtract(double a, double b) => LastResult = a - b;
        public double Multiply(double a, double b) => LastResult = a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return LastResult = a / b;
        }
    }
}
