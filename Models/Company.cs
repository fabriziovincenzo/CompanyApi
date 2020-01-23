using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Tva { get; set; }

        [Required]
        public virtual Address Headquarter { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}