namespace RealEstate.Entities.Domain;

public class Location
{
    public Guid ID { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string StreetName { get; set; }

    public string PostalCode { get; set; }

    public string State { get; set; }

    public string XCoordinate { get; set; }
    public string YCoordinate { get; set; }

    public string Description { get; set; }
}