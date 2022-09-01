using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Gear type of the vehicle
/// </summary>
public class GearType : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Vehicle>? Vehicles { get; set; }
}