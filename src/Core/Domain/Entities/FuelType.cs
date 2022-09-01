using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Fuel type of the vehicle
/// </summary>
public class FuelType : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Vehicle>? Vehicles { get; set; }
}
