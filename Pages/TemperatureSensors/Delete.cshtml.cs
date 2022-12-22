using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TemperatureWebApp.Models;

namespace TemperatureWebApp.Pages_TemperatureSensors
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTemperatureSensorContext _context;

        public DeleteModel(RazorPagesTemperatureSensorContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TemperatureSensor = await _context.TemperatureSensor.FindAsync(id);

            if (TemperatureSensor != null)
            {
                _context.TemperatureSensor.Remove(TemperatureSensor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
