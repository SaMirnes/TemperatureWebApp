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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTemperatureSensorContext _context;

        public IndexModel(RazorPagesTemperatureSensorContext context)
        {
            _context = context;
        }

        public IList<TemperatureSensor> TemperatureSensor { get;set; }

        public async Task OnGetAsync()
        {
            TemperatureSensor = await _context.TemperatureSensor.ToListAsync();
        }
    }
}
