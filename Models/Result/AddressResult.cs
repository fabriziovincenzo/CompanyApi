using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Result
{
    public class AddressResult
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Locality { get; set; }
    }
}