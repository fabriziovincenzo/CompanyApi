using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyApi.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Locality { get; set; }

        public virtual Person Person { get; set; }
        public virtual Company CompanyHeadquarter { get; set; }
    }
}