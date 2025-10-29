using CalculatorApp;

namespace CalculatorLib
{
    public class ScientificCalculator : Calculator
    {
        private readonly string[] SpecificOperations = { "pow", "sqrt", "sin", "cos" };
        public override string[] ValidOperations => base.ValidOperations.Concat(SpecificOperations).ToArray();
        public double Pow(double a, double b) => LastResult = Math.Pow(a, b);

        public double Sqrt(double a)
        {
            if (a < 0)
                throw new InvalidOperationException("Cannot calculate square root of a negative number.");
            return LastResult = Math.Sqrt(a);
        }

        public double Sin(double degrees)
        {
            double radians = degrees * Math.PI / 180;
            return LastResult = Math.Sin(radians);
        }

        public double Cos(double degrees)
        {
            double radians = degrees * Math.PI / 180;
            return LastResult = Math.Cos(radians);
        }

        public override double Divide(double a, double b)
        {
            Console.WriteLine("[Scientific] Performing division.");

            if (double.IsNaN(a) || double.IsNaN(b))
                throw new InvalidOperationException("Inputs cannot be NaN.");

            if (double.IsInfinity(a) || double.IsInfinity(b))
                throw new InvalidOperationException("Inputs cannot be infinite.");

            if (b == 0)
                throw new DivideByZeroException("Division by zero is not allowed in Scientific Calculator.");

            return LastResult = a / b;
        }

        public override void PerformOperation(double a, double b)
        {
            if (ActiveOperation == "pow")
                Pow(a, b);
            else if (ActiveOperation == "sqrt")
                Sqrt(a);
            else if (ActiveOperation == "sin")
                Sin(a);
            else if (ActiveOperation == "cos")
                Cos(a);

            else base.PerformOperation(a, b);
        }

        public override bool SecondInputRequired()
        {
            if (ActiveOperation == "sqrt" || ActiveOperation == "sin" || ActiveOperation == "cos")
                return false;

           return base.SecondInputRequired();
        }
    }
}
