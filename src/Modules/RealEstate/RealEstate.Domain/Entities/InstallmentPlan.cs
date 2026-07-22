using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class InstallmentPlan
{
    public Money DownPayment { get; set; }
    public int NumberOfInstallments { get; set; }
    public Money InstallmentAmount { get; set; }
    public Frequency Frequency { get; set; }
}
