using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FAQAPI.Data;
using FAQAPI.Models;
using System.Net.Http;

namespace FAQAPI.Controllers
{
    public class HomeController : Controller
    {
        private FAQAPIContext db = new FAQAPIContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.im_Faq.ToList<im_Faq>());
        }
    

        public ActionResult Details()
        {
            var id = (string)Url.RequestContext.RouteData.Values["id"];
            int CurrentID = Convert.ToInt32(id);
            im_Faq im_Faq = db.im_Faq.SingleOrDefault(i => i.Id == CurrentID);
            return View(im_Faq);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}
