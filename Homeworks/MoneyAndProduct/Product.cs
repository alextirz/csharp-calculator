namespace MoneyAndProduct
{
    internal class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }
        public string? Description { get; set; }

        public Product(string name, Money price, string? description = null)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public void IncreasePrice(decimal value) => Price.Increase(value);
        public void DecreasePrice(decimal value) => Price.Decrease(value);

        public override string ToString() => $"Name: {Name}, Price: {Price}, Description: {Description}";

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase)
                       && Price == other.Price && string.Equals(Description, other.Description);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name?.ToLowerInvariant(), Price);
        }
    }
}
