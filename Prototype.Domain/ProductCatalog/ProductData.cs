using Prototype.Domain.ProductCatalog;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class ProductData : ProductCatalogEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public List<StandardFeature> StandardFeatures { get; set; } = new List<StandardFeature>();
        public List<MediaAsset> MediaAssets { get; set; } = new List<MediaAsset>();

        public List<Part> Parts { get; set; } = new List<Part>();
        public List<Price> Prices { get; set; } = new List<Price>();

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string SalesStatus { get; set; }
    }
}