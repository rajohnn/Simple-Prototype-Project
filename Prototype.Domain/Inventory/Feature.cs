using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Feature : InventoryEntity {
        public int? ProductId { get; set; }
        public int? PackageId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("PackageId")]
        public Package Package { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; }
    }
}