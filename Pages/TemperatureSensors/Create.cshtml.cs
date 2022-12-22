using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TemperatureWebApp.Models;

namespace TemperatureWebApp.Pages_TemperatureSensors
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesTemperatureSensorContext _context;

        public CreateModel(RazorPagesTemperatureSensorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TemperatureSensor TemperatureSensor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TemperatureSensor.Add(TemperatureSensor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
