using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Brand of the vehicle
/// </summary>
public class Brand : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<VehicleCategory>? VehicleCategories { get; set; }
    public ICollection<Serial>? Serials { get; set; }
}