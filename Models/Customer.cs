using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FName { get; set; }

        [Display(Name = "Фамилия")]
        public string LName { get; set; }

        [Display(Name = "Отчество")]
        public string MName { get; set; }

        [Display(Name = "Номер водительского удостоверения")]
        public string LicenseNum { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
