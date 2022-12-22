using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TemperatureWebApp.Models;

namespace TemperatureWebApp.Pages_TemperatureSensors
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTemperatureSensorContext _context;

        public EditModel(RazorPagesTemperatureSensorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TemperatureSensor TemperatureSensor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TemperatureSensor = await _context.TemperatureSensor.FirstOrDefaultAsync(m => m.ID == id);

            if (TemperatureSensor == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TemperatureSensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemperatureSensorExists(TemperatureSensor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TemperatureSensorExists(int id)
        {
            return _context.TemperatureSensor.Any(e => e.ID == id);
        }
    }
}
