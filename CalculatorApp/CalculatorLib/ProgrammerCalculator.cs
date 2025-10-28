using CalculatorApp;

namespace CalculatorLib
{
    public class ProgrammerCalculator : Calculator
    {
        private readonly string[] SpecificOperations = { "bin", "hex", "&", "|", "^" };
        protected override string[] ValidOperations => base.ValidOperations.Concat(SpecificOperations).ToArray();
        public string ToBinary(int number) => Convert.ToString(number, 2);
        public string ToHex(int number) => Convert.ToString(number, 16).ToUpper();

        public int And(int a, int b)
        {
            int result = a & b;
            LastResult = result;
            return result;
        }

        public int Or(int a, int b)
        {
            int result = a | b;
            LastResult = result;
            return result;
        }

        public int Xor(int a, int b)
        {
            int result = a ^ b;
            LastResult = result;
            return result;
        }

        public override double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("[Programmer] Divide by zero attempt blocked.");
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            Console.WriteLine("[Programmer] Integer division performed.");
            return LastResult = Math.Floor(a / b); 
        }
    }
}
