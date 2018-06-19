using Newtonsoft.Json;
using Prototype.Domain.Webhook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prototype.Domain.Repository {

    public class PayloadTestRepository {

        public DealerMessage GetTestPayload(string overridenPath) {
            string file = string.Empty;
            if (String.IsNullOrWhiteSpace(overridenPath)) {
                var path = Directory.GetCurrentDirectory();
                file = Path.Combine(path, "data/payload2.json");
            }
            else {
                file = Path.Combine(overridenPath, @"bin\data\payload2.json");
            }
            return JsonConvert.DeserializeObject<DealerMessage>(File.ReadAllText(file));
        }

        public InventoryItemViewModel GetProductViewModel(string path, string id) {
            var message = GetTestPayload(path);
            var product = message.Product;
            var vm = new InventoryItemViewModel {
                ProductDetailsModel = MapProduct(product)               
            };
            vm.CurrentProductDetailsModel = new ProductDetailsModel();
            var displayName = GetIdentifierValue(product, "Display Name");

            vm.NavigationItems = new List<NavigationItem> {
                new NavigationItem {
                    Id = vm.ProductDetailsModel.Id,
                    DisplayName = vm.ProductDetailsModel.DisplayName
                }
            };
            return vm;
        }

        public ProductDetailsModel MapProduct(Product product) {
            var pdm = new ProductDetailsModel {
                Id = Guid.NewGuid().ToString(),
                ProductType = product.ProductType,
                Condition = product.Condition,
                Designation = product.Designation,
                DisplayName = GetIdentifierValue(product, "Display Name"),
                Status = product.Status,                
                ManufacturerCode = product.Manufacturer.Code,
                ManufacturerMake = product.Manufacturer.Make,
                ModelCode = product.Model.Code,
                SubModelName = product.Model.Models.Count > 0 ? product.Model.Models[0].Name : "",
                ModelName = product.Model.Name,
                ModelYear = GetYear(product),
                StockNumber = GetIdentifierValue(product, "Stock Number")
            };

            pdm.NavigationItems = new List<NavigationItem> {
                new NavigationItem {
                    Id = pdm.Id,
                    DisplayName = pdm.DisplayName
                }
            };
            
            if (product.Description.Length > 0) {
                pdm.MarketingDetails.Add(new MarketingDetailModel {
                    Category = "Product Description",
                    Name ="",
                    Value = product.Description
                });               
            }

            foreach (var activity in product.Activities.OrderBy(a=>a.Name)) {
                pdm.Activities.Add(new ActivityModel {
                    Category = activity.CategoryName,
                    Name = activity.Name,
                    Value = activity.Value
                });
            }

            foreach (var color in product.Colors.OrderBy(c=>c.Name)) {
                pdm.Colors.Add(new ColorModel {
                    Category = color.Category,
                    Name = color.Name,
                    Value = color.Value
                });
            }

            foreach (var c in product.MarketingDescriptions.OrderBy(md=>md.Name)) {
                pdm.MarketingDetails.Add(new MarketingDetailModel {
                    Category = c.CategoryName,
                    Name = c.Name,
                    Value = c.Value
                });
            }

            foreach (var c in product.Prices.OrderBy(p=>p.Value)) {
                pdm.Prices.Add(new PriceModel {
                    Amount = c.Value,
                    Category = c.Category,
                    FormattedAmount = String.Format("{0:C}", c.Value.Value),
                    DisplayValue = c.DisplayValue
                });
            }

            foreach (var c in product.Specifications.OrderBy(s=>s.CategoryName).ThenBy(s=>s.Name)) {
                pdm.Specifications.Add(new SpecificationModel {
                    Amount = c.NumericValue,
                    Category = c.CategoryName,
                    Name = c.Name,
                    UnitType = c.UnitType,
                    Value = c.Value
                });
            }

            foreach(var feature in product.Features.OrderBy(f=>f.Description)) {
                pdm.Features.Add(MapFeature(feature, pdm.NavigationItems));
            }

            return pdm;
        }

        public FeatureModel MapFeature(Feature product, List<NavigationItem> navigationItems) {
            var displayName = GetIdentifierValue(product, "Display Name");
            if (String.IsNullOrWhiteSpace(displayName)) {
                displayName = product.Description;
            }
            var fm = new FeatureModel {
                Id = Guid.NewGuid().ToString(),
                ProductType = product.ProductType,
                Condition = product.Condition,
                Designation = product.Designation,
                Status = product.Status,
                DisplayName = displayName,
                ManufacturerCode = product.Manufacturer.Code,
                ManufacturerMake = product.Manufacturer.Make,
                ModelCode = product.Model.Code,
                SubModelName = product.Model.Models.Count > 0 ? product.Model.Models[0].Name : "",
                ModelName = product.Model.Name,
                ModelYear = GetYear(product),
                StockNumber = GetIdentifierValue(product, "Stock Number")
            };

            foreach(var ni in navigationItems) {
                fm.NavigationItems.Add(ni);
            }

            fm.NavigationItems.Add(new NavigationItem {
                Id = fm.Id,
                DisplayName = fm.DisplayName
            });

            foreach (var activity in product.Activities) {
                fm.Activities.Add(new ActivityModel {
                    Category = activity.CategoryName,
                    Name = activity.Name,
                    Value = activity.Value
                });
            }

            foreach (var color in product.Colors) {
                fm.Colors.Add(new ColorModel {
                    Category = color.Category,
                    Name = color.Name,
                    Value = color.Value
                });
            }          

            foreach (var c in product.MarketingDescriptions) {
                fm.MarketingDetails.Add(new MarketingDetailModel {
                    Category = c.CategoryName,
                    Name = c.Name,
                    Value = c.Value
                });
            }

            foreach (var c in product.Prices) {
                fm.Prices.Add(new PriceModel {
                    Amount = c.Value,
                    Category = c.Category,
                    FormattedAmount = String.Format("{0:C}", c.Value.Value),
                    DisplayValue = c.DisplayValue
                });
            }

            foreach (var c in product.Specifications) {
                fm.Specifications.Add(new SpecificationModel {
                    Amount = c.NumericValue,
                    Category = c.CategoryName,
                    Name = c.Name,
                    UnitType = c.UnitType,
                    Value = c.Value
                });
            }
            foreach (var feature in product.Features.OrderBy(f=>f.Description)) {
                fm.Features.Add(MapFeature(feature, fm.NavigationItems));
            }
            return fm;
        }

        private int GetYear(Product product) {
            var yearIdentifier = product.Identifiers.SingleOrDefault(i => i.Name.ToLower() == "year");
            if (yearIdentifier != null)
                return Int32.Parse(yearIdentifier.Value);
            return 0;
        }

        private string GetIdentifierValue(Product product, string name) {
            var stockId = product.Identifiers.SingleOrDefault(i => i.Name.ToLower() == name.ToLower());
            if (stockId != null)
                return stockId.Value;
            return string.Empty;
        }
    }
}