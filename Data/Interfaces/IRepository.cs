using Data.Models;

namespace Data.Interfaces;

public interface IRepository
{
    public Ninja GetNinja(int ninjaId);
    public Equipment GetEquipment(int equipmentId);
    public List<Equipment> GetEquipmentList();
    public List<NinjaEquipment> GetOwnedEquipmentList(int ninjaId);
    public bool NinjaHasItemInCategory(int ninjaId, string equipmentCategory);
}

