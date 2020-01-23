using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApi.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}