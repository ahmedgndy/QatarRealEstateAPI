namespace RealEstate.Domain.ValueObjects;

public class Money
{
    public decimal Amount { get; private set; }
    
    public string Currency { get; private set; }

    private Money() { }

    public static Money Create(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required.", nameof(currency));

        return new Money
        {
            Amount = amount,
            Currency = currency
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Money other)
            return false;

        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}