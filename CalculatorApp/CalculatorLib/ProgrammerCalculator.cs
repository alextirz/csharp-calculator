using CalculatorApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CalculatorLib
{
    public class ProgrammerCalculator : Calculator
    {
        private readonly string[] SpecificOperations = { "&", "|", "^" };
        public override string[] ValidOperations => base.ValidOperations.Concat(SpecificOperations).ToArray();

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

        public override void PerformOperation(double a, double b)
        {
            if (CheckIfInputsCanBeIntegers(a, b))
                throw new ArgumentException("Programmer calculator supports only integers.");

            var firstNumberInt = Convert.ToInt32(a);
            var secondNumberInt = Convert.ToInt32(b);
            if (ActiveOperation == "&")
                And(firstNumberInt, secondNumberInt);
            else if (ActiveOperation == "|")
                Or(firstNumberInt, secondNumberInt);
            else if (ActiveOperation == "^")
                Xor(firstNumberInt, secondNumberInt);

            else base.PerformOperation(a, b);
        }

        private bool CheckIfInputsCanBeIntegers(double a, double b)
        {
            return a % 1 != 0 && b % 1 != 0;
        }
    }
}