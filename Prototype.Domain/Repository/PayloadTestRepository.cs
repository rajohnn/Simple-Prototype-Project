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
                ProductDetailsModel = MapProduct(product),
                BaseClasses = GetBaseClasses(),
                SpecificationTypes = GetSpecificationTypes().OrderBy(c=>c.Name).ToList(),
                UnitTypes = GetUnitTypes().OrderBy(c=>c.Name).ToList(),
                PriceTypes = GetPriceTypes().OrderBy(c=>c.Name).ToList(),
                ColorTypes = GetColorTypes().OrderBy(c=>c.Name).ToList(),
                ActivityTypes = GetActivityTypes().OrderBy(c=>c.Name).ToList()
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
                    Category = GetSelectItem(GetActivityTypes(), activity.CategoryName),
                    Name = activity.Name,
                    Value = activity.Value
                });
            }

            foreach (var color in product.Colors.OrderBy(c=>c.Name)) {
                string colorCategory = "Exterior";
                if (!String.IsNullOrWhiteSpace(color.Category)) {
                    colorCategory = color.Category;
                }
                pdm.Colors.Add(new ColorModel {
                    Category = GetSelectItem(GetColorTypes(), colorCategory),
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
                    Category = GetSelectItem(GetPriceTypes(), c.Category),
                    FormattedAmount = String.Format("{0:C}", c.Value.Value),
                    DisplayValue = c.DisplayValue
                });
            }

            foreach (var c in product.Specifications.OrderBy(s=>s.CategoryName).ThenBy(s=>s.Name)) {
                pdm.Specifications.Add(new SpecificationModel {
                    Amount = c.NumericValue,
                    Category = GetSelectItem(GetSpecificationTypes(), c.CategoryName),
                    Name = c.Name,
                    UnitType = GetSelectItem(GetUnitTypes(), c.UnitType),
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
                    Category = GetSelectItem(GetActivityTypes(), activity.CategoryName),
                    Name = activity.Name,
                    Value = activity.Value
                });
            }

            foreach (var color in product.Colors) {
                string colorCategory = "Exterior";
                if (!String.IsNullOrWhiteSpace(color.Category)) {
                    colorCategory = color.Category;
                }
                fm.Colors.Add(new ColorModel {
                    Category = GetSelectItem(GetColorTypes(), colorCategory),
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
                    Category = GetSelectItem(GetPriceTypes(), c.Category),
                    FormattedAmount = String.Format("{0:C}", c.Value.Value),
                    DisplayValue = c.DisplayValue
                });
            }

            foreach (var c in product.Specifications) {
                fm.Specifications.Add(new SpecificationModel {
                    Amount = c.NumericValue,
                    Category = GetSelectItem(GetSpecificationTypes(), c.CategoryName),
                    Name = c.Name,
                    UnitType = GetSelectItem(GetUnitTypes(), c.UnitType),
                    Value = c.Value
                });
            }
            foreach (var feature in product.Features.OrderBy(f=>f.Description)) {
                fm.Features.Add(MapFeature(feature, fm.NavigationItems));
            }
            return fm;
        }

        private SelectItem GetSelectItem(List<SelectItem> items, string value) {
            var item = items.SingleOrDefault(c => c.Name.ToLower() == value.ToLower());
            if (item != null)
                return item;
            else
                return new SelectItem { Id=999, Name=value };
        }

        public List<SelectItem> GetBaseClasses() {
            var list = new List<SelectItem> {
                new SelectItem {
                    Id = 1,
                    Name = "Fishing"
                },
                new SelectItem {
                    Id =2,
                    Name = "Bowrider"
                },
                new SelectItem {
                    Id = 3,
                    Name = "Deck Boat"
                },
                new SelectItem {
                    Id = 4,
                    Name = "Walkaround"
                },
                new SelectItem {
                    Id = 5,
                    Name = "Tow Boats"
                },
                new SelectItem {
                    Id = 6,
                    Name = "Cruiser"
                },
                new SelectItem {
                    Id = 7,
                    Name = "Cuddy Cabin"
                },
                new SelectItem {
                    Id = 8,
                    Name = "Dinghies"
                },
                new SelectItem {
                    Id = 9,
                    Name = "High Performance"
                },
                new SelectItem {
                    Id = 10,
                    Name = "Jet Boat"
                },
                new SelectItem {
                    Id = 11,
                    Name = "Multi-Hull Power Boats"
                },
                new SelectItem {
                    Id = 12,
                    Name = "Personal Watercraft (PWC)"
                },
                new SelectItem {
                    Id = 13,
                    Name = "Pontoon"
                },
                new SelectItem {
                    Id = 14,
                    Name = "Sailboats"
                },
                new SelectItem {
                    Id = 15,
                    Name = "Trawlers"
                },
                new SelectItem {
                    Id = 16,
                    Name = "Yachts"
                },
            };
            return list;
        }
        public List<SelectItem> GetSpecificationTypes() {
            var list = new List<SelectItem> {
                new SelectItem { Id = 1, Name="Dimension" },
                new SelectItem { Id = 2, Name="Performance" },
                new SelectItem { Id = 3, Name="Electrical" },
                new SelectItem { Id = 4, Name="Usage" },
                new SelectItem { Id = 5, Name="Capacity" },
                new SelectItem { Id = 6, Name="Weight" }               
            };
            return list;
        }
        public List<SelectItem> GetUnitTypes() {
            var list = new List<SelectItem> {
                new SelectItem { Id = 1, Name = "Feet" },
                new SelectItem { Id = 2, Name = "Inches" },
                new SelectItem { Id = 3, Name = "Meters" },
                new SelectItem { Id = 4, Name = "Hours" },
                new SelectItem { Id = 5, Name = "Volts" },
                new SelectItem { Id = 6, Name = "Watts" },
                new SelectItem { Id = 7, Name = "Horsepower" },
                new SelectItem { Id = 8, Name = "Kilowatts" },
                new SelectItem { Id = 9, Name = "Amps" },
                new SelectItem { Id = 10, Name = "Pounds" },
                new SelectItem { Id = 11, Name = "Kilograms" },
                new SelectItem { Id = 12, Name = "Gallons" },
                new SelectItem { Id = 13, Name = "Liters" },
                new SelectItem { Id = 14, Name = "Count"}                
            };
            return list;
        }
        public List<SelectItem> GetPriceTypes() {
            var list = new List<SelectItem> {
                new SelectItem { Id = 1, Name = "MSRP" },
                new SelectItem { Id = 2, Name = "Selling" },
                new SelectItem { Id = 3, Name = "Internet" },
                new SelectItem { Id = 4, Name = "Promotional" },
            };
            return list;
        }
        public List<SelectItem> GetColorTypes() {
            var list = new List<SelectItem> {
                new SelectItem { Id=1, Name = "Exterior" },
                new SelectItem { Id=2, Name = "Interior" },
                new SelectItem { Id=3, Name = "Hull" },
            };
            return list;
        }
        public List<SelectItem> GetActivityTypes() {
            var list = new List<SelectItem> {
                new SelectItem { Id=1, Name = "Offshore Boating" },
                new SelectItem { Id=2, Name = "Freshwater Fishing" },
                new SelectItem { Id=3, Name = "Overnight Cruising" },
                new SelectItem { Id=4, Name = "Saltwater Fishing" },
                new SelectItem { Id=5, Name = "Watersports" },
                new SelectItem { Id=6, Name = "Competition" },
                new SelectItem { Id=7, Name = "Racing" },
                new SelectItem { Id=8, Name = "Green Boating" },
                new SelectItem { Id=9, Name = "Personal Watercraft" },
                new SelectItem { Id=10, Name = "Scuba Diving" },
                new SelectItem { Id=11, Name = "Day Cruising" },
                new SelectItem { Id=12, Name = "Just for Fun" },
                new SelectItem { Id=13, Name = "Safety" },
                new SelectItem { Id=14, Name = "Education" },
                new SelectItem { Id=15, Name = "Sleeping Onboard" },
                new SelectItem { Id=16, Name = "Entertainment" },
                new SelectItem { Id=17, Name = "Sailing" },
                new SelectItem { Id=18, Name = "Family Time" },
                new SelectItem { Id=19, Name = "Floatilla" },
                new SelectItem { Id=20, Name = "Redneck Yacht Clubbing" },
            };
            return list;
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