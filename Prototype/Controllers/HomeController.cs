using Prototype.Domain.Repository;
using Prototype.Domain.Webhook;
using Prototype.Models;
using Prototype.Service;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult DealerCreation() {
            var vm = new DealerCreationViewModel();
            return View(vm);
        }

        public ActionResult Import() {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            var service = new ImportService();
            var vm = service.GetImportViewModel(path);
            return View(vm);
        }

        //public JsonResult Get(string query) {Okay            
        //    List<Models.Location> records = new List<Models.Location>();
            

        //    return this.Json(records, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult LazyGet(int? parentId) {
        //    List<Location> locations;
        //    List<Models.Location> records;
        //    using (ApplicationDbContext context = new ApplicationDbContext()) {
        //        locations = context.Locations.ToList();

        //        records = locations.Where(l => l.ParentID == parentId).OrderBy(l => l.OrderNumber)
        //            .Select(l => new Models.DTO.Location {
        //                id = l.ID,
        //                text = l.Name,
        //                @checked = l.Checked,
        //                population = l.Population,
        //                flagUrl = l.FlagUrl,
        //                hasChildren = locations.Any(l2 => l2.ParentID == l.ID)
        //            }).ToList();
        //    }

        //    return this.Json(records, JsonRequestBehavior.AllowGet);
        //}

        //private List<Models.Location> GetChildren(List<Location> locations, int parentId) {
        //    return locations.Where(l => l.ParentID == parentId).OrderBy(l => l.OrderNumber)
        //        .Select(l => new Models.DTO.Location {
        //            id = l.ID,
        //            text = l.Name,
        //            population = l.Population,
        //            flagUrl = l.FlagUrl,
        //            @checked = l.Checked,
        //            children = GetChildren(locations, l.ID)
        //        }).ToList();
        //}

        //[HttpPost]
        //public JsonResult SaveCheckedNodes(List<int> checkedIds) {
        //    if (checkedIds == null) {
        //        checkedIds = new List<int>();
        //    }
        //    using (ApplicationDbContext context = new ApplicationDbContext()) {
        //        var locations = context.Locations.ToList();
        //        foreach (var location in locations) {
        //            location.Checked = checkedIds.Contains(location.ID);
        //        }
        //        context.SaveChanges();
        //    }

        //    return this.Json(true);
        //}

        //[HttpPost]
        //public JsonResult ChangeNodePosition(int id, int parentId, int orderNumber) {
        //    using (ApplicationDbContext context = new ApplicationDbContext()) {
        //        var location = context.Locations.First(l => l.ID == id);

        //        var newSiblingsBelow = context.Locations.Where(l => l.ParentID == parentId && l.OrderNumber >= orderNumber);
        //        foreach (var sibling in newSiblingsBelow) {
        //            sibling.OrderNumber = sibling.OrderNumber + 1;
        //        }

        //        var oldSiblingsBelow = context.Locations.Where(l => l.ParentID == location.ParentID && l.OrderNumber > location.OrderNumber);
        //        foreach (var sibling in oldSiblingsBelow) {
        //            sibling.OrderNumber = sibling.OrderNumber - 1;
        //        }

        //        location.ParentID = parentId;
        //        location.OrderNumber = orderNumber;

        //        context.SaveChanges();
        //    }

        //    return this.Json(true);
        //}

        //public JsonResult GetCountries(string query) {
        //    List<Models.DTO.Location> records;
        //    using (ApplicationDbContext context = new ApplicationDbContext()) {
        //        records = context.Locations.Where(l => l.Parent != null && l.Parent.ParentID == null)
        //            .Select(l => new Models.DTO.Location {
        //                id = l.ID,
        //                text = l.Name,
        //                @checked = l.Checked,
        //                population = l.Population,
        //                flagUrl = l.FlagUrl
        //            }).ToList();
        //    }

        //    return this.Json(records, JsonRequestBehavior.AllowGet);
        //}
    }
}