using BuildingBlocks.Common.Results.Errors;

namespace RealEstate.Domain.DomainErros;

public static class PropertyErrors
{
    // Title
    public static Error TitleRequired =>
        Error.Validation("Property.Title.Required", "Property title is required.");

    public static Error TitleTooShort =>
        Error.Validation("Property.Title.TooShort", "Property title must be at least 3 characters.");

    public static Error TitleTooLong =>
        Error.Validation("Property.Title.TooLong", "Property title must not exceed 150 characters.");

    // Description
    public static Error DescriptionTooLong =>
        Error.Validation("Property.Description.TooLong", "Property description must not exceed 4000 characters.");

    // Property type
    public static Error PropertyTypeRequired =>
        Error.Validation("Property.PropertyType.Required", "A property type must be specified.");

    public static Error PropertyTypeNotFound =>
        Error.NotFound("Property.PropertyType.NotFound", "The specified property type does not exist.");

    // Location
    public static Error LocationRequired =>
        Error.Validation("Property.Location.Required", "Property location is required.");

    // Listing terms (the core invariant)
    public static Error SaleTermsRequired =>
        Error.Validation("Property.SaleTerms.Required", "Sale terms are required for a property listed for sale.");

    public static Error RentTermsRequired =>
        Error.Validation("Property.RentTerms.Required", "Rent terms are required for a property listed for rent.");

    public static Error ListingTermsMissing =>
        Error.Validation("Property.ListingTerms.Missing", "A property must have either sale terms or rent terms.");

    // Media
    public static Error TooManyMediaItems =>
        Error.Validation("Property.Media.TooMany", "A property cannot have more than 20 media items.");

    public static Error PrimaryMediaRequired =>
        Error.Validation("Property.Media.PrimaryRequired", "A property must have exactly one primary image.");

    // Duplicate prevention (raised in the application layer)
    public static Error DuplicateListing =>
        Error.Conflict("Property.Duplicate", "An active listing already exists for this property.");

    // Lifecycle / lookup
    public static Error NotFound =>
        Error.NotFound("Property.NotFound", "The requested property was not found.");

    public static Error AlreadyPublished =>
        Error.Conflict("Property.AlreadyPublished", "The property is already published.");

    public static Error MediaRequired =>
        Error.Validation("Property.Media.Required", "At least one media item is required for the property.");
}