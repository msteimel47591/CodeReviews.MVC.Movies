using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class TelevisionSeriesController : Controller
{
    private readonly TelevisionSeriesContext _context;

    public TelevisionSeriesController(TelevisionSeriesContext context)
    {
        _context = context;
    }

    // GET: TelevisionSeries
    public async Task<IActionResult> Index(string searchString)
    {
        if (_context.TelevisionSeries == null)
        {
            return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        }

        var televisionSeries = from m in _context.TelevisionSeries
                     select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            televisionSeries = televisionSeries.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
        }

        return View(await televisionSeries.ToListAsync());
    }

    // GET: TelevisionSeries/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var televisionSeries = await _context.TelevisionSeries
            .FirstOrDefaultAsync(m => m.Id == id);
        if (televisionSeries == null)
        {
            return NotFound();
        }

        return View(televisionSeries);
    }

    // GET: TelevisionSeries/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TelevisionSeries/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] TelevisionSeries televisionSeries)
    {
        if (ModelState.IsValid)
        {
            _context.Add(televisionSeries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(televisionSeries);
    }

    // GET: TelevisionSeries/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var televisionSeries = await _context.TelevisionSeries.FindAsync(id);
        if (televisionSeries == null)
        {
            return NotFound();
        }
        return View(televisionSeries);
    }

    // POST: TelevisionSeries/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] TelevisionSeries televisionSeries)
    {
        if (id != televisionSeries.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(televisionSeries);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelevisionSeriesExists(televisionSeries.Id))
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
        return View(televisionSeries);
    }

    // GET: TelevisionSeries/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var televisionSeries = await _context.TelevisionSeries
            .FirstOrDefaultAsync(m => m.Id == id);
        if (televisionSeries == null)
        {
            return NotFound();
        }

        return View(televisionSeries);
    }

    // POST: TelevisionSeries/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var televisionSeries = await _context.TelevisionSeries.FindAsync(id);
        if (televisionSeries != null)
        {
            _context.TelevisionSeries.Remove(televisionSeries);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TelevisionSeriesExists(int id)
    {
        return _context.TelevisionSeries.Any(e => e.Id == id);
    }
}
