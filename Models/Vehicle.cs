using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMXRentACar.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int NrOfSeats { get; set; }
        public string Color { get; set; }
        public int YearOfProduction { get; set; }
        public float PricePerDay { get; set; }
    }
}