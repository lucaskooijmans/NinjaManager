using Data.Models;

namespace Data.Interfaces;

public interface IRepository
{
    public List<Equipment> GetEquipmentList();
    public List<NinjaEquipment> GetOwnedEquipmentList(int ninjaId);


}

