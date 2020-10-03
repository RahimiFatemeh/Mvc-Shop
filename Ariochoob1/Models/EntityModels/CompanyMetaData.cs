using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ariochoob1.Models.EntityModels
{
    internal class CompanyMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "نام شرکت خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام شرکت")]
        [Display(Name = "نام شرکت")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "شماره تماس خود را وارد کنید")]
        [Display(Name = "شماره تماس")]
        [DisplayName("شماره تماس")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Tel { get; set; }

        [Required(ErrorMessage = "آدرس شرکت خود را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("آدرس شرکت")]
        [Display(Name = "آدرس شرکت")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 200 کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "ایمیل")]
        [DisplayName("ایمیل")]
        [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$", ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Email { get; set; }
    }
}

namespace Ariochoob1.Models.DomainModels
{
    [MetadataType(typeof(Ariochoob1.Models.EntityModels.CompanyMetaData))]
    public partial class Campany
    { 
       
    }
}
