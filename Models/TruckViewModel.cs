using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class TruckViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Марка")]
        public int BrandId { get; set; }

        [Display(Name = "Пробег")]
        public int Mileage { get; set; }

        [Display(Name = "Емкость бензобака")]
        public int FuelTankCapacity { get; set; }

        [Display(Name = "Цвет")]
        public int ColorId { get; set; }

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

        [Display(Name = "VIN номер")]
        public string VIN { get; set; }

        [Display(Name = "Марка двигателя")]
        public int EngineSpecificationsId { get; set; }

    }
}
