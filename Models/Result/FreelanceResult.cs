using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Result
{
    public class FreelanceResult : PersonResult
    {
        public string Tva { get; set; }
    }
}