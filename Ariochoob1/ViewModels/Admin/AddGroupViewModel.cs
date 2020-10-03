using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ariochoob1.ViewModels.Admin
{
    public class AddGroupViewModel
    {
        public IEnumerable<Ariochoob1.Models.DomainModels.Group> Groups { get; set; }

        public Ariochoob1.Models.DomainModels.Group Group { get; set; }

    }
}