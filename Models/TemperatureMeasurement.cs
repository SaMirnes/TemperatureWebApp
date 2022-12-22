

using System;

namespace TemperatureWebApp.Models
{
    public class TemperatureMeasurement
    {
        public int ID { get; set; }
        public float Temperature { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfMeasurement { get; set; }
    }
}
