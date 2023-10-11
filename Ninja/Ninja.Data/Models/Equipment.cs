using Ninja.Data.Models;

public class Equipment
{
    public int EquipmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PriceInGold { get; set; }

    public List<Inventory> Inventories { get; set; }
    public List<PurchaseHistory> PurchaseHistories { get; set; }
}