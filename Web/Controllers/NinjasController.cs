using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers;
public class NinjasController : Controller
{
    private readonly NinjaEquipmentDbContext _context;

    public NinjasController(NinjaEquipmentDbContext context)
    {
        _context = context;
    }

    // GET: Ninjas
    public async Task<IActionResult> Index()
    {
        return _context.Ninjas != null ?
                    View(await _context.Ninjas.ToListAsync()) :
                    Problem("Entity set 'NinjaEquipmentDbContext.Ninjas'  is null.");
    }

    // GET: Ninjas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        var ninja = await _context.Ninjas.Include(n => n.NinjaEquipment).ThenInclude(ne => ne.Equipment).FirstOrDefaultAsync(n => n.Id == id);

        if (ninja == null)
        {
            return NotFound();
        }

        return View(ninja);
    }

    // GET: Ninjas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Ninjas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Gold")] Ninja ninja)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ninja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ninja);
    }

    // GET: Ninjas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Ninjas == null)
        {
            return NotFound();
        }

        var ninja = await _context.Ninjas.FindAsync(id);
        if (ninja == null)
        {
            return NotFound();
        }
        return View(ninja);
    }

    // POST: Ninjas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gold")] Ninja ninja)
    {
        if (id != ninja.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ninja);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NinjaExists(ninja.Id))
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
        return View(ninja);
    }

    // GET: Ninjas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Ninjas == null)
        {
            return NotFound();
        }

        var ninja = await _context.Ninjas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ninja == null)
        {
            return NotFound();
        }

        return View(ninja);
    }

    // POST: Ninjas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Ninjas == null)
        {
            return Problem("Entity set 'NinjaEquipmentDbContext.Ninjas'  is null.");
        }
        var ninja = await _context.Ninjas.FindAsync(id);
        if (ninja != null)
        {
            _context.Ninjas.Remove(ninja);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NinjaExists(int id)
    {
        return (_context.Ninjas?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<IActionResult> ClearInventory(int id)
    {
        var ninja = await _context.Ninjas
            .Include(n => n.NinjaEquipment)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (ninja == null)
        {
            return NotFound();
        }

        // Calculate the total value of the cleared equipment and add it to the ninja's gold
        int totalValue = ninja.NinjaEquipment.Sum(ne => ne.ValueAtPurchase);
        ninja.Gold += totalValue;

        // Clear the ninja's inventory
        ninja.NinjaEquipment.Clear();

        // Update the ninja and save changes
        _context.Update(ninja);
        await _context.SaveChangesAsync();

        // Reload the Details view with the updated ninja
        return View("Details", ninja);
    }


}
