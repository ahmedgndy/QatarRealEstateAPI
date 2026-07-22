
using System.Security.Cryptography.X509Certificates;
using BuildingBlocks.Common;
using BuildingBlocks.Common.Results;
using RealEstate.Domain.Constants;
using RealEstate.Domain.DomainErros;
using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;



public sealed class Property : AuditableEntity
{
    private readonly List<Media> _media = new();
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Location Location { get; private set; }
    public ListingKind ListingKind { get; private set; }

    public SaleTerms? SaleTerms { get; private set; }
    public RentTerms? RentTerms { get; private set; }
    public Guid PropertyTypeId { get; private set; }
    public PropertyStatus Status { get; private set; }

    public List<PropertyFeature> PropertyFeatures { get; private set; }

    public IReadOnlyCollection<Media> Media => _media.AsReadOnly();

    private Property() { }                       // EF Core



    private Property(Guid id, string title, string description,
                     Guid typeId, Location location,
                     ListingKind kind, SaleTerms? sale, RentTerms? rent)
        : base(id)
    {
        Title = title; Description = description;
        PropertyTypeId = typeId; Location = location;
        ListingKind = kind; SaleTerms = sale; RentTerms = rent;
        Status = PropertyStatus.Draft;
    }

    //create method to validate the property creation
    public static Result<Property> Create(Guid id, string title, string description, Guid typeId, Location location, ListingKind kind, SaleTerms? sale, RentTerms? rent)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return PropertyErrors.TitleRequired;
        }

        if (title.Length < PropertyConstants.MinTitleLength)
        {
            return PropertyErrors.TitleTooShort;
        }

        if (title.Length > PropertyConstants.MaxTitleLength)
        {
            return PropertyErrors.TitleTooLong;
        }
        if (description.Length > PropertyConstants.MaxDescriptionLength)
        {
            return PropertyErrors.DescriptionTooLong;
        }

        if (typeId == Guid.Empty)
        {
            return PropertyErrors.PropertyTypeRequired;
        }

        if (location == null)
        {
            return PropertyErrors.LocationRequired;
        }

        if (ListingKind.Sale == kind && sale == null)
        {
            return PropertyErrors.SaleTermsRequired;
        }

        if (ListingKind.Rent == kind && rent == null)
        {
            return PropertyErrors.RentTermsRequired;
        }
        return new Property(id, title, description, typeId, location, kind, sale, rent);
    }

    //update method to update the property
    public Result<Updated> Update(string title, string description, Guid typeId, Location location, ListingKind kind, SaleTerms? sale, RentTerms? rent)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return PropertyErrors.TitleRequired;
        }

        if (title.Length < PropertyConstants.MinTitleLength)
        {
            return PropertyErrors.TitleTooShort;
        }

        if (title.Length > PropertyConstants.MaxTitleLength)
        {
            return PropertyErrors.TitleTooLong;
        }
        if (description.Length > PropertyConstants.MaxDescriptionLength)
        {
            return PropertyErrors.DescriptionTooLong;
        }

        if (typeId == Guid.Empty)
        {
            return PropertyErrors.PropertyTypeRequired;
        }

        if (location == null)
        {
            return PropertyErrors.LocationRequired;
        }

        if (ListingKind.Sale == kind && sale == null)
        {
            return PropertyErrors.SaleTermsRequired;
        }

        if (ListingKind.Rent == kind && rent == null)
        {
            return PropertyErrors.RentTermsRequired;
        }

        Title = title;
        Description = description;
        PropertyTypeId = typeId;
        Location = location;
        ListingKind = kind;
        SaleTerms = sale;
        RentTerms = rent;

        return Result.Updated;
    }

    public Result<Updated> AddMedia(Media media)
    {
        if (media == null)
        {
            return PropertyErrors.MediaRequired;
        }

        if (_media.Count >= PropertyConstants.MaxMediaItems)
        {
            return PropertyErrors.TooManyMediaItems;
        }

        if (media.IsPrimary && _media.Any(m => m.IsPrimary))
        {
            return PropertyErrors.PrimaryMediaRequired;
        }

        _media.Add(media);
        return Result.Updated;
    }

    public Result<Updated> AddListOfMedia(List<Media> medias)
    {
        if (medias == null || medias.Count == 0)
        {
            return PropertyErrors.MediaRequired;
        }
        _media.AddRange(medias);
        return Result.Updated;

    }

    public Result<Updated> RemoveMedia(Media media)
    {
        if (media == null)
        {
            return PropertyErrors.MediaRequired;
        }

        if (!_media.Contains(media))
        {
            return PropertyErrors.MediaRequired;
        }

        _media.Remove(media);
        return Result.Updated;
    }

    public Result<Updated> RemoveListOfMedia(List<Media> medias)
    {
        if (medias == null || medias.Count == 0)
        {
            return PropertyErrors.MediaRequired;
        }

        foreach (var media in medias)
        {
            if (!_media.Contains(media))
            {
                return PropertyErrors.MediaRequired;
            }
        }

        _media.RemoveAll(m => medias.Contains(m));
        return Result.Updated;
    }

    public Result<Updated> Publish()
    {
        if (Status == PropertyStatus.Published)
        {
            return PropertyErrors.AlreadyPublished;
        }

        if (_media.Count == 0)
        {
            return PropertyErrors.MediaRequired;
        }

        Status = PropertyStatus.Published;
        return Result.Updated;
    }

    public Result<Updated> Unpublish()
    {
        if (Status == PropertyStatus.Draft)
        {
            return PropertyErrors.AlreadyPublished;
        }

        Status = PropertyStatus.Draft;
        return Result.Updated;
    }

    public Result<Updated> UpdateStatus(PropertyStatus status)
    {
        if (Status == status)
        {
            return PropertyErrors.AlreadyPublished;
        }

        Status = status;
        return Result.Updated;
    }

    public Result<Updated> UpdateLocation(Location location)
    {
        if (location == null)
        {
            return PropertyErrors.LocationRequired;
        }

        Location = location;
        return Result.Updated;
    }

    public Result<Updated> UpdateListingKind(ListingKind kind, SaleTerms? sale, RentTerms? rent)
    {
        if (ListingKind == kind)
        {
            return PropertyErrors.AlreadyPublished;
        }

        if (ListingKind.Sale == kind && sale == null)
        {
            return PropertyErrors.SaleTermsRequired;
        }

        if (ListingKind.Rent == kind && rent == null)
        {
            return PropertyErrors.RentTermsRequired;
        }

        ListingKind = kind;
        SaleTerms = sale;
        RentTerms = rent;

        return Result.Updated;
    }

    public Result<Updated> UpdatePropertyType(Guid typeId)
    {
        if (typeId == Guid.Empty)
        {
            return PropertyErrors.PropertyTypeRequired;
        }

        PropertyTypeId = typeId;
        return Result.Updated;
    }

}
