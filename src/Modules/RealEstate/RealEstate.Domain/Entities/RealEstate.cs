
namespace RealEstate.Entities.Domain;

public class RealEstate
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Media> Media { get; set; }
    public Location Location { get; set; }
    public PropertyType PropertyType { get; set; } //office // villa 

    public RentTerms? rentTerms;

}
