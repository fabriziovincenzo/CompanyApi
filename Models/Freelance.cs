using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApi.Models
{
    public class Freelance : Person
    {
        [Required]
        public string Tva { get; set; }
    }
}