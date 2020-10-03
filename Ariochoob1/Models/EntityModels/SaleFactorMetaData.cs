using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ariochoob1.Models.EntityModels
{
    internal class SaleFactorMetaData
    {
        [DisplayName("خریدار")]
        [Display(Name = "خریدار ")]
        [ScaffoldColumn(false)]
        public int SaleFactorId { get; set; }

        [Required(ErrorMessage = "تاریخ خرید را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ خرید")]
        [Display(Name = "تاریخ خرید ")]
        public System.DateTime BuyDate { get; set; }

        [DisplayName("کد رهگیری")]
        [Display(Name = "کد رهگیری")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string FillowCode { get; set; }

        [DisplayName("توضیحات خرید")]
        [Display(Name = "توضیحات خرید")]
        [StringLength(400, ErrorMessage = "این فیلد باید حداکثر 400 کاراکتر باشد")]
        public string Description { get; set; }

        [DisplayName("خریدار")]
        [Display(Name = "خریدار")]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [DisplayName("قیمت")]
        [Display(Name = "قیمت")]
        [ScaffoldColumn(false)]
        public decimal Price { get; set; }
    }
}

namespace Ariochoob1.Models.DomainModels
{
    [MetadataType(typeof(Ariochoob1.Models.EntityModels.SaleFactorMetaData))]
    public partial class SaleFactor
    {

    }
}
