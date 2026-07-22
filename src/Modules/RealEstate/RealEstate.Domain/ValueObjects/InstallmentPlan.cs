using System;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.ValueObjects;
/// <summary>
/// InstallmentPlan is a value object representing payment schedule details.
/// It's immutable and compared by value (record) to follow DDD practices.
/// </summary>
public sealed record InstallmentPlan
{
    public Money DownPayment { get; init; } = default!;

    public int NumberOfInstallments { get; init; }

    public Money InstallmentAmount { get; init; } = default!;

    public Frequency Frequency { get; init; }

    // for ORM
    private InstallmentPlan() { }

    private InstallmentPlan(Money downPayment, int numberOfInstallments, Money installmentAmount, Frequency frequency)
    {
        if (downPayment is null) throw new ArgumentNullException(nameof(downPayment));
        if (installmentAmount is null) throw new ArgumentNullException(nameof(installmentAmount));
        if (numberOfInstallments <= 0) throw new ArgumentException("Number of installments must be greater than zero.", nameof(numberOfInstallments));
        if (installmentAmount.Amount < 0) throw new ArgumentException("Installment amount cannot be negative.", nameof(installmentAmount));
        if (downPayment.Amount < 0) throw new ArgumentException("Down payment cannot be negative.", nameof(downPayment));
        if (!string.Equals(downPayment.Currency, installmentAmount.Currency, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Down payment and installment amount must use the same currency.");

        DownPayment = downPayment;
        NumberOfInstallments = numberOfInstallments;
        InstallmentAmount = installmentAmount;
        Frequency = frequency;
    }

    public static InstallmentPlan Create(Money downPayment, int numberOfInstallments, Money installmentAmount, Frequency frequency)
        => new InstallmentPlan(downPayment, numberOfInstallments, installmentAmount, frequency);

    public Money TotalAmount()
    {
        var total = DownPayment.Amount + InstallmentAmount.Amount * NumberOfInstallments;
        return Money.Create(total, DownPayment.Currency);
    }
}
