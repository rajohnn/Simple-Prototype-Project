using Prototype.Domain.Inventory;
using System.Collections.Generic;
using Prototype.Domain.Ext;

namespace Prototype.Domain.Webhook {

    public class FeatureIdentifierMapper {

        public void MapIdentifiers(Product payload, List<InventoryFeature> items) {
            foreach(var item in items) {
                var attributeName = item.AttributeName.RemoveSpecialCharacters(); 
                attributeName = attributeName.Replace("Trim", "Manufacturer Model");

                if (attributeName.ToLower().Contains("photo")) {
                    MapToMedia(payload, item);
                }     
                else {
                    payload.Identifiers.Add(new Identifier {
                        Description = "",
                        Name = attributeName,
                        Value = item.Value.RemoveSpecialCharacters()
                    });
                }
            }
        }

        private void MapToMedia(Product payload, InventoryFeature feature) {
            int count = payload.MediaContent.Count + 1;
            payload.MediaContent.Add(new Media {
                Category = payload.ProductType,                
                Name = feature.AttributeName.RemoveSpecialCharacters(),
                SortOrder = count,
                Type = "Image",
                Url = feature.Value
            });
        }        
    }
}