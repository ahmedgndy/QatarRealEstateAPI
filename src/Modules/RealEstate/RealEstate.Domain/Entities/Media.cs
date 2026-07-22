using System.Data.Common;
using System.Drawing;


using BuildingBlocks.Common;
namespace RealEstate.Domain.Entities;

public class Media : AuditableEntity
{
    public string Url { get; set; } = string.Empty;

    public string MediaType { get; set; } = string.Empty;

    public int Width { get; set; }

    public int Height { get; set; }

    public int Order { get; set; }

    public bool IsPrimary { get; set; }

    public int PropertyId { get; set; }

    private Media() { }

    public static Media Create(string url, string mediaType, int width, int height, int order, bool isPrimary)
    {
        return new Media
        {
            Url = url,
            MediaType = mediaType,
            Width = width,
            Height = height,
            Order = order,
            IsPrimary = isPrimary
        };
    }
}