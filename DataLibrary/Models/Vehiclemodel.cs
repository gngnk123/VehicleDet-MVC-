﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Vehiclemodel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Odo { get; set; }
        public string Color { get; set; }
        public int Engine { get; set; }
    }
}
