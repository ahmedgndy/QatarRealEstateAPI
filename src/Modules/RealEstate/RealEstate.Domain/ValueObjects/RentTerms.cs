namespace RealEstate.Domain.ValueObjects;

public class RentTerms
{
    public Money Price { get; private set; }

    public int ContractDurationMonths { get; private set; }

    private RentTerms() { }

    public static RentTerms Create(Money price, int contractDurationMonths)
    {
        if (price == null)
            throw new ArgumentNullException(nameof(price), "Price is required.");

        if (contractDurationMonths <= 0)
            throw new ArgumentException("Contract duration must be greater than 0.", nameof(contractDurationMonths));

        return new RentTerms
        {
            Price = price,
            ContractDurationMonths = contractDurationMonths
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not RentTerms other)
            return false;

        return Price.Equals(other.Price) && ContractDurationMonths == other.ContractDurationMonths;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Price, ContractDurationMonths);
    }
}