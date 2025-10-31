namespace MoneyAndProduct
{
    internal class Money
    {
        private int majorUnit;
        private int minorUnit;
        public string Currency { get; private set; }

        public int WholePart
        {
            get => majorUnit;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Amount can not be negative");
                majorUnit = value;

            }
        }
        public int Cents
        {
            get => minorUnit;
            set
            {
                if (value < 0 || value > 99)
                    throw new ArgumentOutOfRangeException("Minor units (cents) can be from 0 to 99");
                minorUnit = value;
            }
        }

        public Money(int whole, int cents, string currency = "uah")
        {
            WholePart = whole;
            Cents = cents;
            Currency = currency;
        }

        public void SetOrUpdateAmount(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount can not be negative");

            WholePart = Convert.ToInt32(Math.Floor(amount));
            Cents = Convert.ToInt32((amount - WholePart) * 100);
        }

        public void Increase(decimal value)
        {
            SetOrUpdateAmount(ToDecimal() + value);
        }

        public void Decrease(decimal value)
        {
            decimal newValue = ToDecimal() - value;
            if (newValue < 0)
            {
                newValue = 0;
            }
            SetOrUpdateAmount(newValue);
        }

        public decimal ToDecimal() => WholePart + Cents / 100m;

        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return WholePart == other.WholePart &&
                       Cents == other.Cents &&
                       Currency == other.Currency;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WholePart, Cents, Currency);
        }

        public override string ToString()
        {
            return $"{WholePart}.{Cents:00} {Currency}";
        }
    }
}
