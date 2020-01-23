using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Request
{
    public class UpdateFreelanceRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Tva { get; set; }
    }
}