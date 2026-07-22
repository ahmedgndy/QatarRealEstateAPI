using BuildingBlocks.Common;

namespace RealEstate.Domain.Entities;

public class PropertyFeature : AuditableEntity
{
    public int PropertyId { get; private set; }

    public int FeatureId { get; private set; }

    public string FeatureName { get; private set; } = string.Empty;

    public string FeatureValue { get; private set; } = string.Empty;

    public string? Icon { get; private set; }

    private PropertyFeature() { }

    public static PropertyFeature Create(int propertyId, int featureId, string featureName, string featureValue, string? icon = null)
    {
        if (propertyId <= 0)
            throw new ArgumentException("Property ID must be greater than 0.", nameof(propertyId));

        if (featureId <= 0)
            throw new ArgumentException("Feature ID must be greater than 0.", nameof(featureId));

        if (string.IsNullOrWhiteSpace(featureName))
            throw new ArgumentException("Feature name is required.", nameof(featureName));

        if (string.IsNullOrWhiteSpace(featureValue))
            throw new ArgumentException("Feature value is required.", nameof(featureValue));

        return new PropertyFeature
        {
            PropertyId = propertyId,
            FeatureId = featureId,
            FeatureName = featureName,
            FeatureValue = featureValue,
            Icon = icon
        };
    }
}