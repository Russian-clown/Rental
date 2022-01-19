using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class CarBody
    {
        public int TruckId { get; set; }

        [Display(Name = "Номер рамы")]
        public string CarBodyNum { get; set; }

        [Display(Name = "Длина")]
        public float Lenght { get; set; }

        [Display(Name = "Ширина")]
        public float Width { get; set; }

        [Display(Name = "Высота")]
        public float Height { get; set; }

        [Display(Name = "База")]
        public string Base { get; set; }

        [Display(Name = "Количество мест")]
        public int SeatsCount { get; set; }


        public virtual Truck Truck { get; set; }
    }
}
