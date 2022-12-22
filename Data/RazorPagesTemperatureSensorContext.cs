using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemperatureWebApp.Models;

    public class RazorPagesTemperatureSensorContext : DbContext
    {
        public RazorPagesTemperatureSensorContext (DbContextOptions<RazorPagesTemperatureSensorContext> options)
            : base(options)
        {
        }

        public DbSet<TemperatureWebApp.Models.TemperatureSensor> TemperatureSensor { get; set; }
    }
