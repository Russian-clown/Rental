using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Brand
    {
        public Brand()
        {
            Trucks = new HashSet<Truck>(); //хеш таблица для хранения элементов коллекци без дубликатов
        }

        //установить ключа в качестве идентификатора
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
