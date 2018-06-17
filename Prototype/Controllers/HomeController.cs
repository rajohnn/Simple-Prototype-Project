using Prototype.Domain.Repository;
using System.Web.Mvc;

namespace Prototype.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            var repo = new PayloadTestRepository();
            //var vm = repo.GetProductViewModel("foobar");
            return View();
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