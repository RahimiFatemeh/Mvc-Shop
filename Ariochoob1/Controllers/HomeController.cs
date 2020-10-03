using Ariochoob1.Models.DomainModels;
using Ariochoob1.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //this is for login

namespace Ariochoob1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            GroupRepository blGroup = new GroupRepository();
            ProductRepository blProduct = new ProductRepository();
            var model = new Ariochoob1.ViewModels.Home.HomeIndexViewModel();
            model.Groups = blGroup.Select();
            model.Products = blProduct.Select();
            model.BestSellerProducts = blProduct.Select().OrderBy(p => p.Orders.Count).Take(6) ;

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            UserRepository blUser = new UserRepository();

            if (ModelState.IsValid)
            {
                if (blUser.Add(user))
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username , string password , bool rememberme)
        {
            var blUser = new UserRepository();
            if (blUser.Exist(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, rememberme);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "نام کاربری یا پسورد اشتباه است";
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");     
        }

        public ActionResult AddToCart(int Id , byte Count)
        {
            try
            {
                if (Request.Cookies.AllKeys.Contains("Cart_" + Id.ToString()))
                { // for other time , Edit cookie
                    var cookie = new HttpCookie("Cart_" + Id.ToString(), (Convert.ToByte(Request.Cookies["Cart_" + Id.ToString()].Value) + 1).ToString());
                    // یه دونه به تعداد کوکی ها اضافه کن
                    cookie.Expires = DateTime.Now.AddMonths(1); //after one month delete automatic
                    //cookie.HttpOnly = true; //user cant send javascrip , ... 
                    Response.Cookies.Set(cookie);

                }
                else
                { //for first time add new cooki
                    var cookie = new HttpCookie("Cart_" + Id.ToString(), Count.ToString());
                    cookie.Expires = DateTime.Now.AddMonths(1); //after one month delete automatic
                    //cookie.HttpOnly = true; //user cant send javascrip , ... 
                    Response.Cookies.Add(cookie);
                }
                List<HttpCookie> lst = new List<HttpCookie>();
                for (int i = Request.Cookies.Count - 1; i >= 0; i--)
                {
                    if (lst.Where(p => p.Name == Request.Cookies[i].Name).Any() == false)
                        lst.Add(Request.Cookies[i]);
                }
                int CartCount = lst.Where(p => p.Name.StartsWith("Cart_")).Count();
                return Json(new JsonData() { Success = true ,
                                         Script = JavaScript("alert('کالا به سبد خرید اضافه شد');").Script,
                                         Html = "لیست خرید" +  "(" + CartCount.ToString() + ")"  });

            }
            catch (Exception)
            {
                return Json(new JsonData()
                {
                    Success = false,
                    Script = JavaScript("alert('کالا به سبد خرید اضافه نشد');").Script,
                    Html = ""
                });
            } 
        }

        public ActionResult RemoveCart(int Id) 
        {
            try
            {
                if (Request.Cookies.AllKeys.Contains("Cart_" + Id.ToString()))  // if contain cookie
                {
                    Response.Cookies["Cart_" + Id.ToString()].Expires = DateTime.Now.AddDays(-1);
                    Request.Cookies.Remove("Cart_" + Id.ToString()); //delete from server
                    return Json(new JsonData()
                    {
                        Success = true,
                        Script = JavaScript("alert('کالا از سبد خرید حذف شد');").Script,
                        Html = "لیست خرید (" + CartCount() + ")"
                    });
                }
                else
                {
                    return Json(new JsonData()
                    {
                        Success = true,
                        Script = JavaScript("alert('این کالا در سبد خرید شما وجود ندارد');").Script,
                        Html = "لیست خرید (" + CartCount() + ")"
                    });

                }
            }
            catch (Exception)
            {
                return Json(new JsonData()
                {
                    Success = false,
                    Script = JavaScript("alert('کالا از سبد خرید شما  حذف نشد');").Script,
                    Html = ""
                });
            } 
        }

        public string CartCount()
        {
            List<HttpCookie> lst = new List<HttpCookie>();
            for (int i = Request.Cookies.Count - 1; i >= 0; i--)
            {
                if (lst.Where(p => p.Name == Request.Cookies[i].Name).Any() == false)
                    lst.Add(Request.Cookies[i]);
            }
            int CartCount = lst.Where(p => p.Name.StartsWith("Cart_")).Count();
            return CartCount.ToString();
        }

        public ActionResult Basket()
        {
            ProductRepository blProduct = new ProductRepository();
            List<BasketViewModel> listBasket = new List<BasketViewModel>();
            List<HttpCookie> lst = new List<HttpCookie>(); //list of cookie 
            for (int i = Request.Cookies.Count - 1; i >= 0; i--)
            {
                if (lst.Where(p => p.Name == Request.Cookies[i].Name).Any() == false)  //delete repetetive cooki
                    lst.Add(Request.Cookies[i]); // add cooki to list
            }
            foreach (var item in lst.Where(p => p.Name.StartsWith("Cart_")))
            {
                listBasket.Add(new BasketViewModel { Product = blProduct.Find(Convert.ToInt32(item.Name.Substring(5))), Count = Convert.ToInt32(item.Value) });
            }

            decimal price = 0;
            foreach (var item in listBasket)
            {
                price += (item.Product.Price * item.Count);

            }
            ViewBag.pice = price;
            return View(listBasket);

        }

        [HttpGet]
        public ActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buy(SaleFactor salefactor)
        {
            OrderRepository blOrder = new OrderRepository();
            SaleFactorRepository blFactor = new SaleFactorRepository();
            ProductRepository blProduct = new ProductRepository();
            List<BasketViewModel> listBasket = new List<BasketViewModel>();
            List<HttpCookie> lst = new List<HttpCookie>(); //list of cookie 
            for (int i = Request.Cookies.Count - 1; i >= 0; i--)
            {
                if (lst.Where(p => p.Name == Request.Cookies[i].Name).Any() == false)  //delete repetetive cooki
                    lst.Add(Request.Cookies[i]); // add cooki to list
            }
            decimal price = 0;
            foreach (var item in listBasket)
            {
                price += (item.Product.Price * item.Count);
                                
            }
            salefactor.BuyDate = DateTime.Now;
            salefactor.Price = price ;
            //salefactor.Description = "خرید در تاریخ " +‌ DateTime.Now.ToString() + "یه مبلغ" +‌ salefactor.Price.ToString() + "انجام شد";
            salefactor.Description = "ok";
            salefactor.UserId = Convert.ToInt32(Session["LoginUserId"]);

            if (blFactor.Add(salefactor))
            {
                int FactorId  = blFactor.GetLastIdentity();
                foreach (var item in listBasket)
                {
                    blOrder.Add(new Order() { OrderId = FactorId, ProductId = item.Product.ProductId, Qty = Convert.ToByte(item.Count) });    
                }
            }
            else
            {
                ViewBag.Message = "اطلاعات شما ثبت نشد";
            }

 
            return View();
        }

        public class JsonData
        {
            public string Script { get; set; }

            public string Html { get; set; }

            public bool Success { get; set; }
        }
    }
}
