using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ariochoob1.Models.EntityModels
{
    internal class ProductMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "نام محصول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام محصول  ")]
        [Display(Name = "نام محصول")]
        [StringLength(50, ErrorMessage = "این فیلد باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }

        [DisplayName("گروه محصول  ")]
        [Display(Name = "گروه محصول")]
        [ScaffoldColumn(false)]
        public int GroupId { get; set; }

        [Required(ErrorMessage = " قیمت محصول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("قیمت محصول  ")]
        [Display(Name = "قیمت محصول")]
        [Range(1, int.MaxValue, ErrorMessage = "قیمت نامعتبر است")]
        public decimal Price { get; set; }

        [DisplayName("آدرس محصول  ")]
        [Display(Name = "آدرس محصول")]
        [Required(ErrorMessage = " آدرس محصول را وارد کنید", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "این فیلد باید حداکثر 100 کاراکتر باشد")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Url, ErrorMessage = "آدرس محصوب باید  Url  معتبر باشد.")]
        public string Url { get; set; }

        [DisplayName("تگ کلمات کلیدی")]
        [Display(Name = "تگ کلمات کلیدی")]
        [StringLength(300, ErrorMessage = "این فیلد باید حداکثر 300 کاراکتر باشد")]
        public string Keywords { get; set; }

        [DisplayName("تگ توضیحات")]
        [Display(Name = "تگ توضیحات")]
        [StringLength(500, ErrorMessage = "این فیلد باید حداکثر 500 کاراکتر باشد")]
        public string Description { get; set; }

        [DisplayName("برچسب‌ها")]
        [Display(Name = "برچسب‌ها")]
        [StringLength(200, ErrorMessage = "این فیلد باید حداکثر 200 کاراکتر باشد")]
        public string Tags { get; set; }

        [DisplayName("تعداد like ها")]
        [Display(Name = "تعداد like ها")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار نامعتبر است")]
        public int Like { get; set; }

        [DisplayName("تعداد Dislike ها")]
        [Display(Name = "تعداد Dislike ها")]
        [Range(0, int.MaxValue, ErrorMessage = "مقدار نامعتبر است")]
        public int Dislike { get; set; }

        [DisplayName("این محصول فعال است")]
        [Display(Name = "این محصول فعال است")]
        public bool Enable { get; set; }

        [DisplayName("تصویر محصول")]
        [Display(Name = "تصویر محصول")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.ImageUrl)]
        public string Image { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "توضیحات محصول را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("توضیحات محصول")]
        [Display(Name = "توضیحات محصول")]
        [DataType(DataType.Html, ErrorMessage = "فرمت متن نا معتبر است")]
        public string Summery { get; set; }



    }
}

namespace Ariochoob1.Models.DomainModels
{
    [MetadataType(typeof(Ariochoob1.Models.EntityModels.ProductMetaData))]
    public partial class Product
    {

    }
}
