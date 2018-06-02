using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Attribute : ProductCatalogEntity {
        public int? FeatureId { get; set; }

        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DisplayValue { get; set; }
    }
}