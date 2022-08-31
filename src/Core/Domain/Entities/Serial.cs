using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Serial of the Brand
/// </summary>
public class Serial : BaseEntity
{
    public string? Name { get; set; }
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<Model>? Models { get; set; }
}