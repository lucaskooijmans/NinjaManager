namespace Ninja.Data.Models
{
    public class Inventory
    {
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public User User { get; set; }
        public Equipment Equipment { get; set; }
    }
}