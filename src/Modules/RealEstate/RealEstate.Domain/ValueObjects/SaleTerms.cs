using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.ValueObjects;

public class SaleTerms
{
    public Money Price { get; private set; }

    public PaymentMethod PaymentMethod { get; private set; }

    public InstallmentPlan? InstallmentPlan { get; private set; }

    private SaleTerms() { }

    public static SaleTerms Create(Money price, PaymentMethod paymentMethod, InstallmentPlan? installmentPlan = null)
    {
        if (price == null)
            throw new ArgumentNullException(nameof(price), "Price is required.");

        if (!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
            throw new ArgumentException("Invalid payment method.", nameof(paymentMethod));

        if (paymentMethod == PaymentMethod.Installment && installmentPlan == null)
            throw new ArgumentException("Installment plan is required when payment method is Installment.", nameof(installmentPlan));

        return new SaleTerms
        {
            Price = price,
            PaymentMethod = paymentMethod,
            InstallmentPlan = installmentPlan
        };
    }

    public override bool Equals(object? obj)
    {
        if (obj is not SaleTerms other)
            return false;

        return Price.Equals(other.Price) && PaymentMethod == other.PaymentMethod && InstallmentPlan == other.InstallmentPlan;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Price, PaymentMethod, InstallmentPlan);
    }
}