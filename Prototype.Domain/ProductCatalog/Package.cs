using Prototype.Domain.ProductCatalog;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Package : ProductCatalogEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Code { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Title { get; set; }

        public List<Price> Prices { get; set; } = new List<Price>();
    }
}