using RealEstate.Domain.Enums;

namespace RealEstate.Entities.Domain;

public class SaleTerms
{
    public Money Price { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }
}

