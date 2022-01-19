using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class Color
    {
        public Color()
        {
            Trailers = new HashSet<Trailer>();
            Trucks = new HashSet<Truck>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
