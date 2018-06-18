using Prototype.Domain.Repository;
using System.Web.Mvc;

namespace Prototype.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            var repo = new PayloadTestRepository();
            var path = Server.MapPath("/");
            var vm = repo.GetProductViewModel(path, "foobar");
            return View(vm);
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