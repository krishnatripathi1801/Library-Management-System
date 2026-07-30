using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly LibraryContext _context;

        public PublicationsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Publications?type=Newspaper|Magazine&searchString=&pageNumber=
        public async Task<IActionResult> Index(string type, string? searchString, int pageNumber = 1)
        {
            if (string.IsNullOrEmpty(type)) type = "Newspaper";

            if (!Enum.TryParse(type, true, out PublicationType pubType))
                return NotFound();

            ViewData["CurrentType"] = type;
            ViewData["CurrentFilter"] = searchString;

            var items = _context.Publications.AsNoTracking().Where(p => p.Type == pubType).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(p =>
                    (p.Title != null && p.Title.Contains(searchString)) ||
                    (p.Publisher != null && p.Publisher.Contains(searchString)));
            }

            int pageSize = 5;
            int totalItems = await items.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages && totalPages > 0) pageNumber = totalPages;

            var paginatedList = await items
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewData["PageNumber"] = pageNumber;
            ViewData["TotalPages"] = totalPages;

            return View(paginatedList);
        }

        // GET: Publications/Create?type=Newspaper
        public IActionResult Create(string type)
        {
            ViewData["CurrentType"] = type;
            return View(new Publication { Type = Enum.TryParse(type, true, out PublicationType t) ? t : PublicationType.Newspaper });
        }

        // POST: Publications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publication publication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publication);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Successfully added: {publication.Title}.";
                return RedirectToAction(nameof(Index), new { type = publication.Type.ToString() });
            }

            ViewData["CurrentType"] = publication.Type.ToString();
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var publication = await _context.Publications.FindAsync(id);
            if (publication == null) return NotFound();

            ViewData["CurrentType"] = publication.Type.ToString();
            return View(publication);
        }

        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Publication publication)
        {
            if (id != publication.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publication);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Successfully updated: {publication.Title}.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Publications.Any(p => p.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index), new { type = publication.Type.ToString() });
            }

            ViewData["CurrentType"] = publication.Type.ToString();
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var publication = await _context.Publications.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null) return NotFound();

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            string type = publication?.Type.ToString() ?? "Newspaper";

            if (publication != null)
            {
                _context.Publications.Remove(publication);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Publication deleted successfully.";
            }

            return RedirectToAction(nameof(Index), new { type });
        }
    }
}
