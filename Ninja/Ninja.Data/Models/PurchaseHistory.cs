namespace Ninja.Data.Models
{
    public class PurchaseHistory
    {
        public int PurchaseHistoryId { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }

        public User User { get; set; }
        public Equipment Equipment { get; set; }
    }
}