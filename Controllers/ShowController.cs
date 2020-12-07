using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class ShowController : Controller
    {
        
        private readonly MainUser _context;
        
        public ShowController(MainUser context)
        {
            _context = context;
        }

        // GET: Show
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.show.Include(a => a.Cinema).Include(a => a.Customer);

            return View(await hospitalContext.ToListAsync());
        }

        // GET: Show/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.show
                .Include(a => a.Cinema)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.showId == id);

            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            //set the full name of the cinema and customer so the user can identify
            ViewData["customerId"] = new SelectList(_context.cinema, "showId", "fullname");
            ViewData["customerId"] = new SelectList(_context.customer, "customerId", "customerfullname");
            return View();
        }

        // POST: Show/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("showId,showType,showDate,showname,cinemaId,customerId")] Show show)
        {
            //put the appointment type into a validate function to check its string length
            if (show.Validate(show.showType) == false)
            {
                return View("Fail");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(show);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //set the alias of doctor ID and patient ID to the full name of the doctor or patient so the user can see who the ID belongs too
                ViewData["cinemaId"] = new SelectList(_context.cinema, "cinemaId", "fullname", show.cinemaId);
                ViewData["customerId"] = new SelectList(_context.customer, "customerId", "customerfullname", show.customerId);
                return View(show);
            }

        }

        // GET: Show/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            //set the alias of doctor ID and patient ID to the full name of the doctor or patient so the user can see who the ID belongs too
            ViewData["cinemaId"] = new SelectList(_context.cinema, "cinemaId", "fullname", show.cinemaId);
            ViewData["customerId"] = new SelectList(_context.customer, "customerId", "customerfullname", show.customerId);
            return View(show);
        }

        // POST: Show/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("showId,showType,showDate,cinemaId,customerId")] Show show)
        {
            if (id != show.showId)
            {
                return NotFound();
            }
            if (show.Validate(show.showType) == false)
            {
                return View("Fail");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(show);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AppointmentExists(show.showId))
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
                //set the alias of doctor ID and patient ID to the full name of the doctor or patient so the user can see who the ID belongs too
                ViewData["cinemaId"] = new SelectList(_context.cinema, "cinemaId", "fullname", show.cinemaId);
                ViewData["customerId"] = new SelectList(_context.customer, "customerId", "customerfullname", show.customerId);
                return View(show);
            }

        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.show
                .Include(a => a.Cinema)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(m => m.showId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.show.FindAsync(id);
            _context.show.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.show.Any(e => e.showId == id);
        }
    }
}
