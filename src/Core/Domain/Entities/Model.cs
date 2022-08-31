using Domain.Entities.Common;

namespace Domain.Entities;

/// <summary>
/// Model of the Serial
/// </summary>
public class Model : BaseEntity
{
    public string? Name { get; set; }
    public int? SerialId { get; set; }
    public Serial? Serial { get; set; }
}