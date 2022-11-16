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
    public class BitacorasController : Controller
    {
        private readonly FacturacionDbContext _context;

        public BitacorasController(FacturacionDbContext context)
        {
            _context = context;
        }

        // GET: Bitacoras
        public async Task<IActionResult> Index()
        {
            var facturacionDbContext = _context.Bitacoras.Include(b => b.IdClienteNavigation);
            return View(await facturacionDbContext.ToListAsync());
        }

        // GET: Bitacoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .Include(b => b.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // GET: Bitacoras/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            return View();
        }

        // POST: Bitacoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBitacora,IdCliente,Descripcion,NumReferencia,FechaCreacion,FechaVerificada,HoraVerificada,MontoTotal,Completada")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bitacora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", bitacora.IdCliente);
            return View(bitacora);
        }

        // GET: Bitacoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", bitacora.IdCliente);
            return View(bitacora);
        }

        // POST: Bitacoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBitacora,IdCliente,Descripcion,NumReferencia,FechaCreacion,FechaVerificada,HoraVerificada,MontoTotal,Completada")] Bitacora bitacora)
        {
            if (id != bitacora.IdBitacora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bitacora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BitacoraExists(bitacora.IdBitacora))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", bitacora.IdCliente);
            return View(bitacora);
        }

        // GET: Bitacoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bitacoras == null)
            {
                return NotFound();
            }

            var bitacora = await _context.Bitacoras
                .Include(b => b.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdBitacora == id);
            if (bitacora == null)
            {
                return NotFound();
            }

            return View(bitacora);
        }

        // POST: Bitacoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bitacoras == null)
            {
                return Problem("Entity set 'FacturacionDbContext.Bitacoras'  is null.");
            }
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora != null)
            {
                _context.Bitacoras.Remove(bitacora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BitacoraExists(int id)
        {
          return _context.Bitacoras.Any(e => e.IdBitacora == id);
        }
    }
}
