using Data.Enum;
using Data.Interfaces;
using Data.Models;

namespace Data.Repository;

public class Repository : IRepository
{
    private readonly NinjaEquipmentDbContext _context;
    public Repository(NinjaEquipmentDbContext context) 
    {
        _context = context;
    }


    public List<Equipment> GetEquipmentList()
    {
        return _context.Equipments.ToList();
    }

    public List<NinjaEquipment> GetOwnedEquipmentList(int ninjaId)
    {
        return  _context.NinjaEquipment.Where(ne => ne.NinjaId == ninjaId).ToList();
    }
    public Ninja GetNinja(int ninjaId)
    {
        return _context.Ninjas.Where(e => e.Id == ninjaId).First();
    }

    public Equipment GetEquipment(int equipmentId)
    {
        return _context.Equipments.Where(e => e.Id == equipmentId).First();
    }

    public bool NinjaHasItemInCategory(int ninjaId, string equipmentCategory)
    {
        return _context.NinjaEquipment.Where(ne => ne.NinjaId == ninjaId).Any(ne => ne.Equipment.Category == equipmentCategory);
    }
}

