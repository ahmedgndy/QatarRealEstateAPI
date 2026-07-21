using System.Runtime;

namespace RealEstate.Entities.Domain;

public class RentTerms
{
    public Guid ID { get; set; }
    public required Money money { get; set; }

    //public Period period;
    public int ContractDurationMonths { get; set; }


}