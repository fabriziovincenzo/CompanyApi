using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Models.Result
{
    public abstract class PersonResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressResult Address { get; set; }
    }
}