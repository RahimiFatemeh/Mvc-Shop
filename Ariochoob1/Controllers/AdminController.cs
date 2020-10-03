using Ariochoob1.Helpers.Filters;
using Ariochoob1.Models.Repositories;
using Ariochoob1.ViewModels.Admin;
using Ariochoob1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ariochoob1.Helpers.Utilities;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace Ariochoob1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult MyIndex()
        {
            return View();
        }

        GroupRepository blgroup = new GroupRepository();
        public ActionResult Groups()
        {
            var model = new AddGroupViewModel();
            model.Groups = blgroup.Select().ToList();
            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult AddGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                if (blgroup.Add(group))
                {
                    ViewData["id"] = "Group_ParentId";
                    ViewData["name"] = "Group.ParentId";
                    return Json(new JsonData()
                    {
                        Script = JavaScript("alert('ثبت شد');").Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blgroup.Select().ToList())
                    });
                }
                else
                {
                    return Json(new JsonData
                    {
                        Script = JavaScript("alert('ثبت نشد');").Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {

                return Json(new JsonData
                {
                    Script = JavaScript("alert('مقادیر ورودی اشتباه است');").Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteGroup(int id)
        {
            if (blgroup.Delete(id))
            {
                ViewData["id"] = "Group_ParentId";
                ViewData["name"] = "Group.ParentId";
                return Json(new JsonData()
                {
                    Script = JavaScript("alert('حذف شد');").Script,
                    Success = true,
                    Html = this.RenderPartialToString("_GroupList", blgroup.Select().ToList())
                });
            }
            else
            {
                return Json(new JsonData
                {
                    Script = JavaScript("alert('حذف نشد');").Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult EditGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                if (blgroup.Update(group))
                {
                    ViewData["id"] = "Group_ParentId";
                    ViewData["name"] = "Group.ParentId";
                    //موفق
                    return Json(new JsonData()
                    {
                        Script = JavaScript("alert('.ویرایش شد');").Script,
                        Success = true,
                        Html = this.RenderPartialToString("_GroupList", blgroup.Select().ToList())
                    });
                }
                else
                {
                    //نا موفق
                    return Json(new JsonData
                    {
                        Script = JavaScript("alert('ویرایش نشد');").Script,
                        Success = false,
                        Html = ""
                    });
                }
            }
            else
            {
                //خطا مقداری
                return Json(new JsonData
                {
                    Script = JavaScript("alert('مقادیر ورودی اشتباه است');").Script,
                    Success = false,
                    Html = ""
                });
            }
        }

        public class JsonData
        {
            public string Script { get; set; }

            public string Html { get; set; }

            public bool Success { get; set; }
        }


        ProductRepository blproduct = new ProductRepository();

        [HttpGet]
        public ActionResult AddProduct()
        {
            var model = new AddProductViewModel();
            model.Groups = blgroup.Select();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product product, HttpPostedFileBase UploadImage)
        {
            if (UploadImage.ContentLength > 0)
            {
                UploadImage.SaveAs(HttpContext.Server.MapPath("~/Files/")
                                                  + UploadImage.FileName);
                product.Image = UploadImage.FileName;
            }
            if (ModelState.IsValid)
            {

                if (blproduct.Add(product))
                {

                    return JavaScript("alert('اضافه شد');");
                }
                else
                {

                    return JavaScript("alert('اضافه نشد');");
                }
            }
            else
            {
                return JavaScript("alert('مقادیر ورودی اشتباه است');");
            }
        }

        [HttpGet]
        public ActionResult Products()
        {
            return View(blproduct.Select());
        }


        public ActionResult SerachProducts(string txtSearch)
        {
            ViewBag.txtSearch = txtSearch;
            var model = blproduct.Where(p => p.Name.Contains(txtSearch)).ToList();

            return View("Products", model);
        }


        public ActionResult DeleteProduct(int id)
        {
            blproduct.Delete(id);
            return View("Products", blproduct.Select());
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var model = new AddProductViewModel();
            model.Groups = blgroup.Select();
            model.Product = blproduct.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProduct(Product product, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {

                if (blproduct.Add(product))
                {

                    return JavaScript("alert('اضافه شد');");
                }
                else
                {

                    return JavaScript("alert('اضافه نشد');");
                }
            }
            else
            {
                return JavaScript("alert('مقادیر ورودی اشتباه است');");
            }
        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Campany campany)
        {
            CampanyRepository blCompany = new CampanyRepository();
            if (ModelState.IsValid)
            {
                if (blCompany.Add(campany))
                {
                    return JavaScript("alert('با موفقیت ثبت شد')");
                }
                else
                {
                    return JavaScript("alert('ثبت نشد')");
                }
            }
            else
            {
                return JavaScript("alert('مقادیر ورودی اشتباه است')");
            }
        }

        public ActionResult GetUserInfo_withsp()
        {
            AriochoobDBEntities1 db = new AriochoobDBEntities1();
            return View(db.GetUserInf());
        }
        public ActionResult GetUserInfo_withView()
        {
            AriochoobDBEntities1 db = new AriochoobDBEntities1();
            return View(db.GetUserWithViews);
        }


        public ActionResult myuser()
        {
            using (AriochoobDBEntities1 dc = new AriochoobDBEntities1())
            {
                var v = dc.Users.ToList();
                return View(v);
            }
        }

        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "Report1.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<User> cm = new List<User>();
            using (AriochoobDBEntities1 dc = new AriochoobDBEntities1())
            {
                cm = dc.Users.ToList();
            }
            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =

    "<DeviceInfo>" +
    "  <OutputFormat>" + id + "</OutputFormat>" +
    "  <PageWidth>8.5in</PageWidth>" +
    "  <PageHeight>11in</PageHeight>" +
    "  <MarginTop>0.5in</MarginTop>" +
    "  <MarginLeft>1in</MarginLeft>" +
    "  <MarginRight>1in</MarginRight>" +
    "  <MarginBottom>0.5in</MarginBottom>" +
    "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }
    }
}
