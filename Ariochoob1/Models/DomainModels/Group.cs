//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ariochoob1.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        public Group()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int GroupId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
