using L5.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.ProductCatalog {

    public class Price : ProductCatalogEntity {
        public int? PriceTypeId { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? SuggestedValue { get; set; }

        [ForeignKey("PriceTypeId")]
        public PriceType PriceType { get; set; }
    }

    public class PriceType : ProductCatalogEntity {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}