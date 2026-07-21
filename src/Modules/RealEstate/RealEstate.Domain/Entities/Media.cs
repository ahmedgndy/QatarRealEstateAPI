using System.Data.Common;
using System.Drawing;

namespace RealEstate.Entities.Domain;

public class Media
{
    public string Url { get; set; }
    public string MediaType { get; set; }
    public Size size;

    public int order;
    public DateTime UploadDate;


}