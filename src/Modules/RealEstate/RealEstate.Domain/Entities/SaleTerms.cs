using RealEstate.Domain.Enums;
using RealEstate.Domain.ValueObjects;

namespace RealEstate.Domain.Entities;

public class SaleTerms
{
    public Money Price { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }
}

