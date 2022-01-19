using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Order
    {
        public Order()
        {
            Trucks = new HashSet<Truck>();
            Trailers = new HashSet<Trailer>();
        }

        public int Id { get; set; }

        [Display(Name = "Дата начала проката")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Дата окончания проката")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Клиент")]
        public int CustomerId { get; set; }
        
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
        public virtual ICollection<Trailer> Trailers { get; set; }
    }
}
