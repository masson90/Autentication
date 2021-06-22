using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autentication.Data;
using Autentication.Models;

namespace Autentication.Controllers
{
    public class AluguelCarroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AluguelCarroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AluguelCarroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AluguelCarros.ToListAsync());
        }

        // GET: AluguelCarroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguelCarro = await _context.AluguelCarros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aluguelCarro == null)
            {
                return NotFound();
            }

            return View(aluguelCarro);
        }

        // GET: AluguelCarroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AluguelCarroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomedoCarro,Valor")] AluguelCarro aluguelCarro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguelCarro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluguelCarro);
        }

        // GET: AluguelCarroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguelCarro = await _context.AluguelCarros.FindAsync(id);
            if (aluguelCarro == null)
            {
                return NotFound();
            }
            return View(aluguelCarro);
        }

        // POST: AluguelCarroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NomedoCarro,Valor")] AluguelCarro aluguelCarro)
        {
            if (id != aluguelCarro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguelCarro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelCarroExists(aluguelCarro.ID))
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
            return View(aluguelCarro);
        }

        // GET: AluguelCarroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguelCarro = await _context.AluguelCarros
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aluguelCarro == null)
            {
                return NotFound();
            }

            return View(aluguelCarro);
        }

        // POST: AluguelCarroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguelCarro = await _context.AluguelCarros.FindAsync(id);
            _context.AluguelCarros.Remove(aluguelCarro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguelCarroExists(int id)
        {
            return _context.AluguelCarros.Any(e => e.ID == id);
        }
    }
}
