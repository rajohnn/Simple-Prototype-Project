using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Product : InventoryEntity {
        public List<Identifiers> Identifiers { get; set; }
        public int? Year { get; set; }
        public int? ProductTypeId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }        

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string DisplayName { get; set; }

        public List<ReferenceCode> Prices { get; set; } = new List<ReferenceCode>();

        [ForeignKey("ProductTypeId")]
        public ReferenceCode ProductType { get; set; }

        public List<MediaAsset> Assets { get; set; }
    }
}