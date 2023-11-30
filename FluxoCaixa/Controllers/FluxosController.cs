using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Data;
using FluxoCaixa.Models;

namespace FluxoCaixa.Controllers
{
    public class FluxosController : Controller
    {
        private readonly FluxoCaixaDbContext _context;

        public FluxosController(FluxoCaixaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.FluxoCaixaModels != null ?
                        View(await _context.FluxoCaixaModels.ToListAsync()) :
                        Problem("Entity set 'FluxoCaixaDbContext.FluxoCaixaModels'  is null.");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FluxoCaixaModels == null)
            {
                return NotFound();
            }

            var fluxoCaixaModels = await _context.FluxoCaixaModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fluxoCaixaModels == null)
            {
                return NotFound();
            }

            return View(fluxoCaixaModels);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProduto,ValorProduto,FormaPgto")] FluxoCaixaModels fluxoCaixaModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fluxoCaixaModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fluxoCaixaModels);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FluxoCaixaModels == null)
            {
                return NotFound();
            }

            var fluxoCaixaModels = await _context.FluxoCaixaModels.FindAsync(id);
            if (fluxoCaixaModels == null)
            {
                return NotFound();
            }
            return View(fluxoCaixaModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProduto,ValorProduto,FormaPgto")] FluxoCaixaModels fluxoCaixaModels)
        {
            if (id != fluxoCaixaModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fluxoCaixaModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FluxoCaixaModelsExists(fluxoCaixaModels.Id))
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
            return View(fluxoCaixaModels);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FluxoCaixaModels == null)
            {
                return NotFound();
            }

            var fluxoCaixaModels = await _context.FluxoCaixaModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fluxoCaixaModels == null)
            {
                return NotFound();
            }

            return View(fluxoCaixaModels);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FluxoCaixaModels == null)
            {
                return Problem("Entity set 'FluxoCaixaDbContext.FluxoCaixaModels'  is null.");
            }
            var fluxoCaixaModels = await _context.FluxoCaixaModels.FindAsync(id);
            if (fluxoCaixaModels != null)
            {
                _context.FluxoCaixaModels.Remove(fluxoCaixaModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FluxoCaixaModelsExists(int id)
        {
            return (_context.FluxoCaixaModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
