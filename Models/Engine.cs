using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Engine
    {
        public int TruckId { get; set; }

        [Display(Name = "VIN номер")]
        public string VIN { get; set; }

        [Display(Name = "Спецификация двигателя")]
        public int EngineSpecificationsId { get; set; }

        public virtual EngineSpecification EngineSpecifications { get; set; }

        public virtual Truck Truck { get; set; }
    }
}
