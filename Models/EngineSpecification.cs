using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class EngineSpecification
    {
        public EngineSpecification()
        {
            Engines = new HashSet<Engine>();
        }

        public int Id { get; set; }

        [Display(Name = "Наименование двигателя")]
        public string Name { get; set; }

        [Display(Name = "Объем двигателя")]
        public float Volume { get; set; }

        [Display(Name = "Количество цилиндров")]
        public int CylindersCount { get; set; }

        [Display(Name = "Тип топлива")]
        public string FuelType { get; set; }

        [Display(Name = "Мощность")]
        public float Power { get; set; }

        [Display(Name = "Впрыск топлива")]
        public int FuelInjectionId { get; set; }

        [Display(Name = "Выбросы СО2")]
        public float CO2Blowout { get; set; }

        [Display(Name = "Крутящий момент")]
        public int Torque { get; set; }

        public virtual FuelInjection FuelInjection { get; set; }

        public virtual ICollection<Engine> Engines { get; set; }
    }
}
