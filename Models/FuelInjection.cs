using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class FuelInjection
    {
        public FuelInjection()
        {
            Engines = new HashSet<EngineSpecification>();
        }

        public int Id { get; set; }

        [Display(Name = "Значение")]
        public string Value { get; set; }

        public virtual ICollection<EngineSpecification> Engines { get; set; }
    }
}
