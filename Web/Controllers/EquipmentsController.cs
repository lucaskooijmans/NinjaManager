﻿using Data;
using Data.Enum;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;

namespace Web.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly NinjaEquipmentDbContext _context;
        private EquipmentViewModel equipmentViewModel;
        private readonly Repository repository;
        public EquipmentsController(NinjaEquipmentDbContext context)
        {
            _context = context;
            repository = new Repository(context);
        }

        // GET: Equipments
        public async Task<IActionResult> Store(int ninjaId)
        {
            equipmentViewModel = new EquipmentViewModel
            {
                Ninja = await _context.Ninjas.Where(e => e.Id == ninjaId).FirstOrDefaultAsync(),
                EquipmentList = repository.GetEquipmentList()
            };

            equipmentViewModel.Ninja.NinjaEquipment = repository.GetOwnedEquipmentList(ninjaId);

            return View("Store", equipmentViewModel);
        }

        public IActionResult Index()
        {
            equipmentViewModel = new EquipmentViewModel
            {
                EquipmentList = repository.GetEquipmentList(),
            };
            return View(equipmentViewModel);
        }

        [HttpPost]
        public IActionResult Filter(EquipmentCategory? selectedCategory, int? ninjaId, string returnUrl)
        {
            var equipmentList = repository.GetEquipmentList();
            if (selectedCategory.HasValue)
            {
                equipmentList = equipmentList.Where(e => e.Category == selectedCategory.Value.ToString()).ToList();
            }
            var viewModel = new EquipmentViewModel
            {
                EquipmentList = equipmentList,
                SelectedCategory = selectedCategory
            };
            if (returnUrl == "Index")
            {
                return View("Index", viewModel);
            }
            else if (returnUrl == "Store")
            {
                viewModel.Ninja = repository.GetNinja((int)ninjaId);
                viewModel.Ninja.NinjaEquipment = repository.GetOwnedEquipmentList((int)ninjaId);
                return View("Store", viewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int equipmentId, int ninjaId)
        {
            var ninja = repository.GetNinja(ninjaId);
            ninja.NinjaEquipment = repository.GetOwnedEquipmentList(ninjaId);
            var equipment = repository.GetEquipment(equipmentId);

            var equipmentCategory = equipment.Category;
            bool hasItemInCategory = repository.NinjaHasItemInCategory(ninjaId, equipmentCategory);

            if (ninja != null && equipment != null && !hasItemInCategory)
            {
                // Cost of equipment
                int equipmentCost = equipment.ValueInGold;

                // Check if the ninja has enough gold
                if (ninja.Gold >= equipmentCost)
                {
                    ninja.Gold -= equipmentCost;

                    // Create new NinjaEquipment to save purchase
                    var ninjaEquipment = new NinjaEquipment
                    {
                        NinjaId = ninja.Id,
                        EquipmentId = equipment.Id,
                        ValueAtPurchase = equipmentCost
                    };
                    _context.NinjaEquipment.Add(ninjaEquipment);
                    await _context.SaveChangesAsync(); // Asynchrone opslaan

                }
                // Possible errors
                else ModelState.AddModelError(string.Empty, "Not enough gold to make the purchase.");
            }
            else ModelState.AddModelError(string.Empty, "Ninja already has equipment in category: " + equipment.Category);

            equipmentViewModel = new EquipmentViewModel
            {
                Ninja = ninja,
                EquipmentList = repository.GetEquipmentList()
            };
            // Return to the store
            return View("Store", equipmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int equipmentId, int ninjaId)
        {
            var ninja = repository.GetNinja(ninjaId);
            ninja.NinjaEquipment = repository.GetOwnedEquipmentList(ninjaId);
            var equipment = repository.GetEquipment(equipmentId);

            if (ninja != null && equipment != null)
            {
                // Check if the ninja owns the equipment
                var ninjaEquipment = ninja.NinjaEquipment.FirstOrDefault(ne => ne.EquipmentId == equipmentId);
                if (ninjaEquipment != null)
                {
                    // sell value, in this case this is the value at purchase
                    int sellValue = ninjaEquipment.ValueAtPurchase;
                    ninja.Gold += sellValue;

                    // Remove equipment from inventory
                    _context.NinjaEquipment.Remove(ninjaEquipment);
                    await _context.SaveChangesAsync();                  
                }
            }
            return RedirectToAction("Store", new { ninjaId }); 
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
                equipmentViewModel = new EquipmentViewModel
                {
                    EquipmentList = _context.Equipments.ToList()
                };
                return View("Index", equipmentViewModel);

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

                var category = Enum.Parse(typeof(EquipmentCategory), equipment.Category).ToString(); // parse categorynumber to stringvalue
                equipment.Category = category;
                _context.Update(equipment);
                await _context.SaveChangesAsync();

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
            var numNinjas = _context.NinjaEquipment.Count(ne => ne.EquipmentId == id);
            ViewData["NumNinjas"] = numNinjas;

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment != null)
            {
                // Find all ninjas who own this equipment
                var owningNinjas = _context.NinjaEquipment
                    .Where(ne => ne.EquipmentId == id)
                    .ToList();

                int equipmentValue = equipment.ValueInGold;

                if (owningNinjas.Any())
                {
                    foreach (var ninja in owningNinjas) //ninja == ninjaEquipment
                    {
                        ninja.Ninja = repository.GetNinja(ninja.NinjaId);
                        ninja.Ninja.Gold += ninja.ValueAtPurchase; // or equipment.ValueInGold?
                    }
                }
                // Remove equipment
                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
