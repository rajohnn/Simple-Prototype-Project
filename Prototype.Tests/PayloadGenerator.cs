using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Prototype.Domain.Ext;
using Prototype.Domain.Repository;
using Prototype.Domain.Webhook;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Tests {

    [TestClass]
    public class PayloadGenerator {
        private readonly string connectionString = string.Empty;

        public PayloadGenerator() {
            connectionString = ConfigurationManager.ConnectionStrings["PrototypeContext"].ConnectionString;
        }

        [TestMethod]
        public async Task CreatePayloadFromDatabase_Test12() {
            var repo = new InventoryRepository(connectionString);
            var product = await repo.GetProduct(12);
            var features = await repo.GetFeatures(12);           

            var payload = new Product {
                CatalogId = product.TrimId.ToString(),
                Condition = "", // need product condition
                DataType = DataType.Inventory,
                Designation = product.Designation,
                Configuration = "", // need product configuration
                Id = product.ProductId.ToString(), // need external ID
                ProductType = product.ProdType,
                Source = "CRS", // need source
                Status = product.Status
            };

            var groupedFeatures = features
                .GroupBy(f => f.FeatureName)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToList();

            var identiferMapper = new FeatureIdentifierMapper();
            var featureMapper = new FeatureMapper();

           foreach (var group in groupedFeatures) {
                string key = group.Key;
               switch (key) {
                    case "Identifiers":
                        identiferMapper.MapIdentifiers(payload, group.Items);
                        break;

                    case "Price":
                        foreach(var p in group.Items) {
                             if (Decimal.TryParse(p.Value, out decimal amount)) {
                                Price price = new Price { };
                                var uom = p.AttributeName.GetMeasurementType();
                                if (String.IsNullOrWhiteSpace(uom)) {
                                    price = new Price {
                                        Category = p.AttributeName,
                                        DisplayValue = String.Format("{0:C}", amount),
                                        Value = amount
                                    };
                                }
                                else {
                                    var token = string.Concat("(", uom, ")");
                                    price = new Price {
                                        Category = p.AttributeName.Replace(token, "").Trim(),
                                        DisplayValue = String.Concat(amount, " ", uom),
                                        Value = amount
                                    };
                                }                                
                                payload.Prices.Add(price);
                            }                            
                        }                        
                        break;
                    default:
                        featureMapper.MapFeature(payload, key, group.Items);
                        break;
                }
            }

            var json = JsonConvert.SerializeObject(payload, Formatting.Indented, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
            Console.WriteLine(json);

        }



       
    }
}