using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ariochoob1.Models.EntityModels
{
    internal class GroupMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "نامگروه را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام گروه")]
        [Display(Name = "نام گروه  ")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("گروه پدر")]
        [Display(Name = " گروه پدر ")]
        public Nullable<int> ParentId { get; set; }
    }
}

namespace Ariochoob1.Models.DomainModels
{
    [MetadataType(typeof(Ariochoob1.Models.EntityModels.GroupMetaData))]
    public partial class Group
    {

    }
}
