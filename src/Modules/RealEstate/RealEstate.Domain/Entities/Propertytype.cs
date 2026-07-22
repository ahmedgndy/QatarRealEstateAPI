using BuildingBlocks.Common;

namespace RealEstate.Domain.Entities;

public class PropertyType : AuditableEntity
{
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    private PropertyType() { }

    public static PropertyType Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property type name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Property type description is required.", nameof(description));

        return new PropertyType
        {
            Name = name,
            Description = description
        };
    }

    public void Update(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Property type name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Property type description is required.", nameof(description));

        Name = name;
        Description = description;
    }
}