using System.ComponentModel.DataAnnotations;

namespace Data.Models;
public class NinjaEquipment
{
    [Key]
    public int NinjaId { get; set; }
    [Key]
    public int EquipmentId { get; set; }
    [Range(0, int.MaxValue)]
    public int ValueAtPurchase { get; set; }
    public Ninja Ninja { get; set; }
    public Equipment Equipment { get; set; }
}

