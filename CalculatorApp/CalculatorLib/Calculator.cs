namespace CalculatorApp
{
    public static class Calculator
    {
        public static double LastResult { get; private set; }
        public static double Add(double a, double b) => LastResult = a + b;
        public static double Subtract(double a, double b) => LastResult = a - b;
        public static double Multiply(double a, double b) => LastResult = a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return LastResult = a / b;
        }
    }
}
