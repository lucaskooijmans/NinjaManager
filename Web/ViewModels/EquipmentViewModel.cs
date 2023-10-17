using Data.Enum;
using Data.Models;

namespace Web.ViewModels;

public class EquipmentViewModel
{
    public Ninja Ninja { get; set; }
    public List<Equipment> EquipmentList { get; set; }
    public List<Equipment>? Owned { get; set; }
    public EquipmentCategory? SelectedCategory { get; set; }
}