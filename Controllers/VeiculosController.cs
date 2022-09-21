using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using atvCarros0609;
using atvCarros0609.Models;

namespace atvCarros0609.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly Contexto _context;

        public VeiculosController(Contexto context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
              return _context.veiculos != null ? 
                          View(await _context.veiculos.ToListAsync()) :
                          Problem("Entity set 'Contexto.veiculos'  is null.");
        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.veiculos
                .FirstOrDefaultAsync(m => m.veiculosId == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("veiculosId,proprietario,telefone,placa,corVe,modeloVe")] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculos);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.veiculos.FindAsync(id);
            if (veiculos == null)
            {
                return NotFound();
            }
            return View(veiculos);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("veiculosId,proprietario,telefone,placa,corVe,modeloVe")] Veiculos veiculos)
        {
            if (id != veiculos.veiculosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculosExists(veiculos.veiculosId))
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
            return View(veiculos);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.veiculos == null)
            {
                return NotFound();
            }

            var veiculos = await _context.veiculos
                .FirstOrDefaultAsync(m => m.veiculosId == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.veiculos == null)
            {
                return Problem("Entity set 'Contexto.veiculos'  is null.");
            }
            var veiculos = await _context.veiculos.FindAsync(id);
            if (veiculos != null)
            {
                _context.veiculos.Remove(veiculos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculosExists(int id)
        {
          return (_context.veiculos?.Any(e => e.veiculosId == id)).GetValueOrDefault();
        }
    }
}
