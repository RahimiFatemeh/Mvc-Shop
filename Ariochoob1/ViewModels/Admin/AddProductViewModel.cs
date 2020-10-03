using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.ViewModels.Admin
{
    public class AddProductViewModel
    {
        public IEnumerable<Ariochoob1.Models.DomainModels.Group> Groups { get; set; } // list of Group

        public Ariochoob1.Models.DomainModels.Product Product { get; set; }           //product
    }
}