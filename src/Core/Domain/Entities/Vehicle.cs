using Domain.Entities.Common;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public string? Description { get; set; }
    public string? Kilometer { get; set; }
    public string? Year { get; set; }
    public int FuelTypeId { get; set; }
    public FuelType? FuelType { get; set; }
    public int GearTypeId { get; set; }
    public GearType? GearType { get; set; }
    public int ModelId { get; set; }
    public Model? Model { get; set; }
}