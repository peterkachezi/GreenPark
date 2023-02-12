
namespace ParkingSystem.DAL.Models
{
    public partial class ParkingSlot
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
