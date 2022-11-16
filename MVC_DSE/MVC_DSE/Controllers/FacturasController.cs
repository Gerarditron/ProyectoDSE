using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_DSE.Models;

namespace MVC_DSE.Controllers
{
    public class FacturasController : Controller
    {
        private readonly FacturacionDbContext _context;

        public FacturasController(FacturacionDbContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var facturacionDbContext = _context.Facturas.Include(f => f.IdBitacoraNavigation).Include(f => f.IdTipoProcesoNavigation);
            return View(await facturacionDbContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdBitacoraNavigation)
                .Include(f => f.IdTipoProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IdBitacora"] = new SelectList(_context.Bitacoras, "IdBitacora", "IdBitacora");
            ViewData["IdTipoProceso"] = new SelectList(_context.TipoProcesos, "IdTipoProceso", "IdTipoProceso");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,IdTipoProceso,IdBitacora,Concepto,FechaFactura,Valor")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBitacora"] = new SelectList(_context.Bitacoras, "IdBitacora", "IdBitacora", factura.IdBitacora);
            ViewData["IdTipoProceso"] = new SelectList(_context.TipoProcesos, "IdTipoProceso", "IdTipoProceso", factura.IdTipoProceso);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IdBitacora"] = new SelectList(_context.Bitacoras, "IdBitacora", "IdBitacora", factura.IdBitacora);
            ViewData["IdTipoProceso"] = new SelectList(_context.TipoProcesos, "IdTipoProceso", "IdTipoProceso", factura.IdTipoProceso);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,IdTipoProceso,IdBitacora,Concepto,FechaFactura,Valor")] Factura factura)
        {
            if (id != factura.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IdFactura))
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
            ViewData["IdBitacora"] = new SelectList(_context.Bitacoras, "IdBitacora", "IdBitacora", factura.IdBitacora);
            ViewData["IdTipoProceso"] = new SelectList(_context.TipoProcesos, "IdTipoProceso", "IdTipoProceso", factura.IdTipoProceso);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.IdBitacoraNavigation)
                .Include(f => f.IdTipoProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'FacturacionDbContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
          return _context.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
