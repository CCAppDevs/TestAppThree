using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAppThree.Data;
using TestAppThree.Models;

namespace TestAppThree.Controllers
{
    public class NewsItemsController : Controller
    {
        private readonly AppDbContext _context;

        public NewsItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NewsItems
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.NewsItems.Include(n => n.Customer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: NewsItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsItem = await _context.NewsItems
                .Include(n => n.Customer)
                .FirstOrDefaultAsync(m => m.NewsItemID == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        // GET: NewsItems/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
            return View();
        }

        // POST: NewsItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsItemID,Title,Body,PostedOn,ImageURL,CustomerId")] NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", newsItem.CustomerId);
            return View(newsItem);
        }

        // GET: NewsItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsItem = await _context.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", newsItem.CustomerId);
            return View(newsItem);
        }

        // POST: NewsItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsItemID,Title,Body,PostedOn,ImageURL,CustomerId")] NewsItem newsItem)
        {
            if (id != newsItem.NewsItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsItemExists(newsItem.NewsItemID))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", newsItem.CustomerId);
            return View(newsItem);
        }

        // GET: NewsItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsItem = await _context.NewsItems
                .Include(n => n.Customer)
                .FirstOrDefaultAsync(m => m.NewsItemID == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }

        // POST: NewsItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsItem = await _context.NewsItems.FindAsync(id);
            _context.NewsItems.Remove(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsItemExists(int id)
        {
            return _context.NewsItems.Any(e => e.NewsItemID == id);
        }
    }
}
