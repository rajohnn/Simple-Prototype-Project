using L5.DomainModel;
using L5.DomainModel.Inventory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype.Domain.Dealership {

    public class FeatureConfiguration : DealerEntity {
        public int? FeatureId { get; set; }

        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
        public string CustomName { get; set; }
    }

    public class CustomFeature : DealerEntity {
        public int? ProductId { get; set; }
        public int? PackageId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        public List<CustomAttribute> Attributes { get; set; }
    }
}