using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElBotonRojo.Context;
using ElBotonRojo.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ElBotonRojo.Controllers
{
    public class PartidasController : Controller
    {
        private readonly ElBotonRojoDatabaseContext _context;

        public PartidasController(ElBotonRojoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Partidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partidas.ToListAsync());
        }

        // GET: Partidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // GET: Partidas/Create/Jugador1
        public IActionResult Create()
        //string? seleccionado
        {
            Juego j = new Juego
            {
                Jugadores = _context.Jugadores.ToList(),
                Partidas = _context.Partidas.ToList()
            };
            //String jugadorSelect = seleccionado;
            //            StartGame Inicio = new StartGame();
            //            Inicio.Jugador = "Player1";
            //            Inicio.Jugadores = jugadores; 

            return View(j);
        }

        // POST: Partidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Clicks,IdJugador")] Partida partida)
        {
            partida.Apodo = _context.Jugadores.ToList().Find(item => item.Id == partida.IdJugador).Apodo;
            partida.Fecha = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(partida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partida);
        }

        // GET: Partidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }
            return View(partida);
        }

        // POST: Partidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Clicks,IdJugador")] Partida partida)
        {
            if (id != partida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidaExists(partida.Id))
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
            return View(partida);
        }

        // GET: Partidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partida = await _context.Partidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partida == null)
            {
                return NotFound();
            }

            return View(partida);
        }

        // POST: Partidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partida = await _context.Partidas.FindAsync(id);
            _context.Partidas.Remove(partida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.Id == id);
        }
    }
}
