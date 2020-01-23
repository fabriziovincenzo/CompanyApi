using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Result
{
    public class CompanyResult
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tva { get; set; }
        public AddressResult HeadquarterAddress { get; set; }
    }
}