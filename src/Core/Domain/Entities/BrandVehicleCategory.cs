using Domain.Entities.Common;

namespace Domain.Entities
{
    public class BrandVehicleCategory : BaseEntity
    {
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int VehicleCategoryId { get; set; }
        public VehicleCategory? VehicleCategory { get; set; }
    }
}
