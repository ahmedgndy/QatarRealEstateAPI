using BuildingBlocks.Common.Results.Errors;

namespace RealEstate.Domain.DomainErros;

public static class MediaErrors
{
    public static Error UrlRequired =>
        Error.Validation("Media.Url.Required", "Media URL is required.");

    public static Error MediaTypeRequired =>
        Error.Validation("Media.MediaType.Required", "Media type is required.");

    public static Error InvalidDimensions =>
        Error.Validation("Media.Dimensions.Invalid", "Width and height must be greater than 0.");

    public static Error InvalidOrder =>
        Error.Validation("Media.Order.Invalid", "Media order must be greater than or equal to 0.");

    public static Error InvalidPropertyId =>
        Error.Validation("Media.PropertyId.Invalid", "Property ID must be greater than 0.");
}