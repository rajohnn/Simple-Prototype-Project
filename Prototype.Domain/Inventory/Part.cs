using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L5.DomainModel.Inventory {

    public class Part : InventoryEntity {
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string DataType { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Value { get; set; }
    }
}