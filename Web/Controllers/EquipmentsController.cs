using Data;
using Data.Enum;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;

namespace Web.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly NinjaEquipmentDbContext _context;
        private EquipmentViewModel equipmentViewModel;
        public EquipmentsController(NinjaEquipmentDbContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Store(int ninjaId)
        {
            equipmentViewModel = new EquipmentViewModel
            {
                Ninja = _context.Ninjas.Where(e => e.Id == ninjaId).FirstOrDefault(),

                EquipmentList = await _context.Equipments.ToListAsync()
            };
            return View(equipmentViewModel);
        }
        public async Task<IActionResult> Index()
        {
            equipmentViewModel = new EquipmentViewModel
            {
                EquipmentList = await _context.Equipments.ToListAsync()
            };
            return View(equipmentViewModel);
        }

        [HttpPost]
        public IActionResult Index(EquipmentCategory? selectedCategory)
        {
            var equipmentList = _context.Equipments.ToList();


            if (selectedCategory.HasValue)
            {
                equipmentList = equipmentList.Where(e => e.Category == selectedCategory.Value.ToString()).ToList();
            }

            var viewModel = new EquipmentViewModel
            {
                EquipmentList = equipmentList,
                SelectedCategory = selectedCategory
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Buy(int equipmentId, int ninjaId)
        {
            var ninja = _context.Ninjas.Where(e => e.Id == ninjaId).First();
            var equipment = _context.Equipments.Where(e => e.Id == equipmentId).First();
            if (ninja != null && equipment != null)
            {
                // Calculate the cost of the equipment
                int equipmentCost = equipment.ValueInGold;

                // Check if the ninja has enough gold to make the purchase
                if (ninja.Gold >= equipmentCost)
                {
                    // Deduct the cost from the ninja's gold
                    ninja.Gold -= equipmentCost;

                    // Create a new NinjaEquipment entry to represent the purchase
                    var ninjaEquipment = new NinjaEquipment
                    {
                        NinjaId = ninja.Id,
                        EquipmentId = equipment.Id,
                        ValueAtPurchase = equipmentCost
                    };

                    // Add the NinjaEquipment entry to the database
                    _context.NinjaEquipment.Add(ninjaEquipment);

                    // Save changes to the database
                    _context.SaveChanges();
                    
                }
            }
            return RedirectToAction("Index", "Home");
        }
        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipments == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ValueInGold,Category,Strength,Intelligence,Agility")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                var category = Enum.Parse(typeof(EquipmentCategory), equipment.Category).ToString(); // parse categorynumber to stringvalue
                equipment.Category = category;
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                equipmentViewModel = new EquipmentViewModel();
                equipmentViewModel.EquipmentList = _context.Equipments.ToList();
                return View("Index",equipmentViewModel);

            }
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipments == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ValueInGold,Category,Strength,Intelligence,Agility")] Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var category = Enum.Parse(typeof(EquipmentCategory), equipment.Category).ToString(); // parse categorynumber to stringvalue
                    equipment.Category = category;
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipments == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipments == null)
            {
                return Problem("Entity set 'NinjaEquipmentDbContext.Equipments'  is null.");
            }
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return (_context.Equipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
