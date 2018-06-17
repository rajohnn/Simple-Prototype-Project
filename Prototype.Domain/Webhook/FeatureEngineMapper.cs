using Prototype.Domain.Ext;
using Prototype.Domain.Inventory;
using System;
using System.Collections.Generic;

namespace Prototype.Domain.Webhook {

    public class FeatureMapper {

        public void MapFeature(Product payload, string key, List<InventoryFeature> items) {
            var feature = new Feature {
                ProductType = key,
            };

            foreach (var item in items) {               
                var attributeName = item.AttributeName.Replace("Trim", "Manufacturer Model");
                var uom = attributeName.GetMeasurementType();

                if (String.IsNullOrWhiteSpace(uom)) { // tacking on a feature to the feature
                    var md = new MarketingDescription {
                        CategoryName = "",
                        Name = attributeName,                      
                        Value = item.Value
                    };
                    feature.MarketingDescriptions.Add(md);
                }
                else {
                    var token = string.Concat("(", uom, ")");
                    Decimal.TryParse(item.Value, out decimal numericValue);

                    var spec = new Specification {
                        CategoryName = "",
                        Name = attributeName.Replace(token,"").Trim(),
                        NumericValue = numericValue,                        
                        UnitType = uom,
                        Value = item.Value + " " + uom
                    };
                    feature.Specifications.Add(spec);
                }
                

            }

            payload.Features.Add(feature);
        }        
    }
}