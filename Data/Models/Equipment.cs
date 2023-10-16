using Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;
public class Equipment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Range(0, int.MaxValue)]
    public int ValueInGold { get; set; }
    [Required]
    public string Category { get; set; }
    [Range(int.MinValue, int.MaxValue)]
    public int Strength { get; set; }
    [Range(int.MinValue, int.MaxValue)]
    public int Intelligence { get; set; }
    [Range(int.MinValue, int.MaxValue)]
    public int Agility { get; set; }
}
