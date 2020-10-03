using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Ariochoob1.Models.DomainModels.Group> Groups { get; set; } // list of Group

        public IEnumerable<Ariochoob1.Models.DomainModels.Product> Products { get; set; }

        public IEnumerable<Ariochoob1.Models.DomainModels.Product> BestSellerProducts { get; set; }

        public IEnumerable<Ariochoob1.Models.DomainModels.Product> OffProducts { get; set; }

    }
}