using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Package : InventoryEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Code { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Title { get; set; }

        public List<ReferenceCode> Prices { get; set; } = new List<ReferenceCode>();
    }
}