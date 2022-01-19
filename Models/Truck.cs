using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Truck
    {
        public Truck()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Display(Name = "Марка")]
        public int BrandId { get; set; }

        [Display(Name = "Пробег")]
        public int Mileage { get; set; }

        [Display(Name = "Емкость бензобака")]
        public int FuelTankCapacity { get; set; }

        [Display(Name = "Цвет")]
        public int ColorId { get; set; }

        //[Display(Name = "Кузов")]
        //public int CarBodyId { get; set; }

        //[Display(Name = "Двигатель")]
        //public int EngineId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual CarBody CarBody { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Color Color { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
