using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Main category of the vehicle
/// </summary>
public class VehicleCategory : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Brand>? Brands { get; set; }
}