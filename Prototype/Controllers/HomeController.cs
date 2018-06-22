using Prototype.Domain.Repository;
using Prototype.Domain.Webhook;
using System;
using System.Web.Mvc;

namespace Prototype.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            var repo = new PayloadTestRepository();
            var path = Server.MapPath("/");
            var vm = repo.GetProductViewModel(path, "foobar");
            return View(vm);
        }

        [HttpPost]
        public ActionResult GetNewFeature(ProductDetailsModel model) {
            var feature = new FeatureModel {
                Id = Guid.NewGuid().ToString(),
                DisplayName = "* New Feature",
                NavigationItems = model.NavigationItems
            };
            feature.NavigationItems.Add(
                new NavigationItem {
                    Id = feature.Id,
                    DisplayName = feature.DisplayName
                }
            );
            return Json(new { feature }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}