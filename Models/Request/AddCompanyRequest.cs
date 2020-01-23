using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Request
{
    public class AddCompanyRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Tva { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Locality { get; set; }
    }
}